using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrLfChecker
{
    public class Detector
    {
        readonly DetectionLogic _detectionLogic = new DetectionLogic();

        public IEnumerable<Result> AnalyzeDirectory(string rootDir)
        {
            var results = new List<Result>();

            var dir = new DirectoryInfo(rootDir);
            AnalyzeDirectoryRecursive(dir, results);

            return results;
        }

        private void AnalyzeDirectoryRecursive(DirectoryInfo dir, List<Result> results)
        {
            foreach (var file in dir.EnumerateFiles())
            {
                var result = new Result()
                {
                    FilePath = file.FullName,
                    FileName = file.Name
                };

                var text = File.ReadAllText(file.FullName);
                result.LfCount = _detectionLogic.CountLf(text);
                result.CrLfCount = _detectionLogic.CountCrLf(text);

                results.Add(result);
            }

            foreach (var subdir in dir.EnumerateDirectories())
            {
                AnalyzeDirectoryRecursive(subdir, results);
            }
        }
    }

    public class DetectionLogic
    {
        public int CountCrLf(string text)
        {
            var replacedText = text.Replace("\r\n", "");
            return (text.Length - replacedText.Length) / 2;
        }

        public int CountLf(string text)
        {
            var replacedText = text.Replace("\r\n", "00").Replace("\n", "");
            return (text.Length - replacedText.Length);
        }
    }

    public class Result
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public int LfCount { get; set; }
        public int CrLfCount { get; set; }
    }
}
