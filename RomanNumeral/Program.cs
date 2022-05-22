using System;
using RomanNumeral;

while (true)
{
    Console.Write("\nEnter a Roman Numeral (type \"exit\" to quit):");
    var userInput = Console.ReadLine()!.ToUpper();
    if (userInput == "EXIT") Environment.Exit(0);
    if (Conversion.PrintNumber(userInput)==0) 
        Console.WriteLine("\nInvalid Roman Numeral, Please Try Again!");
    else 
        Console.WriteLine("\n----> The number is: {0}", Conversion.PrintNumber(userInput));
}