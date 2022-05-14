namespace RomanNumeral;
using System.Text.RegularExpressions;

public class Conversion
{
    public Conversion(string userInput)
    {
        UserInput = userInput.ToUpper();
    }
    public string UserInput { get; set; }
    public bool RomanNumeralValidation(string UserInput)
    {
        const string regularExpression = "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        Regex checkByRegex = new Regex(regularExpression);
        return checkByRegex.IsMatch(UserInput.ToUpper());
    }
    
    public int ConvertToTenBase(char romanChar)
    {
        char upperRomanChar = Char.ToUpper(romanChar);
        if (upperRomanChar == 'I') return 1;
        if (upperRomanChar == 'V') return 5;
        if (upperRomanChar == 'X') return 10;
        if (upperRomanChar == 'L') return 50;
        if (upperRomanChar == 'C') return 100;
        if (upperRomanChar == 'D') return 500;
        if (upperRomanChar == 'M') return 1000;
        return 0;
    }

    public int ExtractValue(string UserInput)
    { //I'm Working on a better Method, this is just a quick fix.
        int result = 0;
        int i = 0;
        while (i < UserInput.Length)
        {
            int firstTemp = ConvertToTenBase(UserInput[i]);
            if (i + 1 < UserInput.Length)
            {
                int secondTemp = ConvertToTenBase(UserInput[i + 1]);
                if (firstTemp >= secondTemp)
                {
                    result += firstTemp;
                    i++;
                }
                else
                {
                    result = result + secondTemp - firstTemp;
                    i += 2;
                }
            }
            else
            {
                result += firstTemp;
                i++;
            }
        }
        return result;
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
