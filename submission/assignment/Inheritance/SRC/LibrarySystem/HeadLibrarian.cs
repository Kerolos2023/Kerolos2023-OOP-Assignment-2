namespace Inheritance.SRC.LibrarySystem;

public class HeadLibrarian : Staff
{
    public HeadLibrarian(
        int personId,
        string fullName,
        string phoneNumber,
        DateTime hireDate,
        decimal salary)
        : base(
            personId,
            fullName,
            phoneNumber,
            hireDate,
            salary,
            400)
    {
    }

    public void ChangeLateFee(
        LibraryItem item,
        decimal newFee)
    {
        item.ChangeLateFee(newFee);
    }

    public void Withdraw(LibraryItem item)
    {
        item.Withdraw();
    }

    public void Restore(LibraryItem item)
    {
        item.Restore();
    }
}