namespace Infrastructure.Services.Impl
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ReadFileAppService: IReadFileAppService
    {
        private readonly ILogger _logger;

        public ReadFileAppService(ILogger<ReadFileAppService> logger)
        {
            _logger = logger;
        }

        public List<string> GetFileContent(string fileName)
        {
            var baseDirectory = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));
            try
            {
                var lines = File.ReadAllText($"{baseDirectory}\\files\\{fileName}");
                var splitLines = lines.Split("\r\n\r\n");
                return splitLines.ToList();
            }
            catch (Exception e)
            {
                var message = $"An error has occurred: {e.Message}";
                _logger.LogError(message);
                throw;
            }
        }
    }
}
