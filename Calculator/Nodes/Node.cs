using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    public abstract class Node
    {
        public abstract double Eval(IContext context = null);
        
        
    }
    
}
