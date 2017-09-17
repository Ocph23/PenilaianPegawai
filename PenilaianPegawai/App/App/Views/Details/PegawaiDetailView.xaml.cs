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
    public partial class PegawaiDetailView : ContentPage
    {
        public pegawai Pegawai { get; set; }
        public PegawaiDetailView() { }
        public PegawaiDetailView(pegawai item)
        {
            this.Pegawai = item;
            InitializeComponent();
            this.BindingContext = this;
        }
    }
}