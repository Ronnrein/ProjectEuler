using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Framework.Attributes {
    [AttributeUsage(AttributeTargets.Field)]
    class DescriptionAttribute : Attribute {

        public string Msg { get; private set; }

        public DescriptionAttribute(string msg) {
            Msg = msg;
        }

    }
}
