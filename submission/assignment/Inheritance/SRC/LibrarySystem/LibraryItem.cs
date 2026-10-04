namespace Inheritance.SRC.LibrarySystem;

public class LibraryItem
{
    public int CatalogNumber { get; private set; }

    public string Title { get; private set; }

    public decimal BaseLateFee { get; private set; }

    public bool IsWithdrawn { get; private set; }

    public bool IsOnLoan { get; private set; }

    private int _loanPeriodDays;

    private decimal _feeMultiplier;

    public LibraryItem(
        int catalogNumber,
        string title,
        decimal baseLateFee,
        int loanPeriodDays,
        decimal feeMultiplier)
    {
        CatalogNumber = catalogNumber;
        Title = title;
        BaseLateFee = baseLateFee;
        _loanPeriodDays = loanPeriodDays;
        _feeMultiplier = feeMultiplier;
    }

    public int GetLoanPeriodDays()
    {
        return _loanPeriodDays;
    }

    public decimal GetDailyLateFee()
    {
        return BaseLateFee * _feeMultiplier;
    }

    public void ChangeLateFee(decimal newFee)
    {
        if (newFee < 0)
            throw new ArgumentException(
                "Late fee cannot be negative.");

        BaseLateFee = newFee;
    }

    public void Withdraw()
    {
        IsWithdrawn = true;
    }

    public void Restore()
    {
        IsWithdrawn = false;
    }

    public void Borrow()
    {
        if (IsWithdrawn)
            throw new InvalidOperationException(
                "A withdrawn item cannot be borrowed.");

        if (IsOnLoan)
            throw new InvalidOperationException(
                "An item that is already on loan cannot be borrowed.");

        IsOnLoan = true;
    }

    public void Return()
    {
        IsOnLoan = false;
    }
}