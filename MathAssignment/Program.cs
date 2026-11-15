namespace MathAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

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

       
        //Process the calculator
        static void ProcessCommand(string userInput)
        {
            if(userInput.Contains("(") || userInput.Contains(")"))
            {
                CalculateParenthesesExpression(userInput);
            }
            else
            {
                if (userInput.EndsWith("!"))
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
                else
                {
                    bool answer = CalculateExpression(userInput, out double result);
                    if(answer == true)
                    {
                        Console.WriteLine(result);
                    }
                }

            }
        }

    }
}