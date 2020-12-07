using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinContactPage.Models;
using XamarinContactPage.ViewModels;
using System.Collections.ObjectModel;

namespace XamarinContactPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactPage : ContentPage
    {
        public EditContactPage(ObservableCollection<Contact> contacts, Contact currentContact)
        {
            InitializeComponent();
            BindingContext = new EditContactViewModel(contacts, currentContact);
        }
    }
}