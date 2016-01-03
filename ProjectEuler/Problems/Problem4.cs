using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem4 : EulerProblem{

        [Description("Enter number of digits to search for")]
        public int digits;

        [Description("Enter how many numbers to search for")]
        public int numbers;

        public override string Name {
            get { return "Largest palindrome product"; }
        }

        public override int Id {
            get { return 4; }
        }

        public override string Run() {
            int result = MathUtils.LargestPalindromeProduct(digits, numbers);
            return "The largest palindrome made from the product of "+numbers+" "+digits+"-digit numbers is "+result;
        }
    }
}