using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTBLApplication
{
    public interface ISaveLoad
    {
        void Save(string _filename, string _text);

        string Load(string _filename);
    }
}
