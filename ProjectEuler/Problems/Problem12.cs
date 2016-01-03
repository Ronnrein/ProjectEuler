using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    class Problem12 : EulerProblem {

        [Description("How many divisors should be searched for?")]
        public int divisors;

        public override string Name {
            get { return "Highly divisible triangular number"; }
        }

        public override int Id {
            get { return 12; }
        }

        public override string Run() {
            int i = 1;
            while (true) {
                int tri = MathUtils.TriangularNumber(i);
                int d = MathUtils.GetAllDivisors(tri).Count;
                if (d > divisors) {
                    return "The "+Utils.AddOrdinal(i)+" triangular number ("+tri+") has "+d+" divisors";
                }
                i++;
            }
        }

        
    }
}
