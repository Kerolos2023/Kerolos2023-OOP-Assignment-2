namespace Inheritance.SRC.LibrarySystem;

public class Member : Person
{
    private List<Loan> _loans = new List<Loan>();

    private int _maxLoans;

    public IReadOnlyList<Loan> Loans
    {
        get { return _loans; }
    }

    public Member(
        int personId,
        string fullName,
        string phoneNumber,
        int maxLoans)
        : base(personId, fullName, phoneNumber)
    {
        _maxLoans = maxLoans;
    }

    public int GetMaxLoans()
    {
        return _maxLoans;
    }

    public void Borrow(
        int loanId,
        DateTime borrowDate,
        LibraryItem item)
    {
        if (_loans.Count >= _maxLoans)
        {
            throw new System.InvalidOperationException(
                "Maximum number of loans reached.");
        }

        item.Borrow();

        Loan loan = new Loan(
            loanId,
            borrowDate,
            this,
            item);

        _loans.Add(loan);
    }
}