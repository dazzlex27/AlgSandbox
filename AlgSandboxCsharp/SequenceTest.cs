using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
	internal class SequenceTest
	{
		public void TestSequence()
		{
			RunLRETest();
			//GenerateBracketSequenceTest();
			//FindLongestSeqInBinaryVectorTest();
			//CheckAnagramsTest();
		}

		private void RunLRETest()
		{
			var samples = new[] { "LLLLLRRRRE", "", "RrRaaaaaaLLL" , "FFFFFFF", "K" };
			foreach (var sample in samples)
				Console.WriteLine($"{sample} = {GetLRE(sample)}");
		}

		private string GetLRE(string str)
		{
			var length = str.Length;
			if (length == 0)
				return "";

			var lastChar = str[0];
			var lastCharCnt = 1;

			var sb = new StringBuilder(length);

			for (var i = 1; i < length; i++)
			{
				var c = str[i];
				if (lastChar != c)
				{
					WriteCharToLRE(sb, lastChar, lastCharCnt);
					lastCharCnt = 1;
					lastChar = c;
				}
				else
					lastCharCnt++;
			}

			WriteCharToLRE(sb, lastChar, lastCharCnt);

			return sb.ToString();
		}

		private void WriteCharToLRE(StringBuilder sb, char c, int count)
		{
			if (count > 1)
				sb.Append($"{c}{count}");

			sb.Append(c);
		}

		private void GenerateBracketSequenceTest()
		{
			var samples = Enumerable.Range(1, 3);

			foreach (var sample in samples)
			{
				GenerateBracketSequence("", 0, 0, sample);
				Console.WriteLine();
			}
		}

		private void GenerateBracketSequence(string str, int open, int closed, int n)
		{
			if (str.Length == 2 * n)
			{
				Console.WriteLine(str);
				return;
			}

			if (open < n)
				GenerateBracketSequence(str + "(", open + 1, closed, n);

			if (closed < open)
				GenerateBracketSequence(str + ")", open, closed + 1, n);
		}

		private void CheckAnagramsTest()
		{
			var trueSamples = new List<(string, string)>();
			trueSamples.Add(("ab", "ba"));
			trueSamples.Add(("abc", "bca"));
			trueSamples.Add(("voldemort", "tomvredlo"));

			var falseSamples = new List<(string, string)>();
			falseSamples.Add(("aab", "abb"));
			falseSamples.Add(("a", "ab"));
			falseSamples.Add(("a", ""));

			foreach (var sample in trueSamples)
				Console.WriteLine($"{sample} = {CheckAreAnagrams(sample)}");

			Console.WriteLine();

			foreach (var sample in falseSamples)
				Console.WriteLine($"{sample} = {CheckAreAnagrams(sample)}");
		}

		private bool CheckAreAnagrams((string, string) strs)
		{
			if (strs.Item1.Length != strs.Item2.Length)
				return false;

			var accArray1 = BuildAccArray(strs.Item1);
			var accArray2 = BuildAccArray(strs.Item2);

			return accArray1.SequenceEqual(accArray2);
		}

		private SortedDictionary<char, int> BuildAccArray(string str)
		{
			var accArray = new SortedDictionary<char, int>();
			foreach (var ch in str)
				if (accArray.ContainsKey(ch))
					accArray[ch]++;
				else
					accArray.Add(ch, 1);

			return accArray;
		}

		private void FindLongestSeqInBinaryVectorTest()
		{
			var samples = new[]
			{
				new[] { 0, 0, 0 },
				new[] { 1, 1, 1 },
				new[] { 1, 1, 0 },
				new[] { 0, 1, 1 },
				new[] { 0, 1, 0 },
				new int[0]
			};

			foreach (var sample in samples)
				Console.WriteLine($"{string.Join(" ", sample)} = {FindLongestSeqInBinaryVector(sample)}");
		}

		private int FindLongestSeqInBinaryVector(int[] sequence)
		{
			var maxCount = 0;
			var currentCount = 0;

			for (int i = 0; i < sequence.Length; i++)
			{
				if (sequence[i] > 0)
					currentCount++;
				else
					currentCount = 0;

				if (currentCount > maxCount)
					maxCount = currentCount;
			}

			return maxCount;
		}
	}
}
