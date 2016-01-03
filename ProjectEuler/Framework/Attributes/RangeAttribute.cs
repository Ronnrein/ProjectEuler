using System;

namespace ProjectEuler.Framework.Attributes {
    class RangeAttribute : CustomAttribute {

        public int min;
        public int max;

        public override string Error {
            get { return "Value must be between " + min + " and " + max; }
        }

        public RangeAttribute(int min, int max) {
            this.min = min;
            this.max = max;
        }

        public override bool Check(object val) {
            return Int32.Parse(val.ToString()) >= min && Int32.Parse(val.ToString()) <= max;
        }
    }
}
