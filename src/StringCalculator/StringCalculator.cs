using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string args)
        {
            var delimiters = new[] { ',', '\n' };
            if (args.StartsWith(@"//"))
            {
                args = args.Substring(4);
                delimiters = new[] {';'};
            }
            var result = Add2(args, delimiters); 
            return result;
        }

        private int Add2(string args, char[] delimiters)
        {
            return args.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Sum();
        }
    }
}
