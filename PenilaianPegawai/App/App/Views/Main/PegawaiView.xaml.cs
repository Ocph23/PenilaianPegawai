using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Services;
using App.ViewModels.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PegawaiView : ContentPage
    {
        private AuthenticationToken token;

        public PegawaiViewModel VM { get; }

        public PegawaiView()
        {
            InitializeComponent();
           
        }

        public PegawaiView(AuthenticationToken token)
        {
            InitializeComponent();
            this.token = token;
            this.VM = new ViewModels.Main.PegawaiViewModel(Navigation,token);
            this.BindingContext = VM;
        }

        private async void listPegawai_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Models.pegawai;
            if (item == null)
                return;
            await Navigation.PushModalAsync(new Views.Details.PenilaianView(item));

            // Manually deselect item
            listPegawai.SelectedItem = null;
        }

        private void OnMore(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            VM.ShowDetailAsync(Convert.ToInt32(menu.CommandParameter));
        }
    }
}