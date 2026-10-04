namespace Inheritance.SRC.LibrarySystem;

public class Person
{
    public int PersonId { get; private set; }
    public string FullName { get; private set; }
    public string PhoneNumber { get; private set; }

    public Person(
        int personId,
        string fullName,
        string phoneNumber)
    {
        PersonId = personId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
    }
}