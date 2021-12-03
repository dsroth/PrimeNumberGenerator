using System;
using System.Collections.Generic;


//Implementation of a Prime Number Generator that takes a range of input values (converted to absolute values) and outputs all primes between the two values (inclusive)
namespace PrimalityTest
{
    public interface PrimeNumberGenerator
    {
        List<int> Generate(int starting_value, int ending_value);
        bool IsPrime(int value);
    }
    public class PrimalityCheck : PrimeNumberGenerator
    {
        public static void Main()
        {
            Console.WriteLine("Please specify desired range start:");
            PrimalityCheck check = new PrimalityCheck();
            var start = ReadInput();
            Console.WriteLine("Please specify desired range end:");
            var end = ReadInput();
            Console.WriteLine("Primes found:");
            WritePrimes(check.Generate(start, end));
        }

        public static void WritePrimes(List<int> primes_list)
        {
            foreach (int i in primes_list)
            {
                Console.WriteLine(i);
            }
        }
        public static int ReadInput()
        {
            return Math.Abs(Convert.ToInt32(Console.ReadLine()));
        }
        public List<int> Generate(int starting_value, int ending_value)
        {
            //initialize the return value
            var integer_list = new List<int>();

            //check if input range is inverted and convert to non-inverted if so
            if (starting_value > ending_value)
            {
                var tmp = ending_value;
                ending_value = starting_value;
                starting_value = tmp;
            }

            //add the requested values to the list
            for (int i = starting_value; i < ending_value + 1; i++)
            {
                integer_list.Add(i);
            }

            var primes = new List<int>();
            foreach (int i in integer_list)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        public bool IsPrime(int value)
        {
            //2 and 3 are prime numbers that don't fit the mathematical pattern used next
            if (value == 2 || value == 3)
                return true;

            //primes are only positive integers over 1
            //Ignore lesser values and those whose prime factorization includes 2 or 3
            if (value <= 1 || value % 2 == 0 || value % 3 == 0)
                return false;

            //all integers can take the form 6k + i where i = -1, 0, 1, 2, 3, or 4
            //primes will only include 6k + 1 or 6k -1 since 6k + 0, 2, or 4 is divisible by 2, and 6k + 3 is divisible by 3
            //all prime factors of a number must be less than or equal to the square root of the number, so we only have to check for factors up to that value
            //Thus we start at our first 6k -  1 and 6k + 1 (5 and 7) and check for each pair above that by incrementing by six each iteration
            for (int i = 5; i * i <= value; i += 6)
            {
                if (value % i == 0 || value % (i + 2) == 0)
                    return false;
            }

            //the above method will catch all composite numbers, leaving only primes
            return true;
        }
    }
}
