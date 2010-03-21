using System;

namespace MefEnabled.Interfaces
{
    public class GeneratorSelectorEventArgs : EventArgs
    {
        public GeneratorSelectorEventArgs(IGenerator generator)
        {
            Generator = generator;
        }

        public IGenerator Generator { get; set; }
    }
}