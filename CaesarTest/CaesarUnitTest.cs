using NUnit.Framework;
using FluentAssertions;
using RomanNumeral;

namespace CaesarTest;

public class Tests
{
    private Conversion  conversionTest;
    
    [SetUp]
    public void Setup()
    {
        conversionTest = new Conversion("CaesarUnitTest");
    }

    [Test]
    public void PrintNumber_Should_Return_CorrectValue_For_Upper_RomanNumerals()
    {
        conversionTest.PrintNumber("MMXXII").Should().Be(2022);
        conversionTest.PrintNumber("MMMCMXCIX").Should().Be(3999);
        conversionTest.PrintNumber("I").Should().Be(1);
        conversionTest.PrintNumber("X").Should().Be(10);
        conversionTest.PrintNumber("DCCCLXXXVIII").Should().Be(888);
    }
    
    [Test]
    public void PrintNumber_Should_Return_CorrectValue_For_Lower_RomanNumerals()
    {
        conversionTest.PrintNumber("mmxxii").Should().Be(2022);
        conversionTest.PrintNumber("mmmcmxcix").Should().Be(3999);
        conversionTest.PrintNumber("i").Should().Be(1);
        conversionTest.PrintNumber("x").Should().Be(10);
    }
    
    [Test]
    public void PrintNumber_Should_Return_CorrectValue_For_Mixed_RomanNumerals()
    {
        conversionTest.PrintNumber("mMXiI").Should().Be(2012);
        conversionTest.PrintNumber("mMmCMxcix").Should().Be(3999);
        conversionTest.PrintNumber("DccXxix").Should().Be(729);
        conversionTest.PrintNumber("DCcClXxXViii").Should().Be(888);
        
    }
    
    [Test]
    public void PrintNumber_Should_Return_ZERO_For_Wrong_RomanNumerals()
    {
        conversionTest.PrintNumber("MMIIXX").Should().Be(0);
        conversionTest.PrintNumber("mmiixx").Should().Be(0);
        conversionTest.PrintNumber("VIIIV").Should().Be(0);
        conversionTest.PrintNumber("iiiiiii").Should().Be(0);
    }
    
    [Test]
    public void PrintNumber_Should_Return_CorrectValue_For_Upper_RomanNumerals_With_Subtraction()
    {
        conversionTest.PrintNumber("MMXXII-MMXXII").Should().Be(0);
        conversionTest.PrintNumber("MMMCMXCIX-MMMCMXCIX").Should().Be(0);
        conversionTest.PrintNumber("I-I").Should().Be(0);
        conversionTest.PrintNumber("X-X").Should().Be(0);
    }
    
    [Test]
    public void PrintNumber_Should_Return_CorrectValue_For_Lower_RomanNumerals_With_Subtraction()
    {
        conversionTest.PrintNumber("mmxxii-mmxxii").Should().Be(0);
        conversionTest.PrintNumber("mmmcmxcix-mmmcmxcix").Should().Be(0);
        conversionTest.PrintNumber("i-i").Should().Be(0);
        conversionTest.PrintNumber("x-x").Should().Be(0);
    }
    [Test]
    public void PrintNumber_Should_Return_ZERO_For_Wrong_Input()
    {
        
        conversionTest.PrintNumber("").Should().Be(0);
        conversionTest.PrintNumber("@#__").Should().Be(0);
        conversionTest.PrintNumber("VC!@$#").Should().Be(0);
        conversionTest.PrintNumber("hello").Should().Be(0);
        conversionTest.PrintNumber("EXIT").Should().Be(0);
        conversionTest.PrintNumber("exit").Should().Be(0);
    }
    
    [Test]
    public void ExtractValue_Should_Return_CorrectValue_For_RomanNumerals()
    {
        conversionTest.ExtractValue("MMXXII").Should().Be(2022);
        conversionTest.ExtractValue("MMMCMXCIX").Should().Be(3999);
        conversionTest.ExtractValue("I").Should().Be(1);
        conversionTest.ExtractValue("X").Should().Be(10);
        conversionTest.ExtractValue("DCCCLXXXVIII").Should().Be(888);
    }

    [Test]
    public void RomanNumeralValidation_Should_Return_TRUE_For_Valid_MIXED_RomanNumeral()
    {
        conversionTest.RomanNumeralValidation("MiX").Should().Be(true);
        conversionTest.RomanNumeralValidation("MIX").Should().Be(true);
        conversionTest.RomanNumeralValidation("I").Should().Be(true);
        conversionTest.RomanNumeralValidation("II").Should().Be(true);
        conversionTest.RomanNumeralValidation("MmXxII").Should().Be(true);
        conversionTest.RomanNumeralValidation("viii").Should().Be(true);
    }
    [Test]
    public void RomanNumeralValidation_Should_Return_FALSE_For_inValid_MIXED_RomanNumeral()
    {
        conversionTest.RomanNumeralValidation("MiiIiX").Should().Be(false);
        conversionTest.RomanNumeralValidation("vvMIX").Should().Be(false);
        conversionTest.RomanNumeralValidation("Ib").Should().Be(false);
        conversionTest.RomanNumeralValidation("IyyI").Should().Be(false);
        conversionTest.RomanNumeralValidation("MccccmXxII").Should().Be(false);
        conversionTest.RomanNumeralValidation("viIii").Should().Be(false);
    }
}