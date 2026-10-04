namespace Inheritance.SRC.LibrarySystem;

public class Book : LibraryItem
{
    public Book(
        int catalogNumber,
        string title,
        decimal baseLateFee)
        : base(
            catalogNumber,
            title,
            baseLateFee,
            21,
            1)
    {
    }
}