
Calculator Calculator = new Calculator();
int result = Calculator.Add("1\n2,3");
Console.WriteLine(result);

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers)) return 0;

        var stringNumbers = numbers.Split(new[] { ",", "\n" }, StringSplitOptions.None);

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