using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public interface IMessage
    {
        //Message text
        string Message { get; set; }
        //Variables added to message
        List<string> Variables { get; set; }
    }
}
