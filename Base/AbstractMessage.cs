using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class AbstractMessage : IMessage
    {
        public string Message { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public bool Ack { get; set; }
        public NetworkType Type { get; set; }

        public List<string> Variables { get; set; }

        public Task<string> Invoke(IMessage _message)
        {
            throw new NotImplementedException();
        }
    }
}
