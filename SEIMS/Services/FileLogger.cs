using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SEIMS.Events;

namespace SEIMS.Services
{
    /// <summary>
    /// System utility class (Question 6): FileStream + StreamWriter + StreamReader.
    /// Written in plain C# 5 with no other dependencies except LogHandler.cs, so it can be
    /// compiled by hand with csc.exe (see Notepad_Proof_csc_commands.txt).
    /// </summary>
    public class FileLogger
    {
        private readonly string _path;
        private readonly object _sync = new object();

        public FileLogger(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("A log file path is required.");

            _path = path;
            string dir = Path.GetDirectoryName(Path.GetFullPath(path));
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        public string FilePath { get { return _path; } }

        /// <summary>Appends one time-stamped line to the plain text log file.</summary>
        public void Write(string message)
        {
            string clean = (message ?? "").Replace("\r", " ").Replace("\n", " ");
            string line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " | " + clean;

            lock (_sync)
            {
                FileStream stream = null;
                StreamWriter writer = null;
                try
                {
                    stream = new FileStream(_path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    writer = new StreamWriter(stream, Encoding.UTF8);
                    writer.WriteLine(line);
                }
                catch (IOException)
                {
                    // logging must never crash the application
                }
                catch (UnauthorizedAccessException)
                {
                }
                finally
                {
                    if (writer != null) writer.Dispose();
                    else if (stream != null) stream.Dispose();
                }
            }
        }

        /// <summary>Returns a LogHandler delegate that points at Write().</summary>
        public LogHandler AsHandler()
        {
            return new LogHandler(Write);
        }

        /// <summary>Reads the last N lines using StreamReader.</summary>
        public List<string> ReadLast(int count)
        {
            List<string> lines = new List<string>();
            if (!File.Exists(_path)) return lines;

            using (FileStream stream = new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                    if (lines.Count > count) lines.RemoveAt(0);
                }
            }
            return lines;
        }
    }
}
