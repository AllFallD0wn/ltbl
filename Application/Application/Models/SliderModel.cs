using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base;
using Xamarin.Forms;

namespace LTBLApplication.Models
{
    public class SliderModel : DeviceModel
    {

        private int _maxValue;

        public int MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                OnPropertyChanged("MaxValue");
            }
        }

        public SliderModel()
        {
            Id = Guid.NewGuid();
            AddDeviceCommand = new Command(_a =>
            {
                CreateDevice();
            });
        }

        /// <summary>
        /// Creates the slider in the database
        /// </summary>
        protected override void CreateDevice()
        {
            var slider = new Base.Slider
            {
                Ack = this.Ack,
                Address = this.Address,
                Id = Id,
                Name = Name,
                Port = Port,
                Type = (NetworkType)Type,
                MaxValue = MaxValue
            };
            slider.CreateMessage(Message);
            Resources.AddDevice(slider);
        }
    }
}
