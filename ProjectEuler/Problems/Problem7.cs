using System;
using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem7 : EulerProblem {

        [Description("Enter Nth prime number to find")]
        [Range(0, Int32.MaxValue)]
        public int num;

        public override string Name {
            get { return "10001st prime"; }
        }

        public override int Id {
            get { return 7; }
        }

        public override string Run() {
            int prime = MathUtils.GetPrime(num);
            return "The "+Utils.AddOrdinal(num)+" prime number is "+prime;
        }
    }
}