using System.Collections.Generic;

namespace AddressBook.ContactsFetch
{
    public interface IContacts
    {
        List<Database.ContactInfo> GetContactInfo();
    }
}
