using System.Collections.Generic;
using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem14 : EulerProblem {

        [Description("Max starting number")]
        public int max;

        public override int Id {
            get { return 14; }
        }

        public override string Name {
            get { return "Longest Collatz Sequence"; }
        }

        public override string Run() {
            KeyValuePair<int, int> longest = new KeyValuePair<int, int>(0, 0);
            for (int i = 1; i <= max; i++) {
                int length = MathUtils.CollatzSequenceLength(i);
                if (length > longest.Value) {
                    longest = new KeyValuePair<int, int>(i, length);
                }
            }
            return "Longest collatz sequence from starting number below " + max + " is " + longest.Key;
        }
    }
}