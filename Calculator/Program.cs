
Calculator Calculator = new Calculator();
int result = Calculator.Add("//,\n2,ff,100");
Console.WriteLine(result);

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers)) return 0;

        string[] delimiters = new[] { ",", "\n" };
        if (numbers.StartsWith("//"))
        {
            var index = numbers.IndexOf("\n", StringComparison.Ordinal);
            delimiters = new[] { numbers.Substring(2, index - 2) };
            numbers = numbers.Substring(index + 1);
        }

        var stringNumbers = numbers.Split(delimiters, StringSplitOptions.None);

        int sum = 0;
        foreach (var number in stringNumbers)
        {
            if (int.TryParse(number, out var parsedNumber))
            {
                if (parsedNumber < 0) throw new ArgumentException("Negative numbers are not allowed");
                if (parsedNumber > 1000) continue;
                sum += parsedNumber;
            }
        }
        return sum;
    }
}