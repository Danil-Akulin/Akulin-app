using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace tthk_graz_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var contactsList = App.Database.GetItems();
            contactsListView.ItemsSource = contactsList;
            this.BindingContext = this;
            base.OnAppearing();
        }

        private void AddContactToolbarItem_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditContactPage());
        }

        private void ContactsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            if (contact != null)
            {
                Navigation.PushAsync(new ContactPage(contact));
            }

        }
    }
}
