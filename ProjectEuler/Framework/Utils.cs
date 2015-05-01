using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProjectEuler.Framework {
    class Utils {

        /// <summary>
        /// Get problem object from supplied id
        /// </summary>
        /// <param name="id">Id of problem to get</param>
        /// <returns>Problem object</returns>
        /// <exception cref="ArgumentException">Thrown whenever a problem id can not be found</exception>
        public static Problem GetProblem(int id) {
            string problemCheck = "ProjectEuler.Problems.Problem" + id;
            Type type = Type.GetType(problemCheck);
            if (type == null) {
                throw new ArgumentException("There is no problem with id "+id);
            }
            return (Problem)Activator.CreateInstance(type);
        }

        /// <summary>
        /// Get a list of integers of all available problems
        /// </summary>
        /// <returns>List of all available problems</returns>
        public static List<int> GetProblemList() {
            Type[] typeList =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => String.Equals(t.Namespace, "ProjectEuler.Problems", StringComparison.Ordinal))
                    .ToArray();
            List<int> nums = new List<int>();
            foreach (Type type in typeList) {
                int num = Int32.Parse(Regex.Replace(type.Name, "[^0-9.]", ""));
                nums.Add(num);
            }
            nums.Sort();
            return nums;
        }

        /// <summary>
        /// Get all problem objects in a list
        /// </summary>
        /// <returns>List containing all problem objects</returns>
        public static List<Problem> GetAllProblems() {
            List<Problem> problems = new List<Problem>();
            foreach (int i in GetProblemList()) {
                problems.Add(GetProblem(i));
            }
            return problems;
        } 

        /// <summary>
        /// Get user input
        /// </summary>
        /// <typeparam name="T">The type of input you want</typeparam>
        /// <param name="msg">Message to display to user</param>
        /// <returns>The user input converted to desired type</returns>
        public static T GetInput<T>(string msg) {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof (T));
            while (true) {
                Console.WriteLine(msg);
                string input = Console.ReadLine();
                try {
                    T value = (T) converter.ConvertFromString(input);
                    return value;
                }
                catch (Exception e) {
                    Console.WriteLine("Invalid input, please retry using valid "+typeof(T));
                }
            }
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
        /// Check whether a number is prime or not
        /// </summary>
        /// <param name="num">Number to check</param>
        /// <returns>If the number is prime or not</returns>
        public static bool IsPrime(int num) {
            for (int i = 2; i <= num / 2; i++) {
                if (num % i == 0) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get a list of all primes below a given value
        /// </summary>
        /// <param name="max">Maximum number to check</param>
        /// <param name="min">Lowest number to check</param>
        /// <returns>List of all primes between given values</returns>
        public static List<int> GetAllPrimes(int max, int min = 2) {
            List<int> primes = new List<int>();
            for (int i = min; i < max; i++) {
                if (IsPrime(i)) {
                    primes.Add(i);
                }
            }
            return primes;
        }

        /// <summary>
        /// Gets the Nth triangular number
        /// </summary>
        /// <param name="num">The triangular number to get</param>
        /// <returns>The triangular number</returns>
        public static int TriangularNumber(int num) {
            return Enumerable.Range(1, num).Sum();
        }

        /// <summary>
        /// Get all divisors of given number
        /// </summary>
        /// <param name="num">Number to get divisors for</param>
        /// <returns>List of all divisors for given number</returns>
        public static List<int> GetAllDivisors(int num) {
            List<int> divisors = new List<int> {1, num};
            for (int i = 2; i <= num/2; i++) {
                float divisor = (float)num/(float)i;
                if (divisor%1 == 0) {
                    divisors.Add((int)divisor);
                }
            }
            return divisors;
        }

    }
}
