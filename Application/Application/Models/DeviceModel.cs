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
        private string _name, _address, _message;
        private int _port;
        private int _type;
        private string _networkType;

        private List<string> Types = new List<string> {"TCP", "UDP"}; 

        public event PropertyChangedEventHandler PropertyChanged;

        public DeviceModel()
        {
            AddDeviceCommand = new Command(_a =>
            {
                CreateDevice();
            });
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

        public ICommand AddDeviceCommand { protected set; get; }

        protected virtual void OnPropertyChanged(string _propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(_propertyName));
            }
        }

        private void CreateDevice()
        {
            
        }
    }
}
