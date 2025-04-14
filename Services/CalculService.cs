using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Extensions.Primitives;

namespace algorithms.Services
{
    public class CalculService
    {
        public CalculService(string text) 
        {
            

            double a = 1;
            double b = 2;
            double c = 3;
            // ParameterExpression par1 = Expression.Parameter(typeof(double), "a");
            // ParameterExpression par2 = Expression.Parameter(typeof(double), "b");
            // ConstantExpression par1 = Expression.Constant(a);
            // ConstantExpression par2 = Expression.Constant(b);

            //BinaryExpression multyplyExpression = Expression.Multiply(par1, par2);

            //ConstantExpression par3 = Expression.Constant(c);

            //BinaryExpression addExpression = Expression.Add(multyplyExpression, par3);

            /*
            Expression<Func<double>> lambdaExpression =
                    Expression.Lambda<Func<double>>(addExpression);

            Func<double> compiledLambda = lambdaExpression.Compile();
            var result = compiledLambda();  */

            text = "3+4*5";

            string stringValue = "";
            List<String> partsEquation = new List<String>();

            //foreach (var item in text)
            for (int i = 0; i < text.Length; i++)
            {
                var item = text[i];

                if (char.IsDigit(item) || item == '.')
                {
                    stringValue += item;
                    if (i == text.Length-1) partsEquation.Add($"{stringValue}");

                    continue;
                }
               
                if (stringValue != "")
                {
                    partsEquation.Add(stringValue);
                    stringValue = "";

                    if (item != ' ') partsEquation.Add($"{item}");

                    continue;
                }

                if (item == ' ')
                {
                    if (i == text.Length - 1) partsEquation.Add($"{stringValue}");
                    continue;
                }

                partsEquation.Add($"{item}");        
            }

            var resultT = RecursionLambda(partsEquation);

           // Expression<Func<double>> lambdaExpression =
           //         Expression.Lambda<Func<double>>(resultT);

          //  Func<double> compiledLambda = lambdaExpression.Compile();
           // var result = compiledLambda();
        }

        private int RecursionLambda(List<String> partsEquation)
        {
            //BinaryExpression
            // for (int i = 0; i < partsEquation.Count; i++)
            // {

            // ((4*3) + 6) / 2 - (4+2)

            //      var binaryExpression = nextBinaryExpression(partsEquation, i);
            //}
            var resultsMultiply = partsEquation.Where(x => x == "*").ToList();

            return 0;
        }

        private void nextBinaryExpression(List<String> partsEquation, int i)
        {
            //BinaryExpression
            if (partsEquation[i] == "(")
            {
                // ((4*3) + 6) / 2 - (4+2)
                int indexNext = i;
                indexNext++;
               // var binaryExpression = nextBinaryExpression(partsEquation, indexNext);
            }
            if (double.TryParse(partsEquation[i], out double value)) {
                var expression = ExpressionBinary("+", Expression.Constant(value), Expression.Constant(0));
               // return expression;
            }




           // return expression;
        }

        private BinaryExpression ExpressionBinary(string sign, Expression par1, Expression par2)
        {
            //ConstantExpression par1 = Expression.Constant(a);
            //ConstantExpression par2 = Expression.Constant(b);
            //BinaryExpression expression = BinaryExpression.Default(double);


            if (sign == "+")
            {
                BinaryExpression expression = Expression.Add(par1, par2);
                return expression;
            }
            if (sign == "-")
            {
                BinaryExpression expression = Expression.Subtract(par1, par2);
                return expression;
            }
            if (sign == "*")
            {
                BinaryExpression expression = Expression.Multiply(par1, par2);
                return expression;
            }
            if (sign == "/")
            {
                BinaryExpression expression = Expression.Divide(par1, par2);
                return expression;
            }
            if (sign == "^")
            {
                BinaryExpression expression = Expression.Power(par1, par2);
                return expression;
            }
       
                
            
            // BinaryExpression addExpression = Expression.Add(multyplyExpression, par3);

            return null;
        }
    }
}
