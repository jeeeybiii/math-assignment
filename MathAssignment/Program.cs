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

        //BEDMAS
        static void CalculateExpression(string userInput)
        {
            //initialize variables
            double total = 0, currentTerm = 0, nextNumber = 0, result = 0;
            string[] codeArray = userInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string operatorSign;
            Console.WriteLine($"Processing: {userInput}");

            if (codeArray.Length < 3)
            {
                Console.WriteLine("Expression is too short");
                return;
            }
            if (codeArray.Length % 2 == 0)
            {
                Console.WriteLine("Invalid expression format");
                return;
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
                        return;
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
                        return;
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
                            return;
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
            Console.WriteLine(result);
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
            if (userInput.EndsWith("!"))
            {
                CalculateFactorial(userInput);
            }
            else if (userInput.StartsWith("square "))
            {
                CalculateSquare(userInput);
            }
            else if(userInput.StartsWith("sqrt "))
            {
                CalculateSquareRoot(userInput);
            }
            else
            {
                CalculateExpression(userInput);
            }
 

        }

    }
}