using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    public abstract class Function
    {
        protected readonly double[] arguments;
        
        public Function(double[] arguments, string name)
        {
            if (arguments.Length == 0) throw new Exception($"Функция {name} должна принимать хотя бы один аргумент.");
            this.arguments = arguments;
        }
        public abstract double Call();
        public double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
    }
}
