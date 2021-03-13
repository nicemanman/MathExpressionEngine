
using Calculator.Nodes;
using Calculator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите математические выражение. Допустимые лексемы - +,-,/,*,^,sin,cos,tg,ctg. Также вы можете вводить числа с плаващей точкой - 4.1");
            var key = Console.ReadLine();
            var context = new Context();
            try
            {
                Console.WriteLine(ExpressionParser.Parse(key).Eval(context));
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
