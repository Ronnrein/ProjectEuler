using System;
using ProjectEuler.Framework;

namespace ProjectEuler.Problems {
    class Problem12 : Problem {
        public string Name {
            get { return "Highly divisible triangular number"; }
        }

        public int Id {
            get { return 12; }
        }

        public void Run() {
            int input = Utils.GetInput<int>("How many divisors should be searched for");
            int i = 1;
            while (true) {
                int tri = Utils.TriangularNumber(i);
                int divisors = Utils.GetAllDivisors(tri).Count;
                if (divisors > input) {
                    Console.WriteLine("The "+Utils.AddOrdinal(i)+" triangular number ("+tri+") has "+divisors+" divisors");
                    return;
                }
                i++;
            }
        }

        
    }
}
