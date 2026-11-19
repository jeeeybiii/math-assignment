//John Vincent L. Macuto & Akirah Quinto's Digital Numeracy Assignment
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

        /*
         * Method: 
         * Main
         * 
         * Purpose:
         * Starts the calculator by calling MainMenu
         * 
         * Difficulty:
         * No significant calculation was required here, but the entry point needed
         * to remain simple.
         * 
         * Solution:
         * Main delegates control to MainMenu instead of containing the full program.
         * 
         * Reason:
         * Separating the menu from Main keeps the entry point clean and
         * makes the program easier to read and maintain.
         */
        static void Main(string[] args)
        {
            MainMenu();
        }




        /*
         * Method:
         * MainMenu
         * 
         * Purpose:
         * Displays the heading, repeatedly acceps user commands, and continues until
         * the user enters exit.
         * 
         * Difficulty:
         * The calculator needed to continue accepting commands while safely handling
         * empty input and null input without crashing.
         * 
         * Solution:
         * Created a do while loop to keep the program active. Input is trimmed and 
         * converted to lowercase, then help, exit, empty input, and mathematical
         * commands are handled separately
         * 
         * Reason:
         * The most suitable since the program must accept at least one commands and
         * repeats until the user chooses to exit.
         */
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


        /*
         * Method:
         * DisplayHelp
         * 
         * Purpose:
         * DisplayHelp lists the available commands of the calculator program in case
         * a user needs some guidance on writing the correct syntax of the calculator.
         * 
         * Difficulty:
         * The repeated console writing was straightforward. It is just easy to be lost
         * since the font colors are similar. Therefore, double checking if they are
         * printed correctly is a must.
         * 
         * Solution:
         * Divided the commands into their respective sections.
         * 
         * Reason:
         * A guidebook in case a user gets confused.
         */
        //menu to display commands
        static void DisplayHelp()
        {
            Console.Clear();
            Console.WriteLine("HELP COMMANDS");
            Console.WriteLine("General Commands:");
            Console.WriteLine($"{"help",-28}Display available commands");
            Console.WriteLine($"{"exit",-28}Close the calculator");
            Console.WriteLine();

            Console.WriteLine("ARITHMETIC");
            Console.WriteLine($"{"number + number",-28}Addition");
            Console.WriteLine($"{"number - number",-28}Subtraction");
            Console.WriteLine($"{"number * number",-28}Multiplication");
            Console.WriteLine($"{"number / number",-28}Division");
            Console.WriteLine($"{"number!",-28}Factorial");
            Console.WriteLine($"{"square number",-28}Square a number");
            Console.WriteLine($"{"sqrt number",-28}Square root a number");
            Console.WriteLine($"{"(expression)",-28}Evaluate parentheses using BEDMAS");
            Console.WriteLine();

            Console.WriteLine("GEOMETRY");
            Console.WriteLine($"{"line name (x1, y1, x2, y2)",-28}Create a line");
            Console.WriteLine($"{"lengthline name",-28}Calculate line length");
            Console.WriteLine($"{"midpointline name",-28}Calculate midpoint");
            Console.WriteLine($"{"gradientline name",-28}Calculate gradient");
            Console.WriteLine($"{"rad2deg value",-28}Convert radians to degrees");
            Console.WriteLine($"{"deg2rad value",-28}Convert degrees to radians");
            Console.WriteLine();

            Console.WriteLine("VECTORS");
            Console.WriteLine($"{"vec name (x, y)",-28}Create a vector");
            Console.WriteLine($"{"lengthvec name",-28}Calculate vector length");
            Console.WriteLine($"{"addvec a b",-28}Add vectors, producing a + b");
            Console.WriteLine($"{"subvec a b",-28}Subtract a from b, producing b - a");
            Console.WriteLine($"{"dotvec a b",-28}Calculate dot product and its meaning");
            Console.WriteLine($"{"scalvec scalar name",-28}Apply scalar multiplication");
            Console.WriteLine();

            Console.WriteLine("NUMBER THEORY");
            Console.WriteLine($"{"numprime number",-28}Test primality");
            Console.WriteLine($"{"numcheckdigit digits",-28}Calculate ISBN, UPC, or EAN-13 check digit");
            Console.WriteLine($"{"numrand a X c m",-28}Generate an LCG sequence");
            Console.WriteLine($"{"divisible divisor number",-28}Test whether one number divides another");
            Console.WriteLine();

            Console.WriteLine("MATRICES");
            Console.WriteLine($"{"mat name (a b c d)",-28}Create a 2 x 2 matrix");
            Console.WriteLine($"{"addmat a b",-28}Add matrices");
            Console.WriteLine($"{"dotmat a b",-28}Multiply matrices");
            Console.WriteLine($"{"scalmat scalar name",-28}Apply scalar multiplication");
            Console.WriteLine($"{"detmat name",-28}Calculate determinant");
            Console.WriteLine($"{"invmat name",-28}Calculate inverse");
        }

        /*
         * Method: DecimalToBinary
         * Purpose: Converts a decimal whole number into binary.
         */
        public static void DecimalToBinary(string userInput)
        {
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: binary number");
                return;
            }

            int number = 0;

            if (int.TryParse(codeArray[1], out number) == false)
            {
                Console.WriteLine("Please enter a valid whole number!");
                return;
            }

            if (number < 0)
            {
                Console.WriteLine("Binary conversion does not accept negative numbers!");
                return;
            }

            if (number == 0)
            {
                Console.WriteLine("0");
                return;
            }

            string binary = "";

            while (number > 0)
            {
                int remainder = number % 2;
                binary = remainder + binary;
                number = number / 2;
            }

            Console.WriteLine(binary);
        }


        /*
        * Method: BinaryToDecimal
        * Purpose: Converts a binary number into its decimal equivalent.
        */
        public static void BinaryToDecimal(string userInput)
        {
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: decimal binaryNumber");
                return;
            }

            string binary = codeArray[1];

            int decimalNumber = 0;
            int power = 1;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] != '0' && binary[i] != '1')
                {
                    Console.WriteLine("Binary numbers can only contain 0 and 1!");
                    return;
                }

                int digit = binary[i] - '0';

                decimalNumber = decimalNumber + (digit * power);

                power = power * 2;
            }

            Console.WriteLine(decimalNumber);
        }

        /*
         * Method:
         * CalculateParenthesesExpression
         * 
         * Purpose:
         * To solve the arithmetic operations inside the parentheses regardless if the
         * algorithm is BEDMAS.
         * 
         * Difficulty:
         * Very difficult. I had to keep asking chatgpt on how to approach the problem since
         * my weakpoint is manipulating strings.
         * 
         * 
         * Solution:
         * I limited chatgpt into just providing me the pseudocode. I've used the algorithm
         * of getting the length first, if the parentheses exist.
         * 
         * Reason:
         * To separate standard arithmetic BEDMAS into prioritizing what's inside the 
         * parentheses first.
         */
        public static void CalculateParenthesesExpression(string userInput)
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

        /*
         * Method:
         * CalculateExpression
         * 
         * Purpose:
         * The standard arithmetic operation using BEDMAS. Every working calculator should
         * at least have this.
         * 
         * Difficulty:
         * Very difficult. This was my initial problem when I was making the calculator.
         * There were lots of trial and error and confusion since I have to capture which
         * one was the number and which was the operator. I thoroughly admit that I had to
         * rely on chatgpt for the solutions.
         * 
         * Solution:
         * Used mod to distinguish which was a number and which was operator. This specific method
         * falls on else on the ProcessCommand if the initial userInput itself is an arithmetic
         * operation.
         * 
         * Reason:
         * To display a working calculator.
         */
        public static bool CalculateExpression(string userInput, out double result)
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


        /*
         * Method:
         * CalculateFactorial
         * 
         * Purpose:
         * To calculate a factorial of a number.
         * 
         * Difficulty:
         * Medium. Since the struggle with string manipulation, it took some time to do this.
         * 
         * Solution:
         * Lots of trial and error with console writing first to test theories.
         * 
         * Reason:
         * I separated the standard arithmetic operations if a userinput has '!' in a number.
         */
        public static void CalculateFactorial(string userInput)
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

        /*
         * Method:
         * CalculateSquare
         * 
         * Purpose:
         * To display a square of a number
         * 
         * Difficulty:
         * Easy. The main issue I encountered was finding the right array slot
         * 
         * Solution:
         * A keyword of the command and then a number. If it doesn't match the length,
         * a hint will be displayed instead.
         * 
         * Reason:
         * To demonstrate that the calculator has the core functionalities.
         */
        public static void CalculateSquare(string userInput)
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

        /*
         * Method:
         * CalculateSquareRoot
         *
         * Purpose:
         * Validates a number supplied after the sqrt command, calculates its
         * square root, and displays the result.
         *
         * Difficulty:
         * Square roots of negative numbers are not real numbers, so the method
         * needed to reject them instead of returning an invalid result.
         *
         * Solution:
         * I split the command into two parts, used TryParse to validate the
         * number, checked that it was not negative, and then used Math.Sqrt.
         *
         * Reason:
         * TryParse prevents invalid text from crashing the program, while the
         * negative-number check prevents an undefined real-number operation.
         */
        public static void CalculateSquareRoot(string userInput)
        {
            double squareRootNumber = 0, squareRootResult = 0;
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 2)
            {
                Console.WriteLine("USE: sqrt number");
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
        /*
         * Method: CreateLine
         * Purpose: Creates and stores a named line using two coordinate pairs.
         * Difficulty: Parentheses and commas had to be removed before the four coordinates could be parsed.
         * Solution: Punctuation is replaced with spaces, all coordinates are validated, duplicate names
         * are rejected, and the completed LineData value is stored in an array.
         * Reason: Named stored lines can be reused by length, midpoint, and gradient commands.
         */
        public static void CreateLine(string userInput)
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

        /*
         * Method: CalculateLineLength
         * Purpose: Finds a stored line and calculates the distance between its endpoints.
         * Difficulty: The command supplies a line name rather than the coordinates directly.
         * Solution: The method searches the line array, calculates changes in x and y, and applies
         * the distance formula using Math.Sqrt.
         * Reason: Searching by name allows one stored line to be used for several calculations.
         */
        public static void CalculateLineLength(string userInput)
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



        /*
         * Method: CalculateMidpoint
         * Purpose: Calculates the midpoint of a stored line.
         * Difficulty: Both coordinate pairs had to be retrieved from the correct stored line.
         * Solution: The method searches by name and averages the two x values and two y values separately.
         * Reason: The midpoint formula produces the coordinate exactly halfway between both endpoints.
         */
        public static void CalculateMidpoint(string userInput)
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



        /*
         * Method: CalculateGradient
         * Purpose: Calculates the gradient of a stored line using change in y divided by change in x.
         * Difficulty: A vertical line has zero change in x, which would cause division by zero.
         * Solution: The method finds the line, calculates both changes, and rejects a zero change in x.
         * Reason: The validation correctly reports an undefined gradient instead of crashing.
         */
        public static void CalculateGradient(string userInput)
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

        /*
         * Method: RadiansToDegrees
         * Purpose: Converts a user-supplied angle from radians to degrees.
         * Difficulty: The command needed exact argument validation before applying the formula.
         * Solution: TryParse validates the value and the method multiplies it by 180 / Math.PI.
         * Reason: Math.PI provides a precise built-in value of pi for the standard conversion formula.
         */
        public static void RadiansToDegrees(string userInput)
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


        /*
         * Method: DegreesToRadians
         * Purpose: Converts a user-supplied angle from degrees to radians.
         * Difficulty: Invalid or missing angle values needed to be rejected safely.
         * Solution: TryParse validates the value and the method multiplies it by Math.PI / 180.
         * Reason: This is the standard degree-to-radian conversion and avoids a hard-coded pi value.
         */
        public static void DegreesToRadians(string userInput)
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



        /*
         * Method: CalculateVectorLength
         * Purpose: Calculates the magnitude of a stored two-dimensional vector.
         * Difficulty: The named vector first had to be located safely in the storage array.
         * Solution: The method searches by name and applies the Pythagorean formula to its x and y components.
         * Reason: A vector's components form the two perpendicular sides used to calculate its magnitude.
         */

        public static void CalculateVectorLength(string userInput)
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




        /*
         * Method: CreateVector
         * Purpose: Creates and stores a named vector containing x and y components.
         * Difficulty: The command contains punctuation and duplicate names could overwrite existing data.
         * Solution: Punctuation is removed, both components are validated, duplicate names are rejected,
         * and the vector is stored at the current vector-counter position.
         * Reason: Stored names allow later vector operations to reuse the same components.
         */

        public static void CreateVector(string userInput)
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




        /*
         * Method: AddVectors
         * Purpose: Adds two stored vectors and displays the resulting vector.
         * Difficulty: Both vector names needed to be found before accessing their array positions.
         * Solution: The method searches for both indexes, returns if either is missing, and adds matching components.
         * Reason: Vector addition combines x with x and y with y.
         */
        public static void AddVectors(string userInput)
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




        /*
         * Method: SubtractVectors
         * Purpose: Subtracts the first named vector from the second and displays the result.
         * Difficulty: The assignment wording requires subvec a b to calculate b - a, so operand order matters.
         * Solution: After locating both vectors, the first vector's components are subtracted from the second's.
         * Reason: This follows the required lexicon definition rather than assuming normal left-to-right order.
         */
        public static void SubtractVectors(string userInput)
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

            double resultX = vectorData[secondVectorIndex].vectorX - vectorData[firstVectorIndex].vectorX;

            double resultY = vectorData[secondVectorIndex].vectorY - vectorData[firstVectorIndex].vectorY;

            Console.WriteLine($"{vectorData[secondVectorIndex].vectorName} - {vectorData[firstVectorIndex].vectorName} = ({resultX}, {resultY})");

        }



        /*
         * Method: MultiplyVectors
         * Purpose: Calculates the dot product of two vectors and explains what its sign means.
         * Difficulty: A dot product returns one scalar rather than another vector, and its meaning also had to be shown.
         * Solution: Matching components are multiplied and added, then the result is classified as positive,
         * zero, or negative to describe the vectors' general directional relationship.
         * Reason: This implements both the calculation and interpretation required by the assignment.
         */
        public static void MultiplyVectors(string userInput)
        {
            string cleanedInput = userInput.Replace("(", " ").Replace(")", " ").Replace(",", " ");
            string[] codeArray = cleanedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (codeArray.Length != 3)
            {
                Console.WriteLine("USE: dotvec firstVector secondVector");
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



        /*
         * Method: ScaleVec
         * Purpose: Applies a scalar value to every component of a stored vector.
         * Difficulty: The scalar and vector name required different validation and lookup steps.
         * Solution: TryParse validates the scalar, the vector array is searched by name, and both components are multiplied.
         * Reason: Scalar multiplication changes a vector's magnitude and possibly its direction while preserving its structure.
         */
        public static void ScaleVec(string userInput)
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
        

        /*
         * Method: CheckPrime
         * Purpose: Determines whether a whole number greater than one is prime.
         * Difficulty: Testing every value up to the number would perform unnecessary calculations.
         * Solution: The method checks possible divisors only while divisor squared is less than or equal to the number.
         * Reason: If a number has a factor, one factor must be at or below its square root, making this more efficient.
         */
        public static void CheckPrime(string userInput)
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

            if(prime >= 10000)
            {
                Console.WriteLine("Prime testing only accepts numbers below 10000.");
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

        

        /*
         * Method: CheckDivisibility
         * Purpose: Reports whether one whole number is exactly divisible by another.
         * Difficulty: A divisor of zero had to be prevented because division by zero is undefined.
         * Solution: Both values are validated, zero is rejected as a divisor, and the remainder operator tests divisibility.
         * Reason: A remainder of zero proves that the division is exact.
         */
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


        

        /*
         * Method: CalculateCheckDigit
         * Purpose: Detects an ISBN-10, UPC-A, or EAN-13 input and calculates its missing check digit.
         * Difficulty: Leading zeros had to be preserved and each code type uses different weights.
         * Solution: The input remains a string, every character is validated with char.IsDigit, and its length
         * selects the appropriate weighted calculation. ISBN check value 10 is displayed as X.
         * Reason: String storage preserves leading zeros while still allowing individual digits to be converted safely.
         */
        public static void CalculateCheckDigit(string userInput)
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


        

        /*
         * Method: GenerateRandomNumber
         * Purpose: Generates and displays a Linear Congruential Method sequence until a value repeats.
         * Difficulty: The newly generated value had to become the next input, and the loop needed a safe stopping condition.
         * Solution: The method repeatedly applies (aX + c) mod m and uses a Boolean array to remember values already seen.
         * Reason: Modulo limits results to 0 through m - 1, so the Boolean array detects the inevitable repeated sequence.
         */
        public static void GenerateRandomNumber(string userInput)
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


        

        /*
         * Method: CreateMatrix
         * Purpose: Creates and stores a named 2x2 matrix containing four numeric elements.
         * Difficulty: Four values had to be mapped consistently to their positions and duplicate names prevented.
         * Solution: The command is cleaned and validated, then values are stored as top-left, top-right,
         * bottom-left, and bottom-right fields in MatrixData.
         * Reason: Named fields make later formulas easier to read and reduce position errors.
         */
        public static void CreateMatrix(string userInput)
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


        

        /*
         * Method: AddMatrices
         * Purpose: Adds two stored 2x2 matrices and displays the working and final matrix.
         * Difficulty: Every result had to combine elements from the same matrix position.
         * Solution: Both matrices are found by name and their four matching fields are added separately.
         * Reason: Matrix addition is performed position by position.
         */
        public static void AddMatrices(string userInput)
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




        /*
         * Method: ScaleMatrix
         * Purpose: Multiplies every element of a stored matrix by a scalar.
         * Difficulty: The method needed to validate a numeric scalar and locate a separately named matrix.
         * Solution: TryParse validates the scalar, the matrix is searched by name, and all four fields are multiplied.
         * Reason: Applying the scalar independently to every element follows the definition of scalar matrix multiplication.
         */
        public static void ScaleMatrix(string userInput)
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




        /*
         * Method: CalculateDeterminant
         * Purpose: Calculates and displays the determinant of a stored 2x2 matrix.
         * Difficulty: The diagonal products and subtraction order needed to remain correct.
         * Solution: The method applies (topLeft * bottomRight) - (topRight * bottomLeft).
         * Reason: This is the determinant formula for a 2x2 matrix and is also needed when finding an inverse.
         */
        public static void CalculateDeterminant(string userInput)
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




        /*
         * Method: MultiplyMatrices
         * Purpose: Multiplies two stored 2x2 matrices and displays the resulting matrix.
         * Difficulty: Matrix multiplication uses rows and columns rather than matching positions, and order matters.
         * Solution: Each result field is calculated using the appropriate row from the first matrix and column from the second.
         * Reason: Writing the four row-by-column calculations separately makes the operation clear and preserves operand order.
         */
        public static void MultiplyMatrices(string userInput)
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




        /*
         * Method: CalculateInverse
         * Purpose: Calculates and displays the inverse of a stored 2x2 matrix.
         * Difficulty: Matrices with a zero determinant have no inverse and would require division by zero.
         * Solution: The determinant is calculated first and zero is rejected. The diagonal values are swapped,
         * the other two values are negated, and every value is divided by the determinant.
         * Reason: This directly implements the standard 2x2 inverse formula while preventing an undefined operation.
         */
        public static void CalculateInverse(string userInput)
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

        //END OF MATRIX COMMANDS

        /*
         * Method: 
         * ProcessCommand
         * 
         * Purpose:
         * The main entry point of the calculator if the user chooses not to type help or exit.
         * Provided that the syntax was written correctly, it will run the specific method.
         * 
         * Difficulty:
         * At the start of making the calculator, I was unsure of what to do since this is
         * my first time writing a CLI based program and had to rely on chatgpt on how to start
         * It was a trial and error if I should write the arithmetic first or go straight into
         * a topic.
         * 
         * Solution:
         * The initial code of the ProcessCommand method was brute forced. I did the arithmetic
         * and the line into one method. I realized that eventually, as a keep adding on topics
         * one method that does all calculation will be confusing. So, I separated lexicons
         * into methods.
         * 
         * Reason:
         * Different methods are the most efficient way of handling specific commands. Having
         * all of them in one method will produce a lot of lines, and if not done correctly,
         * a lot of bugs.
         */
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