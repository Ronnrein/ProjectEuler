using System;
using System.Collections.Generic;
using ProjectEuler.Framework;

namespace ProjectEuler.Problems {
    public class Problem10 : Problem {
        public string Name {
            get { return "Summation of primes"; }
        }

        public int Id {
            get { return 10; }
        }

        public void Run() {
            int max = Utils.GetInput<int>("Input the max prime number to sum");
            List<int> primes = Utils.GetAllPrimes(max);
            long result = 0;
            foreach (int prime in primes) {
                result += prime;
            }
            Console.WriteLine("The sum of all primes up until "+max+" is "+result);
        }

    }
}