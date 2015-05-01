using System;
using System.Globalization;

namespace ProjectEuler.Problems
{
    public class Problem5 : Problem {
        public string Name {
            get { return "Smallest multiple"; }
        }

        public int Id {
            get { return 5; }
        }

        public void Run() {
            while (true) {
                int num1 = 0;
                int num2 = 0;
                Console.WriteLine("Enter minimum number");
                bool num1Success = Int32.TryParse(Console.ReadLine(), out num1);
                Console.WriteLine("Enter maximum number");
                bool num2Success = Int32.TryParse(Console.ReadLine(), out num2);
                if (num1Success && num2Success) {
                    if (num1 == 0 || num2 == 0) {
                        Console.WriteLine("Numbers has to be above 0, try again");
                    } 
                    else if (num1 >= num2) {
                        Console.WriteLine("Second number has to be higher than first number");
                    }
                    else {
                        int result = SmallestMultiple(num1, num2);
                        Console.WriteLine("The smallest multiple of "+num1+" and "+num2+" is " + result);
                        return;
                    }
                }
                
            }
            
        }

        private int SmallestMultiple(int min, int max) {
            int i = 0;
            while (true) {
                i++;
                bool success = true;
                for (int j = min; j <= max; j++) {
                    if (i%j != 0) {
                        success = false;
                        break;
                    }
                }
                if (!success) {
                    continue;
                }
                return i;
            }
        }
    }
}