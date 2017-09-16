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
    public partial class MainView : TabbedPage
    {
        public MainView ()
        {
            InitializeComponent();
            this.VM = new ViewModels.MainViewModel(this.Navigation);
            this.BindingContext = VM;
        }

        internal MainViewModel VM { get; }
    }
}