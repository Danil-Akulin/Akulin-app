using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tthk_graz_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactPage : ContentPage
    {
        private new int Id;
        public EditContactPage()
        {
            InitializeComponent();
            Title = "Uue kontakti lisamine";
        }

        public EditContactPage(Contact contact)
        {
            InitializeComponent();
            Title = "Kontakti muutmine";
            Id = contact.Id;
            firstNameCell.Text = contact.FirstName;
            lastNameCell.Text = contact.LastName;
            phoneCell.Text = contact.Phone;
            twitterCell.Text = contact.Twitter;
            vkCell.Text = contact.VK;
            telegramCell.Text = contact.Telegram;
            emailCell.Text = contact.Email;
        }

        private void SaveContactToolbarItem_OnClicked(object sender, EventArgs e)
        {
            Contact contact = new Contact()
            {
                FirstName = firstNameCell.Text,
                LastName = lastNameCell.Text,
                Phone = phoneCell.Text,
                Twitter = twitterCell.Text,
                VK = vkCell.Text,
                Telegram = telegramCell.Text,
                Email = emailCell.Text,
            };
            contact.Id = Id;
            if (!String.IsNullOrEmpty(contact.FirstName))
            {
                App.Database.SaveItem(contact);
            }

            Navigation.PopToRootAsync();
        }
    }
}