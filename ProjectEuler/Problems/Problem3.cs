using System.Linq;
using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem3 : EulerProblem {

        [Description("Enter number to get largest prime factor of")]
        public long num;

        public override string Name {
            get { return "Name of problem"; }
        }

        public override int Id {
            get { return 3; }
        }

        public override string Run() {
            int result = MathUtils.GetAllPrimeFactors(num).Max();
            return "Largest prime factor of "+num+" is "+result;
        }
    }
}