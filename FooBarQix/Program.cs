using System;

namespace FooBarQix
{
    class Program
    {
        static void Main(string[] args)
        {
            //simple menu
            bool KeepGoing = true;
            while (KeepGoing)
            {
                KeepGoing = MainOperation();
            }

        }

        private static bool MainOperation()
        {
            try
            {
                Console.WriteLine("Enter Number");
                var numberInputted = Convert.ToInt64(Console.ReadLine());
                if (numberInputted == 0 || numberInputted < 0)
                {
                    Console.WriteLine("Enter a value larger than 0");
                    return true;
                }
                else
                {
                    var displayString = Compute(numberInputted);
                    Console.WriteLine(displayString);
                    Console.WriteLine("Retry? Y/N");
                    var carryOn = UserChoice();
                    return carryOn;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Program Failure : {ex.Message}");
                Console.WriteLine("Continue and try again? Y/N");
                var carryOn = UserChoice();
                return carryOn;
            }
        }

        static string Compute(long inputNumber)
        {
            var numberHelper = new NumberRulesHelper();
            var returnedString = numberHelper.displayString(inputNumber);
            return returnedString;
        }

        //user message block
        static bool UserChoice()
        {
            // Console.WriteLine("Retry? Y/N");
            var carryOnWithProgram = Console.ReadKey();
            if (carryOnWithProgram.Key == ConsoleKey.Y || carryOnWithProgram.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
