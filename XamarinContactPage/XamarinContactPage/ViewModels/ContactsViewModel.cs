using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinContactPage.Models;
using XamarinContactPage.Views;
using Xamarin.Essentials;

namespace XamarinContactPage.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> Contacts { get; }

        public ICommand AddCommand => new Command(Add);
        public ICommand MoreCommand => new Command(More);
        public ICommand DeleteCommand => new Command(Delete);

        Contact selectedContact;

        public Contact SelectedContact
        {
            get { return selectedContact; }
            set 
            { 
                if (value != null)
                {
                    selectedContact = value;
                }
            }
        }

        public ContactsViewModel()
        {
            Contacts = new ObservableCollection<Contact>()
            { 
                new Contact("Carlos", "8093412424"),
                new Contact("Pepe", "8093542847"),
                new Contact("Juan", "8296541254")
            };

        }


        async void Add()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddContactPage(Contacts));
        }

        async void More()
        {
            if (selectedContact == null)
                OnNoContactSelected();
            else
            {
                string action = await App.Current.MainPage.DisplayActionSheet("", "Cancel", null, $"Call +{selectedContact.Number}", "Edit");

                if (action == "Edit")
                {
                    await App.Current.MainPage.Navigation.PushAsync(new EditContactPage(Contacts, SelectedContact));
                }
                else if (action == $"Call +{selectedContact.Number}")
                {
                    try
                    {
                        PhoneDialer.Open(selectedContact.Number);
                    }
                    catch (Exception ex)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Can't make the call", "Close");
                    }
                }
            }
        }

        void Delete()
        {
            if (selectedContact == null)
                OnNoContactSelected();
            else
            {
                Contacts.Remove(selectedContact);
                selectedContact = null;
            }
        }

        void OnNoContactSelected()
        {
            App.Current.MainPage.DisplayAlert("Alert",
                "No contact has been selected. Tap a contact before doing a long press or swipe.", "OK");
        }
    }
}
