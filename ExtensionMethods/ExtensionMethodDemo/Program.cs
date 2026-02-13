namespace ExtensionsMethodDemo
{

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Demo for String Extension Method to Mask Payment Information");
            Console.WriteLine("1234567891234567".MaskPaymentInfo(4));

            Console.WriteLine("\nDemo for String Extension Method to Validate Card Number");
            Console.WriteLine("4111-1111-1111-1111".IsValidCardNumber());
        }

    }

    public static class StringExtensions
    {
        public static string MaskPaymentInfo(this string input, int unmaskedLastChars)
        {
            return new string('*', input.Length - unmaskedLastChars) + input.Substring(input.Length - unmaskedLastChars);
        }

        public static bool IsValidCardNumber(this string cardNumber)
        {
            // Clean: remove spaces/dashes, check digits only
            string clean = new string(cardNumber.Where(char.IsDigit).ToArray());
            if (clean.Length < 13 || clean.Length > 19) return false;

            int sum = 0;
            bool isEven = false;  // Alternate doubling from right

            for (int i = clean.Length - 1; i >= 0; i--)
            {
                int digit = clean[i] - '0';
                if (isEven)
                {
                    digit *= 2;
                    if (digit > 9) digit -= 9;  // Equivalent to sum of digits
                }
                sum += digit;
                isEven = !isEven;
            }
            return sum % 10 == 0;
        }
    }
}
