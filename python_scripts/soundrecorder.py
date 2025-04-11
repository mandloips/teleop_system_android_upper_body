import sounddevice as sd
from scipy.io.wavfile import write
import numpy as np
import threading

sample_rate = 44100
output_filename = "output.wav"
recording = []  # Dynamic list to store incoming audio chunks
stop_event = threading.Event()  # Event to signal stopping the recording

# Callback function for audio streaming
def callback(indata, frames, time, status):
    if status:
        print(status)
    recording.append(indata.copy())  # Store each chunk of incoming audio

print("Recording started... Press Ctrl+C to stop.")

# Start recording with InputStream
try:
    with sd.InputStream(samplerate=sample_rate, channels=2, dtype='int16', callback=callback):
        while not stop_event.is_set():
            pass  # Keep waiting until stop is triggered
except KeyboardInterrupt:
    print("\nRecording stopped.")

# Combine recorded chunks
audio_data = np.concatenate(recording, axis=0)

# Save the recording as a WAV file
write(output_filename, sample_rate, audio_data)
print(f"Recording saved as '{output_filename}'")
