using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Sockets.Plugin;

namespace Base
{
    public class UdpMessage : IMessage
    {
        
        public string Message { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public bool Ack
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public List<string> Variables { get; set; }

        public Task<string> Invoke()
        {
            using (var client = new UdpSocketClient())
            {
                var msg = Encoding.UTF8.GetBytes(Message);
                client.SendToAsync(msg, Address, Port);
            }
            return null;
        }

    }
}
