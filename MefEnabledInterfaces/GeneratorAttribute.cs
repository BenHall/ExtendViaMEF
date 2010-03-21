using System;

namespace MefEnabled.Interfaces
{
    public class GeneratorAttribute : Attribute
    {
        private readonly string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
        }

        public GeneratorAttribute(string name)
        {
            _displayName = name;
        }
    }
}