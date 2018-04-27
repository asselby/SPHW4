using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework4
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Thread thread;
        private Process[] processes;
        public Form()
        {
            InitializeComponent();
            thread = new Thread(ShowProcessInformation);
            thread.Start();
        }

        private void ShowProcessInformation()
        {
            while (true)
            {
                try
                {
                    processes = Process.GetProcesses();
                    foreach (Process process in processes)
                    {
                        listView.Items.Add(
                            new ListViewItem(
                                new string[] {
                            $"{process.ProcessName}",
                                $"{process.Id}",
                                $"{process.HandleCount}",
                                $"{process.StartTime}",
                                $"{process.StartInfo}"
                                }));
                    }
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
                Thread.Sleep(5000);
                listView.Refresh();
            }
        }
    }
}
