using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MefEnabled
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //HACK: Just for demo ;)
            string executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            File.Delete(Path.Combine(executionPath, "UI\\MefEnabled.CustomControls.dll"));
            File.Delete(Path.Combine(executionPath, "UI\\MefEnabled.CustomControls.pdb"));
            File.Delete(Path.Combine(executionPath, "Generators\\MefEnabled.GeneratorsContrib.dll"));
            File.Delete(Path.Combine(executionPath, "Generators\\MefEnabled.GeneratorsContrib.pdb"));


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyProgram program = new MyProgram();
            program.Run();
        }
    }

    class MyProgram : Extender
    {
        [Import("MainWindow", typeof(IMainWindow))]
        public IMainWindow MainForm { get; set; }

        public void Run()
        {
            Compose();
            MainForm.Launch();        
        }
    }
}
