using System.Diagnostics.Metrics;
using System.Drawing;
using System.Threading.Channels;

namespace RomanNumeral;
using System.Text.RegularExpressions;

public class Conversion
{
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
            return ExtractValue(input.ToUpper());
        
        return 0;
    }
    
    public static bool RomanNumeralValidation(string input)
    {
        const string regularExpression =
            "^M{0,3}" + // Zero to Three occurrence of M
            "(CM|CD|D?C{0,3})" + // CM or CD or Zero to Three occurrence of D or C
            "(XC|XL|L?X{0,3})" + // XC or XL or Zero to Three occurrence of L or X
            "(IX|IV|V?I{0,3})$"; // IX or IV or Zero to Three occurrence of V or I
        var checkByRegex = new Regex(regularExpression);
        return checkByRegex.IsMatch(input.ToUpper());
    }

    public static int ExtractValue(string input)
    {
        int calculateNumber = 0;
        for (int counter = 0; counter < input.Length; counter++)
        {
            if (counter + 1 < input.Length && mappingCharacters[input[counter]] < mappingCharacters[input[counter + 1]])
                calculateNumber -= mappingCharacters[input[counter]];
            else
                calculateNumber += mappingCharacters[input[counter]];
        }
        return calculateNumber;
    }
    
   
    public static string ConvertToRomanNumeral(int input) 
    {
        //This Method Needs Some REFACTORING.
        string[] romans = {"I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M"};
        int[] value = {1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000};
        var index = romans.Length - 1;
        var romanResult = string.Empty;
        while(input>0)
        {
            while(value[index]<=input)
            {
                romanResult += romans[index];
                input -= value[index];
            }
            index--;
        }
        return romanResult;
    }
}