using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    [Category("Integration")]
    public class IntegrationTests
    {
        private string SendToConsole(params string[] inputs)
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                var input = inputs.Aggregate("", (current, s) => current + (s + Environment.NewLine));

                using (var reader = new StringReader(input))
                {
                    Console.SetIn(reader);

                    Program.Main();

                    return writer.ToString().Replace(Environment.NewLine, String.Empty);
                }
            }
        }

        [TestCase("2", "3", "+", 5)]
        [TestCase("3", "2", "-", 1)]
        public void Main_RunsCalculator(string num1, string num2, string operation, int expectedNumber)
        {
            var expected = string.Format("{0}{1}{2}{3}",
                "Enter a number: ",
                "Enter another number: ",
                "Enter an operator (+ or -): ",
                "Result: " + expectedNumber);

            Assert.That(SendToConsole(num1, num2, operation), Is.EqualTo(expected));
        }
    }
}
