using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using MefEnabled.Interfaces;

namespace MefEnabled
{
    [Export]
    public class GeneratorManager : IPartImportsSatisfiedNotification
    {
        public string GetName(Type instance)
        {
            object[] generatorAttributes = instance.GetCustomAttributes(typeof(GeneratorAttribute), false);

            if (generatorAttributes.Length > 0)
                return ((GeneratorAttribute)generatorAttributes[0]).DisplayName;
            
            return instance.Name;
        }

        [Import(AllowRecomposition = true)]
        private Export<IGenerator>[] _generators;

        private Recomposable<ILogger> _recompLogger;

        public ILogger Logger { get { return _recompLogger.Value; } }

        private readonly ValidatorDelegate<IGenerator> _generatorValidator;

        [ImportingConstructor]
        public GeneratorManager(Recomposable<ILogger> logger, ValidatorDelegate<IGenerator> generatorValidator)
        {

            _recompLogger = logger;
            _generatorValidator = generatorValidator;
        }

        public List<IGenerator> Generators
        {
            get
            {
                List<IGenerator> generators = new List<IGenerator>();
                foreach (Export<IGenerator> value in _generators)
                {
                    if (_generatorValidator(value.GetExportedObject()))
                    {
                        if(value.Metadata.ContainsKey("Name"))
                            Logger.Write("Found >> " + value.Metadata["Name"]);
                        generators.Add(value.GetExportedObject());
                    }
                }

                return generators;
            }
        }

        public delegate void GeneratorLoadedEventHandler(object source, EventArgs args);
        public event GeneratorLoadedEventHandler GeneratorLoaded;

        public void OnImportsSatisfied()
        {
            Logger.Write("Import has completed");
            if (GeneratorLoaded != null)
                GeneratorLoaded(this, EventArgs.Empty);
        }
    }
}