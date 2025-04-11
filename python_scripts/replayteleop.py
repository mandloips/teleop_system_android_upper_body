import socket
import json
from datetime import datetime
import time

def send_stream(data, server_port, server_ip='localhost'):
    androidServer = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    androidServer.connect((server_ip, server_port))
    androidServer.send(data.encode())
    androidServer.close()

# Path to the JSON file inside the "log" folder

file_path = "log/motion_1_corrected.json" #1
# file_path = "log/motion_2_corrected.json" #2
# file_path = "log/motion_3_corrected.json" #3

# Load the JSON data from the file
with open(file_path, "r") as file:
    logdata = json.load(file)

# Delay in seconds

delay_motion = 18.316 #1
# delay_motion = 14.812 #2
# delay_motion = 14.364 #3

delay_sync = 0.5
delay_seconds = delay_motion + delay_sync

# Add a delay before playing the audio
print(f"Waiting for {delay_seconds} seconds before playing the motion...")
time.sleep(delay_seconds)

start_time = datetime.now().timestamp()
first_timestamp = datetime.strptime(logdata[0]["timestamp"], '%Y-%m-%d %H:%M:%S.%f')

# Iterate over each log entry and print the command with a delay
for entry in logdata:
    timestamp = datetime.strptime(entry["timestamp"], '%Y-%m-%d %H:%M:%S.%f')

    # while (time.time() - start_time) < (timestamp - first_timestamp).total_seconds():
    #     time.sleep(0.005)

    # Calculate the time difference in seconds
    time_diff = (timestamp - first_timestamp).total_seconds()
    print("time diff: ", time_diff)
    elapsed_time = datetime.now().timestamp() - start_time
    print("elapsed time: ", elapsed_time)

    # If time_diff > elapsed_time, sleep for the difference to match the timestamp
    if time_diff > elapsed_time:
        time_to_wait = time_diff - elapsed_time
        time.sleep(time_to_wait)

    print(entry["command"])
    send_stream(data=entry["command"], server_port=12000, server_ip='localhost')
