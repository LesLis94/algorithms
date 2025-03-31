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
           ConstantExpression par1 = Expression.Constant(a);
            ConstantExpression par2 = Expression.Constant(b);

            BinaryExpression multyplyExpression = Expression.Multiply(par1, par2);

            ConstantExpression par3 = Expression.Constant(c);

            BinaryExpression addExpression = Expression.Add(multyplyExpression, par3);

            Expression<Func<double>> lambdaExpression =
                    Expression.Lambda<Func<double>>(addExpression);

            Func<double> compiledLambda = lambdaExpression.Compile();
            var result = compiledLambda();




            string stringValue = "";
            List<String> partsEquation = new List<String>();

            foreach (var item in text)
            {
                if (char.IsDigit(item) || item == '.')
                {
                    stringValue += item;
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
                    continue;
                }

                partsEquation.Add($"{item}");        
            }
        }

        private decimal RecursionLambda()
        {
            return 0;
        }
    }
}
