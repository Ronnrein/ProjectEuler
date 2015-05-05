using System;
using ProjectEuler.Framework;

namespace ProjectEuler.Problems {
    public class Problem4 : Problem{
        public string Name {
            get { return "Largest palindrome product"; }
        }

        public int Id {
            get { return 4; }
        }

        public void Run() {
            int digits = Utils.GetInput<int>("Enter number of digits to search for");
            int numbers = Utils.GetInput<int>("Enter how many "+digits+"-digit numbers to search for");
            int result = MathUtils.LargestPalindromeProduct(digits, numbers);
            Console.WriteLine("The largest palindrome made from the product of "+numbers+" "+digits+"-digit numbers is "+result);
        }
    }
}