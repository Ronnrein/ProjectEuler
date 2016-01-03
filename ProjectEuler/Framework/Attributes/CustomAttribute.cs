using System;

namespace ProjectEuler.Framework.Attributes {
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class CustomAttribute : Attribute {

        public abstract string Error { get; }

        public abstract bool Check(object val);

    }
}
