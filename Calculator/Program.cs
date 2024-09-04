
Calculator Calculator = new Calculator();
int result = Calculator.Add("//[*][!!][r9r]\n11r9r22*hh*33!!44");
Console.WriteLine(result);

public class Calculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers)) return 0;

        var delimiters = new List<string> { ",", "\n" };
        if (numbers.StartsWith("//"))
        {
            var endOfDelimiters = numbers.IndexOf("\n");
            var delimitersContent = numbers.Substring(2, endOfDelimiters - 2);
            var matches = System.Text.RegularExpressions.Regex.Matches(delimitersContent, @"\[(.*?)\]");
            foreach (var match in matches)
            {
                delimiters.Add(match.ToString().Trim('[', ']'));
            }
            numbers = numbers.Substring(endOfDelimiters + 1);
        }

        var stringNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);

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