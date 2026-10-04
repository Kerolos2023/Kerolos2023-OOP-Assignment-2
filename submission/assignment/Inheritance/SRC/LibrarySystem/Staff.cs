namespace Inheritance.SRC.LibrarySystem;

public class Staff : Person
{
    public DateTime HireDate { get; private set; }

    public decimal Salary { get; private set; }

    private decimal _responsibilityAllowance;

    public Staff(
        int personId,
        string fullName,
        string phoneNumber,
        DateTime hireDate,
        decimal salary,
        decimal responsibilityAllowance)
        : base(
            personId,
            fullName,
            phoneNumber)
    {
        HireDate = hireDate;
        Salary = salary;
        _responsibilityAllowance = responsibilityAllowance;
    }

    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0)
            throw new ArgumentException(
                "Raise percentage must be greater than zero.");

        Salary = Salary + (Salary * percentage / 100);
    }

    public decimal GetMonthlyPay()
    {
        return Salary + _responsibilityAllowance;
    }
}