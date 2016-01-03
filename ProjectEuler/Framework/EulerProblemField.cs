using System;
using System.Reflection;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Framework {
    public class EulerProblemField {

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Type Type { get; private set; }
        public EulerProblem Owner { get; private set; }
        public CustomAttribute[] Attributes { get; private set; }

        public EulerProblemField(string name, string description, Type type, EulerProblem owner, CustomAttribute[] attributes) {
            Name = name;
            Description = description;
            Type = type;
            Owner = owner;
            Attributes = attributes;
        }

        public override string ToString() {
            return Owner + "." + Name + " (" + Type + "), " + Description;
        }

        /// <summary>
        /// Set the value of a field
        /// </summary>
        /// <param name="value">The value to set, should by this point be the correct type</param>
        public void Set(object value) {
            CheckAttributes(value);
            FieldInfo fieldInfo = Owner.GetType().GetField(Name, BindingFlags.Instance | BindingFlags.Public);
            if (fieldInfo != null) {
                fieldInfo.SetValue(Owner, Utils.NonGenericConvert(Type, value));
            }
        }

        /// <summary>
        /// Go through the attributes for a field and check if the value passes the tests
        /// </summary>
        /// <param name="value">The value to check</param>
        private void CheckAttributes(object value) {
            foreach (CustomAttribute attribute in Attributes) {
                if (!attribute.Check(Utils.NonGenericConvert(Type, value))) {
                    throw new ArgumentException(attribute.Error);
                }
            }
        }

    }
}
