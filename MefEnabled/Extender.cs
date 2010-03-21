using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.IO;
using MefEnabled.Interfaces;
using Microsoft.ComponentModel.Composition.Scripting;

namespace MefEnabled
{
    public class Extender
    {
        [Import]
        public ILogger Logger { get; set; }

        DirectoryCatalog generatorsCatalog;
        DirectoryCatalog UICatalog;

        public void Compose()
        {
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            
            string executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string generatorsPath = Path.Combine(executionPath, "Generators");
            CreatePathIfRequied(generatorsPath);
            generatorsCatalog = new DirectoryCatalog(generatorsPath);

            string uiPath = Path.Combine(executionPath, "UI");
            CreatePathIfRequied(uiPath);
            UICatalog = new DirectoryCatalog(uiPath);

            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(generatorsCatalog);
            catalog.Catalogs.Add(UICatalog);

            //RUBY RUBY RUBY!!!
            var source = new RubyDirectoryPartSource(generatorsPath);
            var rubyCatalog = new RubyCatalog(source);
            catalog.Catalogs.Add(rubyCatalog);

            //Set the defaults....
            CatalogExportProvider mainProvider = new CatalogExportProvider(assemblyCatalog);
            CompositionContainer container = new CompositionContainer(catalog, mainProvider);
            mainProvider.SourceProvider = container;

            
            var batch = new CompositionBatch();
            batch.AddPart(this);

            RefreshCatalog refreshCatalog = new RefreshCatalog(generatorsCatalog, UICatalog);
            container.ComposeParts(refreshCatalog);
            container.Compose(batch);

            Logger.Write("Compose complete");
        }

        private void CreatePathIfRequied(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
    }

    public class RefreshCatalog
    {
        DirectoryCatalog[] directoryCatalog;

        public RefreshCatalog(params DirectoryCatalog[] dc)
        {
            directoryCatalog = dc;
        }

        [Export("Refresh", typeof(Action))]
        public void RefreshExtensions()
        {
            foreach (DirectoryCatalog catalog in directoryCatalog)
            {
                catalog.Refresh();
            }
        }
    }
}