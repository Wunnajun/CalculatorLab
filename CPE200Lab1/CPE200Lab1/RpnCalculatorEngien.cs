using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; //use to Stack


namespace CPE200Lab1
{
    class RpnCalculatorEngine : CalculatorEngine
    {
        //private CalculatorEngine engine;
        public RpnCalculatorEngine()
        {
            //engine = new CalculatorEngine();
        }
        public string Method(string str)
        {
            /* Stack testStack = new Stack();
             testStack.Push("1st element");
             testStack.Push("2st element"); 
             testStack.Pop();
             Console.Out.WriteLine(testStack.Pop()); //เอาไว้ทดเลขเวลาจะดูนะ*/

            string[] word = str.Split(' ');
            string result = null;
            Stack rpnStack = new Stack();
            int size = word.Length;
            string op;
            string first;
            string second;


            /* foreach (string input in parts) //
             {
                 // for (int i=0;  i < parts.Length; i++ ) {
                string input = parts[i]; // = each parts onr-by-one */

            for (int i = 0; i < size; i++)
            {
                if (isNumber(word[i]))
                {
                    rpnStack.Push(word[i]);
                }
                else if (isOperator(word[i]))
                {
                    if (word[i] == "√" || word[i] == "1/x")
                    {
                        op = word[i];
                        first = rpnStack.Pop().ToString();
                        result = unaryCalculate(op, first);
                        rpnStack.Push(result);
                    }
                    else if (word[i] == "%")
                    {
                        second = rpnStack.Pop().ToString();
                        first = rpnStack.Pop().ToString();
                        op = word[i];
                        result = calculate(op, first, second);
                        rpnStack.Push(first);
                        rpnStack.Push(result);
                    }
                    else if (word[i] == "+" || word[i] == "-" || word[i] == "X" || word[i] == "÷")
                    {
                        second = rpnStack.Pop().ToString();
                        first = rpnStack.Pop().ToString();
                        op = word[i];
                        result = calculate(op, first, second, 8);
                        rpnStack.Push(result);
                    }

                }
            }

        
           
            return result;

        }
    }

}
