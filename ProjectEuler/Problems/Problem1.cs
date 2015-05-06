using System;
using System.Linq;
using ProjectEuler.Framework;

namespace ProjectEuler.Problems {
    public class Problem1 : IProblem{
        public string Name {
            get { return "Multiples of 3 and 5"; }
        }

        public int Id {
            get { return 1; }
        }

        public void Run() {
            int num1 = Utils.GetInput<int>("Enter first multiple");
            int num2 = Utils.GetInput<int>("Enter second multiple");
            int max = Utils.GetInput<int>("Enter max number");
            int result = MathUtils.GetAllMultiples(num1, max).Sum() + MathUtils.GetAllMultiples(num2, max).Sum() - MathUtils.GetAllMultiples(num1 * num2, max).Sum();
            Console.WriteLine("The sum of all multiples of "+num1+" and "+num2+" under "+max+" is "+result);
        }
    }
}