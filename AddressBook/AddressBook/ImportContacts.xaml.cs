using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Database;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AddressBook
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImportContacts : ContentPage
	{
		public ImportContacts ()
		{
			InitializeComponent ();
		}

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            var res = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Contacts);
            if(res == PermissionStatus.Granted)
                ButtonsGetContacts.IsEnabled = true;
        }
        private async void CheckPermissionClicked(object sender, EventArgs e)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Contacts);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Contacts);
                if(results.ContainsKey(Permission.Contacts))
                    status = results[Permission.Contacts];
            }
            if (status == PermissionStatus.Granted)
                ButtonsGetContacts.IsEnabled = true;
            else 
                await DisplayAlert("Error", "Can not continue, try again.\nHave you canceled the request?", "OK");
            
        }

        private async void ButtonsGetContacts_OnClicked(object sender, EventArgs e)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Contacts);
            if (status == PermissionStatus.Granted)
            {
                ActivityIndicatorMain.IsVisible = true;
                
            }
            else
                await DisplayAlert("Error", "Can not continue, try again.\nHave you allowed app to access your contacts?", "OK");
            ActivityIndicatorMain.IsVisible = false;
        }
    }
}