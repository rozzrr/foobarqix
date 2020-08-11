using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace FooBarQix
{
    public enum AppendTypes
    {
        Foo, Bar, Qix
    }
    public class NumberRulesHelper
    {

        public string displayString(long number)
        {
            //amended string to be displayed - initalise to empty
            string returnString = string.Empty;
            bool isAnyDivisable = false;

            //business rule added, bool flags presence of 0 in provided number
            bool containsZero = false;

            int zeroCount = 0;

            if (number.ToString().Contains("0"))
            {
                containsZero = true;
            }

            //block to filter number to check if divisible by 3,5,7 to append string output

            if (containsZero)
            {
                //createCountOfZeros
                zeroCount = number.ToString().Count(z => (z == '0'));
            }


            if (IsDivisable(number, 3))
            {
                returnString += AppendTypes.Foo;
                isAnyDivisable = true;
            }
            if (IsDivisable(number, 5))
            {
                returnString += AppendTypes.Bar;
                isAnyDivisable = true;
            }
            if (IsDivisable(number, 7))
            {
                returnString += AppendTypes.Qix;
                isAnyDivisable = true;
            }

            //trace 0
            if (returnString.Contains("0"))
            {
                returnString.Replace("0", "*");
            }

            if (!isAnyDivisable)
            {
                //as return string empty we can use the number as a string as no manipulation occured as of yet.
                var replacedDisplay = number.ToString().Replace('0', '*');
                //replacedDisplay = DigitIncludedInString(replacedDisplay);

                //go and find if the number provided contains a char 3,5,7
                var replacedDisplayNumber = ContainsNumber(number.ToString());
                if (replacedDisplayNumber != string.Empty)
                {
                    return replacedDisplayNumber;
                }

                return replacedDisplay;


            }

            //append the zero trace to the string to be displayed 
            if (zeroCount > 0)
            {
                for (int i = 0; i < zeroCount; i++)
                {
                    returnString += "*";
                }
            }

            if (isAnyDivisable)
            {
                //append to the end of the string if any 3,5,7 are in the input number
                returnString += ContainsNumber(number.ToString());
            }
            return returnString;
        }


        //method which calculates if the number provided includes a 3,5,7. append string if so.
        public string ContainsNumber(string number)
        {
            char[] n = number.ToString().ToCharArray();
            string returnStringtoDisplay = string.Empty;

            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] == '3')
                {
                    returnStringtoDisplay += AppendTypes.Foo;
                }
                else if (n[i] == '5')
                {
                    returnStringtoDisplay += AppendTypes.Bar;
                }
                else if (n[i] == '7')
                {
                    returnStringtoDisplay += AppendTypes.Qix;
                }
            }

            return returnStringtoDisplay;
        }

        public bool IsDivisable(long number, int divider)
        {
            try
            {
                return number % divider == 0;
            }
            catch (Exception)
            {

                return false;
            }

        }

    }

}
