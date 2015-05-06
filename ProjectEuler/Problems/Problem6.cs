using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Framework;
using ProjectEuler.Framework.InputArguments;

namespace ProjectEuler.Problems {
    public class Problem6 : IProblem {
        public string Name {
            get { return "Sum square difference"; }
        }

        public int Id {
            get { return 6; }
        }

        public void Run() {
            int num = Utils.GetInput("Enter how many numbers to be squared", new InputArguments.LargerThan<int>(1));
            int[] nums = Enumerable.Range(1, num).ToArray();
            int squareOfSum = nums.Sum()*nums.Sum();
            int sumOfSquares = nums.Select(n => n*n).Sum();
            int diff = squareOfSum - sumOfSquares;
            Console.WriteLine("The sum of square difference with "+num+" natural numbers is "+diff);
        }
    }
}