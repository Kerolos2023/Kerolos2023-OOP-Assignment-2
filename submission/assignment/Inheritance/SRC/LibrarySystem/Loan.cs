namespace Inheritance.SRC.LibrarySystem;

public class Loan
{
    public int LoanId { get; private set; }

    public DateTime BorrowDate { get; private set; }

    public DateTime DueDate { get; private set; }

    public DateTime? ReturnDate { get; private set; }

    public Member Member { get; private set; }

    public LibraryItem Item { get; private set; }

    public LoanStatus Status { get; private set; }

    public Loan(
        int loanId,
        DateTime borrowDate,
        Member member,
        LibraryItem item)
    {
        LoanId = loanId;
        BorrowDate = borrowDate;
        Member = member;
        Item = item;

        DueDate = borrowDate.AddDays(
            item.GetLoanPeriodDays());

        Status = LoanStatus.Borrowed;
    }

    public void Return(DateTime returnDate)
    {
        if (Status == LoanStatus.Returned)
            throw new InvalidOperationException(
                "A returned loan cannot be returned again.");

        if (Status == LoanStatus.Lost)
            throw new InvalidOperationException(
                "A lost loan cannot be returned.");

        Status = LoanStatus.Returned;

        ReturnDate = returnDate;

        Item.Return();

        if (Member is PremiumMember)
        {
            PremiumMember premiumMember =
                (PremiumMember)Member;

            premiumMember.AddReadingPoints();
        }
    }

    public void MarkAsLost()
    {
        if (Status == LoanStatus.Returned)
            throw new InvalidOperationException(
                "A returned loan cannot be marked as lost.");

        Status = LoanStatus.Lost;
    }
}