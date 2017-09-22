using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        protected Stack<string> mystack;

       

        public new string calculate(string str)
        {
            Stack<string> myStack = new Stack<string>();
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
                    for(i=0;i<token.Length;i++)
                    {
                        if (token[i] == '+')
                            return "E";
                    }
                    //for (i=0; )
                }
                if (isNumber(token))
                {
                    myStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?

                    if (myStack.Count >= 2)
                    { 
                        secondOperand = myStack.Pop();
                        firstOperand = myStack.Pop();
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
                    myStack.Push(result);
                }
                else
                {
                    int i;
                    for (i = 0; i < token.Length; i++) //perm ma ton nee
                    {
                        if (token[i] == '+') //if plus ++ ซ้ำๆ
                            return "E";
                    }
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if (myStack.Count != 1)
                return "E";
                
            else
            result = myStack.Pop();
            return result;
        }
    }
}
