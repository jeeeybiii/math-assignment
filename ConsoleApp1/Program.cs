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
            Console.WriteLine($"Processing: {userInput}");
        }
    }
}