using Inheritance.SRC.LibrarySystem;

class Program
{
    static void Main()
    {
        // ============================================
        // Create Members
        // ============================================

        StudentMember student = new StudentMember(
            1,
            "Kerolos Saleh",
            "01000000000");

        PremiumMember premium = new PremiumMember(
            2,
            "Ahmed Ali",
            "01111111111",
            20);


        // ============================================
        // Create Library Items
        // ============================================

        Book book = new Book(
            101,
            "Clean Code",
            10);

        DVD dvd = new DVD(
            102,
            "C# Course",
            10);

        Magazine magazine = new Magazine(
            103,
            "Tech Magazine",
            5);


        Console.WriteLine("========== Library System ==========");


        // ============================================
        // Student Information
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Student ==========");

        Console.WriteLine($"Name: {student.FullName}");
        Console.WriteLine($"Max Loans: {student.GetMaxLoans()}");
        Console.WriteLine($"Current Loans: {student.Loans.Count}");


        // ============================================
        // Premium Information
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Premium Member ==========");

        Console.WriteLine($"Name: {premium.FullName}");
        Console.WriteLine($"Max Loans: {premium.GetMaxLoans()}");
        Console.WriteLine($"Discount: {premium.FeeDiscountPercentage}%");
        Console.WriteLine($"Reading Points: {premium.ReadingPoints}");


        // ============================================
        // Borrow Book
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Borrow Book ==========");

        student.Borrow(
            1,
            DateTime.Now,
            book);

        Console.WriteLine($"Book: {book.Title}");
        Console.WriteLine($"Student Loans: {student.Loans.Count}");
        Console.WriteLine($"Book Is On Loan: {book.IsOnLoan}");


        // ============================================
        // Borrow DVD
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Borrow DVD ==========");

        premium.Borrow(
            2,
            DateTime.Now,
            dvd);

        Console.WriteLine($"DVD: {dvd.Title}");
        Console.WriteLine($"Premium Loans: {premium.Loans.Count}");
        Console.WriteLine($"DVD Is On Loan: {dvd.IsOnLoan}");


        // ============================================
        // List<LibraryItem>
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Library Items ==========");

        List<LibraryItem> items = new List<LibraryItem>
        {
            book,
            dvd,
            magazine
        };

        foreach (LibraryItem item in items)
        {
            Console.WriteLine();
            Console.WriteLine($"Title: {item.Title}");
            Console.WriteLine($"Loan Period: {item.GetLoanPeriodDays()} days");
            Console.WriteLine($"Daily Late Fee: {item.GetDailyLateFee()}");
        }


        // ============================================
        // Staff
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Staff ==========");

        Librarian librarian = new Librarian(
            3,
            "Mohamed",
            "01222222222",
            DateTime.Now,
            5000);

        HeadLibrarian headLibrarian = new HeadLibrarian(
            4,
            "Mostafa",
            "01333333333",
            DateTime.Now,
            8000);

        Shelver shelver = new Shelver(
            5,
            "Omar",
            "01444444444",
            DateTime.Now,
            4000,
            "Science");

        List<Staff> staffMembers = new List<Staff>
        {
            librarian,
            headLibrarian,
            shelver
        };

        foreach (Staff staff in staffMembers)
        {
            Console.WriteLine($"Staff: {staff.FullName}");
            Console.WriteLine($"Monthly Salary: {staff.GetMonthlyPay()}");
            Console.WriteLine();
        }


        // ============================================
        // Premium Returns DVD 5 Days Late
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Premium Late Return ==========");

        Loan loan = premium.Loans[0];

        DateTime returnDate = loan.DueDate.AddDays(5);

        decimal lateFee =
            5 * dvd.GetDailyLateFee();

        loan.Return(returnDate);

        Console.WriteLine($"Due Date: {loan.DueDate}");
        Console.WriteLine($"Return Date: {returnDate}");
        Console.WriteLine($"Late Days: 5");
        Console.WriteLine($"Daily Late Fee: {dvd.GetDailyLateFee()}");
        Console.WriteLine($"Late Fee: {lateFee}");
        Console.WriteLine($"Reading Points: {premium.ReadingPoints}");
        Console.WriteLine($"Status: {loan.Status}");


        // ============================================
        // Return Same Loan Twice
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Return Same Loan Twice ==========");

        try
        {
            loan.Return(returnDate);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


        // ============================================
        // Returned Loan -> Lost
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Returned Loan -> Lost ==========");

        try
        {
            loan.MarkAsLost();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


        // ============================================
        // Withdrawn Item
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Withdrawn Item ==========");

        headLibrarian.Withdraw(magazine);

        Console.WriteLine($"Magazine: {magazine.Title}");
        Console.WriteLine($"Is Withdrawn: {magazine.IsWithdrawn}");

        try
        {
            student.Borrow(
                3,
                DateTime.Now,
                magazine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        headLibrarian.Restore(magazine);

        Console.WriteLine(
            $"Is Withdrawn After Restore: {magazine.IsWithdrawn}");


        // ============================================
        // Borrow Already On Loan Item
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Already On Loan ==========");

        Book anotherBook = new Book(
            104,
            "Design Patterns",
            10);

        try
        {
            student.Borrow(
                4,
                DateTime.Now,
                anotherBook);

            premium.Borrow(
                5,
                DateTime.Now,
                anotherBook);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


        // ============================================
        // Student 4th Loan
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Student 4th Loan ==========");

        try
        {
            Book book2 = new Book(
                105,
                "Refactoring",
                10);

            DVD dvd2 = new DVD(
                106,
                "Advanced C#",
                10);

            Magazine magazine2 = new Magazine(
                107,
                "Programming Magazine",
                5);

            student.Borrow(
                6,
                DateTime.Now,
                book2);

            student.Borrow(
                7,
                DateTime.Now,
                dvd2);

            student.Borrow(
                8,
                DateTime.Now,
                magazine2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


        // ============================================
        // Librarian Process Return
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Librarian Process Return ==========");

        Book returnBook = new Book(
            108,
            "Clean Architecture",
            10);

        student.Borrow(
            9,
            DateTime.Now,
            returnBook);

        Loan returnLoan =
            student.Loans[student.Loans.Count - 1];

        librarian.ProcessReturn(
            returnLoan,
            DateTime.Now);

        Console.WriteLine($"Loan Status: {returnLoan.Status}");


        // ============================================
        // Librarian Mark As Lost
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Librarian Mark As Lost ==========");

        Book lostBook = new Book(
            109,
            "Domain Driven Design",
            10);

        premium.Borrow(
            10,
            DateTime.Now,
            lostBook);

        Loan lostLoan =
            premium.Loans[premium.Loans.Count - 1];

        librarian.MarkAsLost(lostLoan);

        Console.WriteLine($"Loan Status: {lostLoan.Status}");


        // ============================================
        // Shelver Reassign
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Shelver ==========");

        Console.WriteLine($"Section: {shelver.Section}");

        shelver.Reassign("Technology");

        Console.WriteLine($"New Section: {shelver.Section}");


        // ============================================
        // Head Librarian Change Late Fee
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Change Late Fee ==========");

        Console.WriteLine(
            $"Old Late Fee: {book.BaseLateFee}");

        headLibrarian.ChangeLateFee(
            book,
            15);

        Console.WriteLine(
            $"New Late Fee: {book.BaseLateFee}");

        Console.WriteLine(
            $"New Daily Late Fee: {book.GetDailyLateFee()}");


        // ============================================
        // MUST NOT COMPILE
        // ============================================

        /*
         * These lines MUST NOT COMPILE.
         * They are intentionally commented out.
         */

        // Person person = new Person(...);

        // Member member = new Member(...);

        // Staff staff = new Staff(...);

        // LibraryItem item = new LibraryItem(...);

        // student.FullName = "New Name";

        // student.Loans.Add(loan);

        // book.IsOnLoan = true;


        // ============================================
        // Finished
        // ============================================

        Console.WriteLine();
        Console.WriteLine("========== Finished ==========");
    }
}