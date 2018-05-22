namespace GufoMeParser.FileSaving
{
    public interface IFileSaverCreator
    {
        IFileSaver GetFileSaver();
    }
}
