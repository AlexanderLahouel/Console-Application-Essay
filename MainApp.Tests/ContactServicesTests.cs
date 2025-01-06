using ContactsNamespace;
using Xunit;

public class ContactServiceTests
{
    [Fact]
    public void AddContact_ShouldStoreContact()
    {
        // Arrange
        var service = new ContactService();
        var contact = new Contact { FirstName = "Jane", LastName = "Doe" };

        // Act
        service.AddContact(contact);

        // Assert
        var contacts = service.GetAllContacts();
        Assert.Contains(contact, contacts);
    }

    [Fact]
    public void GetAllContacts_ShouldReturnEmptyList_WhenNoContactsAdded()
    {
        // Arrange
        string testFileName = "test_contacts.json";
        if (File.Exists(testFileName)) File.Delete(testFileName);

        var service = new ContactService(testFileName);

        // Act
        var contacts = service.GetAllContacts();

        // Assert
        Assert.Empty(contacts);

        // Cleanup
        if (File.Exists(testFileName)) File.Delete(testFileName);
    }

}

/*
 AddContact tester lägger till kontakter i listan. GetAllContacts ska innehålla alla sparade kontakter.
Andra testet ska retunera en tom lista om ingen kontakt har sparats. //Cleanup delen ska ta bort den temporära test filen.
*/

