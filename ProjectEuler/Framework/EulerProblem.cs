using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProjectEuler.Framework.Attributes;

namespace ProjectEuler.Framework {

    /// <summary>
    /// The abstract class all Euler problems inherit from
    /// </summary>
    public abstract class EulerProblem {

        /// <summary>
        /// Stores the ID of the Euler problem
        /// </summary>
        public abstract int Id { get; }

        /// <summary>
        /// Stores the name of the Euler problem
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Run the solution of the problem
        /// </summary>
        /// <returns>Result of the solution</returns>
        public abstract string Run();

        /// <summary>
        /// Get a list of all the private fields of this problem
        /// </summary>
        /// <returns>List containing all the fields of this problem</returns>
        public List<EulerProblemField> GetFields() {
            List<EulerProblemField> fields = new List<EulerProblemField>();
            foreach (FieldInfo f in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)) {
                CustomAttribute[] attributes = f.GetCustomAttributes().OfType<CustomAttribute>().ToArray();
                string description = f.GetCustomAttributes().OfType<DescriptionAttribute>().First().Msg;
                fields.Add(new EulerProblemField(f.Name, description, f.FieldType, this, attributes));
            }
            return fields;
        }

        /// <summary>
        /// Checks if all fields of this problem has a value
        /// </summary>
        /// <returns>Whether or not all fields have a value</returns>
        public bool AllFieldsFilled() {
            return GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
                .Any(f => !string.IsNullOrWhiteSpace((f.GetValue(this) as string)));
        }

    }

}
