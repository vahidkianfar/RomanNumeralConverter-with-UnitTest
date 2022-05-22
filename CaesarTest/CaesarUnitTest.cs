using System;
using System.Data;
using System.Threading.Channels;
using NUnit.Framework;
using FluentAssertions;
using RomanNumeral;

namespace CaesarTest;

public class Tests
{
    [SetUp]
    public void Setup() { }
    [Test]
    public void ConvertToRomanNumeral_Should_Return_CorrectValue()
    {
         TenBaseToRoman.ConvertToRomanNumeral(9).Should().Be("IX");
         TenBaseToRoman.ConvertToRomanNumeral(2022).Should().Be("MMXXII");
         TenBaseToRoman.ConvertToRomanNumeral(888).Should().Be("DCCCLXXXVIII");
         TenBaseToRoman.ConvertToRomanNumeral(3000).Should().Be("MMM");
         TenBaseToRoman.ConvertToRomanNumeral(419).Should().Be("CDXIX");
         TenBaseToRoman.ConvertToRomanNumeral(3999).Should().Be("MMMCMXCIX");
    }
    [Test]
    public void ConvertToRomanNumeral_Should_Throws_Exception_For_Invalid_Integer()
    {
        //Valid integer to roman numeral is in range (1,3999)
        Assert.Throws<ArgumentException>(() => TenBaseToRoman.ConvertToRomanNumeral(4000));
        Assert.Throws<ArgumentException>(() => TenBaseToRoman.ConvertToRomanNumeral(0));
        Assert.Throws<ArgumentException>(() => TenBaseToRoman.ConvertToRomanNumeral(-10));
    }
    [Test]
    public void ExtractValue_Should_Throw_Exception_For_Input_That_Doesnt_Exist_In_Dictionary()
    {
        Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => Conversion.ExtractValue("bf"));
        
        //LowerCase of 'I' doesn't exist in Dictionary
        Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => Conversion.ExtractValue("i")); 
    }
    
    [Test]
    public void ExtractValue_Should_Throw_Exception_For_Attempting_To_Dereference_Null_Object()
    {
        Assert.Throws<NullReferenceException>(() => Conversion.ExtractValue(null));
    }
    
    [Test]
    public void ExtractValue_Should_Return_CorrectValue_For_RomanNumerals()
    {
        Conversion.ExtractValue("MMXXII").Should().Be(2022);
        Conversion.ExtractValue("MMMCMXCIX").Should().Be(3999);
        Conversion.ExtractValue("I").Should().Be(1);
        Conversion.ExtractValue("X").Should().Be(10);
        Conversion.ExtractValue("DCCCLXXXVIII").Should().Be(888);
    }
    
    [Test]
    public void PrintNumber_Should_Throw_Exception_For_Attempting_To_Dereference_Null_Object()
    {
        Assert.Throws<NullReferenceException>(() => Conversion.PrintNumber(null));
    }

    [Test]
    public void PrintNumber_Should_Return_CorrectValue_For_Upper_RomanNumerals()
    {
        Conversion.PrintNumber("MMXXII").Should().Be(2022);
        Conversion.PrintNumber("MMMCMXCIX").Should().Be(3999);
        Conversion.PrintNumber("I").Should().Be(1);
        Conversion.PrintNumber("X").Should().Be(10);
        Conversion.PrintNumber("DCCCLXXXVIII").Should().Be(888);
    }
    
    [Test]
    public void PrintNumber_Should_Return_CorrectValue_For_Lower_RomanNumerals()
    {
        Conversion.PrintNumber("mmxxii").Should().Be(2022);
        Conversion.PrintNumber("mmmcmxcix").Should().Be(3999);
        Conversion.PrintNumber("i").Should().Be(1);
        Conversion.PrintNumber("x").Should().Be(10);
    }
    
    [Test]
    public void PrintNumber_Should_Return_CorrectValue_For_Mixed_RomanNumerals()
    {
        Conversion.PrintNumber("mMXiI").Should().Be(2012);
        Conversion.PrintNumber("mMmCMxcix").Should().Be(3999);
        Conversion.PrintNumber("DccXxix").Should().Be(729);
        Conversion.PrintNumber("DCcClXxXViii").Should().Be(888);
    }
    
    [Test]
    public void PrintNumber_Should_Return_ZERO_For_Wrong_RomanNumerals()
    {
        Conversion.PrintNumber("MMIIXX").Should().Be(0);
        Conversion.PrintNumber("mmiixx").Should().Be(0);
        Conversion.PrintNumber("VIIIV").Should().Be(0);
        Conversion.PrintNumber("iiiiiii").Should().Be(0);
    }
    
    [Test]
    public void PrintNumber_Should_Return_CorrectValue_For_Upper_RomanNumerals_With_Subtraction()
    {
        Conversion.PrintNumber("MMXXII-MMXXII").Should().Be(0);
        Conversion.PrintNumber("MMMCMXCIX-MMMCMXCIX").Should().Be(0);
        Conversion.PrintNumber("I-I").Should().Be(0);
        Conversion.PrintNumber("X-X").Should().Be(0);
    }
    
    [Test]
    public void PrintNumber_Should_Return_CorrectValue_For_Lower_RomanNumerals_With_Subtraction()
    {
        Conversion.PrintNumber("mmxxii-mmxxii").Should().Be(0);
        Conversion.PrintNumber("mmmcmxcix-mmmcmxcix").Should().Be(0);
        Conversion.PrintNumber("i-i").Should().Be(0);
        Conversion.PrintNumber("x-x").Should().Be(0);
    }
    
    [Test]
    public void PrintNumber_Should_Return_ZERO_For_Wrong_Input()
    {
        
        Conversion.PrintNumber("").Should().Be(0);
        Conversion.PrintNumber("@#__").Should().Be(0);
        Conversion.PrintNumber("VC!@$#").Should().Be(0);
        Conversion.PrintNumber("hello").Should().Be(0);
        Conversion.PrintNumber("EXIT").Should().Be(0);
        Conversion.PrintNumber("exit").Should().Be(0);
    }

    [Test]
    public void RomanNumeralValidation_Should_Throw_Exception_For_Attempting_To_Dereference_Null_Object()
    {
        Assert.Throws<NullReferenceException>(() => Conversion.RomanNumeralValidation(null));
    }
    
    [Test]
    public void RomanNumeralValidation_Should_Return_TRUE_For_Valid_MIXED_RomanNumeral()
    {
        Conversion.RomanNumeralValidation("MiX").Should().Be(true);
        Conversion.RomanNumeralValidation("MIX").Should().Be(true);
        Conversion.RomanNumeralValidation("I").Should().Be(true);
        Conversion.RomanNumeralValidation("II").Should().Be(true);
        Conversion.RomanNumeralValidation("MmXxII").Should().Be(true);
        Conversion.RomanNumeralValidation("viii").Should().Be(true);
    }
    [Test]
    
    public void RomanNumeralValidation_Should_Return_FALSE_For_inValid_MIXED_RomanNumeral()
    {
        Conversion.RomanNumeralValidation("MiiIiX").Should().Be(false);
        Conversion.RomanNumeralValidation("vvMIX").Should().Be(false);
        Conversion.RomanNumeralValidation("IiiiiII").Should().Be(false);
        Conversion.RomanNumeralValidation("MccccmXxII").Should().Be(false);
        Conversion.RomanNumeralValidation("viIii").Should().Be(false);
    }
    
    [Test]
    public void RomanNumeralValidation_Should_Return_FALSE_For_inValid_Input()
    {
        Conversion.RomanNumeralValidation("123").Should().Be(false);
        Conversion.RomanNumeralValidation("Hi!").Should().Be(false);
        Conversion.RomanNumeralValidation("__@#").Should().Be(false);
        Conversion.RomanNumeralValidation("Injection!").Should().Be(false);
        Conversion.RomanNumeralValidation("()*").Should().Be(false);
    }
    
}