using System.Linq;
using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem1 : EulerProblem {

        [Description("Enter first multiple")]
        public int num1;

        [Description("Enter second multiple")]
        public int num2;

        [Description("Enter max number")]
        public int max;

        public override string Name {
            get { return "Multiples of 3 and 5"; }
        }

        public override int Id {
            get { return 1; }
        }

        public override string Run() {
            int result = MathUtils.GetAllMultiples(num1, max).Sum() + MathUtils.GetAllMultiples(num2, max).Sum() - MathUtils.GetAllMultiples(num1 * num2, max).Sum();
            return "The sum of all multiples of " + num1 + " and " + num2 + " under " + max + " is " + result;
        }
    }
}