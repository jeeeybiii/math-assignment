using System.IO;
namespace MathAssignmentTest
{
    [TestClass]
    [DoNotParallelize]
    public sealed class TestClass
    {
        private static string CaptureConsoleOutput(Action action)
        {
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                action();
                return output.ToString();
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

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

        //NUMBERT THEORY TESTS END HERE
        //================================================================

        [TestInitialize]
        public void ResetStoredData()
        {
            MathAssignment.Program.lineData =
                new MathAssignment.Program.LineData[50];
            MathAssignment.Program.lineCounter = 0;

            MathAssignment.Program.vectorData =
                new MathAssignment.Program.VectorData[50];
            MathAssignment.Program.vectorCounter = 0;

            MathAssignment.Program.matrixData =
                new MathAssignment.Program.MatrixData[50];
            MathAssignment.Program.matrixCounter = 0;
        }

        [TestMethod]
        public void CreateMatrix_ValidInput_CreatesMatrix()
        {
            // Arrange
            StringWriter output = new StringWriter();
            TextWriter originalOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                // Act
                MathAssignment.Program.CreateMatrix(
                    "mat a (1 2 3 4)");

                string consoleOutput = output.ToString();

                // Assert
                StringAssert.Contains(
                    consoleOutput,
                    "Matrix a created:");

                StringAssert.Contains(
                    consoleOutput,
                    "[1 2]");

                StringAssert.Contains(
                    consoleOutput,
                    "[3 4]");

                Assert.AreEqual(
                    1,
                    MathAssignment.Program.matrixCounter);
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }

        [TestMethod]
        public void CreateMatrix_InvalidElement_DisplaysError()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateMatrix(
                    "mat a (1 apple 3 4)");
            });

            StringAssert.Contains(
                output,
                "All matrix elements must be valid numbers.");

            Assert.AreEqual(
                0,
                MathAssignment.Program.matrixCounter);
        }

        [TestMethod]
        public void AddMatrices_ValidMatrices_DisplaysSum()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateMatrix(
                    "mat a (1 2 3 4)");

                MathAssignment.Program.CreateMatrix(
                    "mat b (5 6 7 8)");

                MathAssignment.Program.AddMatrices(
                    "addmat a b");
            });

            StringAssert.Contains(output, "a + b =");
            StringAssert.Contains(output, "[6 8]");
            StringAssert.Contains(output, "[10 12]");
        }

        [TestMethod]
        public void AddMatrices_MissingMatrix_DisplaysError()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateMatrix(
                    "mat a (1 2 3 4)");

                MathAssignment.Program.AddMatrices(
                    "addmat a b");
            });

            StringAssert.Contains(
                output,
                "b was not found.");
        }

        [TestMethod]
        public void MultiplyMatrices_ValidMatrices_DisplaysProduct()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateMatrix(
                    "mat a (1 2 3 4)");

                MathAssignment.Program.CreateMatrix(
                    "mat b (5 6 7 8)");

                MathAssignment.Program.MultiplyMatrices(
                    "dotmat a b");
            });

            StringAssert.Contains(output, "a * b =");
            StringAssert.Contains(output, "[19 22]");
            StringAssert.Contains(output, "[43 50]");
        }

        [TestMethod]
        public void ScaleMatrix_ValidScalar_DisplaysScaledMatrix()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateMatrix(
                    "mat a (1 2 3 4)");

                MathAssignment.Program.ScaleMatrix(
                    "scalmat 3 a");
            });

            StringAssert.Contains(output, "[3 6]");
            StringAssert.Contains(output, "[9 12]");
        }

        [TestMethod]
        public void CalculateDeterminant_ValidMatrix_DisplaysDeterminant()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateMatrix(
                    "mat a (1 2 3 4)");

                MathAssignment.Program.CalculateDeterminant(
                    "detmat a");
            });

            StringAssert.Contains(
                output,
                "det(a) = -2");
        }

        [TestMethod]
        public void CalculateInverse_InvertibleMatrix_DisplaysInverse()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateMatrix(
                    "mat a (1 2 3 4)");

                MathAssignment.Program.CalculateInverse(
                    "invmat a");
            });

            StringAssert.Contains(output, "det(a) = -2");
            StringAssert.Contains(output, "Inverse of matrix a");
            StringAssert.Contains(output, "[-2 1]");
            StringAssert.Contains(output, "[1.5 -0.5]");
        }

        [TestMethod]
        public void CalculateInverse_ZeroDeterminant_DisplaysError()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateMatrix(
                    "mat a (1 2 2 4)");

                MathAssignment.Program.CalculateInverse(
                    "invmat a");
            });

            StringAssert.Contains(
                output,
                "This matrix has no inverse");
        }

        //MATRICES TESTS END HERE
        //================================================================
        //GEOMETRY TESTS
        [TestMethod]
        public void CreateLine_ValidCoordinates_CreatesLine()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateLine("line a (1, 2, 3, 4)");
            });

            StringAssert.Contains(output, "Line a created: (1, 2) to (3, 4)");

            Assert.AreEqual(1, MathAssignment.Program.lineCounter);
            Assert.AreEqual("a", MathAssignment.Program.lineData[0].lineName);
            Assert.AreEqual(1.0, MathAssignment.Program.lineData[0].x1, 0.0001);
            Assert.AreEqual(2.0, MathAssignment.Program.lineData[0].y1, 0.0001);
            Assert.AreEqual(3.0, MathAssignment.Program.lineData[0].x2, 0.0001);
            Assert.AreEqual(4.0, MathAssignment.Program.lineData[0].y2, 0.0001);
        }

        [TestMethod]
        public void CreateLine_DuplicateName_DisplaysError()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateLine("line a (1, 2, 3, 4)");

                MathAssignment.Program.CreateLine("line a (5, 6, 7, 8)");
            });

            StringAssert.Contains(output, "Line name already exists!");

            Assert.AreEqual(1, MathAssignment.Program.lineCounter);
            Assert.AreEqual("a", MathAssignment.Program.lineData[0].lineName);
            Assert.AreEqual(1.0, MathAssignment.Program.lineData[0].x1, 0.0001);
            Assert.AreEqual(2.0, MathAssignment.Program.lineData[0].y1, 0.0001);
            Assert.AreEqual(3.0, MathAssignment.Program.lineData[0].x2, 0.0001);
            Assert.AreEqual(4.0, MathAssignment.Program.lineData[0].y2, 0.0001);
        }

        [TestMethod]
        public void CreateLine_InvalidCoordinate_DisplaysError()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateLine("line a (1, apple, 3, 4)");

                MathAssignment.Program.CalculateLineLength("line a (1, apple, 3, 4)");
            });
            StringAssert.Contains(output, "All coordinates must be valid numbers!");
            Assert.AreEqual(0, MathAssignment.Program.lineCounter);

        }

        [TestMethod]
        public void CalculateLineLength_ValidLine_DisplaysLength()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateLine("line a (0, 0, 3, 4)");

                MathAssignment.Program.CalculateLineLength("lengthline a");

            });
            StringAssert.Contains(output, "Length of line a: 5");
        }

        [TestMethod]
        public void CalculateMidpoint_ValidLine_DisplaysMidpoint()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateLine("line a (2, 4, 6, 8)");

                MathAssignment.Program.CalculateMidpoint("midpointline a");

            });
            StringAssert.Contains(output, "Midpoint of line a: (4, 6)");
        }

        [TestMethod]
        public void CalculateGradient_ValidLine_DisplaysGradient()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateLine("line a (1, 2, 3, 6)");

                MathAssignment.Program.CalculateGradient("gradientline a");

            });
            StringAssert.Contains(output, "Gradient line a: 2");
        }

        [TestMethod]
        public void CalculateGradient_VerticalLine_DisplaysUndefinedError()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CreateLine("line a (2, 1, 2, 8)");

                MathAssignment.Program.CalculateGradient("gradientline a");

            });
            StringAssert.Contains(output, "Gradient is undefined for a vertical line");
        }

        [TestMethod]
        public void DegreesToRadians_OneHundredEightyDegrees_DisplaysPi()
        {
            string expectedRadians = Math.PI.ToString();
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.DegreesToRadians("deg2rad 180");

            });
            StringAssert.Contains(output, expectedRadians);
        }

        [TestMethod]
        public void RadiansToDegrees_PiRadians_DisplaysOneHundredEighty()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.RadiansToDegrees($"rad2deg {Math.PI}");

            });
            StringAssert.Contains(output, "180");
        }

        [TestMethod]
        public void CalculateLineLength_MissingLine_DisplaysError()
        {
            string output = CaptureConsoleOutput(() =>
            {
                MathAssignment.Program.CalculateLineLength("lengthline missing");

            });
            StringAssert.Contains(output, "Line not found");
            Assert.AreEqual(0, MathAssignment.Program.lineCounter);
        }
    }
}
