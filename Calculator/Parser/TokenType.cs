using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Parser
{
    public enum TokenType
    {
        EOF,
        Add,
        Subtract,
        Muliple,
        Divide,
        Pow,
        OpenParens,
        CloseParens,
        Number,
        Identifier,
        Comma
    }
}
