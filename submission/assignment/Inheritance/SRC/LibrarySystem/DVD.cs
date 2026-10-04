namespace Inheritance.SRC.LibrarySystem;

public class DVD : LibraryItem
{
    public DVD(
        int catalogNumber,
        string title,
        decimal baseLateFee)
        : base(
            catalogNumber,
            title,
            baseLateFee,
            7,
            2)
    {
    }
}