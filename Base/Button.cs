using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace Base
{
    public class Device : IDevice
    {
        public Guid Id { get; set; }


        public string Name { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public NetworkType Type { get; set; }

        public IMessage Message { get; set; }

        public bool Ack { get; set; }

        public Color Color { get; set; }

        public string Invoke()
        {
            return Message.Invoke(Message).Result;
        }

        public void CreateMessage(string _text)
        {
            Message = new AbstractMessage
            {
                Address = Address,
                Port = Port,
                Message = _text,
                Ack = Ack
            };
        }

    }

    public class Button : Device
    {
        public string MessageText;
        /// <summary>
        /// Default constructor
        /// </summary>
        public Button()
        {
            
        }
    }

    public class Slider : Device
    {
        public int MaxValue { get; set; }
        public Slider()
        {
            
        }
    }

    public class Switch : Device
    {
        public Switch()
        {
            
        }
    }
}
