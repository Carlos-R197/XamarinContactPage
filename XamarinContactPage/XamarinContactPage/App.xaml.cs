using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinContactPage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContactsPage())
            {
                BarBackgroundColor = Color.FromHex("#0E547C"),
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
