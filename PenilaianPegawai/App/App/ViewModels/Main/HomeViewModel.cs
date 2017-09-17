using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App.ViewModels.Main
{
   public  class HomeViewModel:BaseViewModel
    {
        public HomeViewModel(INavigation nav)
        {
            this.Navigation = nav;
        }

        public INavigation Navigation { get; }
    }
}
