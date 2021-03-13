using Calculator.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    public class BinaryNode : Node
    {

        private Node leftNode;                         
        private Node rightNode;
        private Func<double, double, double> op;   
        
        public BinaryNode(Node leftNode, Node rightNode, Func<double, double, double> op)
        {
            this.leftNode = leftNode;
            this.rightNode = rightNode;
            this.op = op;
        }

        public override double Eval(IContext context = null)
        {
            var leftNodeEvaluationResult = leftNode.Eval(context);
            var rightNodeEvaluationResult = rightNode.Eval(context);
            var result = op(leftNodeEvaluationResult, rightNodeEvaluationResult);
            return result;
        }
    }
}
