using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Settings_etc
{
    class comboboxitems : ObservableCollection<string>
    {
        public comboboxitems() 
        {
            Add("Blub");
            Add("Blep");
            Add("Hallo");
        }
    }
}
