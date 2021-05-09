using System;
using System.IO;

namespace Stocky
{
    public static class BinaryExtensions
    {
        public static void SaveOnDisk(this byte[] data, string location = "/")
        {
            File.WriteAllBytes(location, data);
        }
    }
}
