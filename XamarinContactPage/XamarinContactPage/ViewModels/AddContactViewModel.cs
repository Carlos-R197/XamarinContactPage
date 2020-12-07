using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinContactPage.Models;

namespace XamarinContactPage.ViewModels
{
    public class AddContactViewModel
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public ICommand AddContactCommand => new Command(AddContact);

        ObservableCollection<Contact> contacts;

        public AddContactViewModel(ObservableCollection<Contact> contacts)
        {
            this.contacts = contacts;
            Name = "";
            Number = "";
        }


        async void AddContact()
        {
            if (Number.Length == 10 && !string.IsNullOrEmpty(Name))
            {
                contacts.Add(new Contact(Name, Number));
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", 
                    "You must fill the name entry and have exactly 10 numbers in the number entry.", "OK");
            }
        }
    }
}
