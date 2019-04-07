using System;
using System.IO;
using AddressBook.Database;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AddressBook
{
    public partial class App : Application
    {
        public static Database.DatabaseConnection DbConnection;
        public App()
        {
            InitializeComponent();
            DbConnection = new DatabaseConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Contacts.db3"));
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
