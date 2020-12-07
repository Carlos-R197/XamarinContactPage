using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinContactPage.ViewModels;
using XamarinContactPage.Models;

namespace XamarinContactPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContactPage : ContentPage
    {
        public AddContactPage(ObservableCollection<Contact> contacts)
        {
            InitializeComponent();
            BindingContext = new AddContactViewModel(contacts);
        }
    }
}