using System.Text.Json;

GameDataParserApplication app = new GameDataParserApplication(new ConsoleUserInteraction(), new JsonReader());
Logger logger = new Logger("log.txt");

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry! The application has run into an unexpected issue and will have to be closed!");
    logger.Log(ex);
    Console.WriteLine("Press any key to close");
    Console.ReadKey();
}

public class GameDataParserApplication
{
    private readonly IGameDataAppUserInteraction _gameUserInteraction;
    private readonly IGameDataRepository _gameDataRepository;

    public GameDataParserApplication(IGameDataAppUserInteraction gameDataAppUserInteraction, IGameDataRepository gameDataRepository)
    {
        _gameUserInteraction = gameDataAppUserInteraction;
        _gameDataRepository = gameDataRepository;
    }
    
    public void Run()
    {
        bool shouldStop = false;
        Console.WriteLine("Enter the name of the file you want to read:");
        string fileName = "";
        string fileContents = "";

        do
        {
            fileName = Console.ReadLine();

            try
            {
                fileContents = File.ReadAllText(fileName);
                shouldStop = true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("File name cannot be null.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("File name cannot be empty.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found.");
            }
        } while (!shouldStop);

        List<GameData> videoGames = new List<GameData>();

        try
        {
            videoGames = JsonSerializer.Deserialize<List<GameData>>(fileContents);
        }
        catch (JsonException ex)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"JSON in {fileName} file was not in a valid format. JSON body: ");
            Console.WriteLine(fileContents);

            Console.ForegroundColor = originalColor;

            throw new JsonException($"{ex.Message} The file is: {fileName}", ex); // Message is read only, hence the need to create a new exception. Just like java.
        }

        if (videoGames.Count > 0)
        {
            foreach (GameData game in videoGames)
            {
                Console.WriteLine(game);
            }
        }
        else
        {
            Console.WriteLine("No games.");
        }

        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }
}

public class Logger
{
    private readonly string LogFileName;

    public Logger(string logFileName)
    {
        LogFileName = logFileName;
    }

    public void Log(Exception ex)
    {
        string entry =
$@"[{DateTime.Now}]
Exception message: {ex.Message}
Stack trace: {ex.StackTrace}

";

        File.AppendAllText(LogFileName, entry); // creates a log if it doesn't exist.
    }
}

public interface IGameDataAppUserInteraction
{
    public void ShowMessage(string message);
    public string PromptUserFileName();
    public void Exit();
}

public class ConsoleUserInteraction : IGameDataAppUserInteraction
{
    public string PromptUserFileName()
    {
        bool shouldStop = false;

        while(!shouldStop)
        {
            string userInput = Console.ReadLine();



        }

        return null;
    }

    public void ShowMessage(string message)
    {
        throw new NotImplementedException();
    }

    public string DisplayFromFile()
    {
        return null;
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }
}

public interface IGameDataRepository
{
    public string Read(string fileName);
}

public class JsonReader : IGameDataRepository
{
    public string Read(string fileName)
    {

        return null;
    }
}

public class GameData
{
    public string Title { get; }
    public int ReleaseYear { get; }
    public double Rating { get; }

    public GameData(string title, int releaseYear, double rating)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Rating = rating;
    }

    public override string ToString()
    {
        return $"{Title}, released in {ReleaseYear}, with a rating of {Rating}";
    }
}