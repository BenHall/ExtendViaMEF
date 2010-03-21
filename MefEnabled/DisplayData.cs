using System;
using System.Windows.Forms;
using MefEnabled.Interfaces;
using System.ComponentModel.Composition;

namespace MefEnabled
{
    [Export(typeof(IDisplayData))]
    public partial class DisplayData : UserControl, IDisplayData
    {
        public GeneratorManager Manager { get; set; }

        [Import]
        public ILogger Logger { get; set; }

        [ImportingConstructor]
        public DisplayData(GeneratorManager manager)
        {
            InitializeComponent();
            Manager = manager;
        }

        public void Display(IGenerator generator)
        {
            data.Text = "";

            generatorName.Text = string.Format("Data produced from {0}", Manager.GetName(generator.GetType()));

            foreach (var o in generator.Get())
            {
                data.Text += o + Environment.NewLine;
            }

            Logger.Write("Generator selected: " + generator);
        }
    }
}