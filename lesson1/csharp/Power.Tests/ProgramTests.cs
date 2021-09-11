using System;
using System.Numerics;
using Xunit;

namespace Power.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Power_WithBase2AndExponent3_Returns8()
        {
            BigInteger actual = Program.Power(2, 3);

            Assert.Equal(8, actual);
        }

        [Fact]
        public void Power_WithExponent0_Returns1()
        {
            BigInteger actual = Program.Power(100, 0);

            Assert.Equal(1, actual);
        }

        [Fact]
        public void Power_WithBase0AndExponent0_Returns1()
        {
            BigInteger actual = Program.Power(0, 0);

            Assert.Equal(1, actual);
        }

        [Fact]
        public void Power_WithNegativeExponent_ThrowsArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Program.Power(100, -2);
            });
        }
    }
}
