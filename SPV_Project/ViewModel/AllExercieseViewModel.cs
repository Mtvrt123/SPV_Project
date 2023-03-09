using CommunityToolkit.Mvvm.ComponentModel;
using SPV_Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPV_Project.ViewModel
{
    public class AllExercieseViewModel : ObservableObject
    {
        public ObservableCollection<Vaja> Vaje { get; private set; }

        public AllExercieseViewModel()
        {
            this.Vaje = App.Database.GetExercises();
        }
    }
}
