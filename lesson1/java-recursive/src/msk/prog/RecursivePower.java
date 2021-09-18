package msk.prog;

import java.math.BigInteger;

public class RecursivePower {
    public static BigInteger calc(int base, int exponent) {
        if (exponent < 0)
            throw new IllegalArgumentException();

        if (exponent == 0)
            return BigInteger.ONE;

        if (exponent == 1)
            return BigInteger.valueOf(base);

        if (exponent % 2 == 0)
            return calc(base, exponent/2).multiply(calc(base, exponent/2));

        return BigInteger.valueOf(base).multiply(calc(base, exponent-1));
    }
}