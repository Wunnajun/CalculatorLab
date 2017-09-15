using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            Stack<string> rpnStack = new Stack<string>();
           List<string> parts = new List<string>();
            try
            { 
                parts = str.Split(' ').ToList<string>();
            }
            catch (Exception e)
            {
                //  Console.WriteLine("Exception is caught ");
                Console.WriteLine(e.StackTrace); //Show when have problem show in Output 
            }

            string result;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (isNumber(token))
                {
                    int i;
                    for (i=0; )
                }
                if (isNumber(token))
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?

                    if (rpnStack.Count >= 2)
                    { 
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        if (isOperator(firstOperand) || isOperator(secondOperand))
                            return "E";
                    }else
                    {
                        return "E";
                    }
                        result = calculate(token, firstOperand, secondOperand, 4);

                    if (result is "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if (rpnStack.Count != 0)
                result = rpnStack.Pop();
            else
                result = "E";
            return result;
        }
    }
}
