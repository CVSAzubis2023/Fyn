using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man.Settings_etc
{
    public class Viewmodel 
    {
        public ObservableCollection<string> CmbContent {  get; private set; }
        public ObservableCollection<string> Savings { get; private set; }

        public Viewmodel()
        {
            CmbContent = new ObservableCollection<string>
            {
                "Hallo",
                "Blub",
                "Blip",
                "Blep"
            };

            Savings = new ObservableCollection<string>
            {
                "Save",
                "Dont Save"
            };
        }
    }
}
