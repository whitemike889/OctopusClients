using System;
using System.IO;
using Octopus.Client.Logging;

namespace Octopus.Client.Util
{
    internal class TemporaryFile : IDisposable
    {
        public TemporaryFile()
        {
            FileName = Path.GetTempFileName();
        }

        public string FileName { get; }

        public void Dispose()
        {
            try
            {
                File.Delete(FileName);
            }
            catch
            {
                LogProvider.For<TemporaryFile>().Debug("Failed to delete the temporary file");
            }
        }
    }
}