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
            bool calculationSuccessful = false;
            double firstNumber, secondNumber;
            string[] codeArray;
            double result = 0;
            Console.WriteLine($"Processing: {userInput}");
            string cleanedInput = userInput
                                    .Replace("+", " + ")
                                    .Replace("-", " - ")
                                    .Replace("*", " * ")
                                    .Replace("/", " / ");
            codeArray = cleanedInput.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            if(codeArray.Length != 3)
            {
                Console.WriteLine("Invalid expression format.");
            }
            else if (double.TryParse(codeArray[0], out firstNumber) == false || double.TryParse(codeArray[2], out secondNumber) == false)
            {
                Console.WriteLine("Invalid number");
            }
            else 
            {
                switch (codeArray[1])
                {
                    case "+":

                        result = Add(firstNumber, secondNumber);
                        calculationSuccessful = true;
                        break;
                    case "-":

                        result = Subtract(firstNumber, secondNumber);
                        calculationSuccessful = true;
                        break;
                    case "*":

                        result = Multiply(firstNumber, secondNumber);
                        calculationSuccessful = true;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            Console.WriteLine("Cannot divide by 0!");
                        }
                        else
                        {

                            result = Divide(firstNumber, secondNumber);
                            calculationSuccessful = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown operator");
                        break;
                }
            }
            if(calculationSuccessful == true)
            {
                Console.WriteLine(result);
            }
            /*foreach(string parts in codeArray)
            {
                if (codeArray[0].ToLower() == "vec")
                {
                    isRecognised = true;
                    Console.WriteLine("Create vector command recognised");
                }
            }
            */
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