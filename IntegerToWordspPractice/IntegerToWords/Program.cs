using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = -1987;
            string word = ConvertNumberToWords(number);
            Console.WriteLine(word);

            Console.ReadKey();
        }

        //Method to convert Number to words
        static String ConvertNumberToWords(int number)
        {
            //variable declaration.

            string sign = "";
            string result;
            Dictionary<int, String> ones = new Dictionary<int, string>
            {
                {0,""},
                {1,"One"},
                {2,"Two"},
                {3,"Three"},
                {4,"Four"},
                {5,"Five"},
                {6,"Six"},
                {7,"Seven"},
                {8,"Eight"},
                {9,"Nine"}
            };

            Dictionary<int, String> teens = new Dictionary<int, string>
            {
                {10,"Ten"},
                {11,"Eleven"},
                {12,"Twelve"},
                {13,"Thirteen"},
                {14,"Fourteen"},
                {15,"Fiftenn"},
                {16,"Sixteen"},
                {17,"Seventeen"},
                {18,"Eigthteen"},
                {19,"Nineteen"}
            };

            Dictionary<int, String> tens = new Dictionary<int, string>
            {
                {2,"Twenty"},
                {3,"Thirty"},
                {4,"Forty"},
                {5,"Fifty"},
                {6,"Sixty"},
                {7,"Seventy"},
                {8,"Eighty"},
                {9,"Ninety"}
            };

            try
            {
                if(number < -9999 || number > 9999)
                {
                    return "The number is not within the acceptable range.";
                }
                if (number == 0)
                {
                    return "Zero";
                }

                if(number < 0)
                {
                    sign = "Minus ";
                    number = Math.Abs(number);
                }

                if(number < 10)
                {
                    return sign + ones[number];
                }
                else if (number < 20)
                {
                    return sign + teens[number];
                }
                else if(number < 100)
                {
                    result = sign + tens[number/10];
                    if(number % 10 != 0)
                    { 
                        result += " "+ ConvertNumberToWords(number%10);
                    }
                    return result;
                    
                }
                else if (number < 1000)
                {
                    result = sign + ones[number / 100] + " Hundred";

                    if(number % 100 != 0)
                    {
                        result += " and " + ConvertNumberToWords(number % 100);
                    }
                    return result;
                }
                else if (number < 10000)
                {
                    result = sign + ones[number / 1000] + " Thousand";

                    if (number % 1000 != 0)
                    {
                        result += ", " + ConvertNumberToWords(number % 1000);
                    }
                    return result;
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            return null;
        }
    }
}
