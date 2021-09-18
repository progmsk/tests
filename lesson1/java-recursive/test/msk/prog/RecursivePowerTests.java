package msk.prog;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.Arguments;
import org.junit.jupiter.params.provider.MethodSource;

import java.math.BigInteger;
import java.util.stream.Stream;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

class RecursivePowerTests {

    @Test
    public void Power_base1AndExponentNegative_throwsException() {
        assertThrows(IllegalArgumentException.class, () -> RecursivePower.calc(1, -1));
    }

    private static Stream<Arguments> provideTableArguments() {
        return Stream.of(
                Arguments.of(BigInteger.ONE, 0, 0),
                Arguments.of(BigInteger.ONE, 1, 0),
                Arguments.of(BigInteger.ONE, 2, 0),
                Arguments.of(BigInteger.ONE, 1, 1),
                Arguments.of(BigInteger.valueOf(2), 2, 1),
                Arguments.of(BigInteger.valueOf(4), 2, 2),
                Arguments.of(BigInteger.valueOf(8), 2, 3),
                Arguments.of(BigInteger.valueOf(1048576), 2, 20),
                Arguments.of(new BigInteger("1125899906842624"), 2, 50)
        );
    }

    @ParameterizedTest
    @MethodSource("provideTableArguments")
    public void powerShouldBe_whenBase_andExponent(BigInteger expected, int base, int exponent) {
        assertEquals(expected, RecursivePower.calc(base, exponent));
    }

}
