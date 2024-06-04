using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UWBLocationMonitor
{
    public class NetworkConnection
    {
        private UdpClient udpClient;
        private int listenPort;
        private bool isListening;
        private IPAddress allowedSenderIPAddress;

        // Connect to given address
        public NetworkConnection(string allowedIP, int port)
        {
            listenPort = port;
            allowedSenderIPAddress = IPAddress.Parse(allowedIP);
            udpClient = new UdpClient(listenPort);
        }

        // Start listening for messages received from the connection
        public void StartListening()
        {
            isListening = true;
            Task.Run(() => ListenForMessages());
            LogManager.Log("Started connection");
            LogManager.Log("Time;Tag;Anchor1;Dist(cm);Anchor2;Dist(cm);Anchor3;Dist(cm)");
        }

        private void ListenForMessages()
        {
            try
            {
                while (isListening)
                {
                    IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedBytes = udpClient.Receive(ref remoteEndPoint); // Receive data
                    string receivedData = Encoding.UTF8.GetString(receivedBytes); // Parse data to string

                    // Parse data to function
                    OnMessageReceived(receivedData);
                }
            }
            catch (Exception ex)
            {
                LogManager.Log($"Exception in listening: {ex.Message}");
            }
            finally
            {
                udpClient.Close();
            }
        }

        // Stop listening (Not used)
        public void StopListening()
        {
            isListening = false;
            udpClient.Close();
        }

        // Handle message
        protected virtual void OnMessageReceived(string message)
        {
            // Message format:
            // TagID;AnchorID1;DistanceAnchor1;AnchorID2;DistanceAnchor2;AnchorID3;DistanceAnchor3
            // Example:
            // B0:A7:32:AB:19:94;b0a732ab;0.85;34987a74;1.41;34987a72;0.24
            try
            {
                // Split message in parts
                string[] parts = message.Split(";");

                // Check for full message
                if (parts.Length < 7)
                {
                    throw new ArgumentException("Message format is incorrect");
                }

                string tag = parts[0];

                int[] coordinatesAnchor1 = GetAnchorCoordinates(parts[1]);
                int R1 = int.Parse(parts[2]);

                int[] coordinatesAnchor2 = GetAnchorCoordinates(parts[3]);
                int R2 = int.Parse(parts[4]);

                int[] coordinatesAnchor3 = GetAnchorCoordinates(parts[5]);
                int R3 = int.Parse(parts[6]);

                // Add time to message
                DateTime currentTime = DateTime.Now;
                string timeStampedMessage = currentTime.ToString("HH:mm:ss") + (";") + message;
                // Log message with time
                LogManager.Log(timeStampedMessage);

                // Calculate tag position
                LocationService.CalculateTagPos(
                    coordinatesAnchor1[0], coordinatesAnchor1[1], R1,
                    coordinatesAnchor2[0], coordinatesAnchor2[1], R2,
                    coordinatesAnchor3[0], coordinatesAnchor3[1], R3, tag);

            }
            catch (Exception ex)
            {
                LogManager.Log($"Error processing message: {ex.Message}");
            }
        }

        // Hard coded anchor positions
        private int[] GetAnchorCoordinates(string anchorID)
        {
            switch (anchorID)
            {
                case "34987a74":
                    return new int[] { 420, 1650 };
                case "34987a72":
                    return new int[] { 0, 0 };
                default:
                    return new int[] { 420, 0 };
            }
        }
    }
}
