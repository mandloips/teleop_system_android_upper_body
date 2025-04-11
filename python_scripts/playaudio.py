import subprocess
import time
import os

# Path to the audio file

filename = "output_1_modified.wav" #1
# filename = "output_2_modified.wav" #2
# filename = "output_3.wav" #3

# Delay in seconds
# delay_motion = 14.095
# delay_sync = 0
# delay_seconds = delay_motion + delay_sync

# Add a delay before playing the audio
# print(f"Waiting for {delay_seconds} seconds before playing the audio...")
# time.sleep(delay_seconds)

# Use the default Windows media player
subprocess.run(["start", filename], shell=True)
print("Audio playback started...")