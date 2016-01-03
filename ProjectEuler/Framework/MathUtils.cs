using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Framework {
    static class MathUtils {

        /// <summary>
        /// Check whether a number is prime or not
        /// </summary>
        /// <param name="num">Number to check</param>
        /// <returns>If the number is prime or not</returns>
        public static bool IsPrime(decimal num) {
            if (num == 1) { return false; }
            if (num == 2) { return true; }
            int lower = (int) Math.Floor(Math.Sqrt((double)num));
            for (int i = 2; i <= lower; i++) {
                if (num%i == 0) { return false; }
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
        /// Get Nth prime number
        /// </summary>
        /// <param name="n">The prime number to find</param>
        /// <returns>Desired prime number</returns>
        public static int GetPrime(int n) {
            int i = 2;
            int p = 0;
            while (p < n) {
                if (IsPrime(i)) {
                    p++;
                }
                i++;
            }
            return i-1;
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
            List<int> divisors = new List<int> { 1, num };
            for (int i = 2; i <= num / 2; i++) {
                float divisor = (float)num / (float)i;
                if (divisor % 1 == 0) {
                    divisors.Add((int)divisor);
                }
            }
            return divisors;
        }

        /// <summary>
        /// Get all the natural multiples of a number below given number
        /// </summary>
        /// <param name="num">Number to get multiples of</param>
        /// <param name="max">Maximum number</param>
        /// <returns>List of all multiples</returns>
        public static List<int> GetAllMultiples(int num, int max) {
            List<int> multiples = new List<int>();
            for (int i = 1; i < max; i++) {
                if (i % num == 0) {
                    multiples.Add(i);
                }
            }
            return multiples;
        }

        /// <summary>
        /// Get all fibonacci numbers under a given number
        /// </summary>
        /// <param name="max">Max value to get</param>
        /// <returns>List of fibonacci numbers</returns>
        public static List<int> Fibonacci(int max) {
            List<int> nums = new List<int>() { 1, 2 };
            int current = 2;
            int prev = 1;
            while (current < max) {
                int num = current + prev;
                prev = current;
                current = num;
                nums.Add(num);
            }
            return nums;
        }

        /// <summary>
        /// Checks whether the given number is odd
        /// </summary>
        /// <param name="num">Number to check</param>
        /// <returns>Returns true if it is off, false if it is even</returns>
        public static bool IsOdd(int num) {
            return num % 2 != 0;
        }

        /// <summary>
        /// Checks if the number is a whole number
        /// </summary>
        /// <param name="num">Number to check</param>
        /// <returns>Returns true if number is whole, false if not</returns>
        public static bool IsWhole(decimal num) {
            return num % 1 == 0;
        }

        /// <summary>
        /// Get all prime factors of a number
        /// </summary>
        /// <param name="num">Number to get prime factors for</param>
        /// <returns>All prime factors for given number</returns>
        public static List<int> GetAllPrimeFactors(long num) {
            List<int> factors = new List<int>();
            int i = 2;
            while (true) {
                decimal t = (decimal)num/(decimal)i;
                if (IsWhole(t)) {
                    factors.Add(i);
                    if (IsPrime(t)) {
                        factors.Add((int) t);
                        break;
                    }
                    num = (long)t;
                    i = 2;
                }
                else {
                    i++;
                }
            }
            return factors;
        }

        /// <summary>
        /// Get the largest palindrome product with given number of digits
        /// </summary>
        /// <param name="digits">Digits to get palindrome product of</param>
        /// <returns>Largest product</returns>
        public static int LargestPalindromeProduct(int digits, int numbers = 2) {
            int[] nums = new int[numbers];
            char[] chars = new char[digits-1];
            chars.Populate('9');
            nums.Populate(Int32.Parse("9"+new string(chars)));
            int max = nums[0];
            int largest = 0;
            while (nums[0] > 0) {
                Console.WriteLine(largest+" - "+nums[nums.Length-2]);
                for (int i = max; i >= 1; i--) {
                    nums[nums.Length - 1] = i;
                    int sum = nums.Aggregate((a, x) => a*x);
                    if (IsPalindrome(sum.ToString()) && sum > largest) {
                        largest = sum;
                    }
                }
                nums[nums.Length-2]--;
                for (int i = nums.Length - 2; i > 0; i--) {
                    if (nums[i] <= 0) {
                        nums[i] = max;
                        if (i - 1 != 0) {
                            nums[i - 1]--;
                        }
                    }
                }
            }
            return largest;
        }

        /// <summary>
        /// Checks if given string is palindrome
        /// </summary>
        /// <param name="str">String to check</param>
        /// <returns>Whether the string is palindrome or not</returns>
        public static bool IsPalindrome(string str) {
            char[] arr = str.ToCharArray();
            if (IsOdd(arr.Length)) {
                int mid = arr.Length/2;
                arr = arr.Where((val, id) => id != mid).ToArray();
            }
            for (int i = 0; i < arr.Length/2; i++) {
                if (arr[i] != arr[arr.Length - 1 - i]) { return false; }
            }
            return true;
        }

        /// <summary>
        /// Gets the smallest multiple between two numbers
        /// </summary>
        /// <param name="min">Minimum number</param>
        /// <param name="max">Maximum number</param>
        /// <returns>The smallest multiple between the two numbers</returns>
        public static int SmallestMultiple(int min, int max) {
            int i = 0;
            while (true) {
                i++;
                bool success = true;
                for (int j = min; j <= max; j++) {
                    if (!IsEvenlyDivisable(i, j)) {
                        success = false;
                        break;
                    }
                }
                if (!success) {
                    continue;
                }
                return i;
            }
        }

        /// <summary>
        /// Checks whether the two numbers are evenly divisable
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <returns>Whether the number is evenly divisable</returns>
        public static bool IsEvenlyDivisable(int num1, int num2) {
            return num1%num2 == 0;
        }

        /// <summary>
        /// Find largest product in a string of numbers
        /// </summary>
        /// <param name="series">String of numbers</param>
        /// <param name="digits">Number of digits to get a product from</param>
        /// <returns>The largest product in this series</returns>
        public static long LargestProductInSeries(string series, int digits) {
            long largest = 0;
            for (int i = 0; i < series.Length - digits; i++) {
                long sum = 0;
                for (int j = 0; j < digits; j++) {
                    int num = (int) Char.GetNumericValue(series[i + j]);
                    if (num == 0) {
                        i += j;
                        sum = 0;
                        break;
                    }
                    sum = sum != 0 ? sum*num : num;
                }
                if (sum > largest) {
                    largest = sum;
                }
            }
            return largest;
        }

    }
}
