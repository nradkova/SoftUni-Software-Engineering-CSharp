using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream("../../../copyMe.png", FileMode.Open);
            byte[] buffer = new byte[1024];
            while (true)
            {
                var readBytes = reader.Read(buffer, 0, buffer.Length);
                if (readBytes == 0)
                {
                    break;
                }
                using FileStream writer = new FileStream("../../../output.png", FileMode.Append);
                writer.Write(buffer, 0, readBytes);
            }
        }
    }
}
