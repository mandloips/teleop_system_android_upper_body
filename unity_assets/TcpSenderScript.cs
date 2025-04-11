using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class TcpSenderScript : MonoBehaviour
{
    public AndroidManagerScript androidManager; // Reference to DataScript
    TcpClient client;
    NetworkStream stream;

    new void OnEnable()
    {
        client = new TcpClient("localhost", 12345);
        stream = client.GetStream();
    }

    void Start()
    {
        // Modify elements in the array
        androidManager.SetAxisValue(3, 22);
        androidManager.SetInitialAxisValues();
    }

    void Update()
    {
        // Create a command only for these axes
        int[] axes = {
            17, 18, 19, 20, 23,                 // head
            // 22,                                 // back
            27, 28, 29, 30, 31, 32, 33,         // left hand
            34, 35, 36, 37, 38,                 // left fingers
            41, 42, 43, 44, 45, 46, 47,         // right hand
            48, 49, 50, 51, 52                  // right fingers
            };

        string command = "moveaxes";
        for (int i = 0; i < androidManager.axis.Length; i++)
        {
            int j = i + 1;
            if (System.Array.Exists(axes, element => element == j))
            command += " " + (i+1).ToString() + " " + (androidManager.axis[i]).ToString() + " 0 0";
        }
        try
        {
            SendCommand(command);
        }
        catch (Exception ex)  // Catching all exceptions
        {
            Debug.Log("An error occurred while sending the command: " + ex.Message);
            // Optionally, log the stack trace for more details
            Debug.Log("Stack Trace: " + ex.StackTrace);
        }
    }

    void SendCommand(string command)
    {
        string message = command + "\n";
        byte[] data = Encoding.ASCII.GetBytes(message);

        // Prefix the message with its length
        // byte[] lengthBytes = BitConverter.GetBytes(data.Length);
        // stream.Write(lengthBytes, 0, lengthBytes.Length);
    
        // Send the actual message
        stream.Write(data, 0, data.Length);
    }
}
