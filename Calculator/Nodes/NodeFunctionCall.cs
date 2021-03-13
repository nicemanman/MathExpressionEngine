using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    public class NodeFunctionCall : Node
    {
        public NodeFunctionCall(string functionName, Node[] arguments)
        {
            this.functionName = functionName;
            this.arguments = arguments;
        }

        string functionName;
        Node[] arguments;

        public override double Eval(IContext ctx)
        {
            var argVals = new double[arguments.Length];
            for (int i = 0; i < arguments.Length; i++)
            {
                argVals[i] = arguments[i].Eval(ctx);
            }
            return ctx.CallFunction(functionName, argVals);
        }
    }
}
