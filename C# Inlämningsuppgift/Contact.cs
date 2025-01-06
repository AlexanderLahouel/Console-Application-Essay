﻿
namespace ContactsNamespace
{
    public class Contact
    {
        public Guid Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }


    public Contact()
        {
            Id = Guid.NewGuid();
        }
    }
}
