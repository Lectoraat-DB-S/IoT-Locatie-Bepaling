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
            LogManager.Log("Time;Tag;Anchor1;Dist(m);Anchor2;Dist(m);Anchor3;Dist(m)");
        }

        private void ListenForMessages()
        {
            try
            {
                while (isListening)
                {
                    IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedBytes = udpClient.Receive(ref remoteEndPoint);

                    string receivedData = Encoding.UTF8.GetString(receivedBytes);
                    var currentTime = DateTime.Now.TimeOfDay;
                    //LogManager.Log(currentTime+";"+receivedData);

                    OnMessageReceived(receivedData);

                    /* TODO: FIXEN ONMESSAGERECEIVED DING MET FORMAT!!! */
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

            // B0:A7:32:AB:19:94;b0a732ab;0.85;34987a74;1.41;34987a72;0.24


            int X1 = 0;
            int Y1 = 0;
            int R1 = int.Parse(parts[2]);
            int X2 = 0;
            int Y2 = 0;
            int R2 = int.Parse(parts[4]);
            int X3 = 0;
            int Y3 = 0;
            int R3 = int.Parse(parts[6]);
            /*
            for (int i = 0; i < parts.Length; i++)
            {
                LogManager.Log(parts[i]);
            }
            */

            if (parts[1] == "34987a74")
            {
                X1 = 420;
                Y1 = 1650;
            }
            else if (parts[1] == "34987a72")
            {
                X1 = 0;
                Y1 = 0;
            }
            else
            {
                X1 = 420;
                Y1 = 0;
            }

            if (parts[3] == "34987a74")
            {
                X2 = 420;
                Y2 = 1650;
            }
            else if (parts[3] == "34987a72")
            {
                X2 = 0;
                Y2 = 0;
            }
            else
            {
                X2 = 420;
                Y2 = 0;
            }

            if (parts[5] == "34987a74")
            {
                X3 = 420;
                Y3 = 1650;
            }
            else if (parts[5] == "34987a72")
            {
                X3 = 0;
                Y3 = 0;
            }
            else
            {
                X3 = 420;
                Y3 = 0;
            }


            LogManager.Log(message);

            LocationService.CalculateTagPos(X1, Y1, R1, X2, Y2, R2, X3, Y3, R3, tag);
        }
    }
}
