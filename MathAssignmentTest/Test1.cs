using System.IO;
namespace MathAssignmentTest
{
    [TestClass]
    [DoNotParallelize]
    public sealed class TestClass
    {

        //ARITHMETIC UNIT TESTS
        [TestMethod]
        public void CalculateExpression_BedmasExpression_ReturnsTen()
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
        public void CalculateExpression_DivideByZero_ReturnsFalse()
        {
            //Arrange
            string input = "5 / 0";

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

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsFalse(calculationSuccessFul);

        }

        [TestMethod]
        public void CalculateExpression_InvalidOperator_ReturnsFalse()
        {
            //Arrange
            string input = "5 ^ 2";

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsFalse(calculationSuccessFul);

        }

        [TestMethod]
        public void MultiplicationArithmetic()
        {
            //Arrange
            string input = "6 * 7";
            double expectedResult = 42;

            //Act
            bool calculationSuccessFul = MathAssignment.Program.CalculateExpression(input, out double actualResult);

            //Assert
            Assert.IsTrue(calculationSuccessFul);
            Assert.AreEqual(expectedResult, actualResult, 0.0001);

        }

        //ARITHMETIC TESTS END HERE

        //================================================================
        //PRIME TEST
        [TestMethod]
        public void CheckPrime_PrimeNumber_DisplaysPrime()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CheckPrime("numprime 17");

                // Assert
                StringAssert.Contains(output.ToString(), "17 is a prime");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckPrime_CompositeNumber_DisplaysNotPrime()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CheckPrime("numprime 25");

                // Assert
                StringAssert.Contains(output.ToString(), "25 is not a prime");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckPrime_NumberBelowTwo_DisplaysError()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CheckPrime("numprime 1");

                // Assert
                StringAssert.Contains(output.ToString(), "A prime number must be 2 or greater");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckPrime_DecimalInput_DisplaysError()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CheckPrime("numprime 4.5");

                // Assert
                StringAssert.Contains(output.ToString(), "Prime testing requires a whole number");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckPrime_UpperBoundaryPrime_DisplaysPrime()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CheckPrime("numprime 9973");

                // Assert
                StringAssert.Contains(output.ToString(), "9973 is a prime");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckPrime_NumberAtLimit_DisplaysError()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CheckPrime("numprime 10000");

                // Assert
                StringAssert.Contains(output.ToString(), "Prime testing only accepts numbers below 10000.");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        //PRIME TESTS END HERE
        //================================================================
        [TestMethod]
        public void CCheckDigit_IsbnNormal_DisplaysCompletedCode()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CalculateCheckDigit("numcheckdigit 030640615");

                // Assert
                StringAssert.Contains(output.ToString(), "0306406152");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckDigit_IsbnX_DisplaysCompletedCode()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CalculateCheckDigit("numcheckdigit 080442957");

                // Assert
                StringAssert.Contains(output.ToString(), "080442957X");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckDigit_Upc_DisplaysCompletedCode()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CalculateCheckDigit("numcheckdigit 03600029145");

                // Assert
                StringAssert.Contains(output.ToString(), "036000291452");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckDigit_Ean13_DisplaysCompletedCode()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CalculateCheckDigit("numcheckdigit 400638133393");

                // Assert
                StringAssert.Contains(output.ToString(), "4006381333931");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckDigit_InvalidCharacter_DisplaysError()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CalculateCheckDigit("numcheckdigit 123A56789");

                // Assert
                StringAssert.Contains(output.ToString(), "All characters must be a valid number");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckDigit_InvalidLength_DisplaysError()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CalculateCheckDigit("numcheckdigit 12345");

                // Assert
                StringAssert.Contains(output.ToString(), "Unsupported code length");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CheckDigit_MissingInput_DisplaysUsage()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CalculateCheckDigit("numcheckdigit");

                // Assert
                StringAssert.Contains(output.ToString(), "USE: numcheckdigit value");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        // LINEAR CONGRUENTIAL GENERATOR TESTS

        [TestMethod]
        public void GenerateRandomNumber_ValidValues_DisplaysSequenceUntilRepeat()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.GenerateRandomNumber(
                    "numrand 3 7 5 16");

                string consoleOutput = output.ToString();

                // Assert
                StringAssert.Contains(consoleOutput, "X1 = 10");
                StringAssert.Contains(consoleOutput, "X8 = 7");
                StringAssert.Contains(consoleOutput, "Sequence repeats at 7");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void GenerateRandomNumber_SeedOutsideRange_DisplaysError()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.GenerateRandomNumber(
                    "numrand 3 20 5 16");

                // Assert
                StringAssert.Contains(
                    output.ToString(),
                    "The seed must be between 0 and m - 1");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void GenerateRandomNumber_ZeroModulus_DisplaysError()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.GenerateRandomNumber(
                    "numrand 3 7 5 0");

                // Assert
                StringAssert.Contains(
                    output.ToString(),
                    "The modulus must be greater than zero.");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void GenerateRandomNumber_InvalidSeed_DisplaysError()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.GenerateRandomNumber(
                    "numrand 3 seven 5 16");

                // Assert
                StringAssert.Contains(
                    output.ToString(),
                    "x must be a valid whole number.");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void GenerateRandomNumber_MissingValues_DisplaysUsage()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.GenerateRandomNumber(
                    "numrand 3 7 5");

                // Assert
                StringAssert.Contains(
                    output.ToString(),
                    "USE: numrand a X c m");
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }
    }
}
