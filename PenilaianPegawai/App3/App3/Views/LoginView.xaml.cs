using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App3.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentView
	{
		public LoginView ()
		{
			InitializeComponent ();
            this.VM = new ViewModels.LoginViewModel(this.Navigation);
            this.BindingContext = VM;
		}

        public LoginViewModel VM { get; }

        private void Entry_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var obj = sender as Entry;
            if(!string.IsNullOrEmpty(obj.Text))
                VM.Password = obj.Text;

        }
    }
}