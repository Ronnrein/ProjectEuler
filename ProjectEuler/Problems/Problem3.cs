using System;
using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Framework;

namespace ProjectEuler.Problems {
    public class Problem3 : Problem{
        public string Name {
            get { return "Name of problem"; }
        }

        public int Id {
            get { return 3; }
        }

        public void Run() {
            long num = Utils.GetInput<long>("Enter number to get largest prime factor of");
            int result = MathUtils.GetAllPrimeFactors(num).Max();
            Console.WriteLine("Largest prime factor of "+num+" is "+result);
        }
    }
}