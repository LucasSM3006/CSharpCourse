
public class GameDataParserApplication
{
    public void Run()
    {
        private readonly IGameDataAppUserInteraction _gameUserInteraction;
        private readonly IGameDataRepository _gameDataRepository;

        _gameUserInteraction.ShowMessage("Enter the name of the file you want to read:");
        JsonGameData gameData = _gameUserInteraction.PromptUserFileName();

        _gameDataRepository.ReadDataFromJson();

        _gameUserInteraction.Exit();
    }
}

