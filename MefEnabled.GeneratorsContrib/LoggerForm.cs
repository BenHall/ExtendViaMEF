using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MefEnabled.GeneratorsContrib
{
    public partial class LoggerForm : Form
    {
        public LoggerForm()
        {
            InitializeComponent();
        }

        public void Log(string message)
        {
            if (textBox1.InvokeRequired)
                textBox1.Text = "";
            else
                textBox1.Text = textBox1.Text + message + Environment.NewLine;
        }
    }
}
