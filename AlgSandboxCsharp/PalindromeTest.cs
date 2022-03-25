using System;

namespace ConsoleTest
{
	internal class PalindromeTest
	{
		public void TestPalindrome()
		{
			FindLongestPalindromeWithinString();
		}

		private void FindLongestPalindromeWithinString()
		{
			var tests = new[] { "babad", "cbbd", "mississipi", "ac"};
			foreach (var test in tests)
				Console.WriteLine($"{test} = {FindLongestPalindrome(test)}");
		}

		private string FindLongestPalindrome(string str)
		{
			var start = 0;
			var end = 0;

			for (var i = 0; i < str.Length; i++)
			{
				var len1 = TryExpandPalindrome(str, i, i);
				var len2 = TryExpandPalindrome(str, i, i + 1);
				var longestLength = Math.Max(len1, len2);
				if (longestLength > end - start)
				{
					start = i - ((longestLength - 1) / 2);
					end = start + longestLength;
				}
			}

			return str[start..end];
		}

		private int TryExpandPalindrome(string str, int l, int r)
		{
			while (l >=0 && r <= str.Length - 1)
			{
				if (char.ToLower(str[l]) != char.ToLower(str[r]))
					return r - l - 1;

				r++;
				l--;
			}

			return 1;
		}

		private void IsPalindromeLowerCaseLetters()
		{
			var tests = new[] { "abccba", "I'm home e mohmi", "aa", "a        A" };
			var falseTests = new[] { "abcd", "Imok", "", "12345", "1" };

			foreach (var test in tests)
				Console.WriteLine($"{test} = {IsPalindrome(test)}");

			Console.WriteLine();

			foreach (var test in falseTests)
				Console.WriteLine($"{test} = {IsPalindrome(test)}");
		}

		private bool IsPalindrome(string str)
		{
			if (str.Length == 0)
				return false;

			if (str.Length == 1)
				return true;

			var start = 0;
			var end = str.Length - 1;
			var isLetterFound = false;
			
			while (start < end)
			{
				while (!char.IsLetter(str[start]))
				{
					start++;
					if (start == end)
						return isLetterFound;
				}

				while (!char.IsLetter(str[end]))
				{
					end--;
					if (start == end)
						return isLetterFound;
				}

				isLetterFound = true;

				if (char.ToLower(str[start]) != char.ToLower(str[end]))
					return false;

				start++;
				end--;
			}

			return isLetterFound;
		}
	}
}
