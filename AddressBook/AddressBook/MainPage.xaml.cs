using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AddressBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<ContactToShow> ContactsCollection = new ObservableCollection<ContactToShow>();
        public MainPage()
        {
            InitializeComponent();
            ListViewMain.ItemsSource = ContactsCollection;
        }
        private async void MainPage_OnAppearing(object sender, EventArgs e)
        {
            List<Database.ContactInfo> contacts = await App.DbConnection.GetContactInfosAsync();
            foreach (var i in contacts)
            {
                ContactsCollection.Add(new ContactToShow
                {
                    ID = i.ID,
                    Name = i.Name
                });
            }
        }
        private void EntrySearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void ListOnDelete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void AddContactsToolbar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContact());
        }
        public class ContactToShow
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }

}
