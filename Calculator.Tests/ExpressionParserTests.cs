using Calculator.Nodes;
using Calculator.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestFixture]
    public class ExpressionParserTests
    {
        [Test]
        [TestCase("10 + 20",30)]
        [TestCase("10 - 20",-10)]
        [TestCase("10 + 20 - 40 + 100", 90)]
        [TestCase("-10", -10)]
        [TestCase("+10", 10)]
        [TestCase("--10", 10)]
        [TestCase("--++-+-10", 10)]
        [TestCase("10 + -20 - +30", -40)]

        public void AddSubtractTest(string expression, double actualResult) 
        {
            Assert.AreEqual(ExpressionParser.Parse(expression).Eval(), actualResult);
        }

        [Test]
        [TestCase("10 * 20", 200)]
        [TestCase("(10 + 20)*200", 6000)]
        [TestCase("10 + 20/200", 10.1)]
        [TestCase("2 + 2/2", 3)]
        [TestCase("(2 + 2)/2", 2)]
        public void MultipleDivideTests(string expression, double actualResult) 
        {
            Assert.That(ExpressionParser.Parse(expression).Eval().AlmostEqualTo(actualResult));
        }

        [Test]
        [TestCase("2 * pi * x", 10, 62.831853)]
        public void VariableTests(string expression, double var, double actualResult)
        {
            var ctx = new Context(var);
            Assert.That(ExpressionParser.Parse(expression).Eval(ctx).AlmostEqualTo(actualResult));
        }
        [Test]
        [TestCase("2 ^ 2", 4)]
        [TestCase("2 ^ 2 ^ 2", 16)]
        [TestCase("2 ^ 2 ^ 2 ^ 2", 256)]
        public void PowTests(string expression, double actualResult)
        {
            
            Assert.That(ExpressionParser.Parse(expression).Eval().AlmostEqualTo(actualResult));
        }
        [Test]
        [TestCase("sin(90)", 1.00)]
        [TestCase("cos(90)", 0.00)]
        [TestCase("tg(45)", 1)]
        [TestCase("ctg(45)", 1)]
        [TestCase("ctg(45)+ctg(45)", 2)]
        [TestCase("ctg(9*5)+ctg(9*5)", 2)]
        [TestCase("ctg(9*5)+ctg(9*4+9)", 2)]
        public void FunctionsTests(string expression, double actualResult)
        {
            var ctx = new Context(0);
            Assert.That(ExpressionParser.Parse(expression).Eval(ctx).AlmostEqualTo(actualResult));
        }

        [Test]
        [TestCase("tg(90)")]
        [TestCase("tg(270)")]
        [TestCase("ctg(0)")]
        [TestCase("ctg(180)")]
        [TestCase("ctg(360)")]
        public void FunctionsTests2(string expression)
        {
            var ctx = new Context(0);
            Assert.Throws(typeof(Exception), () => ExpressionParser.Parse(expression).Eval(ctx));
        }
    }
}
