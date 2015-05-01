using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Timers;

namespace ProjectEuler {
    class Utils {

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

        public static bool IsPrime(int num) {
            for (int i = 2; i <= num / 2; i++) {
                if (num % i == 0) {
                    return false;
                }
            }
            return true;
        }

        public static List<int> GetAllPrimes(int max, int min = 2) {
            List<int> primes = new List<int>();
            for (int i = min; i < max; i++) {
                if (IsPrime(i)) {
                    primes.Add(i);
                }
            }
            return primes;
        }

        public static int TriangularNumber(int num) {
            return Enumerable.Range(1, num).Sum();
        }

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
