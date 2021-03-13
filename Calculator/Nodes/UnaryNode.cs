using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    public class UnaryNode : Node
    {
        public UnaryNode(Node rightNode, Func<double, double> op)
        {
            this.rightNode = rightNode;
            action = op;
        }

        Node rightNode;                             
        Func<double, double> action;              

        public override double Eval(IContext context = null)
        {
            var rightNodeValue = rightNode.Eval();
            var result = action(rightNodeValue);
            return result;
        }
    }
}
