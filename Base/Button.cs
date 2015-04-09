using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace Base
{
    public class Button : IDevice
    {
        public Guid Id { get; set; }
    
        private string _messageText;

        public string Name { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public NetworkType Type { get; set; }

        public IMessage Message { get; set; }
    
        public bool Ack { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Button()
        {
            
        }

        public Button(Guid _id, string _name, string _address, string _message, int _port, string _type, bool _ack)
        {
            Id = _id;
            Name = _name;
            Address = _address;
            _messageText = _message;
            Port = _port;
            Type = (NetworkType)Enum.Parse(typeof(NetworkType), _type);
            Ack = _ack;
            CreateMessage();
        }

        public string Invoke()
        {
            return Message.Invoke().Result;
        }

        private void CreateMessage()
        {
            switch (Type)
            {
                case NetworkType.UDP:
                    Message = new UdpMessage
                    {
                        Address = Address,
                        Port = Port,
                        Message = _messageText,
                        Ack = Ack
                    };
                    break;
                case NetworkType.TCP:
                    Message = new TcpMessage()
                    {
                        Address = Address,
                        Port = Port,
                        Message = _messageText,
                        Ack = Ack
                    };
                    break;
            }
        }
    }
}
