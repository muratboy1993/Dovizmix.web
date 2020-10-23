using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Infrastructure.Utility
{
    public class FileWriter
    {
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

        private readonly string _content;

        public FileWriter(string content)
        {
            _content = content;
        }

        public void Write()
        {

            //todo: lock eklenmeli

            _readWriteLock.EnterWriteLock();
            StreamWriter streamWriter;
            string logFolder = "C:\\" + @"logs";

            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }
            
            string pathSource = logFolder + $"\\exception-log-{DateTime.Now.ToString("yyyyMMdd")}.txt";

            if (!File.Exists(pathSource))
            {
                streamWriter = File.CreateText(pathSource);
                streamWriter.Close();
                streamWriter.Dispose();
            }
            streamWriter = new StreamWriter(pathSource, true, Encoding.UTF8);

            streamWriter.WriteLineAsync(_content);
            streamWriter.Close();
            streamWriter.Dispose();
            _readWriteLock.ExitWriteLock();
        }
    }
}
