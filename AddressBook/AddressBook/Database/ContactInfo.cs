using SQLite;

namespace AddressBook.Database
{
    public class ContactInfo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public PhonesSave[] Phones { get; set; }
        public AddressSave[] Addresses {get;set;}
    }
    public class PhonesSave
    {
        public string Name{get;set;}
        public string Phone{get;set;}
    }
    public class AddressSave
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Address { get; set; }
    }
}
