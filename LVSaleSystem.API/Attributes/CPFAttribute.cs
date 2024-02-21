using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Attributes
{
    public class CPFAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(string.IsNullOrEmpty(value.ToString()) || value == null)
                return false;

            
            string input = value.ToString();

            input = new string(input.Where(char.IsDigit).ToArray());

            if (input.Length != 11)
                return false;

            if (input.All(c => c == input[0]))
                return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (input[i] - '0') * (10 - i);

            int remainder = (sum * 10) % 11;

            if (remainder == 10) remainder = 0;

            if (input[9] != remainder + '0')
                return false;

            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (input[i] - '0') * (11 - i);

            remainder = (sum * 10) % 11;

            if (remainder == 10) remainder = 0;

            if (input[10] != remainder + '0')
                return false;

            return true;
        }
    }
}
