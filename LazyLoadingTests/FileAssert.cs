using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;

namespace LazyLoadingTests
{
    public static class FileAssert
    {
        static byte[] GetFileHash(string filename)
        {
            Assert.IsTrue(File.Exists(filename));
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }

        public static void AreEqual(string filename1, string filename2)
        {
            byte[] hash1 = GetFileHash(filename1);
            byte[] hash2 = GetFileHash(filename2);

            using (StreamReader reader1 = File.OpenText(filename1))
            {
                using (StreamReader reader2 = File.OpenText(filename2))
                {
                    string contentFile1 = reader1.ReadToEnd();
                    string contentFile2 = reader2.ReadToEnd();

                    Assert.AreEqual(contentFile1, contentFile2);

                }
            }

        }


    }
}
