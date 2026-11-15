//John Vincent L. Macuto & Akirah Quinto's Digital Numeracy Assignment

using System.Runtime.ConstrainedExecution;

namespace MathAssignment
{
    public class Program
    {
        //geometry struct
        public struct LineData
        {
            public string lineName;
            public double x1;
            public double y1;
            public double x2;
            public double y2;
        }

        //vector struct
        public struct VectorData
        {
            public string vectorName;
            public double vectorX;
            public double vectorY;
        }

        //matrix struct
        public struct MatrixData
        {
            public string matrixName;
            public double topLeft;
            public double topRight;
            public double bottomLeft;
            public double bottomRight;
        }

        //geometry data
        public static LineData[] lineData = new LineData[50]; 

        public static int lineCounter = 0;

        //vector data
        public static VectorData[] vectorData = new VectorData[50];
        public static int vectorCounter = 0;


        //matric data
        public static MatrixData[] matrixData = new MatrixData[50];
        public static int matrixCounter = 0;
        static void Main(string[] args)
        {
            MainMenu();
        }

        //main menu commands
        static void MainMenu()
        {
            bool isRunning = true;

            Console.Clear();
            Console.WriteLine("Digital Numeracy Calculator");
            Console.WriteLine("Type help for commands or exit to close.");

            do
            {
                Console.Write("> ");
                string? input = Console.ReadLine();

                if (input == null)
                {
                    isRunning = false;
                    continue;
                }

                string userInput = input.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Please enter a command.");
                }
                else if (userInput == "exit")
                {
                    isRunning = false;
                }
                else if (userInput == "help")
                {
                    DisplayHelp();
                }
                else
                {
                    ProcessCommand(userInput);
                }

            } while (isRunning);

            Console.WriteLine("Calculator closed.");
        }


        //menu to display commands
        static void DisplayHelp()
        {
            Console.Clear();
            Console.WriteLine("HELP COMMANDS");
            Console.WriteLine("help - Display available commands");
            Console.WriteLine("exit - Close the calculator");
        }


        //if there's parentheses
        static void CalculateParenthesesExpression(string userInput)
        {
            int openingCount = 0, closingCount = 0;
            int openingPosition = 0, closingPosition = 0;
            int innerPosition = 0, innerLength = 0;
            string innerExpression;

            //validate matching parentheses
            for (int i = 0; i < userInput.Length; i++)
            {
                if (userInput[i].Equals('('))
                {
                    openingCount++;
                }
                else if (userInput[i].Equals(')'))
                {
                    closingCount++;
                }
            }

            if (openingCount != closingCount)
            {
                Console.WriteLine("Mismatched parentheses");
                return;
            }

            while (userInput.Contains('('))
            {
                openingPosition = userInput.LastIndexOf('(');
                closingPosition = userInput.IndexOf(')', openingPosition + 1);



                if (closingPosition == -1)
                {
                    Console.WriteLine("Parentheses are in the wrong order");
                    return;
                }

                innerPosition = openingPosition + 1;
                innerLength = closingPosition - openingPosition - 1;

                innerExpression = userInput.Substring(openingPosition + 1, innerLength);
                innerExpression = innerExpression.Trim();


                if (CalculateExpression(innerExpression, out double innerResult) == false)
                {
                    return;
                }

                string beforeParentheses = userInput.Substring(0, openingPosition);
                string afterParentheses = userInput.Substring(closingPosition + 1);
                userInput = beforeParentheses + innerResult + afterParentheses;
            }

            if (double.TryParse(userInput.Trim(), out double finalNumber))
            {
                Console.WriteLine(finalNumber);
            }
            else
            {
                if (CalculateExpression(userInput, out double finalResult))
                {
                    Console.WriteLine(finalResult);
                }
            }


        }

        //BEDMAS
        static bool CalculateExpression(string userInput, out double result)
        {
            //initialize variables
            result = 0;
            double total = 0, currentTerm = 0, nextNumber = 0;
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string operatorSign;

            if (codeArray.Length < 3)
            {
                Console.WriteLine("Expression is too short");
                return false;
            }
            if (codeArray.Length % 2 == 0)
            {
                Console.WriteLine("Invalid expression format");
                return false;
            }

            //validate expression
            for (int i = 0; i < codeArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (double.TryParse(codeArray[i], out double tempCatcher) == true)
                    {
                    }
                    else
                    {
                        Console.WriteLine($"Invalid number: {codeArray[i]}");
                        return false;
                    }
                }
                else
                {
                    if (codeArray[i] != "+" &&
                        codeArray[i] != "-" &&
                        codeArray[i] != "*" &&
                        codeArray[i] != "/")
                    {
                        Console.WriteLine("Invalid operator!");
                        return false;
                    }
                }
            }
            currentTerm = double.Parse(codeArray[0]);
            for (int i = 1; i < codeArray.Length; i = i + 2)
            {
                operatorSign = codeArray[i];

                nextNumber = double.Parse(codeArray[i + 1]);


                switch (operatorSign)
                {
                    case "*":
                        currentTerm = currentTerm * nextNumber;
                        break;
                    case "/":
                        if (nextNumber == 0)
                        {
                            Console.WriteLine("Cannot divide by 0!");
                            return false;
                        }
                        currentTerm = currentTerm / nextNumber;
                        break;
                    case "+":
                        total = total + currentTerm;
                        currentTerm = nextNumber;
                        break;
                    case "-":
                        total = total + currentTerm;
                        currentTerm = -nextNumber;
                        break;
                }
            }
            result = total + currentTerm;
            return true;
        }


        //Factorial
        static void CalculateFactorial(string userInput)
        {
            string numberText;
            int index = 0, factorialNumber = 0;
            long factorialResult = 1;

            index = userInput.IndexOf("!");
            userInput = userInput.Substring(0, index);
            userInput = userInput.Trim();
            numberText = userInput;

            //if number is a decimal
            if (int.TryParse(numberText, out factorialNumber) == false)
            {
                Console.WriteLine("Factorial requires a whole number!");
                return;
            }

            //if number is a negative
            if(factorialNumber < 0)
            {
                Console.WriteLine("Factorial cannot use a negative number!");
                return;
            }
            
            //if number is too large
            if(factorialNumber > 20)
            {
                Console.WriteLine("Factorial is too large!");
                return;
            }

            //calculate factorial
            for(int i = 1; i <= factorialNumber; i++)
            {
                factorialResult = factorialResult * i;
            }
            Console.WriteLine(factorialResult);
        }

        //Square
        static void CalculateSquare(string userInput)
        {
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double squareNumber = 0, squareResult = 0;

            if(codeArray.Length != 2)
            {
                Console.WriteLine("USE: square number");
                return;
            }

            if (double.TryParse(codeArray[1], out squareNumber) == false)
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            squareResult = squareNumber * squareNumber;
            Console.WriteLine(squareResult);
        }

        //square root
        static void CalculateSquareRoot(string userInput)
        {
            double squareRootNumber = 0, squareRootResult = 0;
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: square number");
                return;
            }

            if (double.TryParse(codeArray[1], out squareRootNumber) == false)
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            if( squareRootNumber < 0)
            {
                Console.WriteLine("Cannot sqaure root a negative number!");
                return;
            }
            squareRootResult = Math.Sqrt(squareRootNumber);
            Console.WriteLine(squareRootResult);
        }

        //geometry
        //create a line
        static void CreateLine(string userInput)
        {
            bool checker = true;
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 6)
            {
                Console.WriteLine("USE: line name ( x1, y1, x2, y2 )");
                return;
            }

            if (lineCounter >= lineData.Length)
            {
                Console.WriteLine("Line storage is full");
                return;
            }

            
            string newLineName = codeArray[1];
            for (int i = 0; i < lineCounter; i++)
            {
                if (lineData[i].lineName == newLineName)
                {
                    Console.WriteLine("Line name already exists!");
                    return;
                }
            }

            if (double.TryParse(codeArray[2], out double x1) == false)
            {
                checker = false;
            }
            if (double.TryParse(codeArray[3], out double y1) == false)
            {
                checker = false;
            }
            if (double.TryParse(codeArray[4], out double x2) == false)
            {
                checker = false;
            }
            if (double.TryParse(codeArray[5], out double y2) == false)
            {
                checker = false;
            }

            if(checker == false)
            {
                Console.WriteLine("All coordinates must be valid numbers!");
                return;
            }
            else
            {
                lineData[lineCounter].lineName = newLineName;
                lineData[lineCounter].x1 = x1;
                lineData[lineCounter].y1 = y1;
                lineData[lineCounter].x2 = x2;
                lineData[lineCounter].y2 = y2;
            }

            Console.WriteLine($"Line {lineData[lineCounter].lineName} created: ({x1}, {y1}) to ({x2}, {y2})");
            lineCounter++;

        }

        //calculate length of a line
        static void CalculateLineLength(string userInput)
        {
            string targetName;
            int foundIndex = -1; 
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if(codeArray.Length != 2)
            {
                Console.WriteLine("USE: lengthline name");
                return;
            }
            targetName = codeArray[1];

            for(int i = 0; i < lineCounter; i++)
            {
                if (lineData[i].lineName == targetName)
                {
                    foundIndex = i;
                    break;
                }
            }

            if(foundIndex == -1)
            {
                Console.WriteLine("Line not found");
                return;
            }

            double differenceX = lineData[foundIndex].x2 - lineData[foundIndex].x1;

            double differenceY = lineData[foundIndex].y2 - lineData[foundIndex].y1;

            double length = Math.Sqrt((differenceX * differenceX) + (differenceY * differenceY));

            Console.WriteLine($"Length of line {lineData[foundIndex].lineName}: {length}");
        }

        //midpoint of a line
        static void CalculateMidpoint(string userInput)
        {
            string targetName;
            int foundIndex = -1;
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: midpointline name");
                return;
            }
            targetName = codeArray[1];

            for (int i = 0; i < lineCounter; i++)
            {
                if (lineData[i].lineName == targetName)
                {
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex == -1)
            {
                Console.WriteLine("Line not found");
                return;
            }

            double midpointx = (lineData[foundIndex].x1 + lineData[foundIndex].x2) / 2;

            double midpointy = (lineData[foundIndex].y1 + lineData[foundIndex].y2) / 2;

            Console.WriteLine($"Midpoint of line {targetName}: ({midpointx}, {midpointy})");
        }

        //line gradient
        static void CalculateGradient(string userInput)
        {
            string targetName;
            int foundIndex = -1;
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: gradientline name");
                return;
            }
            targetName = codeArray[1];

            for (int i = 0; i < lineCounter; i++)
            {
                if (lineData[i].lineName == targetName)
                {
                    foundIndex = i;
                    break;
                }
            }

            if (foundIndex == -1)
            {
                Console.WriteLine("Line not found");
                return;
            }

            double changeY = (lineData[foundIndex].y2 - lineData[foundIndex].y1);

            double changeX = (lineData[foundIndex].x2 - lineData[foundIndex].x1);

            if(changeX == 0)
            {
                Console.WriteLine("Gradient is undefined for a vertical line");
                return;
            }

            double gradient = changeY / changeX;
            Console.WriteLine($"Gradient line {targetName}: {gradient}");
        }


        //radians to degrees
        static void RadiansToDegrees(string userInput)
        {
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: rad2deg value");
                return;
            }

            double radians = 0;
            if (double.TryParse(codeArray[1], out radians) == false)
            {
                Console.WriteLine("Invalid number!");
                return;
            }
            
            double degrees = radians * 180 / Math.PI;

            Console.WriteLine(degrees);
        }


        //degrees to radians
        static void DegreesToRadians(string userInput)
        {
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: deg2rad value");
                return;
            }

            double degrees = 0;
            if (double.TryParse(codeArray[1], out degrees) == false)
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            double radians = degrees * Math.PI / 180;

            Console.WriteLine(radians);
        }

        static void CalculateVectorLength(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: lengthvec vectorName");
                return;
            }

            string newVectorName = codeArray[1];
            int vectorIndex = -1;

            for (int i = 0; i < vectorCounter; i++)
            {
                if (vectorData[i].vectorName == newVectorName)
                {
                    vectorIndex = i;
                    break;
                }
            }

            if(vectorIndex == -1)
            {
                Console.WriteLine("Vector not found");
                return;
            }

            double vectorX = vectorData[vectorIndex].vectorX;
            double vectorY = vectorData[vectorIndex].vectorY;

            double length = Math.Sqrt((vectorX * vectorX) +(vectorY * vectorY));
            Console.WriteLine($"Length of {newVectorName} = {length}");
        }

        //GEOMETRY COMMANDS END

        //VECTOR COMMANDS START
        //Create a vector

        static void CreateVector(string userInput)
        {
            bool checker = true;
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 4)
            {
                Console.WriteLine("USE: vec name (firstNumber, secondNumber)");
                return;
            }

            if (vectorCounter >= vectorData.Length)
            {
                Console.WriteLine("Vector storage is full");
                return;
            }


            string newVectorName = codeArray[1];
            for (int i = 0; i < vectorCounter; i++)
            {
                if (vectorData[i].vectorName == newVectorName)
                {
                    Console.WriteLine("Vector name already exists!");
                    return;
                }
            }

            if (double.TryParse(codeArray[2], out double vectorX) == false)
            {
                checker = false;
            }
            if (double.TryParse(codeArray[3], out double vectorY) == false)
            {
                checker = false;
            }

            if (checker == false)
            {
                Console.WriteLine("All vectors must be valid numbers!");
                return;
            }
            else
            {
                vectorData[vectorCounter].vectorName = newVectorName;
                vectorData[vectorCounter].vectorX = vectorX;
                vectorData[vectorCounter].vectorY = vectorY;
            }

            Console.WriteLine($"Vector {vectorData[vectorCounter].vectorName} created: ({vectorX}, {vectorY})");
            vectorCounter++;
        }


        //Add vectors
        static void AddVectors(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if(codeArray.Length != 3)
            {
                Console.WriteLine("USE: addvec firstVector secondVector");
                return;
            }

            string firstVectorName = codeArray[1];
            string secondVectorName = codeArray[2];

            int firstVectorIndex = -1;
            int secondVectorIndex = -1;

            for(int i = 0; i < vectorCounter; i++)
            {
                if (vectorData[i].vectorName == firstVectorName)
                {
                    firstVectorIndex = i;
                }

                if (vectorData[i].vectorName == secondVectorName)
                {
                    secondVectorIndex = i;
                }
            }

            if(firstVectorIndex == -1)
            {
                Console.WriteLine($"{firstVectorName} was not found.");
                return;
            }
            if(secondVectorIndex == -1)
            {
                Console.WriteLine($"{secondVectorName} was not found.");
                return;
            }

            double resultX = vectorData[firstVectorIndex].vectorX + vectorData[secondVectorIndex].vectorX;

            double resultY = vectorData[firstVectorIndex].vectorY + vectorData[secondVectorIndex].vectorY;

            Console.WriteLine($"{vectorData[firstVectorIndex].vectorName} + {vectorData[secondVectorIndex].vectorName} = ({resultX}, {resultY})");

        }


        //subtract vectors
        static void SubtractVectors(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 3)
            {
                Console.WriteLine("USE: subvec firstVector secondVector");
                return;
            }

            string firstVectorName = codeArray[1];
            string secondVectorName = codeArray[2];

            int firstVectorIndex = -1;
            int secondVectorIndex = -1;

            for (int i = 0; i < vectorCounter; i++)
            {
                if (vectorData[i].vectorName == firstVectorName)
                {
                    firstVectorIndex = i;
                }

                if (vectorData[i].vectorName == secondVectorName)
                {
                    secondVectorIndex = i;
                }
            }

            if (firstVectorIndex == -1)
            {
                Console.WriteLine($"{firstVectorName} was not found.");
                return;
            }
            if (secondVectorIndex == -1)
            {
                Console.WriteLine($"{secondVectorName} was not found.");
                return;
            }

            double resultX = vectorData[firstVectorIndex].vectorX - vectorData[secondVectorIndex].vectorX;

            double resultY = vectorData[firstVectorIndex].vectorY - vectorData[secondVectorIndex].vectorY;

            Console.WriteLine($"{vectorData[firstVectorIndex].vectorName} - {vectorData[secondVectorIndex].vectorName} = ({resultX}, {resultY})");

        }

        //dot product of vectors

        static void MultiplyVectors(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 3)
            {
                Console.WriteLine("USE: dot firstVector secondVector");
                return;
            }

            string firstVectorName = codeArray[1];
            string secondVectorName = codeArray[2];

            int firstVectorIndex = -1;
            int secondVectorIndex = -1;

            for (int i = 0; i < vectorCounter; i++)
            {
                if (vectorData[i].vectorName == firstVectorName)
                {
                    firstVectorIndex = i;
                }

                if (vectorData[i].vectorName == secondVectorName)
                {
                    secondVectorIndex = i;
                }
            }

            if (firstVectorIndex == -1)
            {
                Console.WriteLine($"{firstVectorName} was not found.");
                return;
            }
            if (secondVectorIndex == -1)
            {
                Console.WriteLine($"{secondVectorName} was not found.");
                return;
            }

            double resultX = vectorData[firstVectorIndex].vectorX * vectorData[secondVectorIndex].vectorX;

            double resultY = vectorData[firstVectorIndex].vectorY * vectorData[secondVectorIndex].vectorY;

            double dotProduct = resultX + resultY;

            Console.WriteLine($"{vectorData[firstVectorIndex].vectorName} * {vectorData[secondVectorIndex].vectorName} = {resultX} + {resultY}");
            Console.WriteLine($"{vectorData[firstVectorIndex].vectorName} * {vectorData[secondVectorIndex].vectorName} = {dotProduct}");

            if(dotProduct > 0)
            {
                Console.WriteLine("The vectors point in a similar general direction.");
            }
            else if(dotProduct == 0)
            {
                Console.WriteLine("The vectors are perpendicular.");
            }
            else
            {
                Console.WriteLine("The vectors point in opposite general directions.");
            }
        }

        //scalar multiplication
        static void ScaleVec(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 3)
            {
                Console.WriteLine("USE: scalvec value vectorName");
                return;
            }

            double scalar = 0;
            if (double.TryParse(codeArray[1], out scalar) == false)
            {
                Console.WriteLine("Scalar must be a valid number!");
                return;
            }
            

            string vectorName = codeArray[2];

            int vectorIndex = -1;


            for (int i = 0; i < vectorCounter; i++)
            {
                if (vectorData[i].vectorName == vectorName)
                {
                    vectorIndex = i;
                }
            }

            if (vectorIndex == -1)
            {
                Console.WriteLine($"{vectorName} was not found.");
                return;
            }

            double resultX = vectorData[vectorIndex].vectorX * scalar;
            double resultY = vectorData[vectorIndex].vectorY * scalar;


            Console.WriteLine($"{scalar}{vectorName} = ({resultX}, {resultY})");
        }
        //END OF VECTORS

        //START OF NUMBER THEORY
        static void CheckPrime(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: numprime value");
                return;
            }

            int prime = 0;
            if (int.TryParse(codeArray[1], out prime) == false)
            {
                Console.WriteLine("Prime testing requires a whole number!");
                return;
            }

            if (prime < 2)
            {
                Console.WriteLine("A prime number must be 2 or greater!");
                return;
            }

            bool isPrime = true;
            for(int i = 2; i * i <= prime; i++)
            {
                if(prime % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if(isPrime == true)
            {
                Console.WriteLine($"{prime} is a prime");
            }
            else
            {
                Console.WriteLine($"{prime} is not a prime");
            }
        }

        static void CheckDivisibility(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if(codeArray.Length != 3)
            {
                Console.WriteLine("USE: divisible number divisor");
                return;
            }

            int number = 0;
            int divisor = 0;

            if (int.TryParse(codeArray[1], out number) == false)
            {
                Console.WriteLine("Number must be a valid number!");
                return;
            }

            if(int.TryParse(codeArray[2], out divisor) == false)
            {
                Console.WriteLine("Divisible must be a valid number!");
                return;
            }

            if(divisor == 0)
            {
                Console.WriteLine("Cannot divide by 0");
                return;
            }

            if(number % divisor == 0)
            {
                Console.WriteLine($"{number} is divisible by {divisor}.");
            }
            else
            {
                Console.WriteLine($"{number} is not divisible by {divisor}.");
            }
        }

        static void CalculateCheckDigit(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            if(codeArray.Length != 2)
            {
                Console.WriteLine("USE: numcheckdigit value");
                return;
            }

            string numericalString = codeArray[1];

            foreach(char s in numericalString)
            {
                if(char.IsDigit(s) == false)
                {
                    Console.WriteLine("All characters must be a valid number!");
                    return;
                }
            }

            int total = 0;
            int digit = 0;
            int checkDigit = 0;
            int weight = 0;
            if(numericalString.Length == 9)
            {
                weight = 10;
                total = 0;
                Console.WriteLine("ISBN detected");
                for (int i = 0; i < numericalString.Length; i++)
                {
                    digit = numericalString[i] - '0';
                    total = total + digit * weight;
                    weight--;
                    
                }
                checkDigit = (11 - (total % 11)) % 11;
                if(checkDigit == 10)
                {
                    Console.WriteLine(numericalString + "X");
                }
                else
                {
                    Console.WriteLine(numericalString + checkDigit);
                }
            }
            else if(numericalString.Length == 11)
            {
                total = 0;
                Console.WriteLine("UPC detected");
                for(int i = 0; i < numericalString.Length; i++)
                {
                    digit = numericalString[i] - '0';

                    if(i % 2 == 0)
                    {
                        total = total + digit * 3;
                    }
                    else
                    {
                        total = total + digit;
                    }
                }
                checkDigit = (10 - (total % 10)) % 10;
                Console.WriteLine(numericalString + checkDigit);
            }
            else if (numericalString.Length == 12)
            {
                Console.WriteLine("EAN-13 detected");
                total = 0;
                for (int i = 0; i < numericalString.Length; i++)
                {
                    digit = numericalString[i] - '0';

                    if (i % 2 == 0)
                    {
                        total = total + digit;
                    }
                    else
                    {
                        total = total + digit * 3;
                    }
                }
                checkDigit = (10 - (total % 10)) % 10;
                Console.WriteLine(numericalString + checkDigit);
            }
            else
            {
                Console.WriteLine("Unsupported code length. Enter 9, 11, or 12 digits");
            }
        }

        static void GenerateRandomNumber(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int xCounter = 1, xValue = 0, currentX = 0;
            if(codeArray.Length != 5)
            {
                Console.WriteLine("USE: numrand a X c m");
                return;
            }

            if (int.TryParse(codeArray[1], out int a) == false)
            {
                Console.WriteLine("a must be a valid whole number.");
                return;
            }
            if (int.TryParse(codeArray[2], out int x) == false)
            {
                Console.WriteLine("x must be a valid whole number.");
                return;
            }
            if (int.TryParse(codeArray[3], out int c) == false)
            {
                Console.WriteLine("c must be a valid whole number.");
                return;
            }
            if (int.TryParse(codeArray[4], out int m) == false)
            {
                Console.WriteLine("m must be a valid whole number.");
                return;
            }

            if(m <= 0)
            {
                Console.WriteLine("The modulus must be greater than zero.");
                return;
            }

            if (x < 0 || x >= m)
            {
                Console.WriteLine("The seed must be between 0 and m - 1");
                return;
            }

            currentX = x;
            bool[] valueSeen = new bool[m];
            valueSeen[currentX] = true;
            bool loop = true;
            while (loop)
            {


                xValue = (a * currentX + c) % m;

                Console.WriteLine($"X{xCounter} = ({a}({currentX}) + {c}) % {m}");
                Console.WriteLine($"X{xCounter} = {xValue}");
                Console.WriteLine();

                if (valueSeen[xValue] == true)
                {
                    Console.WriteLine($"Sequence repeats at {xValue}");
                    break;
                }
                valueSeen[xValue] = true;

                currentX = xValue;

                xCounter++;
            }
        }

        static void CreateMatrix(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 6)
            {
                Console.WriteLine("USE: mat name (a b c d)");
                return;
            }

            if(matrixCounter >= matrixData.Length)
            {
                Console.WriteLine("Matrix storage is full");
                return;
            }

            string newMatrixName = codeArray[1];

            for(int i = 0; i < matrixCounter; i++)
            {
                if (matrixData[i].matrixName == newMatrixName)
                {
                    Console.WriteLine("Matrix name already exists!");
                    return;
                }
            }

            if (double.TryParse(codeArray[2], out double topLeft) == false)
            {
                Console.WriteLine("All matrix elements must be valid numbers.");
                return;
            }
            if (double.TryParse(codeArray[3], out double topRight) == false)
            {
                Console.WriteLine("All matrix elements must be valid numbers.");
                return;
            }
            if (double.TryParse(codeArray[4], out double bottomLeft) == false)
            {
                Console.WriteLine("All matrix elements must be valid numbers.");
                return;
            }
            if (double.TryParse(codeArray[5], out double bottomRight) == false)
            {
                Console.WriteLine("All matrix elements must be valid numbers.");
                return;
            }

            matrixData[matrixCounter].matrixName = newMatrixName;
            matrixData[matrixCounter].topLeft = topLeft;
            matrixData[matrixCounter].topRight = topRight;
            matrixData[matrixCounter].bottomLeft = bottomLeft;
            matrixData[matrixCounter].bottomRight = bottomRight;

            Console.WriteLine($"Matrix {newMatrixName} created:");
            Console.WriteLine($"[{topLeft} {topRight}]");
            Console.WriteLine($"[{bottomLeft} {bottomRight}]");
            matrixCounter++;
        }

        static void AddMatrices(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if(codeArray.Length != 3)
            {
                Console.WriteLine("USE: addmat firstMatrix secondMatrix");
                return;
            }

            string firstMatrixName = codeArray[1];
            string secondMatrixName = codeArray[2];

            int firstMatrixIndex = -1;
            int secondMatrixIndex = -1;

            for (int i = 0; i < matrixCounter; i++)
            {
                if (matrixData[i].matrixName == firstMatrixName)
                {
                    firstMatrixIndex = i;
                }

                if (matrixData[i].matrixName == secondMatrixName)
                {
                    secondMatrixIndex = i;
                }
            }

            if (firstMatrixIndex == -1)
            {
                Console.WriteLine($"{firstMatrixName} was not found.");
                return;
            }
            if (secondMatrixIndex == -1)
            {
                Console.WriteLine($"{secondMatrixName} was not found.");
                return;
            }

            double resultTopLeft = matrixData[firstMatrixIndex].topLeft + matrixData[secondMatrixIndex].topLeft;
            double resultTopRight = matrixData[firstMatrixIndex].topRight + matrixData[secondMatrixIndex].topRight;
            double resultBottomLeft = matrixData[firstMatrixIndex].bottomLeft + matrixData[secondMatrixIndex].bottomLeft;
            double resultBottomRight = matrixData[firstMatrixIndex].bottomRight + matrixData[secondMatrixIndex].bottomRight;
            
            //initial result
            Console.WriteLine($"{matrixData[firstMatrixIndex].matrixName} + {matrixData[secondMatrixIndex].matrixName} = ");
            Console.Write($"[{matrixData[firstMatrixIndex].topLeft} + {matrixData[secondMatrixIndex].topLeft}  ");
            Console.WriteLine($"{matrixData[firstMatrixIndex].topRight} + {matrixData[secondMatrixIndex].topRight}]");
            Console.Write($"[{matrixData[firstMatrixIndex].bottomLeft} + {matrixData[secondMatrixIndex].bottomLeft}  ");
            Console.WriteLine($"{matrixData[firstMatrixIndex].bottomRight} + {matrixData[secondMatrixIndex].bottomRight}]");

            //final output
            Console.WriteLine($"\n{matrixData[firstMatrixIndex].matrixName} + {matrixData[secondMatrixIndex].matrixName} = ");
            Console.WriteLine($"[{resultTopLeft} {resultTopRight}]");
            Console.WriteLine($"[{resultBottomLeft} {resultBottomRight}]");
        }

        static void ScaleMatrix(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 3)
            {
                Console.WriteLine("USE: scalmat scalar matrixName");
                return;
            }

            double scalar = 0;
            if (double.TryParse(codeArray[1], out scalar) == false)
            {
                Console.WriteLine("Scalar must be a valid number");
                return;
            }

            int matrixIndex = -1;
            string matrixName = codeArray[2];
            for(int i = 0; i < matrixCounter; i++)
            {
                if (matrixData[i].matrixName == matrixName)
                {
                    matrixIndex = i;
                }
            }

            if(matrixIndex == -1)
            {
                Console.WriteLine("Matrix not found");
                return;
            }

            double resultTopLeft = matrixData[matrixIndex].topLeft * scalar;
            double resultTopRight= matrixData[matrixIndex].topRight * scalar;
            double resultBottomLeft = matrixData[matrixIndex].bottomLeft * scalar;
            double resultBottomRight = matrixData[matrixIndex].bottomRight * scalar;

            //initial result
            Console.WriteLine($"{matrixName}{scalar} = ");
            Console.WriteLine($"[{matrixData[matrixIndex].topLeft}({scalar})   {matrixData[matrixIndex].topRight}({scalar})]");
            Console.WriteLine($"[{matrixData[matrixIndex].bottomLeft}({scalar})   {matrixData[matrixIndex].bottomRight}({scalar})]");

            //final result
            Console.WriteLine($"{matrixName}{scalar} = ");
            Console.WriteLine($"[{resultTopLeft} {resultTopRight}]");
            Console.WriteLine($"[{resultBottomLeft} {resultBottomRight}]");
        }

        static void CalculateDeterminant(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: detmat matrixName");
                return;
            }

            int matrixIndex = -1;
            string matrixName = codeArray[1];
            for (int i = 0; i < matrixCounter; i++)
            {
                if (matrixData[i].matrixName == matrixName)
                {
                    matrixIndex = i;
                }
            }

            if (matrixIndex == -1)
            {
                Console.WriteLine("Matrix not found");
                return;
            }

            double determinant = (matrixData[matrixIndex].topLeft * matrixData[matrixIndex].bottomRight)
                                - (matrixData[matrixIndex].topRight * matrixData[matrixIndex].bottomLeft);

            Console.WriteLine($"det({matrixName}) = {determinant}");
        }

        static void MultiplyMatrices(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 3)
            {
                Console.WriteLine("USE: dotmat firstMatrix secondMatrix");
                return;
            }

            string firstMatrixName = codeArray[1];
            string secondMatrixName = codeArray[2];

            int firstMatrixIndex = -1;
            int secondMatrixIndex = -1;

            for (int i = 0; i < matrixCounter; i++)
            {
                if (matrixData[i].matrixName == firstMatrixName)
                {
                    firstMatrixIndex = i;
                }

                if (matrixData[i].matrixName == secondMatrixName)
                {
                    secondMatrixIndex = i;
                }
            }

            if (firstMatrixIndex == -1)
            {
                Console.WriteLine($"{firstMatrixName} was not found.");
                return;
            }
            if (secondMatrixIndex == -1)
            {
                Console.WriteLine($"{secondMatrixName} was not found.");
                return;
            }

            double resultTopLeft = (matrixData[firstMatrixIndex].topLeft * matrixData[secondMatrixIndex].topLeft) + (matrixData[firstMatrixIndex].topRight * matrixData[secondMatrixIndex].bottomLeft);
            double resultTopRight = (matrixData[firstMatrixIndex].topLeft * matrixData[secondMatrixIndex].topRight) + (matrixData[firstMatrixIndex].topRight * matrixData[secondMatrixIndex].bottomRight);
            double resultBottomLeft = (matrixData[firstMatrixIndex].bottomLeft * matrixData[secondMatrixIndex].topLeft) + (matrixData[firstMatrixIndex].bottomRight * matrixData[secondMatrixIndex].bottomLeft);
            double resultBottomRight = (matrixData[firstMatrixIndex].bottomLeft * matrixData[secondMatrixIndex].topRight) + (matrixData[firstMatrixIndex].bottomRight * matrixData[secondMatrixIndex].bottomRight);

            //final output
            Console.WriteLine($"\n{matrixData[firstMatrixIndex].matrixName} * {matrixData[secondMatrixIndex].matrixName} = ");
            Console.WriteLine($"[{resultTopLeft} {resultTopRight}]");
            Console.WriteLine($"[{resultBottomLeft} {resultBottomRight}]");
        }

        static void CalculateInverse(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: invmat matrixName");
                return;
            }

            int matrixIndex = -1;
            string matrixName = codeArray[1];
            for (int i = 0; i < matrixCounter; i++)
            {
                if (matrixData[i].matrixName == matrixName)
                {
                    matrixIndex = i;
                }
            }

            if (matrixIndex == -1)
            {
                Console.WriteLine("Matrix not found");
                return;
            }

            double determinant = (matrixData[matrixIndex].topLeft * matrixData[matrixIndex].bottomRight)
                                - (matrixData[matrixIndex].topRight * matrixData[matrixIndex].bottomLeft);

            if(determinant == 0)
            {
                Console.WriteLine("This matrix has no inverse");
                return;
            }
            Console.WriteLine($"det({matrixName}) = {determinant}");

            double inverseTopLeft = matrixData[matrixIndex].bottomRight / determinant;
            double inverseTopRight = -matrixData[matrixIndex].topRight / determinant;
            double inverseBottomLeft = -matrixData[matrixIndex].bottomLeft / determinant;
            double inverseBottomRight = matrixData[matrixIndex].topLeft / determinant;

            Console.WriteLine($"Inverse of matrix {matrixName} = ");
            Console.WriteLine($"[{inverseTopLeft} {inverseTopRight}]");
            Console.WriteLine($"[{inverseBottomLeft} {inverseBottomRight}]");
        }

        //Process the calculator
        static void ProcessCommand(string userInput)
        {
            if (userInput.StartsWith("invmat "))
            {
                CalculateInverse(userInput);
            }
            else if (userInput.StartsWith("dotmat "))
            {
                MultiplyMatrices(userInput);
            }
            else if(userInput.StartsWith("detmat "))
            {
                CalculateDeterminant(userInput);
            }
            else if (userInput.StartsWith("scalmat "))
            {
                ScaleMatrix(userInput);
            }
            else if(userInput.StartsWith("addmat "))
            {
                AddMatrices(userInput);
            }
            else if (userInput.StartsWith("mat "))
            {
                CreateMatrix(userInput);
            }
            else if(userInput.StartsWith("numrand "))
            {
                GenerateRandomNumber(userInput);
            }
            else if (userInput.StartsWith("numcheckdigit "))
            {
                CalculateCheckDigit(userInput);
            }
            else if(userInput.StartsWith("divisible "))
            {
                CheckDivisibility(userInput);
            }
            else if (userInput.StartsWith("numprime "))
            {
                CheckPrime(userInput);
            }
            else if(userInput.StartsWith("scalvec "))
            {
                ScaleVec(userInput);
            }
            else if (userInput.StartsWith("dotvec "))
            {
                MultiplyVectors(userInput);
            }
            else if (userInput.StartsWith("subvec "))
            {
                SubtractVectors(userInput);
            }
            else if (userInput.StartsWith("addvec "))
            {
                AddVectors(userInput);
            }
            else if (userInput.StartsWith("vec "))
            {
                CreateVector(userInput);
            }
            else if (userInput.StartsWith("lengthvec "))
            {
                CalculateVectorLength(userInput);
            }
            else if (userInput.StartsWith("deg2rad "))
            {
                DegreesToRadians(userInput);
            }
            else if (userInput.StartsWith("rad2deg "))
            {
                RadiansToDegrees(userInput);
            }
            else if (userInput.StartsWith("gradientline "))
            {
                CalculateGradient(userInput);
            }
            else if (userInput.StartsWith("midpointline "))
            {
                CalculateMidpoint(userInput);
            }
            else if (userInput.StartsWith("lengthline "))
            {
                CalculateLineLength(userInput);
            }
            else if (userInput.StartsWith("line "))
            {
                CreateLine(userInput);
            }
            else if (userInput.EndsWith("!"))
            {
                CalculateFactorial(userInput);
            }
            else if (userInput.StartsWith("square "))
            {
                CalculateSquare(userInput);
            }
            else if (userInput.StartsWith("sqrt "))
            {
                CalculateSquareRoot(userInput);
            }

            else if (userInput.Contains("(") || userInput.Contains(")"))
            {
                CalculateParenthesesExpression(userInput);
            }
            else
            {
                bool answer = CalculateExpression(userInput, out double result);
                if (answer == true)
                {
                    Console.WriteLine(result);
                }
            }

            
        }

    }
}