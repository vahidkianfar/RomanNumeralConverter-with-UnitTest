namespace RomanNumeral;
using System.Text.RegularExpressions;

public class Conversion
{
    public Conversion(string userInput)
    {
        UserInput = userInput.ToUpper();
    }
    public string UserInput { get; set; }
    
    static readonly Dictionary<char, int> mappingCharacters = new()
    {   { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };
    public static int PrintNumber(string input)
    {
        if (RomanNumeralValidation(input.ToUpper()) && String.IsNullOrEmpty(input) == false)
        {
            return ExtractValue(input.ToUpper());
        }
        return 0;
    }
    
    public static bool RomanNumeralValidation(string input)
    {
        const string regularExpression = 
            "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        Regex checkByRegex = new Regex(regularExpression);
        return checkByRegex.IsMatch(input.ToUpper());
    }

    public static int ExtractValue(string input)
    {
        int sum = 0;
        for (int counter = 0; counter < input.Length; counter++)
        {
            if (counter + 1 < input.Length && mappingCharacters[input[counter]] < mappingCharacters[input[counter + 1]])
            {
                sum -= mappingCharacters[input[counter]];
            }
            else
            {
                sum += mappingCharacters[input[counter]];
            }
        }
        return sum;
    }
}