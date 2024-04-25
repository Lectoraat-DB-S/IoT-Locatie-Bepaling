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
                    LogManager.Log($"Received: {receivedData} from {remoteEndPoint}");

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
            // Message handling
            //LogManager.Log(message);
        }
    }
}
