using System;
using System.Collections.Generic;

namespace ConsoleTest
{
	internal class SumOfNElementsTest
	{
		public void TestSumOfElements()
		{
			var array1 = new[] { 7, 8, 15, 2, 22 };
			var target1 = 9;

			var array2 = new[] { 4, 3, 2, 1 };
			var target2 = 3;

			var array3 = new[] { 0, 3, 2, 1 };
			var target3 = 6;

			var array4 = new[] { 3, 3 };
			var target4 = 6;

			var sum1 = GetSumOfTwoIndexes(array1, target1);
			Console.WriteLine(sum1);

			var sum2 = GetSumOfTwoIndexes(array2, target2);
			Console.WriteLine(sum2);

			var sum3 = GetSumOfTwoIndexes(array3, target3);
			Console.WriteLine(sum3);

			var sum4 = GetSumOfTwoIndexes(array4, target4);
			Console.WriteLine(sum4);
		}

		private (int, int) GetSumOfTwoIndexes(int[] values, int target)
		{
			var map = new Dictionary<int, int>();
			for (int i = 0; i < values.Length; i++)
				map.Add(values[i], i);

			for (var i = 0; i < values.Length; i++)
			{
				var rem = target - values[i];
				if (map.ContainsKey(rem) && map[rem] != i)
					return (i, map[rem]);
			}

			return (-1, -1);
		}
	}
}
