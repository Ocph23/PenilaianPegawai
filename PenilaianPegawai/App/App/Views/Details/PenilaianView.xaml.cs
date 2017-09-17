using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views.Details
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PenilaianView : ContentPage
    {
       

        public PenilaianView()
        {
            InitializeComponent();
        }

        public PenilaianView(pegawai item)
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.Details.PenilaianViewModel(item);
        }
    }
}