using GameDataParserAssignment.Model;

namespace GameDataParserAssignment.DataAccess
{
    public interface IVideoGameDeserializer
    {
        public List<GameData> DeserializeFrom(string filename, string fileContents);
    }
}
