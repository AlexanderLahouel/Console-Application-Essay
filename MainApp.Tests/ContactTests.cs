using ContactsNamespace;
using Xunit;

public class ContactTests
{
    [Fact]
    public void Contact_ShouldGenerateUniqueId()
    {
        // Act
        var contact = new Contact();

        // Assert
        Assert.NotEqual(Guid.Empty, contact.Id);
    }

    [Fact]
    public void Contact_ShouldStorePropertiesCorrectly()
    {
        // Arrange
        var contact = new Contact
        {
            FirstName = "Anders",
            LastName = "Eriksson",
            Email = "AndersEriksson@domain.com",
            PhoneNumber = "123456789",
            Address = "Orrkullegatan 3",
            PostalCode = "33333",
            City = "Karlstad"
        };

        // Assert
        Assert.Equal("Anders", contact.FirstName);
        Assert.Equal("Eriksson", contact.LastName);
        Assert.Equal("AndersEriksson@domain.com", contact.Email);
        Assert.Equal("123456789", contact.PhoneNumber);
        Assert.Equal("Orrkullegatan 3", contact.Address);
        Assert.Equal("33333", contact.PostalCode);
        Assert.Equal("Karlstad", contact.City);
    }
}

// Det mesta av mina test är skapade genom chatgpt, jag fick aldrig ihop det när jag provade själv men jag har studerat och förstår vad saker gör. 
// Första testet kontrollerar att varje gång en kontakt skapas så ska inte contact.id vara guid.empty. Detta ser till att ett Guid-ID skapas varje gång ny kontakt skapas.
// Andra testet ser till att alla egenskaper får värden.
