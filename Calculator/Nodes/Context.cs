using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Nodes
{
    public class Context : IContext
    {
        private double x;
        public Context(double x)
        {
            this.x = x;
        }
        public Context()
        {

        }
        public double CallFunction(string name, double[] arguments)
        {
            name = name.ToLowerInvariant();
            switch (name)
            {
                case "sin":
                    return new SinFunction(arguments,name).Call();
                case "cos":
                    return new CosFunction(arguments, name).Call();
                case "tg":
                    return new TanFunction(arguments, name).Call();
                case "ctg":
                    return new CtgFunction(arguments, name).Call();
                case "log":
                    return new LogFunction(arguments, name).Call();
            }
            throw new Exception($"Неизвестная функция: '{name}'");
        }

        public double ResolveVariable(string name)
        {
            switch (name)
            {
                case "pi": return Math.PI;
                case "x":  return x;
            }
            throw new Exception($"Неизвестная переменная: '{name}'");
        }

        
    }
}
