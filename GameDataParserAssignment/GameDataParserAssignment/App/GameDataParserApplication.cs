using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameDataParserAssignment.DataAccess;
using GameDataParserAssignment.Model;
using GameDataParserAssignment.UserInteraction;

namespace GameDataParserAssignment.App
{
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
}
