
Calculator Calculator = new Calculator();
int result = Calculator.Add("//[***]\n11***22***33");
Console.WriteLine(result);

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers)) return 0;

        string[] delimiters = new[] { ",", "\n" };
        if (numbers.StartsWith("//"))
        {
            var index = numbers.IndexOf("\n");
            delimiters = new[] { numbers.Substring(3, index - 4) };
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