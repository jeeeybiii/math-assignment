namespace MathAssignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
            Console.ReadLine();
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

        static void ProcessCommand(string userInput)
        {
            string compactInput = userInput.Replace(" ", "");

            // Factorial route
            if (compactInput.EndsWith('!'))
            {
                string factorialNumberText =
                    compactInput.Substring(0, compactInput.Length - 1);

                if (!int.TryParse(factorialNumberText, out int factorialNumber))
                {
                    Console.WriteLine("Factorial requires a whole number.");
                    return;
                }

                if (factorialNumber < 0)
                {
                    Console.WriteLine("Factorial cannot use a negative number.");
                    return;
                }

                // Temporary output until factorial calculation is implemented.
                Console.WriteLine($"Factorial number: {factorialNumber}");
                return;
            }

            // Normal arithmetic route
            int operatorPosition = -1;

            // Start at 1 because position 0 could be a negative sign.
            for (int i = 1; i < compactInput.Length; i++)
            {
                if (compactInput[i] == '+' ||
                    compactInput[i] == '-' ||
                    compactInput[i] == '*' ||
                    compactInput[i] == '/')
                {
                    operatorPosition = i;
                    break;
                }
            }

            if (operatorPosition == -1)
            {
                Console.WriteLine("No operator found.");
                return;
            }

            string firstNumberText =
                compactInput.Substring(0, operatorPosition);

            char operatorCharacter =
                compactInput[operatorPosition];

            string secondNumberText =
                compactInput.Substring(operatorPosition + 1);

            if (!double.TryParse(firstNumberText, out double firstNumber) ||
                !double.TryParse(secondNumberText, out double secondNumber))
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            double result;

            switch (operatorCharacter)
            {
                case '+':
                    result = Add(firstNumber, secondNumber);
                    break;

                case '-':
                    result = Subtract(firstNumber, secondNumber);
                    break;

                case '*':
                    result = Multiply(firstNumber, secondNumber);
                    break;

                case '/':
                    if (secondNumber == 0)
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        return;
                    }

                    result = Divide(firstNumber, secondNumber);
                    break;

                default:
                    Console.WriteLine("Unknown operator.");
                    return;
            }

            Console.WriteLine(result);
        }
        static double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        static double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        static double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        static double Divide(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}