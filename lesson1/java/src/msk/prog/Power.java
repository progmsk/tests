package msk.prog;

import java.math.BigInteger;

public class Power {
    public static BigInteger calculate(int base, int exp) {
        BigInteger result = BigInteger.valueOf(1);
        for (int i = 0; i < exp; i++) {
            result = result.multiply(BigInteger.valueOf(base));
        }
        return result;
    }
}
