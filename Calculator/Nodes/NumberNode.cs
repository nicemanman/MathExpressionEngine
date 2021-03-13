using Calculator.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    public class NumberNode : Node
    {
        private double number;             
        public NumberNode(double number)
        {
            this.number = number;
        }
        public override double Eval(IContext context = null)
        {
            return number;
        }
    }
}
