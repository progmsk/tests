package msk.prog;

import java.math.BigInteger;

public class Power {
    public static BigInteger calculate(int base, Exponent exp) {
        BigInteger result = BigInteger.valueOf(1);

        BigInteger newBase = BigInteger.valueOf(base);
        int newExp = exp.getValue();
        while(newExp > 0) {
            if (newExp %2 == 0) {
                newBase = newBase.multiply(newBase);
                newExp /= 2;
            } else {
                result = result.multiply(newBase);
                newExp --;
            }
        }

        return result;
    }
}
