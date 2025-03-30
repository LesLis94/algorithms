using System.Linq.Expressions;
using Microsoft.Extensions.Primitives;

namespace algorithms.Services
{
    public class CalculService
    {
        public CalculService(string text) 
        {
            string stringValue = "";

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





            List<String> partsEquation = new List<String>;

            foreach (var item in text)
            {
                if (item == ' ') continue;

                // if (item == '(') continue;

                if (char.IsDigit(item) || item == '.')
                {
                    stringValue += item;
                }

                //if (!string.IsNullOrEmpty(stringDecimal))
                //{
                //    decimal.TryParse(stringDecimal, out decimal number);
                // }

                partsEquation.Add(stringValue);
                // надо прописать условие, что если это число то должно быть булево которое регулирует когда число закончилось, чтобы его добавить в лист
                // тогда для всех остальных континиум должен быть свой и добавление мб типа того
                
                stringValue = "";
            }
        }

        private decimal RecursionLambda()
        {
            return 0;
        }
    }
}
