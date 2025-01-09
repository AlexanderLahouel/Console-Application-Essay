using System;
using ContactsNamespace;

namespace ContactsManagerNamespace
{
    public class ContactManager
    {
        private readonly ContactService _contactService;

        public ContactManager(ContactService contactService) // Ser till att contactmanager kan använda sig utav contactservices.
        {
            _contactService = contactService;
        }

        public void AddContact(string firstName, string lastName, string email, string phoneNumber,  
                               string address, string postalCode, string city)
        {
            var newContact = new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                PostalCode = postalCode,
                City = city
            };

            _contactService.AddContact(newContact); //Använder _contactService.AddContact för att spara kontakten till en fil.
        }

        public string ViewContacts()  //Hämtar alla kontakter genom _contactService.GetAllContacts. Om listan är tom returneras no contacts found.
           // Om det finns kontakter, skapas en sträng med detaljer för varje kontakt, new string 40 innebär att varje kontaktinformaion avslutas med en streckad linje.
        {
            var contacts = _contactService.GetAllContacts();
            if (contacts.Count == 0)
                return "No contacts found.";

            var result = "\n--- Contact List ---\n";
            foreach (var contact in contacts)
            {
                result += $"ID: {contact.Id}\n";   //Foreach loop som + resultatet av varje egenskap på ny kontakt och lägger in det i listan. 
                result += $"Name: {contact.FirstName} {contact.LastName}\n";
                result += $"Email: {contact.Email}\n";
                result += $"Phone: {contact.PhoneNumber}\n";
                result += $"Address: {contact.Address}\n";
                result += $"Postal Code: {contact.PostalCode}\n";
                result += $"City: {contact.City}\n";
                result += new string('-', 40) + "\n";
            }

            return result;
        }
    }
}
