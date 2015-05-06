using System;
using System.Collections.Generic;
using System.Diagnostics;
using ProjectEuler.Framework;

namespace ProjectEuler {
    class Program {

        public static string workingPrefix = "| ";

        public Program() {
            bool repeat = true;
            while (repeat) {
                Console.WriteLine("Available problems: " + string.Join(", ", Utils.GetProblemList()));
                int id = Utils.GetInput<int>("Please input problem id");
                try {
                    Utils.RunProblem(id);
                    Console.WriteLine("Would you like to run another problem? y/n");
                    repeat = Console.ReadLine().ToLower() == "y";
                }
                catch (ArgumentException e) {
                    Console.WriteLine(e.Message+", please try again");
                }
            }
        }

        static void Main(string[] args) {
            Program p = new Program();
        }
    }
}