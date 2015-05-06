using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ProjectEuler.Framework.InputArguments;

namespace ProjectEuler.Framework {
    static class Utils {

        /// <summary>
        /// Get problem object from supplied id
        /// </summary>
        /// <param name="id">Id of problem to get</param>
        /// <returns>IProblem object</returns>
        /// <exception cref="ArgumentException">Thrown whenever a problem id can not be found</exception>
        public static IProblem GetProblem(int id) {
            string problemCheck = "ProjectEuler.Problems.Problem" + id;
            Type type = Type.GetType(problemCheck);
            if (type == null) {
                throw new ArgumentException("There is no problem with id "+id);
            }
            return (IProblem)Activator.CreateInstance(type);
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
        /// Get all problem objects
        /// </summary>
        /// <returns>List containing all problem objects</returns>
        public static List<IProblem> GetAllProblems() {
            List<IProblem> problems = new List<IProblem>();
            foreach (int i in GetProblemList()) {
                problems.Add(GetProblem(i));
            }
            return problems;
        }

        /// <summary>
        /// Run supplied problem, and output timing information
        /// </summary>
        /// <param name="problem">Problem object to run</param>
        public static void RunProblem(IProblem problem) {
            Console.WriteLine("Running problem " + problem.Id + ": " + problem.Name);
            Stopwatch watch = Stopwatch.StartNew();
            problem.Run();
            watch.Stop();
            Console.WriteLine("Problem finished in " + watch.ElapsedMilliseconds + "ms");
        }

        /// <summary>
        /// Gets the problem object, then runs it
        /// </summary>
        /// <param name="problem">ID of problem</param>
        public static void RunProblem(int problem) {
            RunProblem(GetProblem(problem));
        }

        /// <summary>
        /// Run all problems
        /// </summary>
        public static void RunAllProblems() {
            foreach (IProblem problem in GetAllProblems()) {
                RunProblem(problem);
            }
        }

        /// <summary>
        /// Get user input
        /// </summary>
        /// <typeparam name="T">The type of input you want</typeparam>
        /// <param name="msg">Message to display to user</param>
        /// <param name="args">Input arguments to check for</param>
        /// <returns>The user input converted to desired type</returns>
        public static T GetInput<T>(string msg, params IInputArgument<T>[] args) {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof (T));
            while (true) {
                Console.WriteLine(msg);
                string input = Console.ReadLine();
                try {
                    T value = (T) converter.ConvertFromString(input);
                    bool success = true;
                    foreach (IInputArgument<T> arg in args) {
                        if (!arg.Test(value)) {
                            Console.WriteLine(arg.Error);
                            success = false;
                            break;
                        }
                    }
                    if (!success) {
                        continue;
                    }
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

    }
}
