namespace algorithms.Services
{
    public class CalculService
    {
        public CalculService(string text) 
        {
            string stringDecimal = "";

            foreach (var item in text)
            {
                if (item == ' ') continue;

                if (item == '(') continue;

                if(char.IsDigit(item) || item == '.')
                {
                    stringDecimal += item;
                }
                if (!string.IsNullOrEmpty(stringDecimal))
                {
                    decimal.TryParse(stringDecimal, out decimal number);
                }
            }
        }

        private decimal RecursionLambda()
        {
            return 0;
        }
    }
}
