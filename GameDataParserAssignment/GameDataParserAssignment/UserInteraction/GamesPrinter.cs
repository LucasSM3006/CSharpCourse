using GameDataParserAssignment.Model;

namespace GameDataParserAssignment.UserInteraction
{
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
}
