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
	public partial class ImportContacts : ContentPage
	{
		public ImportContacts ()
		{
			InitializeComponent ();
		}
	}
}