using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sockets.Plugin;

namespace Base
{
    public class TcpMessage : IMessage
    {
        public string Message { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public bool Ack { get; set; }

        public List<string> Variables { get; set; }

        public TcpMessage()
        {
        }

        public async Task<string> Invoke()
        {
            try
            {
                var client = new TcpSocketClient();
                //var t = client.ConnectAsync(Address, Port);
                
                client.Connect(Address, Port);
                var msg = Encoding.UTF8.GetBytes(Message);
                client.WriteStream.Write(msg, 0, msg.Length);
                client.WriteStream.Flush();

                if (!Ack)
                {
                    return null;
                }
                using (var stream = client.ReadStream)
                {
                    stream.ReadTimeout = 1000;
                    var bytes = new byte[1024];
                    var i = stream.Read(bytes, 0, 1024);
                    var s = Encoding.UTF8.GetString(bytes, 0, i);
                    return s;
                }
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        } 
    }
}
