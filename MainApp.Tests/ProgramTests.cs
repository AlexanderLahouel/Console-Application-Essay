using System;
using System.IO;
using ContactsNamespace;
using ContactsManagerNamespace;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestHost;

public class ProgramTests
{
    [Fact]
    public void RunApplication_ShouldAddAndDisplayContacts()
    {
        // Arrange
        var input = new StringReader(
            "1\nAnders\nEriksson\nAndersEriksson@domain.com\n123456789\nOrrkullegatan 3\n33333\nKarlstad\n" +
            "2\n" +
            "3\n"
        );
        var output = new StringWriter();

        Console.SetIn(input);
        Console.SetOut(output);

        var contactService = new ContactService();
        var contactManager = new ContactManager(contactService);

        // Act
        Program.RunApplication(contactManager);

        // Assert
        var consoleOutput = output.ToString();

        Assert.Contains("Added contact.", consoleOutput);
        Assert.Contains("Anders Eriksson", consoleOutput);
        Assert.Contains("Orrkullegatan 3", consoleOutput);
        Assert.Contains("Exiting the program.", consoleOutput);
    }
}
/* 
 Det här testet ser till att mitt program fungerar. 1/n delen indikerar att usern har tryckt 1 för att skapa kontakt och med nytt n vid varje nytt input indikerar att usern klickar enter
där varje nytt enter kräver ett input tills att alla har skrivits in.
2/n är att user valde att se alla kontakter. Assert skriver då ut contacts.
3/n exitar programmet.
//act tillkallar min contactmanager.
 */

