package msk.prog;

import org.junit.jupiter.api.Test;

import java.math.BigInteger;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

public class PowerTest {

    @Test
    public void when1WithExp2Then1() {
        BigInteger result = Power.calculate(1, new Exponent(2));
        assertEquals(BigInteger.valueOf(1), result);
    }

    @Test
    public void when2WithExp3Then8() {
        BigInteger result = Power.calculate(2, new Exponent(3));
        assertEquals(BigInteger.valueOf(8), result);
    }

    @Test
    public void when3WithExp1000ThenBigNumber() {
        BigInteger result = Power.calculate(3, new Exponent(1000));
        assertEquals(new BigInteger(
                "1322070819480806636890455259752144365965422032752148167664920368226828597346704899540778313850608061963909777696872582355950954582100618911865342725257953674027620225198320803878014774228964841274390400117588618041128947815623094438061566173054086674490506178125480344405547054397038895817465368254916136220830268563778582290228416398307887896918556404084898937609373242171846359938695516765018940588109060426089671438864102814350385648747165832010614366132173102768902855220001"
        ), result);
    }

    @Test
    public void when4WithExp0Then1() {
        BigInteger result = Power.calculate(4, new Exponent(0));
        assertEquals(BigInteger.valueOf(1), result);
    }

    @Test
    public void when0WithExp0Then1() {
        BigInteger result = Power.calculate(4, new Exponent(0));
        assertEquals(BigInteger.valueOf(1), result);
    }

    @Test
    public void when4WithExpNegativeThenError() {
        assertThrows(IllegalArgumentException.class, () -> {
            Power.calculate(4, new Exponent(-5));
        });
    }


}
