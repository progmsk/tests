package msk.prog;

import java.math.BigInteger;

public class Power {

    public static BigInteger calculate(int base, Exponent exp) {
        BigInteger result = BigInteger.valueOf(1);

        BigInteger newBase = BigInteger.valueOf(base);
        int newExp = exp.getValue();

        while (newExp > 0) {
            if (isEven(newExp)) {
                newBase = newBase.multiply(newBase);
                newExp /= 2;
            } else {
                result = result.multiply(newBase);
                newExp--;
            }
        }

        return result;
    }

    public static boolean isEven(int value) {
        return value % 2 == 0;
    }
}
