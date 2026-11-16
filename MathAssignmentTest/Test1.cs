namespace MathAssignmentTest
{
    [TestClass]
    public sealed class TestClass
    {

        //ARITHMETIC UNIT TESTS
        [TestMethod]
        public void ArithmeticBEDMAS()
        {
            //Arrange
            string input = "5 + 3 * 2 - 1";
            double expectedResult = 10.0;

            //Act
            bool calculationSuccessful = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsTrue(calculationSuccessful);
            Assert.AreEqual(expectedResult, actualResult, 0.0001);
        }

        [TestMethod]
        public void ArithmeticAddition()
        {
            //Arrange
            string input = "5 + 3";
            double expectedResult = 8;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsTrue(calculationSuccessFul);
            Assert.AreEqual(expectedResult, actualResult, 0.0001);
        }

        [TestMethod]
        public void ArithmeticSubtraction()
        {
            //Arrange
            string input = "5 - 8";
            double expectedResult = -3;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsTrue(calculationSuccessFul);
            Assert.AreEqual(expectedResult, actualResult, 0.0001);
        }

        [TestMethod]
        public void ArithmeticDivisionBeforeAddition()
        {
            //Arrange
            string input = "10 + 12 / 3";
            double expectedResult = 14;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsTrue(calculationSuccessFul);
            Assert.AreEqual(expectedResult, actualResult, 0.0001);
        }

        [TestMethod]
        public void LeftToRightMultiplicationDivision()
        {
            //Arrange
            string input = "20 / 5 * 2";
            double expectedResult = 8;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsTrue(calculationSuccessFul);
            Assert.AreEqual(expectedResult, actualResult, 0.0001);
        }

        [TestMethod]
        public void NegativeNumber()
        {
            //Arrange
            string input = "-5 + 3 * 2";
            double expectedResult = 1;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsTrue(calculationSuccessFul);
            Assert.AreEqual(expectedResult, actualResult, 0.0001);
        }

        [TestMethod]
        public void Decimal()
        {
            //Arrange
            string input = "2.5 * 4";
            double expectedResult = 10;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsTrue(calculationSuccessFul);
            Assert.AreEqual(expectedResult, actualResult, 0.0001);
        }

        [TestMethod]
        public void DivideByZero()
        {
            //Arrange
            string input = "5 / 0";
            bool expectedResult = false;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsFalse(calculationSuccessFul);
            
        }

        [TestMethod]
        public void InvalidNumber()
        {
            //Arrange
            string input = "5 + apple";
            bool expectedResult = false;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsFalse(calculationSuccessFul);

        }

        [TestMethod]
        public void IncompleteExpression()
        {
            //Arrange
            string input = "5 +";
            bool expectedResult = false;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsFalse(calculationSuccessFul);

        }

        [TestMethod]
        public void InvalidOperator()
        {
            //Arrange
            string input = "5 ^";
            bool expectedResult = false;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsFalse(calculationSuccessFul);

        }

        //ARITHMETIC CONSOLE TESTS
        [TestMethod]
        public void StandardOperation()
        {
            //Arrange
            string input = "(2 + 3) * 4";
            double expectedResult = 20;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsTrue(calculationSuccessFul);
            Assert.AreEqual(expectedResult, actualResult, 0.0001);
        }
    }
}
