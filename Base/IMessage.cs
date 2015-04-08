using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace Base
{
    public interface IMessage
    {
        //Message text
        string Message { get; set; }
        string Address { get; set; }
        int Port { get; set; }
        bool Ack { get; set; }
        //Variables added to message
        List<string> Variables { get; set; }

        Task<string> Invoke();
    }
}