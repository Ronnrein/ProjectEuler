using System;
using System.Collections.Generic;
using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem9 : EulerProblem {

        [Description("Input the target triplet sum")]
        public int target;

        public override string Name {
            get { return "Special Pythagorean triplet"; }
        }

        public override int Id {
            get { return 9; }
        }

        public override string Run() {
            double result = PythagoreanTripletProduct(target);
            return result != -1 ? "The product of the triplet is " + result : "No triplets found for sum " + target;
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