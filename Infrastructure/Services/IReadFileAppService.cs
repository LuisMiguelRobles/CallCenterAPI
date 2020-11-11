namespace Infrastructure.Services
{
    using System.Collections.Generic;

    public interface IReadFileAppService
    {
        List<string> GetFileContent(string fileName);
    }
}
