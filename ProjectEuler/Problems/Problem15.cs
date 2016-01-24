using ProjectEuler.Framework;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Problems {
    public class Problem15 : EulerProblem {

        [Description("Size of grid")]
        public int size;

        public override int Id {
            get { return 15; }
        }

        public override string Name {
            get { return "Lattice Paths"; }
        }

        public override string Run() {
            long paths = MathUtils.LatticePathCount(size);
            return "For a " + size + "x" + size + " grid there are " + paths + " lattice paths";
        }
    }
}