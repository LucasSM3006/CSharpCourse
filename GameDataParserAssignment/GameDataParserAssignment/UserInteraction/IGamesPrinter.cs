using GameDataParserAssignment.Model;

namespace GameDataParserAssignment.UserInteraction
{
    public interface IGamesPrinter
    {
        public void PrintGames(List<GameData> videoGames);
    }
}
