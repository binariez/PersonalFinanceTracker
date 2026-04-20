using PersonalFinanceTracker.Models;
using System.Text.Json;

namespace PersonalFinanceTracker.Persistence;

public sealed class FileRepository
{ 
    private readonly string filePath = "serialized.json";

    private string jsonString = string.Empty;

    /// <summary>
    /// Serialize Transaction object and write to JSON file.
    /// </summary>
    public void SaveToFile(List<Transaction> transactions)
    {
        jsonString = JsonSerializer.Serialize(transactions);
        File.WriteAllText(filePath, jsonString);
    }

    /// <summary>
    /// Read and deserialize from JSON file. Then initialize it to List<Transaction>
    /// </summary>
    public List<Transaction> LoadFromFile()
    {
        if (File.Exists(filePath))
        {
            jsonString = File.ReadAllText(filePath);
            List<Transaction> transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonString) ?? [];
            return transactions;
        }
        return [];
    }
}