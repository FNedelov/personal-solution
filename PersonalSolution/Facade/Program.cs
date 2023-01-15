using System;

namespace Facade
{
    /// <summary>
    /// Facade Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Facade
            Mortgage mortgage = new();
            // Evaluate mortgage eligibility for customer
            Customer customer = new("Ann McKinsey");
            bool eligible = mortgage.IsEligible(customer, 125000);
            Console.WriteLine($"\n{customer.Name} has been {(eligible ? "Approved" : "Rejected")}");
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    public class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);
            return true;
        }
    }
    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    public class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }
    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    public class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }
    /// <summary>
    /// Customer class
    /// </summary>
    public class Customer
    {
        private string _name;
        // Constructor
        public Customer(string name)
        {
            _name = name;
        }
        public string Name
        {
            get { return _name; }
        }
    }
    /// <summary>
    /// The 'Facade' class
    /// </summary>
    public class Mortgage
    {
        Bank _bank = new();
        Loan _loan = new();
        Credit _credit = new();
        public bool IsEligible(Customer cust, int amount)
        {
            Console.WriteLine($"{cust.Name} applies for {amount:C} loan\n");
            bool eligible = true;
            // Check creditworthyness of applicant
            if (!_bank.HasSufficientSavings(cust, amount))
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(cust))
            {
                eligible = false;
            }
            return eligible;
        }
    }
}
