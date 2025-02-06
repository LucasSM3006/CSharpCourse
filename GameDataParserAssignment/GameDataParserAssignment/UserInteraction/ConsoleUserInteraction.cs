namespace GameDataParserAssignment.UserInteraction
{
    public class ConsoleUserInteraction : IGameDataAppUserInteraction
    {
        public string ReadValidFilePath()
        {
            bool shouldStop = false;
            string fileName = "";

            do
            {
                Console.WriteLine("Enter the name of the file you want to read:");
                fileName = Console.ReadLine();

                if (fileName is null)
                {
                    Console.WriteLine("File name cannot be null.");
                }
                else if (fileName == string.Empty)
                {
                    Console.WriteLine("File name cannot be empty.");
                }
                else if (!File.Exists(fileName))
                {
                    Console.WriteLine("File not found.");
                }
                else
                {
                    shouldStop = true;
                }
            } while (!shouldStop);
            return fileName;
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintError(string message)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ForegroundColor = originalColor;
        }

        public void Exit()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }
}
