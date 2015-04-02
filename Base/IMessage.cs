using System.Collections.Generic;

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