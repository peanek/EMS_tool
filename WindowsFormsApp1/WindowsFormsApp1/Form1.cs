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

        StatusBar mainStatusBar = new StatusBar();
        StatusBarPanel statusPanel = new StatusBarPanel();
        StatusBarPanel dateTimePanel = new StatusBarPanel();

       


        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            about.Show();
        }

        public void buttonConnectSql_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
                comboBoxSqlInstance.Text, textBoxDbName.Text, textBoxUsername.Text, textBoxPassword.Text);
            try
            {
                SqlHelper sqlConnect = new SqlHelper(connectionString);
                if (sqlConnect.IsConnected)
                {
                    MessageBox.Show("Test connection Succeded","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    String suc = "SUCCEED !";
                    suc = System.Drawing.Color.Green.ToString();
                    statusPanel.Text = suc;
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxSqlInstance.Items.Add(".");
            comboBoxSqlInstance.Items.Add("(local)");
            comboBoxSqlInstance.Items.Add(@".\FCEMS");
            comboBoxSqlInstance.Items.Add(string.Format(@"{0}\FCEMS",Environment.MachineName));
            comboBoxSqlInstance.SelectedIndex = 3;


        }
    }
}
