using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {

        public int Add(string args)
        {

            //if()


            var delimiters = ParseDelimiters(args);
            args = TruncateArguments(args);
            var result = Add(args, delimiters); 
            return result;
        }
        private static string[] ParseDelimiters(string args)
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
            var delimiters = new[] { ParseDelimiter(args) };
            return delimiters;
        }
        private static string ParseDelimiter(string args)
        {
            var result = Regex.Match(args, @"//(.+?)\n").Groups[1].Value;
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
            return args.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Sum();
        }
    }
}
