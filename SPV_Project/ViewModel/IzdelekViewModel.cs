using CommunityToolkit.Mvvm.ComponentModel;
using SPV_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Project.ViewModel
{
    public class IzdelekViewModel : ObservableObject
    {
        public Izdelek Izdelek { get; private set; }

        public IzdelekViewModel()
        {
            this.Izdelek = App.Database.GetIzdelek();
        }
    }
}
