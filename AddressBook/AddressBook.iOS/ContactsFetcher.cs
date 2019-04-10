using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressBook.Database;
using Contacts;
using Foundation;
using UIKit;

using Newtonsoft.Json;

namespace AddressBook.iOS
{
    class ContactsFetcher : ContactsFetch.IContacts
    {
        public List<ContactInfo> GetContactInfo()
        {
            var keysToFetch = new[] { CNContactKey.GivenName, CNContactKey.FamilyName, CNContactKey.PhoneNumbers,CNContactKey.PostalAddresses };
            //var containerId = new CNContactStore().DefaultContainerIdentifier;
            // using the container id of null to get all containers.
            // If you want to get contacts for only a single container type, you can specify that here
            var contactList = new List<CNContact>();

            using (var store = new CNContactStore())
            {
                var allContainers = store.GetContainers(null, out NSError error);
                foreach (var container in allContainers)
                {
                    try
                    {
                        using (var predicate = CNContact.GetPredicateForContactsInContainer(container.Identifier))
                        {
                            var containerResults = store.GetUnifiedContacts(predicate, keysToFetch, out error);
                            contactList.AddRange(containerResults);
                        }
                    }
                    catch
                    {
                        // ignore missed contacts from errors
                    }
                }
            }

            var contacts = new List<ContactInfo>();
 
            foreach (var item in contactList)
            {
                ContactInfo info = new ContactInfo
                {
                    Name = item.GivenName + " " + item.FamilyName
                };
                info.Name = info.Name.Trim();
                if (item.PhoneNumbers != null && item.PhoneNumbers.Length != 0)
                {
                    List<PhonesSave> phones = new List<PhonesSave>();
                    foreach (var i in item.PhoneNumbers)
                    {
                        string label = i.Label.Substring(4);
                        label = label.Remove(label.Length - 4);
                        phones.Add(new PhonesSave{Label = label, Phone = i.Value.StringValue});
                    }
                    info.Phones = JsonConvert.SerializeObject(phones.ToArray());
                }
                else
                    info.Phones = "{}";
                if (item.PostalAddresses != null && item.PostalAddresses.Length != 0)
                {
                    List<AddressSave> address = new List<AddressSave>();
                    foreach (var i in item.PostalAddresses)
                    {
                        string s = i.Value.Country;
                        s += " " + i.Value.State;
                        s += " " + i.Value.City;
                        s += " " + i.Value.Street;
                        s += " " + i.Value.PostalCode;
                        string label = i.Label.Substring(4);
                        label = label.Remove(label.Length - 4);
                        address.Add(new AddressSave{Address = s,Label = label});
                    }

                    info.Addresses = JsonConvert.SerializeObject(address.ToArray());
                }
                else
                    info.Phones = "{}";
                contacts.Add(info);
            }

            return contacts;
        }
        
    }
}