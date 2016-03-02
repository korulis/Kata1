using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringAdditionTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1",1)]
        [InlineData("2", 2)]
        [InlineData("1,2", 3)]
        [InlineData("10",10)]
        [InlineData("2,3",5)]
        [InlineData("1\n2,3",6)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//;\n3;2", 5)] 
        public void AddReturnsSumOfParameters(string parameters, int expected)
        {   
            //set up
            var sut = new StringCalculator();
            //exercise sut
            var actual = sut.Add(parameters);
            //assert
            Assert.Equal(expected, actual);
        }
    }
}
