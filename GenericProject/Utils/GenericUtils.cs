using GenericProject.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericProject.Utils
{
    public static class GenericUtils
    {
        public static string GetProjectDirectory()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }

        public static string GetReportsDirectory()
        {
            string reportDirectory = $"{GetProjectDirectory()}//Reports";
            CreateDirectory(reportDirectory);
            return reportDirectory;
        }
        public static string GetScreenShotsDirectory()
        {
            string directory = $"{GetProjectDirectory()}//Reports//SS";
            CreateDirectory(directory);
            return directory;
        }

        public static bool CreateDirectory(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                ReportProvider.LogInfo($"Directory created: {dir}");
                return true;
            }
            return false;
        }


    }
}
