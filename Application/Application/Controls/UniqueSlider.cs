﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LTBLApplication.Controls
{
    public class UniqueSlider : Slider
    {
        public Guid UniqueId { get; set; }
    }
}
