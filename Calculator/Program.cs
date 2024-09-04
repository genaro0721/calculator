
Calculator Calculator = new Calculator();
int result = Calculator.Add("1,2,3,4,5,6,7,8,9,10,11,12");
Console.WriteLine(result);

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers)) return 0;

        var stringNumbers = numbers.Split(",");

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