using Contact_Management_API.Models;
using Contact_Management_API.Services;

IContactService service = new ContactService();

// Add Contacts
service.AddContact(new Contact
{
    Name = "John",
    Email = "john@test.com",
    Phone = "9999999999"
});

service.AddContact(new Contact
{
    Name = "Sara",
    Email = "sara@test.com",
    Phone = "8888888888"
});

// Display Contacts
Console.WriteLine("All Contacts:");

foreach (var contact in service.GetAllContacts())
{
    Console.WriteLine($"{contact.Id} - {contact.Name} - {contact.Email} - {contact.Phone}");
}

// Update Contact
service.UpdateContact(1, new Contact
{
    Name = "John Updated",
    Email = "john_new@test.com",
    Phone = "7777777777"
});

// Delete Contact
service.DeleteContact(2);

Console.WriteLine("\nAfter Update/Delete:");

foreach (var contact in service.GetAllContacts())
{
    Console.WriteLine($"{contact.Id} - {contact.Name} - {contact.Email} - {contact.Phone}");
}