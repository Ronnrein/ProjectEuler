using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ProjectEuler.Framework {
    internal static class Utils {

        /// <summary>
        /// Get a list of all problem types
        /// </summary>
        /// <returns>List of all available problem types</returns>
        public static List<Type> GetAllProblems() {
            List<Type> typeList =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof (EulerProblem)))
                    .ToList();
            return typeList;
        }

        /// <summary>
        /// Get user input
        /// </summary>
        /// <typeparam name="T">The type of input you want</typeparam>
        /// <param name="msg">Message to display to user</param>
        /// <param name="args">Input arguments to check for</param>
        /// <returns>The user input converted to desired type</returns>
        public static T GetInput<T>(string msg) {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof (T));
            while (true) {
                WriteLine(msg);
                string input = Console.ReadLine();
                try {
                    T value = (T) converter.ConvertFromString(input);
                    return value;
                }
                catch (Exception) {
                    WriteLine("Invalid input, please retry using valid "+typeof(T));
                }
            }
        }

        public static object NonGenericConvert(Type t, object value) {
            return Convert.ChangeType(value, t);
        }

        /// <summary>
        /// Adds ordinal to a number
        /// </summary>
        /// <param name="num">Number to add ordinal to</param>
        /// <returns>String containing number and ordinal</returns>
        public static string AddOrdinal(int num) {
            if (num <= 0) {
                return num.ToString();
            }
            switch (num%100) {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }
            switch (num%10) {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        /// <summary>
        /// Populates array with given value
        /// </summary>
        /// <typeparam name="T">Type to populate with</typeparam>
        /// <param name="a">Array to populate</param>
        /// <param name="val">Object to populate with</param>
        public static void Populate<T>(this T[] a, T val) {
            for (int i = 0; i < a.Length; i++) {
                a[i] = val;
            }
        }

        /// <summary>
        /// Common WriteLine method for project
        /// </summary>
        /// <param name="msg">Message to write</param>
        public static void WriteLine(string msg) {
            Console.WriteLine(msg);
        }

    }
}
