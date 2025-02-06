namespace GameDataParserAssignment.UserInteraction
{
    public interface IGameDataAppUserInteraction
    {
        public string ReadValidFilePath();
        public void PrintMessage(string message);
        public void PrintError(string message);
        public void Exit();
    }
}
