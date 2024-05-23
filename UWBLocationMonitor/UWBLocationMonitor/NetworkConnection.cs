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

        public NetworkConnection(string allowedIP, int port)
        {
            listenPort = port;
            allowedSenderIPAddress = IPAddress.Parse(allowedIP);
            udpClient = new UdpClient(listenPort);
        }

        public void StartListening()
        {
            isListening = true;
            Task.Run(() => ListenForMessages());
            LogManager.Log("Started connection");
            LogManager.Log("Tag;X1;Y1;R1;X2;Y2;R2;X3;Y3;R3;");
        }

        private void ListenForMessages()
        {
            try
            {
                while(isListening)
                {
                    IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedBytes = udpClient.Receive(ref remoteEndPoint);

                    string receivedData = Encoding.UTF8.GetString(receivedBytes);
                    //LogManager.Log(receivedData);

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

        public void StopListening()
        {
            isListening = false;
            udpClient.Close();
        }

        protected virtual void OnMessageReceived(string message)
        {
            //Message handling
            string[] parts = message.Split(";");
            string tag = parts[0];

            int[] numbers = new int[parts.Length - 2];
            for (int i = 1; i < parts.Length - 1; i++)
            {
                numbers[i - 1] = int.Parse(parts[i]);
            }

            int X1 = numbers[0];
            int Y1 = numbers[1];
            int R1 = numbers[2];
            int X2 = numbers[3];
            int Y2 = numbers[4];
            int R2 = numbers[5];
            int X3 = numbers[6];
            int Y3 = numbers[7];
            int R3 = numbers[8];
            
            LogManager.Log(message);

            TagManager.Instance.UpdateTagTrilateration(tag, X1, Y1, R1, X2, Y2, R2, X3, Y3, R3);
        }
    }
}
