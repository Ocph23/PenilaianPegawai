using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using App.ViewModels.Details;
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
            this.VM = new ViewModels.Details.PenilaianViewModel(item);
            this.BindingContext = VM;
        }

        public PenilaianViewModel VM { get; }


        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            if(ItemsListView.SelectedItem!=null)
            {
                Entry entry = sender as Entry;
                var text = entry.Text;
                VM.UpdateDB();
                ItemsListView.SelectedItem = null;
            }
           
           
        }

    }
}