using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CmsMaster.Helpers
{
    public static class DirectoryHelper
    {
        public static void CreateDirectoryNested(string directory)
        {
            if (!Directory.Exists(directory))
            {
                string parent = Path.GetDirectoryName(directory);
                if (!Directory.Exists(parent))
                {
                    CreateDirectoryNested(parent);
                }
                Directory.CreateDirectory(directory);
            }
        }
    }
}