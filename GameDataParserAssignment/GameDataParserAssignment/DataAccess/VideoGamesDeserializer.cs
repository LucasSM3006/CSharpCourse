using GameDataParserAssignment.Model;
using GameDataParserAssignment.UserInteraction;
using System.Text.Json;

namespace GameDataParserAssignment.DataAccess
{
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
}
