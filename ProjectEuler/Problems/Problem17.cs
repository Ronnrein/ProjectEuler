using System.Text.RegularExpressions;
using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem17 : EulerProblem {

        [Description("Enter max number")]
        public int max;

        public override int Id {
            get { return 17; }
        }

        public override string Name {
            get { return "Number letter counts"; }
        }

        public override string Run() {
            long letters = 0;
            Regex rgx = new Regex(@"(\W)");
            for (int i = 1; i <= max; i++) {
                string words = i.ToWord();
                string result = rgx.Replace(words, "");
                letters += result.Length;
            }
            return "All the numbers up to and including " + max + " converted to words are in total " + letters +" characters long";
        }
    }
}