using System.Text.Json;

IGameDataAppUserInteraction userInteraction = new ConsoleUserInteraction();

GameDataParserApplication app = new GameDataParserApplication(userInteraction, new VideoGamesDeserializer(userInteraction), new GamesPrinter(userInteraction), new LocalFileReader());
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
    private readonly IGamesPrinter _gamesPrinter;
    private readonly IVideoGameDeserializer _gameDeserializer;
    private readonly IFileReader _fileReader;

    public GameDataParserApplication(
        IGameDataAppUserInteraction gameDataAppUserInteraction,
        IVideoGameDeserializer videoGameDeserializer,
        IGamesPrinter gamesPrinter,
        IFileReader fileReader)
    {
        _gameUserInteraction = gameDataAppUserInteraction;
        _gamesPrinter = gamesPrinter;
        _gameDeserializer = videoGameDeserializer;
        _fileReader = fileReader;
    }
    
    public void Run()
    {
        string fileName = _gameUserInteraction.ReadValidFilePath();
        string fileContents = _fileReader.Read(fileName);
        List<GameData> videoGames = _gameDeserializer.DeserializeFrom(fileName, fileContents);
        _gamesPrinter.PrintGames(videoGames);
        _gameUserInteraction.Exit();
    }
}

public interface IFileReader
{
    public string Read(string fileName);
}

public class LocalFileReader : IFileReader
{
    public string Read(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}

public interface IGamesPrinter
{
    public void PrintGames(List<GameData> videoGames);
}

public class GamesPrinter : IGamesPrinter
{
    private IGameDataAppUserInteraction _gameUserInteraction;

    public GamesPrinter(IGameDataAppUserInteraction gameDataAppUserInteraction)
    {
        _gameUserInteraction = gameDataAppUserInteraction;
    }

    public void PrintGames(List<GameData> videoGames)
    {
        if (videoGames.Count > 0)
        {
            foreach (GameData game in videoGames)
            {
                _gameUserInteraction.PrintMessage(game.ToString());
            }
        }
        else
        {
            _gameUserInteraction.PrintMessage("No games.");
        }
    }
}

public interface IVideoGameDeserializer
{
    public List<GameData> DeserializeFrom(string filename, string fileContents);
}

public class VideoGamesDeserializer : IVideoGameDeserializer
{
    private readonly IGameDataAppUserInteraction _gameUserInteraction;

    public VideoGamesDeserializer(IGameDataAppUserInteraction gameUserInteraction)
    {
        _gameUserInteraction = gameUserInteraction;
    }

    public List<GameData> DeserializeFrom(string fileName, string fileContents)
    {
        try
        {
            return JsonSerializer.Deserialize<List<GameData>>(fileContents);
        }
        catch (JsonException ex)
        {
            _gameUserInteraction.PrintError($"JSON in {fileName} file was not in a valid format. JSON body: ");
            _gameUserInteraction.PrintError(fileContents);

            throw new JsonException($"{ex.Message} The file is: {fileName}", ex); // Message is read only, hence the need to create a new exception. Just like java.
        }
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
    public string ReadValidFilePath();
    public void PrintMessage(string message);
    public void PrintError(string message);
    public void Exit();
}

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