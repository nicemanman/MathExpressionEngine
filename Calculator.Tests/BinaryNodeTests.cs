using Calculator.Nodes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestFixture]
    public class BinaryNodeTests
    {
        [Test]
        [TestCase(10,20,30)]
        [TestCase(-10, 20, 10)]
        [TestCase(10, -20, -10)]
        [TestCase(10.5, -20.1, -9.6)]
        public void EvaluatingAddTest(double leftOperand, double rightOperand, double actualResult) 
        {
            var expr = new BinaryNode(new NumberNode(leftOperand), new NumberNode(rightOperand), new Func<double, double, double>((a, b) => a + b));
            var result = expr.Eval();
            Assert.That(result.AlmostEqualTo(actualResult));
        }
    }
}
