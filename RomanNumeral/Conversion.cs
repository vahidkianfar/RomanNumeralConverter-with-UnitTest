using System.Data;

namespace RomanNumeral;
using System.Text.RegularExpressions;

public class Conversion
{
    static readonly Dictionary<char, int> MappingCharacters = new()
    {   { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };
    private static readonly string[] Romans = {"I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M"};
    private static readonly int[] Value = {1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000};
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
            if (counter + 1 < input.Length && MappingCharacters[input[counter]] < MappingCharacters[input[counter + 1]])
                calculateNumber -= MappingCharacters[input[counter]];
            else
                calculateNumber += MappingCharacters[input[counter]];
        }
        return calculateNumber;
    }
    
    public static string ConvertToRomanNumeral(int input) 
    {
        //This Method Needs Some REFACTORING.
        if (input is <= 0 or > 3999) throw new InvalidConstraintException();
        var index = Romans.Length - 1;
        var romanResult = string.Empty;
        while(input>0)
        {
            while(Value[index]<=input)
            {
                romanResult += Romans[index];
                input -= Value[index];
            }
            index--;
        }
        return romanResult;
    }
}