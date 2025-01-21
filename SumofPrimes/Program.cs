using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the range (start number):");
        long start = long.Parse(Console.ReadLine());
        
        Console.WriteLine("Enter the range (end number):");
        long end = long.Parse(Console.ReadLine());

        long result = SumOfPrimes(start, end);
        Console.WriteLine($"Sum of prime numbers between {start} and {end} is: {result}");
    }

    public static long SumOfPrimes(long start, long end)
    {
        if (end - start <= 1000)
        {
            return GetPrimesInRange(start, end).Sum();
        }

        long mid = start + (end - start) / 2;
        long sum1 = 0, sum2 = 0;

        Thread t1 = new Thread(() => { sum1 = SumOfPrimes(start, mid); });
        Thread t2 = new Thread(() => { sum2 = SumOfPrimes(mid + 1, end); });

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        return sum1 + sum2;
    }

    private static List<long> GetPrimesInRange(long start, long end)
    {
        List<long> primes = new List<long>();
        
        for (long num = Math.Max(2, start); num <= end; num++)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
            }
        }
        return primes;
    }

    private static bool IsPrime(long number)
    {
        if (number < 2) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        long sqrt = (long)Math.Sqrt(number);
        for (long i = 3; i <= sqrt; i += 2)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}