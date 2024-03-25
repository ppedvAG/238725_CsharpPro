namespace Calculator.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Sum_2_and_3_result_5()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(2, 3);

            //Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Sum_n5_and_n7_result_n12()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(-5, -7);

            //Assert
            Assert.Equal(-12, result);
        }

        [Fact]
        public void Sum_0_and_0_result_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Sum_MAX_and_1_throws_OverflowEx()
        {
            var calc = new Calc();

            //Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue-1, 2));
        }


        [Theory]
        [InlineData(0,0,0)]
        [InlineData(2,3,5)]
        [InlineData(-2,-3,-5)]
        public void Sum_with_results(int a, int b, int exp)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.Equal(exp, result);
        }
    }
}