using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Base;
using LayoutCreator.Properties;

namespace LayoutCreator
{
    public class DeviceModel : INotifyPropertyChanged
    {
        private Guid _id;
        private string _name, _address, _message;
        private int _port;
        private string _type;
        private bool _ack;
        private string _networkType;

        public List<string> Types = new List<string> { "TCP", "UDP" };

        public event PropertyChangedEventHandler PropertyChanged;



        public DeviceModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public int Port
        {
            get { return _port; }
            set
            {
                _port = value;
                OnPropertyChanged("Port");
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                _networkType = value;
                OnPropertyChanged("Type");
            }
        }

        public bool Ack
        {
            get { return _ack; }

            set
            {
                _ack = value;
                OnPropertyChanged("Ack");
            }
        }

        public ICommand AddDeviceCommand { protected set; get; }

        protected virtual void OnPropertyChanged(string _propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(_propertyName));
            }
        }

        /// <summary>
        /// Creates the button in the database
        /// </summary>
        public virtual IDevice CreateDevice()
        {
            return new Base.Button(Id, Name, Address, Message, Port, _networkType, _ack);
        }
    }
}
