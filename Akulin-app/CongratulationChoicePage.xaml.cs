using System;
using System.Collections.Generic;
using Plugin.Messaging;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tthk_graz_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CongratulationChoicePage : ContentPage
    {
        private Contact _contact;
        private KeyValuePair<string, string> _communicationTool;

        public CongratulationChoicePage(KeyValuePair<string, string> communicationTool, Contact contact)
        {
            InitializeComponent();
            _contact = contact;
            _communicationTool = communicationTool;
            List<string> holidays = new List<string>() {"Uus aasta", "Sünnipäev", "Iseseisvumispäev", "Naistepäev", "Jõulupüha"};
            congratulationChoiceListView.ItemsSource = holidays;
            congratulationChoiceListView.ItemTapped += CongratulationChoiceListViewOnItemTapped;
            congratulationChoiceListView.SelectionMode = ListViewSelectionMode.None;
            Title = $"Vali püha: {_communicationTool.Key}";
        }

        private void CongratulationChoiceListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            string holiday = e.Item as string;
            switch (holiday)
            {
                case "Uus aasta":
                    SendCongratulation(StringTemplates.NewYear(_contact.FirstName));
                    break;
                case "Sünnipäev":
                    SendCongratulation(StringTemplates.Birthday(_contact.FirstName));
                    break;
                case "Iseseisvumispäev":
                    SendCongratulation(StringTemplates.IndependenceDay(_contact.FirstName));
                    break;
                case "Naistepäev":
                    SendCongratulation(StringTemplates.WomansDay(_contact.FirstName));
                    break;
                case "Jõulupüha":
                    SendCongratulation(StringTemplates.Christmas(_contact.FirstName));
                    break;
            }
        }

        private void SendCongratulation(string message)
        {
            string communicationTool = _communicationTool.Key;
            string communicationToolField = _communicationTool.Value;
            switch (communicationTool)
            {
                case "Telefoninumber":
                    var smsMessenger = CrossMessaging.Current.SmsMessenger;
                    if (smsMessenger.CanSendSms)
                        smsMessenger.SendSms(communicationToolField, message);
                    Navigation.PopAsync();
                    break;
                case "E-post":
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    if (emailMessenger.CanSendEmail)
                        emailMessenger.SendEmail(communicationToolField, "Õnnesoov!", message);
                    Navigation.PopAsync();
                    break;
                case "Telegram":
                    MakeWayAlert(message);
                    break;
                case "VK":
                    MakeWayAlert(message);
                    break;
                case "Twitter":
                    MakeWayAlert(message);
                    break;
            }
        }

        private async void MakeWayAlert(string message)
        {
            string communicationTool = _communicationTool.Key;
            string communicationToolField = _communicationTool.Value;
            bool answer = await DisplayAlert("Kuidas tuleb saada õnnesoov?",
                $"Kui sa valid \"Ei\" siis tuleb ise valida kuhu saada, vastades \"Jah\" avatakse {communicationTool} sõnumi saatmise aken ise",
                "Jah", "Ei");
            if (answer)
            {
                await Clipboard.SetTextAsync(message);
                switch (communicationTool)
                {
                    case "Telegram":
                        Browser.OpenAsync("https://t.me/" + communicationToolField);
                        break;
                    case "VK":
                        Browser.OpenAsync("https://vk.me/" + communicationToolField);
                        break;
                    case "Twitter":
                        Browser.OpenAsync("https://twitter.com/" + communicationToolField);
                        break;
                }
                Navigation.PopAsync();
            }
            else
            {
                await Share.RequestAsync(new ShareTextRequest(message));
                Navigation.PopAsync();
            }
        }
    }
}