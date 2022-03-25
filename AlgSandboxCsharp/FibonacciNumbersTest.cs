using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleTest
{
	internal class FibonacciNumbersTest
	{
		public void TestFibonacci()
		{
			var valueArray = new[] { 30 };

			var results = new List<double>(valueArray.Length);
			var results2 = new List<double>(valueArray.Length);

			var sw = new Stopwatch();

			foreach (var value in valueArray)
			{
				sw.Start();
				var fib1 = GetFibonacciRecursion(value);
				sw.Stop();
				results.Add(sw.ElapsedTicks);
				sw.Reset();
				sw.Start();
				var fib2 = GetFibonacciOptimzed(value);
				sw.Stop();
				results2.Add(sw.ElapsedTicks);
				Console.WriteLine($"{value}: {fib1} {fib2}");

			}

			var avg1 = results.Average();
			var avg2 = results2.Average();
			Console.WriteLine($"{avg1} {avg2}");
		}

		private int GetFibonacciRecursion(int n)
		{
			if (n < 2)
				return n;

			return GetFibonacciRecursion(n - 1) + GetFibonacciRecursion(n - 2);
		}

		private int GetFibonacciOptimzed(int n)
		{
			if (n < 2)
				return n;

			var a = 1;
			var b = 1;

			for (int i = 3; i <= n; i++)
			{
				var c = a + b;
				a = b;
				b = c;
			}

			return b;
		}
	}
}
