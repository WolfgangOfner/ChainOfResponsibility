using System;

namespace ChainOfResponsibility
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var tom = new ExpenseHandler(new Employee("Tom", "Marketing", 0));
            var susan = new ExpenseHandler(new Employee("Susan", "Teamleader Marketing", 10_000));
            var lisa = new ExpenseHandler(new Employee("Lisa", "Area Manager Marketing", 100_000));
            var wolfgang = new ExpenseHandler(new Employee("Wolfgang", "CEO", 1_000_000_000));

            // register successor
            tom.RegisterNext(susan);
            susan.RegisterNext(lisa);
            lisa.RegisterNext(wolfgang);

            while (true)
            {
                decimal expenseReportAmount = 0;

                Console.WriteLine("Enter report amount or -1 to end program");
                var input = Console.ReadLine();

                try
                {
                    expenseReportAmount = Convert.ToDecimal(input);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your input was not a valid decimal number\n");
                    Console.ResetColor();
                    continue;
                }

                if (expenseReportAmount == -1)
                {
                    break;
                }

                IExpenseReport expense = new ExpenseReport(expenseReportAmount);

                var response = tom.Approve(expense);

                if (response == ApprovalResponse.Approved)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The request was {response}\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The amount was too high. No one can approve such a high number\n");
                    Console.ResetColor();
                }
            }

            Console.ReadKey();
        }
    }
}