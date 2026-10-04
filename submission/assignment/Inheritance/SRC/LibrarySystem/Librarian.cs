namespace Inheritance.SRC.LibrarySystem;

public class Librarian : Staff
{
    public Librarian(
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
            0)
    {
    }

    public void ProcessReturn(
        Loan loan,
        DateTime returnDate)
    {
        loan.Return(returnDate);
    }

    public void MarkAsLost(Loan loan)
    {
        loan.MarkAsLost();
    }
}