using System;
using ProjectEuler.Framework;
using ProjectEuler.Framework.InputArguments;

namespace ProjectEuler.Problems {
    public class Problem7 : IProblem{
        public string Name {
            get { return "10001st prime"; }
        }

        public int Id {
            get { return 7; }
        }

        public void Run() {
            int num = Utils.GetInput("Enter Nth prime number to find", new InputArguments.LargerThan<int>(0));
            int prime = MathUtils.GetPrime(num);
            Console.WriteLine("The "+Utils.AddOrdinal(num)+" prime number is "+prime);
        }
    }
}