using System;
using ProjectEuler.Framework;
using ProjectEuler.Framework.InputArguments;

namespace ProjectEuler.Problems
{
    public class Problem5 : IProblem {
        public string Name {
            get { return "Smallest multiple"; }
        }

        public int Id {
            get { return 5; }
        }

        public void Run() {
            int min = Utils.GetInput("Enter minimum number", new IInputArgument<int>[] { new LargerThan<int>(0) });
            int max = Utils.GetInput("Enter maximum number", new IInputArgument<int>[] { new LargerThan<int>(min) });
            int result = MathUtils.SmallestMultiple(min, max);
            Console.WriteLine("The smallest multiple between "+min+" and "+max+" is "+result);

        }
    }
}