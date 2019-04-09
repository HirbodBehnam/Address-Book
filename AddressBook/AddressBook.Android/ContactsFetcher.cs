using System.Collections.Generic;
using AddressBook.Database;
using Android.App;
using Android.Content;
using Android.Provider;

namespace AddressBook.Droid
{
    public class ContactsFetcher : ContactsFetch.IContacts
    {
        public static Activity MainActivity;
        public List<ContactInfo> GetContactInfo()
        {
            ContentResolver cr = MainActivity.ContentResolver;
            var cur = cr.Query(ContactsContract.Contacts.ContentUri, null, null, null, null);
            List<ContactInfo> infos = new List<ContactInfo>();
            while (cur.MoveToNext())
            { 
                ContactInfo info = new ContactInfo();
                string id = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.Id));
                info.Name = cur.GetString(cur.GetColumnIndex(ContactsContract.Contacts.InterfaceConsts.DisplayName));
                //Address
                {
                    List<AddressSave> addresses = new List<AddressSave>();
                    var postals = cr.Query(ContactsContract.CommonDataKinds.StructuredPostal.ContentUri,
                        null, "contact_id" + " = " + id,null,null);
                    int postFormattedNdx = postals.GetColumnIndex(ContactsContract.CommonDataKinds.StructuredPostal.FormattedAddress);
                    while (postals.MoveToNext()) {
                        addresses.Add(new AddressSave
                        {
                            Address = postals.GetString(postFormattedNdx)
                        });
                    }
                    postals.Close(); 
                    info.Addresses = addresses.ToArray();
                }
                //Phone
                {
                    List<PhonesSave> phonesAry = new List<PhonesSave>();
                    var phones = Application.Context.ContentResolver.Query(
                        ContactsContract.CommonDataKinds.Phone.ContentUri,
                        null,
                        ContactsContract.CommonDataKinds.Phone.InterfaceConsts.ContactId
                        + " = " + id, null, null);
                    // getting phone numbers 
                    while (phones.MoveToNext())
                    {
                        phonesAry.Add(new PhonesSave{
                            Phone = phones.GetString( phones.GetColumnIndex(ContactsContract.CommonDataKinds.Phone.Number))
                        });
                    }
                    phones.Close();
                    info.Phones = Newtonsoft.Json.JsonConvert.SerializeObject(phonesAry.ToArray());
                }
                infos.Add(info);
            }
            return infos;
        }
    }
}