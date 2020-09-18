using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers
{
    class Run
    {
        public void run() {
            BigInteger a = new BigInteger();
            BigInteger b = new BigInteger();
            BigInteger res=new BigInteger();
            char ch='0';
            Console.WriteLine("Arithmetic with big numbers");
            do
            {
                Console.WriteLine("\nEnter arithmetic operator + - * / Exit enter @");
                ch = char.Parse(Console.ReadLine());
                if (ch == '@')
                    break;
                Console.WriteLine("Enter first number");
                a.initialize(Console.ReadLine());
                Console.WriteLine("Enter second number");
                b.initialize(Console.ReadLine());
                switch (ch) { 
                    case '+':
                        res = res.plus(a, b);
                        break;
                    case '-':
                        res= res.minus(a,b);
                        break;
                    case '*':
                        res = res.multiply(a, b);
                        break;
                    case '/':
                        res = res.division(a, b);
                        break;
                }
                Console.WriteLine("\nResult = " + res.ToString());
            } while (ch != '@');
        }
    }
}
