using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems {
    public class Problem9 : Problem {
        public string Name {
            get { return "Special Pythagorean triplet"; }
        }

        public int Id {
            get { return 9; }
        }

        public void Run() {
            while (true) {
                int target = 0;
                Console.WriteLine("Input the target triplet sum");
                bool targetResult = Int32.TryParse(Console.ReadLine(), out target);
                if (targetResult) {
                    double result = PythagoreanTripletProduct(target);
                    if (result == -1) {
                        Console.WriteLine("No triplets found for sum "+target);
                    }
                    else {
                        Console.WriteLine("The product of the triplet is " + result);
                    }
                    return;
                }
                else {
                    Console.WriteLine("Parsing error, try again, using only numbers");
                }
            }
        }

        private long PythagoreanTripletProduct(int target) {
            List<int> results = new List<int>();
            List<int> seconds = new List<int>();
            long result = -1;
            for (int a = 1; a < target; a++) {
                if (result != -1) {
                    break;
                }
                for (int b = a; b < target; b++) {
                    double c = (a*a) + (b*b);
                    double cSqrd = Math.Sqrt(c);
                    if (cSqrd%1 == 0) {
                        if (cSqrd > target || ((cSqrd/2)%1 == 0 && results.Contains((int) cSqrd/2)) || seconds.Contains(b) || (a%2==0 && b%2==0)) {
                            continue;
                        }
                        results.Add((int)cSqrd);
                        seconds.Add(b);
                        long sum = (long)(a + b + cSqrd);
                        if (sum == target) {
                            result = (long)(a * b * cSqrd);
                        }
                        break;
                    }
                }
            }
            return result;
        }
    }
}