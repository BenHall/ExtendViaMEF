using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using MefEnabled.Interfaces;

namespace MefEnabled.Generators
{
    [Export(typeof(IGenerator))]
    [ExportMetadata("Name", "MyGenerator - abc")]
    [Generator("This is a test generator - abc")]
    public class MyGenerator : IGenerator
    {
        public IEnumerable Get()
        {
            List<string> list = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "I got bored...", "x", "y", "z" };

            return list;
        }
    }
}