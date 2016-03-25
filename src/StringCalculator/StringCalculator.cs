using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{

    public class StringCalculator
    {

        public int Add(string args)
        {

            //if()


            var delimiters = DelimiterParser.ParseDelimiters(args);
            args = TruncateArguments(args);
            var result = Add(args, delimiters); 
            return result;
        }

	    private static string TruncateArguments(string args)
        {
            if (args.StartsWith(@"//"))
            {
                args = Truncate(args);
            }
            return args;
        }

        private static string Truncate(string args)
        {
            args = args.Substring(GetStartOfArgs(args));
            return args;
        }

        private static int GetStartOfArgs(string args)
        {
            return args.IndexOf("\n", StringComparison.Ordinal)+1;
        }

        private static int Add(string args, string[] delimiters)
        {
	        var numbers = GetNumbers(args, delimiters);
	        CheckForNegatives(numbers);
	        return numbers.Sum();
        }

	    private static void CheckForNegatives(IEnumerable<int> numbers)
	    {
		    var enumerable = numbers.Where(x => x < 0);
		    if (enumerable.Any())
		    {
			    throw new Exception();
		    }
	    }

	    private static IEnumerable<int> GetNumbers(string args, string[] delimiters)
	    {
		    return args.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
	    }
    }
}
