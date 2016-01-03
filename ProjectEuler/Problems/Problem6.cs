using System.Linq;
using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem6 : EulerProblem {

        [Description("Enter how many numbers to be squared")]
        public int num;

        public override string Name {
            get { return "Sum square difference"; }
        }

        public override int Id {
            get { return 6; }
        }

        public override string Run() {
            int[] nums = Enumerable.Range(1, num).ToArray();
            int squareOfSum = nums.Sum()*nums.Sum();
            int sumOfSquares = nums.Select(n => n*n).Sum();
            int diff = squareOfSum - sumOfSquares;
            return "The sum of square difference with "+num+" natural numbers is "+diff;
        }
    }
}