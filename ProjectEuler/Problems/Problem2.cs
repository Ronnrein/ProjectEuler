using System.Linq;
using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem2 : EulerProblem {

        [Description("Enter max fibonacci number")]
        public int max;

        public override string Name {
            get { return "Even Fibonacci numbers"; }
        }

        public override int Id {
            get { return 2; }
        }

        public override string Run() {
            int sum = MathUtils.Fibonacci(max).Where(n => !MathUtils.IsOdd(n)).Sum();
            return "Sum of all even fibonacci numbers below "+max+" is "+sum;
        }
    }
}