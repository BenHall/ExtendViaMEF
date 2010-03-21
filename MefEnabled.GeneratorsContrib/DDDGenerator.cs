using System.Collections;
using System.ComponentModel.Composition;
using MefEnabled.Interfaces;

namespace MefEnabled.GeneratorsContrib
{
    [Export(typeof(IGenerator))]
    [Generator("Generator from the community")]
    public class DDDGenerator : IGenerator
    {
        public IEnumerable Get()
        {
            return new[] {"DDD Belfast", "DDD Scotland", "Classic DDD", "DDD South West"};
        }
    }
}
