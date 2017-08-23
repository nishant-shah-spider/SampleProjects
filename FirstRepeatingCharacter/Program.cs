using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstNonRepeatingChar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Input String:-");
            string inputString = Console.ReadLine().Trim();
            
            bool isRepeating = false;

            if (String.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Please avoid entering only spaces or keeping the input string blank");
                
            }

            for(int i=0;i<inputString.Length;i++)
            {
                
                isRepeating = false;

                for(int j=0;j<inputString.Length;j++)
                {
                    if (i == j)
                        continue;
                    if (inputString[i].Equals(inputString[j]))
                        isRepeating = true;
                }

                if(isRepeating==false)
                {
                    Console.WriteLine("First Non-Repeating character:-" + inputString[i]);
                    break;
                }

            }

            if (isRepeating == true)
                Console.WriteLine("Sorry..There are no Non-Repeating characters here");
            Console.WriteLine("Press Enter to Quit");
            Console.ReadLine();
        }
    }
}
