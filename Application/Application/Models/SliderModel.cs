using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Creates the slider in the database
        /// </summary>
        protected override void CreateDevice()
        {
            
        }
    }
}
