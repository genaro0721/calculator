
Calculator Calculator = new Calculator();
int result = Calculator.Add("-3,9");
Console.WriteLine(result);

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers)) return 0;

        var stringNumbers = numbers.Split(",");
        if (stringNumbers.Length > 2) throw new ArgumentException("Maximum two numbers allowed");

        int sum = 0;
        foreach (var number in stringNumbers)
        {
            if (int.TryParse(number, out var parsedNumber))
            {
                sum += parsedNumber;
            }
        }
        return sum;
    }
}