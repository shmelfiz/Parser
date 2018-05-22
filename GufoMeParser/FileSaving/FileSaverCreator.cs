namespace GufoMeParser.FileSaving
{
    public class FileSaverCreator : IFileSaverCreator
    {
        public IFileSaver GetFileSaver()
        {
            var fileSaver = new FileSaver();

            return fileSaver;
        }
    }
}
