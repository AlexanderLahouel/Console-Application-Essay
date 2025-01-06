
using ContactsNamespace;
using System.Text.Json;

public class ContactService
{
    private readonly string _fileName;
    private readonly List<Contact> _contacts;

    public ContactService(string fileName = "contacts.json")
    {
        _fileName = fileName;
        _contacts = LoadContactsFromFile();    //LoadContactsFromFile sparar dem i _contacts.
    }

    public void AddContact(Contact contact)
    {
        _contacts.Add(contact);
        SaveContactsToFile();   
    }

    public List<Contact> GetAllContacts()
    {
        return _contacts;   //alla kontakter som sparats i _contacts ska returneras och visas i programmet.
    }

    private void SaveContactsToFile()
    {
        try
        {
            var json = JsonSerializer.Serialize(_contacts, new JsonSerializerOptions { WriteIndented = true });  //Omvandlar _contacts till JSON-format, writeindented ger bättre läsbarhet.
            File.WriteAllText(_fileName, json);  //Skriver ut allt i filen.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving contacts: {ex.Message}");
        }
    }

    private List<Contact> LoadContactsFromFile()
    {
        try
        {
            if (File.Exists(_fileName))  //kontrollerar att filen existerar annars anropas error meddelandet.
            {
                var json = File.ReadAllText(_fileName);
                var contacts = JsonSerializer.Deserialize<List<Contact>>(json);  //Deserialiserar JSON tillbaka till en lista av objektet Contact
                return contacts ?? new List<Contact>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading contacts: {ex.Message}");
        }

        return new List<Contact>();
    }
}


/* 
 ContactServices ansvarar för att lägga till kontakter och spara ner dem i en JSON-fil. 
Det ansvarar även att man ska kunna ladda dessa kontakter och retunera en lista med alla sparade kontakter
 */
