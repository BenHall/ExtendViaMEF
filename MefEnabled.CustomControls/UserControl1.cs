using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using MefEnabled.Interfaces;

namespace MefEnabled.CustomControls
{
    [Export(typeof(IDisplayData))]
    public partial class UserControl1 : UserControl, IDisplayData
    {
        public UserControl1()
        {
            InitializeComponent();
        }

            public void Display(IGenerator generator)
            {
                textBox1.Text = string.Empty;
                foreach (object o in generator.Get())
                {
                    textBox1.Text += o + Environment.NewLine;
                }
            }
    }
}
