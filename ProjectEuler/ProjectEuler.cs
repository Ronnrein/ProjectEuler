using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProjectEuler.Framework;

namespace ProjectEuler {
    public static class ProjectEuler {

        /// <summary>
        /// Private member contaning problems
        /// </summary>
        private static List<EulerProblem> problems; 

        /// <summary>
        /// Singleton returning list of all problems
        /// </summary>
        public static List<EulerProblem> Problems {
            get { return problems ?? (problems = GetProblems()); }
        }

        /// <summary>
        /// Gets a list of all problem ids
        /// </summary>
        public static List<int> ProblemIds {
            get { return Problems.Select(p => p.Id).ToList(); }
        }

        /// <summary>
        /// Get the problem with supplied id
        /// </summary>
        /// <param name="id">The id of problem to get</param>
        /// <returns>The problem object</returns>
        public static EulerProblem GetProblem(int id) {
            return Problems.Single(p => p.Id == id);
        }

        /// <summary>
        /// Get a list containing all problem objects
        /// </summary>
        /// <returns>List with all problems</returns>
        private static List<EulerProblem> GetProblems() {
            List<Type> typeList =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(EulerProblem)))
                    .ToList();
            return typeList.Select(t => (EulerProblem)Activator.CreateInstance(t)).OrderBy(o => o.Id).ToList();
        }

    }
}
