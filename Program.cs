using PersonalFinanceTracker.Common;
using PersonalFinanceTracker.Services;

TransactionService service = new();

const string HORIZONTAL_RULE = "------------------";
string option;

do
{
    Console.WriteLine("Select an Option");
    Console.WriteLine(HORIZONTAL_RULE);
    Console.WriteLine("1. Current Balance");
    Console.WriteLine("2. Deposit");
    Console.WriteLine("3. Withdraw");
    Console.WriteLine("4. View history");
    Console.WriteLine("5. Exit");
    Console.WriteLine(HORIZONTAL_RULE);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
    option = Console.ReadLine().Trim() ?? string.Empty;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

    switch (option)
    {
        case "1":
            Console.WriteLine($"Current balance: ${service.GetBalance()}");
            break;

        case "2":
            Console.Write("Enter amount: $");

            decimal depositAmount = TryParseStr.ToDecimal(Console.ReadLine() ?? "");

            if (depositAmount > 0) service.AddTransaction(depositAmount, Enums.Income);
            else Console.WriteLine("Not a valid positive number");
            break;

        case "3":
            Console.Write("Enter amount: $");

            // Try to parse the input string to decimal
            decimal withdrawAmount = TryParseStr.ToDecimal(Console.ReadLine() ?? "");

            // Ensure it's a positive number and user has a sufficient balance
            if (withdrawAmount > 0)
            {
                if(!service.AddTransaction(withdrawAmount, Enums.Expense))
                {
                    Console.WriteLine($"You don't have a sufficient amount of balance");
                    break;
                }
            }

            else Console.WriteLine("Not a valid positive number");
            break;

        case "4":
            Console.WriteLine("History");
            Console.WriteLine(HORIZONTAL_RULE);

            string transactionType;

            // Iterate through transaction collection
            foreach (var n in service.GetHistory())
            {
                transactionType = n.Type == Enums.Income ? "Income " : "Expense";
                Console.WriteLine($"[{n.Time}] {transactionType}: {n.Amount}");
            }
            break;

        case "5":
            Console.WriteLine("User exits");
            break;

        default:
            Console.WriteLine("Not a valid option");
            break;
    }

} while (option != "5");