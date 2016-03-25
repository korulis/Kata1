using System.Text.RegularExpressions;

namespace StringCalculator
{
	public class DelimiterParser
	{
		public static string[] ParseDelimiters(string args)
		{
			var delimiters = new[] { ",", "\n" };
			if (args.StartsWith(@"//"))
			{
				delimiters = GetNewDelimiter(args);
			}
			return delimiters;
		}

		private static string[] GetNewDelimiter(string args)
		{
			return FormatDelimiterType(Regex.Match(args, @"//(.+?)\n").Groups[1].Value);
		}

		private static string[] FormatDelimiterType(string delimiters)
		{
			return new[] {delimiters};
		}
	}
}