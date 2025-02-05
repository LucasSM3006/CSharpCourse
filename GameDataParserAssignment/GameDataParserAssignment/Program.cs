
using System.Text.Json;

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


    }

    public void ShowMessage(string message)
    {
        throw new NotImplementedException();
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
}