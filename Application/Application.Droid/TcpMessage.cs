using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using LTBLApplication.Droid;
using System.Net.Sockets;
using System.Threading;
using Android.Media;
using Base;
using Xamarin.Forms;

[assembly: Dependency(typeof(TcpMessage))]
namespace LTBLApplication.Droid
{
    public class TcpMessage : IMessage
    {
        public string Message { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public bool Ack { get; set; }

        public NetworkType Type { get; set; }
    

        public List<string> Variables { get; set; }

        private bool IsConnected = false;
        private  ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        public async Task<string> Invoke(IMessage _message)
        {
            switch (_message.Type)
            {
                case NetworkType.TCP:
                {
                    try
                    {
                        TcpClient client = new TcpClient();
                        client.BeginConnect(_message.Address, _message.Port, new AsyncCallback(Callback), client);
                        TimeoutObject.WaitOne(250, false);
                        if (IsConnected)
                        {
                            using (NetworkStream stream = client.GetStream())
                            {
                                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(_message.Message);
                                stream.Write(bytes, 0, bytes.Length);
                                stream.Flush();
                                if (_message.Ack)
                                {
                                    bytes = new byte[1024];
                                    stream.ReadTimeout = 1000;
                                    var i = stream.Read(bytes, 0, 1024);
                                    var s = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                                    return s;
                                }
                            }
                            return null;
                        }
                        else
                        {
                            return "Cannot connect to server";
                        }
                    }
                    catch (Exception)
                    {
                        return "Cannot connect to server";
                    }
                    break;
                }
                case NetworkType.UDP:
                {
                    try
                    {
                        UdpClient client = new UdpClient();

                    }
                    catch (Exception)
                    {
                        
                    }
                    break;
                }
            }
            return null;
        }

        public void Callback(IAsyncResult result)
        {
            try
            {
                TcpClient client = result.AsyncState as TcpClient;
                if (client.Client != null)
                {
                    client.EndConnect(result);
                    IsConnected = true;
                }
            }
            catch (Exception)
            {
                IsConnected = false;
            }
        }
    }
}

