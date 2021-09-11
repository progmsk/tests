using System;
using System.Numerics;

namespace Power
{
    public class Program
    {
        public static BigInteger Power(BigInteger @base, int exponent)
        {
            if (exponent < 0)
                throw new ArgumentOutOfRangeException(nameof(exponent));

            BigInteger result = 1;

            while (exponent > 0)
            {
                if (exponent % 2 == 0)
                {
                    @base *= @base;
                    exponent /= 2;
                }
                else
                {
                    result *= @base;
                    exponent--;
                }
            }

            return result;
        }

        public static BigInteger OldPower(BigInteger @base, int exponent)
        {
            if (exponent < 0)
                throw new ArgumentOutOfRangeException(nameof(exponent));

            BigInteger result = 1;

            for (int i = 0; i < exponent; i++)
                result *= @base;

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Power(3, 1000));
        }
    }
}
