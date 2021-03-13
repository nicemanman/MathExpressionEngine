using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    public class CtgFunction : Function
    {
        public CtgFunction(double[] arguments, string name) : base(arguments, name)
        {
            if (arguments.Length > 1) throw new Exception($"Функция '{name}' не принимает больше одного аргумента");
        }

        public override double Call()
        {
            if (arguments[0] % 180 == 0) throw new Exception($"Значения функции 'tg' для угла {arguments[0]} градусов не существует");
            double result = Math.Tan(DegreesToRadians(arguments[0]));
            return Math.Round(result, 2);
        }
    }
}
