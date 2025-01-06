using System;
using ContactsNamespace;
using ContactsManagerNamespace;

public class Program
{

    public static void Main()
    {
        var contactService = new ContactService();
        var contactManager = new ContactManager(contactService);

        RunApplication(contactManager);
    }


    public static void RunApplication(ContactManager contactManager)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Add contact");
            Console.WriteLine("2. View contact list");
            Console.WriteLine("3. Exit");
            Console.WriteLine("---------------------------");
            Console.WriteLine("Select option: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddContact(contactManager);
                    break;

                case "2":
                    Console.WriteLine(contactManager.ViewContacts());
                    break;

                case "3":
                    running = false;
                    Console.WriteLine("Exiting program.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void AddContact(ContactManager contactManager)
    {
        Console.WriteLine("\n--- Add a New Contact ---");

        Console.WriteLine("First Name: ");
        string firstName = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Last Name: ");
        string lastName = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Email: ");
        string email = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Phone Number: ");
        string phoneNumber = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Address: ");
        string address = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Postal Code: ");
        string postalCode = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("City: ");
        string city = Console.ReadLine() ?? string.Empty;

        contactManager.AddContact(firstName, lastName, email, phoneNumber, address, postalCode, city);
        Console.WriteLine("\nAdded contact.");
    }
}



