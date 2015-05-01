using System;

namespace ProjectEuler.Problems {
    public class Problem7 : Problem{
        public string Name {
            get { return "10001st prime"; }
        }

        public int Id {
            get { return 7; }
        }

        public void Run() {
            while (true) {
                int num = 0;
                Console.WriteLine("Enter prime number to find");
                if (Int32.TryParse(Console.ReadLine(), out num)) {
                    if (num <= 0) {
                        Console.WriteLine("Has to be above 0, try again");
                    }
                    else {
                        int result = GetPrimeNumber(num);
                        string numStr = num.ToString();
                        switch (num%10) {
                            case 1:
                                numStr += "st";
                                break;
                            case 2:
                                numStr += "nd";
                                break;
                            case 3:
                                numStr += "rd";
                                break;
                            default:
                                numStr += "th";
                                break;
                        }
                        Console.WriteLine("The "+numStr+" prime number is "+result);
                        return;
                    }
                }
            }
        }

        private int GetPrimeNumber(int num) {
            int currentPrime = 0;
            int i = 1;
            Console.WriteLine("Working...");
            while (currentPrime < num) {
                i++;
                if (Utils.IsPrime(i)) {
                    currentPrime++;
                }
            }
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            return i;
        }

    }
}