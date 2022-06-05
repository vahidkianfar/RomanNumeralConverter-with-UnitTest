using System.Data;
namespace RomanNumeral;

public class ArabicToRoman
{
    private static readonly string[] Romans = {"I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M"};
    private static readonly int[] Value = {1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000};
    public static string ConvertToRomanNumeral(int input) 
    {
        //This Method needs some REFACTORING.
        if (input is <= 0 or > 3999) throw new ArgumentException
        {
            HelpLink = null,
            HResult = 0,
            Source = null
        };
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