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
    { { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };
    public bool RomanNumeralValidation(string userInput)
    {
        const string regularExpression = 
            "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        Regex checkByRegex = new Regex(regularExpression);
        return checkByRegex.IsMatch(userInput.ToUpper());
    }

    public int ExtractValue(string userInput)
    { 
        int sum = 0;
        int counter = 0;
        while (counter < userInput.Length)
        {
            int firstRomanChar  = mappingCharacters
                .Where(x => x.Key == userInput.ToUpper().ToCharArray()[counter])
                .Select(x => x.Value)
                .FirstOrDefault();
            if (counter + 1 < userInput.Length)
            {
                int secondRomanChar = mappingCharacters
                    .Where(x => x.Key == userInput.ToUpper().ToCharArray()[counter+1])
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
    
    public int PrintNumber(string userInput)
    {
        userInput = userInput.ToUpper();
        if (RomanNumeralValidation(userInput) && String.IsNullOrEmpty(userInput) == false)
        {
            return ExtractValue(userInput);
        }
        return 0;
    }
}
