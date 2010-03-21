using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using MefEnabled.Interfaces;

namespace MefEnabled
{
    [Export(typeof(ISelector))]
    public partial class GeneratorSelector : UserControl, ISelector
    {
        public GeneratorManager Manager { get; set; }
        
        public event SelectedGeneratorEventHandler GeneratorChanged;

        [Import(AllowRecomposition = true)] //Overrides never work on this because it is set in the constructor... :(
        public ILogger Logger { get; set; }

        [Import("Internal", typeof(ILogger))]
        public ILogger FilteredLogger { get; set; }

        [ImportingConstructor]
        public GeneratorSelector(GeneratorManager manager, ILogger logger)
        {
            Manager = manager;
            Logger = logger;
            InitializeComponent();

            manager.GeneratorLoaded += manager_GeneratorLoaded;
            PopulateCombo();
        }

        delegate void SetTextCallback();
        void manager_GeneratorLoaded(object source, EventArgs args)
        {
            if (generators.InvokeRequired)
            {
                Logger.Write("Invoke required");
                SetTextCallback d = ClearCombo;
                this.Invoke(d, new object[] { });
            }
            else
            {
                ClearCombo();
            }
        }

        private void ClearCombo()
        {
            generators.Items.Clear();
            PopulateCombo();
        }

        private void PopulateCombo()
        {
            foreach (var type in Manager.Generators)
            {
                GeneratorItem item = new GeneratorItem() {Generator = type, Name = Manager.GetName(type.GetType())};
                generators.Items.Add(item);
            }

            Logger.Write(string.Format("combo populated with {0}", generators.Items.Count));

            
        }

        private void generators_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilteredLogger != null) FilteredLogger.Write("I don't want this message to appear in my override, just my internal");
            Logger.Write("Different generator selected. Plus super secret hidden message!!");

            GeneratorItem generatorItem = generators.SelectedItem as GeneratorItem;
            IGenerator instance = generatorItem.Generator;
            if (instance == null)
                return;

            if(GeneratorChanged != null)
                GeneratorChanged(this, new GeneratorSelectorEventArgs(instance));
        }

        class GeneratorItem
        {
            public string Name { get; set; }

            public IGenerator Generator { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }        
    }
}