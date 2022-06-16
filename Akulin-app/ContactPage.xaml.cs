using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tthk_graz_app
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        private Contact _contact;
        public ContactPage(Contact contact)
        {
            _contact = contact;
            InitializeComponent();
            string fullName = contact.FirstName + " " + contact.LastName;
            Title = fullName;
            Dictionary<string, string> contactData = new Dictionary<string, string>();
            string[] fieldTitles = new string[] {"Telefoninumber", "E-post", "Telegram", "VK", "Twitter"};
            string[] fieldData = new string[]
                {contact.Phone, contact.Email, contact.Telegram, contact.VK, contact.Twitter};
            for (int i = 0; i < fieldTitles.Length; i++)
            {
                if (!String.IsNullOrEmpty(fieldData[i]))
                    contactData.Add(fieldTitles[i], fieldData[i]);
            }
            contactFullNameLabel.Text = fullName;
            contactInitialsLabel.Text = contact.Initials;
            contactInitialsCircle.BackgroundColor = contact.CircleColor;
            contactDataListView.ItemsSource = contactData;
            contactDataListView.SelectionMode = ListViewSelectionMode.None;
            contactDataListView.ItemTapped += ContactDataListViewOnItemTapped;
            contactDataListView.ItemTemplate = new DataTemplate(() =>
            {
                Label fieldTitleLabel = new Label()
                {
                    FontSize = 10
                };
                fieldTitleLabel.SetBinding(Label.TextProperty, "Key");
                Label fieldDataLabel = new Label()
                {
                    FontSize = 17
                };
                fieldDataLabel.SetBinding(Label.TextProperty, "Value");
                return new ViewCell()
                {
                    View = new StackLayout()
                    {
                        Padding = new Thickness(10),
                        Orientation = StackOrientation.Vertical,
                        Children = { fieldTitleLabel, fieldDataLabel }
                    }
                };
            });
        }

        private void ContactDataListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var field = (KeyValuePair<string, string>) e.Item;
            string communicationToolField = field.Value;
            if (!String.IsNullOrEmpty(communicationToolField))
                Navigation.PushAsync(new CongratulationChoicePage(field, _contact));
        }

        private void DeleteContactMenuItemOnClicked(object sender, EventArgs e)
        {
            App.Database.DeleteItem(_contact.Id);
            Navigation.PopAsync();
        }

        private void ChangeContactMenuItemOnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditContactPage(_contact));
        }
    }
}