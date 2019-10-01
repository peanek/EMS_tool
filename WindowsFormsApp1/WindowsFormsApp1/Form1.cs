using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StatusBar mainStatusBar = new StatusBar();
            StatusBarPanel statusPanel = new StatusBarPanel();
            StatusBarPanel dateTimePanel = new StatusBarPanel();

            mainStatusBar.ShowPanels = true;
            Controls.Add(mainStatusBar);

            statusPanel.BorderStyle = StatusBarPanelBorderStyle.Raised;
            statusPanel.Text = "App started. No action yet.";
            statusPanel.ToolTipText = "Status of app.";
            statusPanel.AutoSize = StatusBarPanelAutoSize.Spring;
            mainStatusBar.Panels.Add(statusPanel);

            dateTimePanel.BorderStyle = StatusBarPanelBorderStyle.Raised;
            dateTimePanel.ToolTipText = "Date Time: " + System.DateTime.Today.ToString();
            dateTimePanel.Text = System.DateTime.Today.ToLongDateString();
            dateTimePanel.AutoSize = StatusBarPanelAutoSize.Contents;
            
            mainStatusBar.Panels.Add(dateTimePanel);
            

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        Form about = new Form();

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            about.Show();
        }

        
        

    }
}
