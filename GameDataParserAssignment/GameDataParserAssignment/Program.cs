
using System.Text.Json;

bool shouldStop = false;
Console.WriteLine("Enter the name of the file you want to read:");

do
{
    string fileName = Console.ReadLine();
    string fileContents;

    try
    {
        if(File.Exists(fileName)) // Could've simply thrown an exception but I prefer it this way.
        {
            fileContents = File.ReadAllText(fileName);
            List<GameData> videoGames;
            try
            {
                videoGames = JsonSerializer.Deserialize<List<GameData>>(fileContents);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON in the {fileName} was not in a valid format.");
                Console.WriteLine($"JSON body: {fileContents}");
                // Logger.Add(ex);
                break;
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

            shouldStop = true;
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine("File name cannot be null.");
        shouldStop = false;
    }
} while (!shouldStop);

Console.WriteLine("Press any key to close.");
Console.ReadKey();


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

        _gameUserInteraction.ShowMessage("Enter the name of the file you want to read:");

        string fileName = _gameUserInteraction.PromptUserFileName();

        _gameDataRepository.Read(fileName);

        _gameUserInteraction.Exit();
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