using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using MefEnabled.Interfaces;

namespace MefEnabled
{
    [Export("MainWindow", typeof(IMainWindow))]
    public partial class Form1 : Form, IMainWindow, IPartImportsSatisfiedNotification
    {
        public Form1()
        {
            InitializeComponent();
        }

        [Import(typeof(ISelector), AllowRecomposition = true)]
        private ISelector Selector;

        [Import(typeof(IDisplayData), AllowRecomposition = true)]
        private IDisplayData Data;
        
        [Import("Refresh", typeof(Action))]
        private Action RefreshCatalog = null;

        [Import(AllowRecomposition = true)]
        public ILogger Logger { get; set; }

        void SelectorGeneratorChanged(object source, GeneratorSelectorEventArgs generatorSelectorEventArgs)
        {
            Data.Display(generatorSelectorEventArgs.Generator);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RefreshCatalog != null) RefreshCatalog();
        }

        private void forceLoggedMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Write("Log message forced...");
        }

        public void Launch()
        {
            Application.Run(this);
        }

        public void OnImportsSatisfied()
        {
            Selector.GeneratorChanged -= SelectorGeneratorChanged;
            topPanel.Controls.Clear();
            dataPanel.Controls.Clear();

            SetupForm();
        }

        private void SetupForm()
        {
            Selector.GeneratorChanged += SelectorGeneratorChanged;
            topPanel.Controls.Add(Selector as Control);

            dataPanel.Controls.Add(Data as Control);
        }
    }
}