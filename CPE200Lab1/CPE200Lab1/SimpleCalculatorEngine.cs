using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class SimpleCalculatorEngine : CalculatorEngine

    {
        protected double firstOperand;
        protected double secondOperand;

        public void setFirstOperand(string num)  //void it not use return
        {
            firstOperand = Convert.ToDouble(num); // change num to double and throw num to firstOperand
        }
        public void setSecondOperand(string num)
        {
            secondOperand = Convert.ToDouble(num); //change num to double and throw num to secondOperand
        }
        public string calculate(string oper,int maxOutputSize =8)
        {
            switch (oper)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != 0)
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        if ((Convert.ToDouble(firstOperand) % Convert.ToDouble(secondOperand)) == 0) //if mod = 0 will print number (10) no(10.0)

                        {
                            return result.ToString();
                            //return Convert.ToString(Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)); //bring Convert.toString 
                            // split between integer part and fractional part
                        }

                        parts = result.ToString().Split('.');

                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 2; //change -1 to -2 it calculat 0.5 
                                                                            // trim the fractional part gracefully. =
                        result = Math.Round(result, 4);
                        return result.ToString();//("N" + remainLength);
                        // return result.ToString("G29"); 
                    }
                    break;
                case "%":
                    //your code here
                    break;
            }
            return "E";
        }


    }




}

