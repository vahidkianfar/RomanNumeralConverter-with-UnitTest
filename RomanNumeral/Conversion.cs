﻿namespace RomanNumeral;
using System.Text.RegularExpressions;

public class Conversion
{
    public string UserInput { get; set; }

    public Conversion(string userInput)
    {
        UserInput = userInput.ToUpper();
    }
    
    public bool RomanNumeralValidation(string userInput)
    {
        userInput=userInput.ToUpper();
        const string regularExpression = "^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        Regex checkByRegex = new Regex(regularExpression);
        return checkByRegex.IsMatch(userInput);
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

    public int ExtractValue(string userInput)
    {
        userInput=userInput.ToUpper();
        if (!RomanNumeralValidation(userInput)) return 0;
        int result = 0;
        int i = 0;
        while (i < userInput.Length)
        {
            int firstTemp = ConvertToTenBase(userInput[i]);
            if (i + 1 < userInput.Length)
            {
                int secondTemp = ConvertToTenBase(userInput[i + 1]);
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
        string upperInput = userInput.ToUpper();
        if (RomanNumeralValidation(upperInput) && String.IsNullOrEmpty(upperInput) == false)
        {
            return ExtractValue(upperInput);
        }
        return 0;
    }
}