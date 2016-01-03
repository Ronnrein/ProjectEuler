using System.Collections.Generic;
using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem10 : EulerProblem {

        [Description("Input the max prime number to sum")]
        public int max;

        public override string Name {
            get { return "Summation of primes"; }
        }

        public override int Id {
            get { return 10; }
        }

        public override string Run() {
            List<int> primes = MathUtils.GetAllPrimes(max);
            long result = 0;
            foreach (int prime in primes) {
                result += prime;
            }
            return "The sum of all primes up until "+max+" is "+result;
        }

    }
}