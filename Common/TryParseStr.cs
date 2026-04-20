namespace PersonalFinanceTracker.Common;

public static class TryParseStr
{
    /// <summary>
    /// Misc function to check if the input string format is parsable into number
    /// </summary>
    public static decimal ToDecimal(string input)
    {
        if (decimal.TryParse(input, out decimal result) && result > 0) return result;
        else return -1;
    }
}