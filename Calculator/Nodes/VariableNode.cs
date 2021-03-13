using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    public class VariableNode : Node
    {
        string _variableName;
        public VariableNode(string variableName)
        {
            _variableName = variableName;
        }

        public override double Eval(IContext ctx)
        {
            return ctx.ResolveVariable(_variableName);
        }

    }
}

