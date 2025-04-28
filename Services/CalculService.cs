using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Primitives;

namespace algorithms.Services
{
    public class CalculService
    {
        public double CalculetService(string text) 
        {
            string stringValue = "";
            List<String> partsEquation = new List<String>();

            for (int i = 0; i < text.Length; i++)
            {
                var item = text[i];

                if (char.IsDigit(item) || item == '.')
                {
                    stringValue += item;
                    if (i == text.Length-1) partsEquation.Add($"{stringValue}");

                    continue;
                };
               
                if (stringValue != "")
                {
                    partsEquation.Add(stringValue);
                    stringValue = "";

                    if (item != ' ') partsEquation.Add($"{item}");

                    continue;
                };

                if (item == ' ')
                {
                    if (i == text.Length - 1) partsEquation.Add($"{stringValue}");
                    continue;
                };

                if (item == '-' || item == '+')
                {
                   if (i == 0)
                    {
                        stringValue += item;
                        continue;
                    };
                   
                    if (partsEquation[partsEquation.Count() - 1] == "(")
                    {
                        stringValue += item;
                        continue;
                    };
                };

                partsEquation.Add($"{item}");        
            }

            var resultT = RecursionLambda(partsEquation, 0, partsEquation.Count());

            Expression<Func<double>> lambdaExpression =
                    Expression.Lambda<Func<double>>(resultT);

            Func<double> compiledLambda = lambdaExpression.Compile();
            var result = compiledLambda();

            return result;
        }

        private Expression RecursionLambda(List<String> partsEquation, int start, int end)
        {

            var operators = new Stack<string>();
            var operands = new Stack<Expression>();

            for (int i = start; i < end; i++)
            {
                var value = partsEquation[i];
                if (double.TryParse(value, out double valueDouble))
                {
                    operands.Push(Expression.Constant(valueDouble));
                }
                else if (value == "*" || value == "/" || value == "^" || value == "+" || value == "-")
                {

                    while (operators.Count > 0 && PriorityOperator(operators.Peek()) >= PriorityOperator(value))
                    {
                        ExpressionBinary(operators.Pop(), operands);
                    }

                    operators.Push(value);
                }
                else if (value == "(")
                {
                    int s = i + 1;
                    int e = i + 1;
                    int numberBrackets = 0;
                    for (int ie = e; ie < end; ie++)
                    {
                        var v = partsEquation[ie];
                        if (v == ")")
                        {
                            if (numberBrackets == 0)
                            {
                                e = ie;
                                break;
                            }
                            else
                            {
                                numberBrackets--;
                            }
                        }
                        if (v == "(")
                        {
                            numberBrackets++;
                        }
                    }
                    operands.Push(RecursionLambda(partsEquation, s, e));
                    i = e;
                }
            }

            while (operators.Count > 0)
            {
                ExpressionBinary(operators.Pop(), operands);
            }

            return operands.Pop();
        }
 
        private int PriorityOperator(string op)
        {
            return op switch
            {
                "+" or "-" => 1,
                "*" or "/" => 2,
                "^" => 3,
                _ => 0
            };
        }

        private void ExpressionBinary(string sign, Stack<Expression> operands)
        {
            var right = operands.Pop();
            var left = operands.Pop();

            switch(sign) {

                case "+":
                    operands.Push(Expression.Add(left, right));
                    break;
                case "-":
                    operands.Push(Expression.Subtract(left, right));
                    break;
                case "*":
                    operands.Push(Expression.Multiply(left, right));
                    break;
                case "/":
                    operands.Push(Expression.Divide(left, right));
                    break;
                case "^":
                    operands.Push(Expression.Power(left, right));
                    break;
            }
        }
    }
}
