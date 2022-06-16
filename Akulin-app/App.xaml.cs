using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tthk_graz_app
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "contacts.db";
        public static ContactRespository database;

        public static ContactRespository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ContactRespository(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
