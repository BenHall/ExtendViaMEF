using System.ComponentModel.Composition;
using MefEnabled.Interfaces;

namespace MefEnabled.GeneratorsContrib
{
    [Export(typeof(ILogger))]
    public class MsgBoxLogger : ILogger
    {
        LoggerForm form;

        public MsgBoxLogger()
        {
            form = new LoggerForm();
            form.TopMost = true;
        }

        public void Write(string message)
        {
            if(!form.Visible)
                form.Show();
            form.Log(message);
        }
    }
}