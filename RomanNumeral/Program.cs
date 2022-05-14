using RomanNumeral;

while (true)
{
    Console.Write("\nEnter a Roman Numeral (type \"exit\" to quit):"); 
    var userInput = Console.ReadLine().ToUpper();
    var convert = new Conversion(userInput);
    if (userInput == "EXIT") Environment.Exit(0);
    else if (convert.PrintNumber(userInput)==0) 
        Console.WriteLine("\nInvalid Roman Numeral, Please Try Again!");
    else 
        Console.WriteLine("\n----> The number is {0}", convert.PrintNumber(userInput));
}





