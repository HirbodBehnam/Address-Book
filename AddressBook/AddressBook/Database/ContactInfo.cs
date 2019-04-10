using SQLite;

namespace AddressBook.Database
{
    public class ContactInfo
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        /// <summary>
        /// Label of contact
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Phone numbers of contact, use JSON to deserialize with <see cref="PhonesSave"/> class
        /// </summary>
        public string Phones { get; set; }
        /// <summary>
        /// Addresses of contact, use JSON to deserialize with <see cref="AddressSave"/> class
        /// </summary>
        public string Addresses {get;set;}
    }
    public class PhonesSave
    {
        public string Label{get;set;}
        public string Phone{get;set;}
    }
    public class AddressSave
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Address { get; set; }
        public string Label { get; set; }
    }
}
