using Calculator.Parser;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestFixture]
    public class TokenizerTests
    {

        private static readonly object[] TestCases =
        {
            new TestCaseData( "10 + 20 - 30.123", new List<TokenType>(){ TokenType.Number, TokenType.Add, TokenType.Number, TokenType.Subtract, TokenType.Number} ).SetName("TokenizerSuccessTests"),
            new TestCaseData( "10 * 20 / 30.123", new List<TokenType>(){ TokenType.Number, TokenType.Muliple, TokenType.Number, TokenType.Divide, TokenType.Number} ).SetName("TokenizerSuccessTests1"),
            new TestCaseData( "10 + 20 / 30.123", new List<TokenType>(){ TokenType.Number, TokenType.Add, TokenType.Number, TokenType.Divide, TokenType.Number} ).SetName("TokenizerSuccessTests2"),
            new TestCaseData( "10 * 20 - 30.123", new List<TokenType>(){ TokenType.Number, TokenType.Muliple, TokenType.Number, TokenType.Subtract, TokenType.Number} ).SetName("TokenizerSuccessTests3"),
            new TestCaseData( "(10 * 20) - 30.123", new List<TokenType>(){ TokenType.OpenParens, TokenType.Number, TokenType.Muliple, TokenType.Number, TokenType.CloseParens, TokenType.Subtract, TokenType.Number} ).SetName("TokenizerSuccessTests4"),
            new TestCaseData( "10^10", new List<TokenType>(){ TokenType.Number, TokenType.Pow, TokenType.Number} ).SetName("TokenizerSuccessTests5"),
            new TestCaseData( "10,10", new List<TokenType>(){ TokenType.Number, TokenType.Comma, TokenType.Number} ).SetName("TokenizerSuccessTests6"),
        };


        [Test, TestCaseSource("TestCases")]
        public void TokenizerSuccessTests(string expression, List<TokenType> tokenTypes) 
        {
            var t = new Tokenizer(new StringReader(expression));
            int index = 0;
            while (t.CurrentTokenType != TokenType.EOF) 
            {
                Assert.AreEqual(t.CurrentTokenType, tokenTypes[index]);
                t.NextToken();
                index++;
            }
        }
    }
}
