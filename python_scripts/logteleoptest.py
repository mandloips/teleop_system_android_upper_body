import socket
import time

import json
import os
from datetime import datetime

def send_stream(data, server_port, server_ip='localhost'):
    androidServer = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    androidServer.connect((server_ip, server_port))
    androidServer.send(data.encode())
    androidServer.close()

timestamp1 = datetime.now().timestamp()

# Set the IP address and port to match the Unity client script
server_ip = "localhost"  # Replace with your computer's IP address
server_port = 12345

# Create a TCP/IP socket
server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

# Bind the socket to a specific address and portf
server_socket.bind((server_ip, server_port))

# Listen for incoming connections
server_socket.listen()

print(f"Server listening on {server_ip}:{server_port}")

# Accept a connection from a client
client_socket, client_address = server_socket.accept()
print(f"Connection established with {client_address}")

last_time = time.time()

# Initialize loop number
loopno = 1
n = 1

initial_unusable_command = "moveaxes 17 128 0 0 18 170 0 0 19 127 0 0 20 0 0 0 22 255 0 0 23 128 0 0 27 58 0 0 28 255 0 0 29 31 0 0 30 0 0 0 31 127 0 0 32 132 0 0 33 127 0 0 34 0 0 0 35 0 0 0 36 0 0 0 37 0 0 0 38 0 0 0 41 255 0 0 42 255 0 0 43 255 0 0 44 0 0 0 45 127 0 0 46 132 0 0 47 127 0 0 48 0 0 0 49 0 0 0 50 0 0 0 51 0 0 0 52 0 0 0"

# Initialize data list to store logs
logdata = []

# Create the 'log' folder if it doesn't exist
log_folder = 'log'
os.makedirs(log_folder, exist_ok=True)

# Format the filename as motion_date_time (only once)
file_name = datetime.now().strftime('motion_%Y-%m-%d_%H-%M-%S-%f.json')
file_path = os.path.join(log_folder, file_name)

timestamp2 = datetime.now().timestamp()
motion_start_delay = timestamp2 - timestamp1

# Receive and process commands from Unity
while True:
    loop_time = time.time() - last_time
    data = client_socket.recv(1024)
    print(f"Loop time: {loop_time}")
    if not data:
        break
    print("continuing") 
    received_commands = data.decode("utf-8").split('\n')
    
    for received_command in received_commands:
        print("inside1")
        if received_command and (time.time() - last_time) >= 0.05 and received_command != initial_unusable_command:
            timestamp = datetime.now().strftime('%Y-%m-%d %H:%M:%S.%f')[:-3]
            print("inside2")
            print(f"Received command from Unity: {received_command}")
            send_stream(data=received_command, server_port=12000, server_ip='localhost')
            last_time = time.time()

            log_entry = {
                            "timestamp": timestamp,
                            "loopno": loopno,
                            "command": received_command,
                            "motion_start_delay": motion_start_delay
                        }
            logdata.append(log_entry)
            loopno += 1

    if loopno >= 100 * n:
        with open(file_path, 'w') as file:
            json.dump(logdata, file, indent=4)
        n += 1

    # Process the received command (add your logic here)
    # For example, perform actions based on the command
    if received_command == "Rotate":
        print("Rotating humanoid")

    client_socket.recv(0)

# Clean up the connection
print(f"Log entries added to {file_path}")
client_socket.close()
server_socket.close()