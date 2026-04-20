using PersonalFinanceTracker.Common;
using PersonalFinanceTracker.Models;
using PersonalFinanceTracker.Persistence;

namespace PersonalFinanceTracker.Services;

public sealed class TransactionService
{
    private readonly List<Transaction> _transactions;
    private readonly FileRepository _repo = new();

    public TransactionService()
    {
        _transactions = [];
        _transactions = _repo.LoadFromFile();
    }

    /// <summary>
    /// Get current balance
    /// </summary>
    public decimal GetBalance() => _transactions.Sum(x => x.Type == Enums.Income ? x.Amount : -x.Amount);

    /// <summary>
    /// Get enumerator for Transaction
    /// </summary>
    public IEnumerable<Transaction> GetHistory() => _transactions.OrderByDescending(x => x.Time);

    /// <summary>
    /// Add a new transaction
    /// </summary>
    public bool AddTransaction(decimal amount, Enums type)
    {
        // Check if user has a sufficient balance when the transaction type is `Expense`
        if (GetBalance() < amount && type == Enums.Expense)
        {
            return false;
        }

        // Proceed the transaction
        _transactions.Add(new Transaction { Amount = amount, Time = DateTime.Now, Type = type });
        _repo.SaveToFile(_transactions);

        return true;
    }
}