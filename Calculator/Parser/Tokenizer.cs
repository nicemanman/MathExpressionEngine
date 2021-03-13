using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parser
{
    public class Tokenizer
    {
        private readonly TextReader reader;

        private TokenType currentTokenType;
        private double currentNumber;
        private char currentChar;
        private string identifier;

        public TokenType CurrentTokenType { get => currentTokenType; }
        public double CurrentNumber { get => currentNumber; }
        public string Identifier { get => identifier; }

        public Tokenizer(TextReader reader)
        {
            this.reader = reader;
            NextChar();
            NextToken();
        }

        public void NextToken() 
        {
            while (char.IsWhiteSpace(currentChar)) 
            {
                NextChar();
            }
            // Special characters
            switch (currentChar)
            {
                case '\0':
                    currentTokenType = TokenType.EOF;
                    return;

                case '+':
                    NextChar();
                    currentTokenType = TokenType.Add;
                    return;

                case '-':
                    NextChar();
                    currentTokenType = TokenType.Subtract;
                    return;
                case '/':
                    NextChar();
                    currentTokenType = TokenType.Divide;
                    return;
                case '*':
                    NextChar();
                    currentTokenType = TokenType.Muliple;
                    return;
                case '^':
                    NextChar();
                    currentTokenType = TokenType.Pow;
                    return;
                case '(':
                    NextChar();
                    currentTokenType = TokenType.OpenParens;
                    return;
                case ')':
                    NextChar();
                    currentTokenType = TokenType.CloseParens;
                    return;
                case ',':
                    NextChar();
                    currentTokenType = TokenType.Comma;
                    return;
            }
            //считываем числа
            if (char.IsDigit(currentChar) || currentChar == '.') 
            {
                var sb = new StringBuilder();
                bool haveDecimalPoint = false;
                while (char.IsDigit(currentChar) || (!haveDecimalPoint && currentChar == '.')) 
                {
                    sb.Append(currentChar);
                    haveDecimalPoint = currentChar == '.';
                    NextChar();
                }
                currentNumber = double.Parse(sb.ToString(), CultureInfo.InvariantCulture);
                currentTokenType = TokenType.Number;
                return;
            }
            //считываем переменные
            if (char.IsLetter(currentChar) || currentChar == '_')
            {
                var sb = new StringBuilder();
                while (char.IsLetter(currentChar) || currentChar == '_')
                {
                    sb.Append(currentChar);
                    NextChar();
                }
                identifier = sb.ToString();
                currentTokenType = TokenType.Identifier;
                return;
            }
            throw new InvalidDataException($"Неожиданный символ: {currentChar}");
        }
        private void NextChar() 
        {
            int ch = reader.Read();
            currentChar = ch < 0 ? '\0' : (char)ch;
        }

    }
}
