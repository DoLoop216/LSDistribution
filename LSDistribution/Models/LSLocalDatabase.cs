using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LSDistribution.Models
{
    public class LSLocalDatabase
    {
        private static bool _Initialized = false;
        private static string _RootFolder;
        public static string RootFolder { get => _RootFolder; }

        public static void Initialize()
        {
            if (_Initialized)
                return;

            _Initialized = true;

            Directory.CreateDirectory("LSLocalDatabase");
            _RootFolder = "LSLocalDatabase";
        }
        public static void InitializeFolder(string folderName)
        {
            Directory.CreateDirectory(folderName);
        }
    }
}
