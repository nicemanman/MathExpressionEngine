using Calculator.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parser
{
    public class ExpressionParser
    {
        private readonly Tokenizer tokenizer;
        public ExpressionParser(Tokenizer tokenizer)
        {
            this.tokenizer = tokenizer;
        }
        public Node ParseExpression() 
        {
            var expr = ParseAddSubtract();
            if (tokenizer.CurrentTokenType != TokenType.EOF)
                throw new Exception("Неизвестные символы в конце выражения");
            return expr;
        }

        private Node ParseAddSubtract() 
        {
            var leftNode = ParseMultipleDivide();
            while (true) 
            {
                Func<double, double, double> op = null;
                if (tokenizer.CurrentTokenType == TokenType.Add)
                {
                    op = (a, b) => a + b;
                }
                else if (tokenizer.CurrentTokenType == TokenType.Subtract)
                {
                    op = (a, b) => a - b;
                }
                if (op == null) 
                {
                    return leftNode;
                }
                tokenizer.NextToken();
                var rightNode = ParseMultipleDivide();
                leftNode = new BinaryNode(leftNode, rightNode, op);
            }
        }

        private Node ParseMultipleDivide()
        {
            var leftNode = ParseUnary();
            while (true)
            {
                Func<double, double, double> op = null;
                if (tokenizer.CurrentTokenType == TokenType.Muliple)
                {
                    op = (a, b) => a * b;
                }
                else if (tokenizer.CurrentTokenType == TokenType.Divide)
                {
                    op = (a, b) => a / b;
                }
                else if (tokenizer.CurrentTokenType == TokenType.Pow)
                {
                    op = (a, b) => Math.Pow(a,b);
                }
                if (op == null)
                {
                    return leftNode;
                }
                tokenizer.NextToken();
                var rightNode = ParseUnary();
                leftNode = new BinaryNode(leftNode, rightNode, op);
            }
        }
        private Node ParseUnary()
        {
            //Если встретили '+' то пропускаем
            if (tokenizer.CurrentTokenType == TokenType.Add)
            {
                tokenizer.NextToken();
                return ParseUnary();
            }

            if (tokenizer.CurrentTokenType == TokenType.Subtract)
            {
                tokenizer.NextToken();
                var rhs = ParseUnary();
                return new UnaryNode(rhs, (a) => -a);
            }

            return ParseLeaf();
        }
        private Node ParseLeaf()
        {
            if (tokenizer.CurrentTokenType == TokenType.Number)
            {
                var node = new NumberNode(tokenizer.CurrentNumber);
                tokenizer.NextToken();
                return node;
            }
            if (tokenizer.CurrentTokenType == TokenType.OpenParens)
            {
                tokenizer.NextToken();
                var node = ParseAddSubtract();
                if (tokenizer.CurrentTokenType != TokenType.CloseParens)
                    throw new Exception("Missing close parenthesis");
                tokenizer.NextToken();
                return node;
            }
            if (tokenizer.CurrentTokenType == TokenType.Identifier)
            {
                var name = tokenizer.Identifier;
                tokenizer.NextToken();
                if (tokenizer.CurrentTokenType != TokenType.OpenParens)
                {
                    return new VariableNode(name);
                }
                else
                {
                    tokenizer.NextToken();
                    var arguments = new List<Node>();
                    while (true)
                    {
                        arguments.Add(ParseAddSubtract());

                        if (tokenizer.CurrentTokenType == TokenType.Comma)
                        {
                            tokenizer.NextToken();
                            continue;
                        }

                        break;
                    }

                    if (tokenizer.CurrentTokenType != TokenType.CloseParens)
                        throw new Exception("Отсутствует закрывающая скобка");
                    tokenizer.NextToken();
                    return new NodeFunctionCall(name, arguments.ToArray());
                }
            }
                throw new Exception($"Неизвестный тип токена: {tokenizer.CurrentTokenType}");
        }

        public static Node Parse(string str)
        {
            return Parse(new Tokenizer(new StringReader(str)));
        }

        public static Node Parse(Tokenizer tokenizer)
        {
            var parser = new ExpressionParser(tokenizer);
            return parser.ParseExpression();
        }
    }
}
