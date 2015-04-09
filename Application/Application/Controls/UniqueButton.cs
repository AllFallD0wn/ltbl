using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;

namespace LTBLApplication.Controls
{
    class UniqueButton : Button
    {
        public Guid UniqueId { get; set; }
    }
}
