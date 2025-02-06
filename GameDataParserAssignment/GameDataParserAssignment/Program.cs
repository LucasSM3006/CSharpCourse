using GameDataParserAssignment.App;
using GameDataParserAssignment.DataAccess;
using GameDataParserAssignment.Logging;
using GameDataParserAssignment.UserInteraction;
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
