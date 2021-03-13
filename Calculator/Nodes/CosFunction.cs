using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    class CosFunction : Function
    {
        public CosFunction(double[] arguments, string name) : base(arguments, name)
        {
            if (arguments.Length > 1) throw new Exception($"Функция '{name}' не принимает больше одного аргумента");
        }

        public override double Call()
        {
            return Math.Round(Math.Cos(DegreesToRadians(arguments[0])), 2);
        }
    }
}
