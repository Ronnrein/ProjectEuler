using System;
using System.Collections.Generic;
using System.Linq;
namespace ProjectEuler.Framework.InputArguments {
    public interface IInputArgument<T> {
        string Error { get; }
        bool Test(T val);
    }
}
