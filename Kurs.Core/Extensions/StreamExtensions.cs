using System.IO;
using System.Threading.Tasks;

namespace Kurs.Core.Extensions
{
    public static class StreamExtensions
    {
        public static async Task<byte[]> ReadAllBytesAsync(this Stream stream)
        {
            stream.CheckArgumentNull(nameof(stream));

            byte[] result = new byte[stream.Length];
            await stream.ReadAsync(result, 0, result.Length);

            return result;
        }
    }
}