using System;
using System.IO;
using Microsoft.ComponentModel.Composition.Scripting;
using Microsoft.Scripting.Hosting;

namespace MefEnabled
{
    class RubyDirectoryPartSource : RubyPartSource
    {
        private readonly string path;

        public RubyDirectoryPartSource(string path)
        {
            this.path = path;
        }

        public override void Execute(ScriptEngine scriptEngine)
        {          
            var directoryInfo = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path));
            var rubyFiles = directoryInfo.GetFiles("*.rb");

            foreach (FileInfo file in rubyFiles)
            {
                new RubyPartFile(file.FullName).Execute(scriptEngine);
            }
        }
    }
}