using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstNonRepeatingChar
{
    public class Program
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("Enter the Input String:-");
            string inputString = Console.ReadLine().Trim();
            String nonRepeating = GetFirstNonRepeatingChar(inputString);

           if(String.IsNullOrEmpty(nonRepeating))
           {
               Console.WriteLine("String has Either only Spaces OR NO non-Repeating characters");
           }

           Console.WriteLine(nonRepeating);
           Console.ReadLine();
        }

       public static String GetFirstNonRepeatingChar(String inputString)
       {
           bool isRepeating = false;

           if (String.IsNullOrWhiteSpace(inputString))
           {
               return null;
              
           }

           for (int i = 0; i < inputString.Length; i++)
           {

               isRepeating = false;

               for (int j = 0; j < inputString.Length; j++)
               {
                   if (i == j)
                       continue;
                   if (inputString[i].Equals(inputString[j]))
                       isRepeating = true;
               }

               if (isRepeating == false)
               {
                   Console.WriteLine("First Non-Repeating character:-");
                   return inputString[i].ToString();
               }

           }

           
               return null;
           
       }
    }
}
