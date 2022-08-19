using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerShell_Project
{
    public partial class Form1 : Form
    {

        FileStreamClass fsc = new FileStreamClass();

        public Form1()
        {
            InitializeComponent();

            fsc.CreatePowerShellFiles(); // Method to create embedded files (Default Save Path : your temp folder)

            foreach (string FoundFile in fsc.Files)
                MessageBox.Show($"Found File : {FoundFile}");
        }

        private void Execute_Button_Click(object sender, EventArgs e)
        {
            List<string> PSFiles = fsc.Files;
            if (PSFiles.Count < 1) { return; }
            Thread Thr = new Thread(new ThreadStart(() =>
            {
                foreach (string PowerShellFile in PSFiles)
                {
                    using (Process Proc = new Process())
                    {
                        Proc.StartInfo.FileName = "PowerShell";
                        Proc.StartInfo.Arguments = "-nop -exec bypass -file \"" + PowerShellFile + "\"";
                        Proc.Start();
                    }
                }
            }));
            if (!Thr.IsAlive)
                Thr.Start();
        }
    }
}
