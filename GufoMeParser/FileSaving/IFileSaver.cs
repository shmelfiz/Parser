using System.Threading.Tasks;

namespace GufoMeParser.FileSaving
{
    public interface IFileSaver
    {
        Task Save(string text, string name, int fileType);
    }
}
