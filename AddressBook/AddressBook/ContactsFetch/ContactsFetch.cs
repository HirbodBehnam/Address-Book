using System;
using System.Collections.Generic;
using System.Text;
using AddressBook.Database;
#if __MOBILE_

#else

#endif

namespace AddressBook.ContactsFetch
{
    public static class ContactsFetch
    {
        public static List<ContactInfo> GetContacts()
        {
            List<ContactInfo> contacts = new List<ContactInfo>();
            
#if __ANDROID__
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific
#endif
#if __IOS__

#endif
            return contacts;
        }
    }
}
