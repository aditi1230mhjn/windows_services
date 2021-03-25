using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCaseConverter
{
    //Main running logic in this class
    class CaseConvertor
    {
        private FileSystemWatcher watcher;

        public bool Start()
        {
            watcher = new FileSystemWatcher(@"C:\Demo\temp", "*_in.txt");

            watcher.Created += ProcessFileCreated;
            //Created Event called

            watcher.IncludeSubdirectories = false;
            //subdirectories aren't included

            watcher.EnableRaisingEvents = true;
            //to notify for newly created files and start automatically(when auto-start)

            return true;
            //bool to indicate successful starting of the method
        }

        private void ProcessFileCreated(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
            //Event Handling method

            string content = File.ReadAllText(e.FullPath); //fullpath property to get the entire path including the filename of the newly created file

            string upperCaseContent = content.ToUpperInvariant(); //grabs the content and convert it to uppercase

            //All are static methods of Path class
            var dir = Path.GetDirectoryName(e.FullPath);
            var caseConvertedFileName = (Path.GetFileName(e.FullPath) + ".converted");
            var convertedPath = Path.Combine(dir, caseConvertedFileName);

            //To write the Uppercase text in a new "filename.converted"
            File.WriteAllText(convertedPath, upperCaseContent);

        }

        public bool Stop()
        {
            watcher.Dispose();
            return true;
        }
    }
}
