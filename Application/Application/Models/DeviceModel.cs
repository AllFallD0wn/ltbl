using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Base;
using Xamarin.Forms;

namespace LTBLApplication.Models
{
    public class DeviceModel : INotifyPropertyChanged
    {
        private Guid _id;
        private string _name, _address, _message;
        private int _port;
        private int _type;
        private bool _ack;
        private Color _color;
        private string _networkType;

        private List<string> Types = new List<string> {"TCP", "UDP"};

        public event PropertyChangedEventHandler PropertyChanged;

        public DeviceModel()
        {
            Id = Guid.NewGuid();
            AddDeviceCommand = new Command(_a =>
            {
                CreateDevice();
            });
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

        public int Type
        {
            get { return _type; }
            set
            {
                _type = value;
                _networkType = Types[_type];
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
        protected virtual void CreateDevice()
        {
            var button = new Base.Button
            {
                Id = Id,
                Name = Name,
                Address = Address,
                Port = Port,
                Type = (NetworkType)Type,
                Ack = Ack
            };
            button.CreateMessage(Message);
            Resources.AddDevice(button);
        }
    }
}
