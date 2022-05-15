namespace RomanNumeral;
using System.Text.RegularExpressions;
using System.Linq;

public class Conversion
{
    public Conversion(string userInput)
    {
        UserInput = userInput.ToUpper();
    }
    public string UserInput { get; set; }
    
    readonly Dictionary<char, int> mappingCharacters = new()
    {   { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };
    public int PrintNumber(string input)
    {
        if (RomanNumeralValidation(input.ToUpper()) && String.IsNullOrEmpty(input) == false)
        {
            return ExtractValue(input.ToUpper());
        }
        return 0;
    }
    public bool RomanNumeralValidation(string input)
    {
        const string regularExpression = 
            "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        Regex checkByRegex = new Regex(regularExpression);
        return checkByRegex.IsMatch(input.ToUpper());
    }

    public int ExtractValue(string input)
    { 
        int sum = 0;
        int counter = 0;
        while (counter < input.Length)
        {
            int firstRomanChar  = mappingCharacters
                .Where(x => x.Key == input.ToUpper().ToCharArray()[counter])
                .Select(x => x.Value)
                .FirstOrDefault();
            if (counter + 1 < input.Length)
            {
                int secondRomanChar = mappingCharacters
                    .Where(x => x.Key == input.ToUpper().ToCharArray()[counter+1])
                    .Select(x => x.Value)
                    .FirstOrDefault();
                if (firstRomanChar >= secondRomanChar)
                {
                    sum += firstRomanChar;
                    counter++;
                }
                else
                {
                    sum += secondRomanChar - firstRomanChar;
                    counter += 2;
                }
            }
            else
            {
                sum += firstRomanChar;
                counter++;
            }
        }
        return sum;
    }
}