using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AddressBook
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddContact : ContentPage
	{
		public AddContact ()
		{
			InitializeComponent ();
		}

        private async void ImportContactsToolbar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImportContacts());
            Navigation.RemovePage(this);
        }
        
    }
}