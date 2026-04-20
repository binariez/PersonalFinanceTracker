using PersonalFinanceTracker.Common;

namespace PersonalFinanceTracker.Models;

public class Transaction
{
    public decimal Amount { get; set; }

    public DateTime Time { get; set; }

    public Enums Type{ get; set; }
}