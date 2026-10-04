namespace Inheritance.SRC.LibrarySystem;

public class PremiumMember : Member
{
    private int _readingPoints;

    public decimal FeeDiscountPercentage { get; private set; }

    public int ReadingPoints
    {
        get { return _readingPoints; }
    }

    public PremiumMember(
        int personId,
        string fullName,
        string phoneNumber,
        decimal feeDiscountPercentage)
        : base(
            personId,
            fullName,
            phoneNumber,
            10)
    {
        FeeDiscountPercentage = feeDiscountPercentage;
        _readingPoints = 0;
    }

    public void AddReadingPoints()
    {
        _readingPoints += 5;
    }
}