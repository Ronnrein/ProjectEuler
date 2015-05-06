using System;
using ProjectEuler.Framework;

namespace ProjectEuler.Problems {
    public class Problem6 : IProblem {
        public string Name {
            get { return "Sum square difference"; }
        }

        public int Id {
            get { return 6; }
        }

        public void Run() {
            while (true) {
                int num = 0;
                Console.WriteLine("Enter how many numbers to be squared");
                if (Int32.TryParse(Console.ReadLine(), out num)) {
                    if (num <= 1) {
                        Console.WriteLine("Has to be above 1");
                    }
                    else {
                        int result = SumSquareDifference(num);
                        Console.WriteLine("The sum of square difference with "+num+" natural numbers is "+result);
                        return;
                    }
                }
                
            }
        }

        private int SumSquareDifference(int nums) {
            int sumSquares = 0;
            int squareSum = 0;
            for (int i = 1; i <= nums; i++) {
                sumSquares += i*i;
                squareSum += i;
            }
            squareSum = squareSum*squareSum;
            Console.WriteLine(Program.workingPrefix+"Sum of squares is "+sumSquares);
            Console.WriteLine(Program.workingPrefix+"Square of sum is "+squareSum);
            return squareSum - sumSquares;
        }
    }
}