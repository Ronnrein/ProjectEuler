using System;
using System.Linq;
using ProjectEuler.Framework;

namespace ProjectEuler.Problems {
    public class Problem2 : IProblem{
        public string Name {
            get { return "Even Fibonacci numbers"; }
        }

        public int Id {
            get { return 2; }
        }

        public void Run() {
            int max = Utils.GetInput<int>("Enter max fibonacci number");
            int sum = MathUtils.Fibonacci(4000000).Where(n => !MathUtils.IsOdd(n)).Sum();
            Console.WriteLine("Sum of all even fibonacci numbers below "+max+" is "+sum);
        }
    }
}