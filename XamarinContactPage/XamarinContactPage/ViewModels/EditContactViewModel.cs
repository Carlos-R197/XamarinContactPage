using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinContactPage.Models;

namespace XamarinContactPage.ViewModels
{
    public class EditContactViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public Contact oldContact;
        public ICommand EditContactCommand => new Command(EditContact);

        ObservableCollection<Contact> contacts;

        public EditContactViewModel(ObservableCollection<Contact> contacts, Contact oldContact)
        {
            this.contacts = contacts;
            this.oldContact = oldContact;

            Name = oldContact.Name;
            Number = oldContact.Number;
        }


        void EditContact()
        {
            int index = contacts.IndexOf(oldContact);
            contacts[index] = new Contact(Name, Number);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
