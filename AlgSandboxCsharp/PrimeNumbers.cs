using System;
using System.Linq;

namespace ConsoleTest
{
	internal class PrimeNumbersTest
	{
		public void TestPrimeNumbers()
		{
			var valueArray = Enumerable.Range(1, 20);
			foreach (var value in valueArray)
			{
				var isPrime = IsPrime(value);
				Console.WriteLine($"{value} {isPrime}");
			}

			var primesToFind = Enumerable.Range(1, 8);
			foreach (var value in primesToFind)
			{
				var nthPrime = GetNthPrimeNaive(value);
				Console.WriteLine($"prime {value} is {nthPrime}");
			}
		}

		private int GetNthPrimeNaive(int n)
		{
			var totalPrimesFound = 0;
			var lastPrime = 0;
			var currentNum = 2;

			while (n > totalPrimesFound)
			{
				var isPrime = IsPrime(currentNum);
				if (isPrime)
				{
					lastPrime = currentNum;
					totalPrimesFound++;
				}
				currentNum++;
			}

			return lastPrime;
		}

		private int GetNthPrimeSeive(int n)
		{
			var bools = Enumerable.Repeat(true, n).ToArray();

			for (var i = 2; i * i <= n; i++)
				if (IsPrime(i))
					for (var j = 2 * i; j < n; j += i)
						bools[j] = false;

			var index = 0;
			var primeIndex = 0;

			while (primeIndex < n)
			{
				if (bools[index])
					primeIndex++;

				index++;
			}

			return index;
		}

		private bool IsPrime(int n)
		{
			for (var i = 2; i * i <= n; i++)
			{
				if (n % i == 0)
					return false;
			}

			return n > 1;
		}
	}
}
