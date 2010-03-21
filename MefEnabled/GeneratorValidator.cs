using System;
using System.ComponentModel.Composition;
using MefEnabled.Interfaces;

namespace MefEnabled
{
    public delegate bool ValidatorDelegate<T>(T value);

    public class GeneratorValidator //This is imported because on the ValidatorDeletgate export type... 
    {
        public string GetName(Type instance)
        {
            object[] generatorAttributes = instance.GetCustomAttributes(typeof(GeneratorAttribute), false);

            if (generatorAttributes.Length > 0)
                return ((GeneratorAttribute)generatorAttributes[0]).DisplayName;
            else
                return string.Empty;
        }


        [Export(typeof(ValidatorDelegate<IGenerator>))]
        public bool Validate(IGenerator generator)
        {
            string name = GetName(generator.GetType());
            return !string.IsNullOrEmpty(name);
        }
    }
}