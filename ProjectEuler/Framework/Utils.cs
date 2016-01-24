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

        /// <summary>
        /// Prints a twodimensional array
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="array">Twodimensional array</param>
        public static void PrintGrid<T>(this T[,] array) {
            for (int i = 0; i < array.GetLength(0); i++) {
                if (i > 0) {
                    Console.Write("\n");
                }
                for (int j = 0; j < array.GetLength(1); j++) {
                    if (j > 0) {
                        Console.Write("\t");
                    }
                    Console.Write(array[i, j]);
                }
            }
            Console.Write("\n");
        }

        /// <summary>
        /// Returns the word representation of integer up until 999999
        /// </summary>
        /// <param name="num">Number to get words for</param>
        /// <returns>String containing words for the number</returns>
        public static string ToWord(this int num) {
            string[] numbers = {
                "one", "two", "three", "four", "five", "six", "seven", "eight",
                "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
                "sixteen", "seventeen", "eighteen", "nineteen"
            };
            string[] tens = {
                "twenty", "thirty", "forty", "fifty",
                "sixty", "seventy", "eighty", "ninety"
            };
            string result = "";
            while (num > 0) {
                int digit = int.Parse(num.ToString().Substring(0, 1));
                if (num < 20) {
                    if (result.Length > 1 && result.Substring(result.Length - 1) != "-") {
                        result += " and ";
                    }
                    result += numbers[num-1];
                    num = 0;
                }
                else if (num < 100) {
                    if (result.Length != 0) {
                        result += " and ";
                    }
                    result += tens[digit - 2];
                    num -= int.Parse(digit+"0");
                    if (num != 0) {
                        result += "-";
                    }
                }
                else if (num < 1000) {
                    result += numbers[digit - 1] + " hundred";
                    num -= int.Parse(digit + "00");
                }
                else if (num < 1000000) {
                    int offset = num > 99999 ? 3 : num > 9999 ? 2 : 1;
                    int digits = int.Parse(num.ToString().Substring(0, offset));
                    string t = digits.ToWord();
                    result += t + " thousand";
                    num -= int.Parse(digits + "000");
                    if (num != 0) {
                        result += ", ";
                    }
                }
                else {
                    return "Number too large";
                }
            }
            return result;
        }

    }
}
