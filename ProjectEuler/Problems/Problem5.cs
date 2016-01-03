using System;
using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems
{
    public class Problem5 : EulerProblem {

        [Description("Enter minimum number")]
        [Range(0, Int32.MaxValue)]
        public int min;

        [Description("Enter maximum number")]
        [Range(0, Int32.MaxValue)]
        public int max;

        public override string Name {
            get { return "Smallest multiple"; }
        }

        public override int Id {
            get { return 5; }
        }

        public override string Run() {
            int result = MathUtils.SmallestMultiple(min, max);
            return "The smallest multiple between "+min+" and "+max+" is "+result;
        }
    }
}