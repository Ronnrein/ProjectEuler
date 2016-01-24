using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem16 : EulerProblem {

        [Description("Number to use")]
        public int number;

        [Description("Power to use")]
        public int power;

        public override int Id {
            get { return 16; }
        }

        public override string Name {
            get { return "Power digit sum"; }
        }

        public override string Run() {
            long sum = MathUtils.PowerDigitSum(number, power);
            return "The power digit sum of " + number + "^" + power + " is " + sum;
        }
    }
}