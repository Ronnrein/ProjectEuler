using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ProjectEuler {
    class Program {

        public static string workingPrefix = "| ";

        public delegate void ProblemStartedHandler(Problem p, EventArgs e);
        public delegate void ProblemFinishedHandler(Problem p, EventArgs e);

        public event ProblemStartedHandler ProblemStarted;
        public event ProblemFinishedHandler ProblemFinished;

        public Program() {
            bool repeat = true;
            while (repeat) {
                Problem p = GetProblem();
                Console.WriteLine("Running problem " + p.Id + ": " + p.Name);
                Stopwatch watch = Stopwatch.StartNew();
                p.Run();
                watch.Stop();
                Console.WriteLine("Problem finished in " + watch.ElapsedMilliseconds + "ms");
                Console.WriteLine("Would you like to run another problem? y/n");
                repeat = Console.ReadLine().ToLower() == "y";}
        }

        private Problem GetProblem() {
            Console.WriteLine("Available problems: " + string.Join(", ", GetProblemList()));
            Console.WriteLine("Please input problem id");
            while (true) {
                string input = Console.ReadLine();
                string problemCheck = "ProjectEuler.Problems.Problem" + input;
                Type type = Type.GetType(problemCheck);
                if (type != null) {
                    return (Problem)Activator.CreateInstance(type);
                }
                Console.WriteLine("Problem "+input+" not found, try again");
            }
        }

        private List<int> GetProblemList() {
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

        static void Main(string[] args) {
            Program p = new Program();
        }
    }
}