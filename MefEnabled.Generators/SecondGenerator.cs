using System.Collections;
using System.ComponentModel.Composition;
using MefEnabled.Interfaces;

namespace MefEnabled.Generators
{
    [Export(typeof(IGenerator))]
    [Generator("This is my second method")]
    public class SecondGenerator : IGenerator
    {
        public IEnumerable Get()
        {
            return new[] { 1, 2, 3, 4, 5, 7, 8, 9, 10 };
        }
    }
}
