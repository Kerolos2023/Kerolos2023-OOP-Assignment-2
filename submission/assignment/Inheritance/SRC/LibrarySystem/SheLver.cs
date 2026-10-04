namespace Inheritance.SRC.LibrarySystem;

public class Shelver : Staff
{
    public string Section { get; private set; }

    public Shelver(
        int personId,
        string fullName,
        string phoneNumber,
        DateTime hireDate,
        decimal salary,
        string section)
        : base(
            personId,
            fullName,
            phoneNumber,
            hireDate,
            salary,
            0)
    {
        Section = section;
    }

    public void Reassign(string newSection)
    {
        Section = newSection;
    }
}