
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

        string filename = _gameUserInteraction.PromptUserFileName();

        _gameDataRepository.ReadDataFromJson(fileName);

        _gameUserInteraction.Exit();
    }
}

public interface IGameDataAppUserInteraction
{
    public void ShowMessage(string message);
    public string PromptUserFileName();
    public void Exit();
}

public interface IGameDataRepository
{
    public JsonGameData ReadDataFromJson(string fileName);
}

public class JsonGameData
{
    public string Title { get; }
    public int ReleaseYear { get; }
    public double Rating { get; }

    public JsonGameData(string title, int releaseYear, double rating)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Rating = rating;
    }
}