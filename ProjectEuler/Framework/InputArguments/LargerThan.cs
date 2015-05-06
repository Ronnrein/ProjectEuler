﻿using System;

namespace ProjectEuler.Framework.InputArguments {

    /// <summary>
    /// Argument to check if input is larger than number
    /// </summary>
    /// <typeparam name="T">Type that is comparable</typeparam>
    class LargerThan<T> : IInputArgument<T> where T : IComparable<T> {

        private T min;

        public string Error {
            get { return "Input needs to be larger than " + min; }
        }

        public LargerThan(T min) {
            this.min = min;
        } 

        public bool Test(T val) {
            return val.CompareTo(min) > 0;
        }
    }
}