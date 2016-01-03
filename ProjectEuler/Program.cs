using System;
using System.Collections.Generic;
using ProjectEuler.Framework;

namespace ProjectEuler {
    class Program {

        public Program() {

            // Whether the program should keep repeating when done
            bool repeat = true;

            // Program loop
            while (repeat) {

                // Get a list of all problem objects and ids
                List<EulerProblem> problems = ProjectEuler.Problems;
                List<int> problemIds = ProjectEuler.ProblemIds;

                // List all available problems and get desired problem id
                Console.WriteLine("Available problems: "+string.Join(", ", problemIds)+"\nPlease input desired problem id");
                int id;
                while (true) {
                    if (Int32.TryParse(Console.ReadLine(), out id)) {
                        break;
                    }
                    Console.WriteLine("Not a valid integer, please try again");
                }

                // Try to get the problem with supplied id
                // (Throws InvalidOperationException if problem does not exist)
                try {
                    EulerProblem problem = ProjectEuler.GetProblem(id);

                    // Go through each input field of problem and get input
                    foreach (EulerProblemField field in problem.GetFields()) {
                        GetFieldInput(field);
                    }

                    // Run the problem and print the result
                    try {
                        Console.WriteLine(problem.Run());
                    }
                    catch (Exception e) {
                        Console.WriteLine("An exception occured while trying to run problem "+id+":");
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.StackTrace);
                    }
                    
                }
                catch (InvalidOperationException e) {
                    Console.WriteLine("No problem with id " + id + ", please try again");
                    continue;
                }

                // Check to see if user wants to repeat the program
                Console.WriteLine("Would you like to run another problem? y/n");
                repeat = Console.ReadLine().ToLower() == "y";
            }
        }

        private void GetFieldInput(EulerProblemField field) {

            // Repeat until valid input is supplied
            while (true) {
                Console.WriteLine(field.Description);
                string input = Console.ReadLine();

                // Try to set the field with supplied input
                // (Throws FormatException if input is invalid format)
                // (Throws ArgumentException if the input does not meed attributes)
                try {
                    field.Set(input);
                    return;
                }
                catch (FormatException) {
                    Console.WriteLine("Invalid input, please retry using valid " + field.Type);
                }
                catch (ArgumentException e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public static void Main() {
            Program p = new Program();
        }

    }
}