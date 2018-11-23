using System.IO;
using Octodiff.Core;
using Octodiff.Diagnostics;
using Octopus.Client.Logging;
using Octopus.Client.Model;
using Octopus.Client.Util;

namespace Octopus.Client.Features
{
    internal class DeltaCompression
    {
        public static bool CreateDelta(Stream contents, PackageSignatureResource signatureResult, string deltaTempFile)
        {
            var logger = LogProvider.For<DeltaCompression>();
            logger.Info($"Calculating delta");
            var deltaBuilder = new DeltaBuilder();

            using (var signature = new MemoryStream(signatureResult.Signature))
            using (var deltaStream = File.Open(deltaTempFile, FileMode.Create, FileAccess.ReadWrite))
            {
                deltaBuilder.BuildDelta(
                    contents,
                    new SignatureReader(signature, new NullProgressReporter()),
                    new AggregateCopyOperationsDecorator(new BinaryDeltaWriter(deltaStream))
                );
            }
                
            var originalFileSize = contents.Length;
            var deltaFileSize = new FileInfo(deltaTempFile).Length;
            var ratio = deltaFileSize / (double) originalFileSize;

            if (ratio > 0.95)
            {
                logger.Info($"The delta file ({deltaFileSize:n0} bytes) is more than 95% the size of the orginal file ({originalFileSize:n0} bytes)");
                return false;
            }

            logger.Info($"The delta file ({deltaFileSize:n0} bytes) is {ratio:p2} the size of the orginal file ({originalFileSize:n0} bytes), uploading...");
            return true;
        }
    }
}
