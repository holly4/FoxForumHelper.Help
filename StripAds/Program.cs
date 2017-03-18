using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripAds
{
    class Program
    {
        static void CleanFolder(string folder)
        {
            var folderInfo = new DirectoryInfo(folder);
            if (!folderInfo.Exists)
            {
                Console.WriteLine("Error: folder does not exist: {0}", folder);
            }
            else
            {
                var target = "class=\"rvps4\">";
                foreach (var fileInfo in folderInfo.EnumerateFiles("*.html"))
                {
                    if (fileInfo.Name == "Introduction.html")
                    {
                        Console.WriteLine("EXCLUDING  {0}", fileInfo.FullName);
                    }
                    else
                    {
                        Console.WriteLine("PROCESSING {0}", fileInfo.FullName);
                        List<string> output = new List<string>();
                        var lines = File.ReadAllLines(fileInfo.FullName)
                            .Where(i => !i.Contains(target));
                        File.WriteAllLines(fileInfo.FullName, lines);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                CleanFolder(args[0]);
            }
            else
            {
                CleanFolder(".\\help");
            }
        }
    }
}
