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
            if (scriptEngine == null)
            {
                throw new ArgumentNullException("scriptEngine");
            }

            var info = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path));
            if (info.Exists == false)
            {
                throw new Exception(string.Format("Can't find path: {0}", path));
            }

            var rubyFiles = info.GetFiles("*.rb");

            foreach (FileInfo file in rubyFiles)
            {
                new RubyPartFile(file.FullName).Execute(scriptEngine);
            }
        }
    }
}