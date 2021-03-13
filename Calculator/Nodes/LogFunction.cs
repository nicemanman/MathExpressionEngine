using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    public class LogFunction : Function
    {
        public LogFunction(double[] arguments, string name) : base(arguments, name)
        {
            if (arguments.Length == 1) throw new Exception($"Функция '{name}' принимает ДВА аргумента");
            if (arguments.Length > 2) throw new Exception($"Функция '{name}' не принимает больше двух аргументов");
        }

        public override double Call()
        {
            return Math.Log(arguments[1], arguments[0]);
        }
    }
}
