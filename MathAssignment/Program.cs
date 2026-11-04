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

        static void ProcessCommand(string userInput)
        {
            //initialize variables
            int total = 0, currentTerm = 0;
            string[] codeArray = userInput.Split(' ', '\t', StringSplitOptions.RemoveEmptyEntries);
            bool numberValidation = false, operatorValidation = false;
            Console.WriteLine($"Processing: {userInput}");

            if(codeArray.Length < 3)
            {
                Console.WriteLine("Expression is too short");
                return;
            }
            if(codeArray.Length % 2 == 0)
            {
                Console.WriteLine("Invalid expression format");
                return;
            }

            for (int i = 0; i < codeArray.Length; i++)
            {
                if(i % 2 == 0)
                {
                    if (double.TryParse(codeArray[i], out double tempCatcher) == true)
                    {
                        Console.WriteLine($"Parsed value: {tempCatcher}");
                        numberValidation = true;
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
                    else
                    {
                        operatorValidation = true;
                    }
                }
            }


            if(numberValidation == true && operatorValidation == true)
            {
                Console.WriteLine("Expression accepted.");

            }
        }

    }
}