using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlHelper sqlConnect;
        public Form1()
        {
            

            InitializeComponent();
            hidSqlButtons();
            textBoxPassword.UseSystemPasswordChar = true;

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

        public void hidSqlButtons()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            checkBoxAdvancedOptions.Visible = false;

        }

        public void hideSqlAdvancedButtons()
        {

        }

        public void showSqlButtons()
        {
            button1.Visible = true;
            button2.Visible = true;
            button5.Visible = true;
            checkBoxAdvancedOptions.Visible = true;

            if (checkBoxAdvancedOptions.Checked == true)
            {

            }
            else
            {
                button3.Visible = false;
                button4.Visible = false;
            }

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
            //STRING CHANGED TO FIXED DATA
            //string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", //ConnectionTimeout=2, CommandTimeout = 2, add 2-5 sectimoeut to quic reaction
            //comboBoxSqlInstance.Text, textBoxDbName.Text, textBoxUsername.Text, textBoxPassword.Text);

            string connectionString = @"Data Source=SQLLOCALDB;Initial Catalog=AdventureWorks;User ID=sa;Password='!Fddd89829'";



            try
            {
                sqlConnect = new SqlHelper(connectionString);
                if (sqlConnect.IsConnected)
                {
                    MessageBox.Show("Test connection Succeded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    statusPanel.Text = "SUCCED !";
                    showSqlButtons();

                    /* change statusPanel.Text color to GREEN, but won't happen..... :( */
                    //String suc = "SUCCEED !";
                    //suc = System.Drawing.Color.Green.ToString();
                    //statusPanel.Text = suc;

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
            comboBoxSqlInstance.Items.Add(string.Format(@"{0}\FCEMS", Environment.MachineName));
            comboBoxSqlInstance.SelectedIndex = 3;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", //ConnectionTimeout=2, CommandTimeout = 2, add 2-5 sectimoeut to quic reaction
comboBoxSqlInstance.Text, textBoxDbName.Text, textBoxUsername.Text, textBoxPassword.Text);

            String SqlOutput="";

            SqlConnection connSQL = new SqlConnection(connectionString);
            connSQL.Open();
            SqlCommand command = new SqlCommand("UPDATE Person.Person SET PersonType = 'DUPA' where BusinessEntityId = 1",connSQL);
            SqlCommand commandSelect = new SqlCommand("SELECT Person.Type FROM Person.Person where BusinessEntityId = 1");


            SqlDataReader dataReader = command.ExecuteReader(); //System.Data.SqlClient.SqlException: 'String or binary data would be truncated.
            //The statement has been terminated.' !!!!


            while (dataReader.Read())
            {
                SqlOutput = SqlOutput + dataReader.GetValue(0) + dataReader.GetValue(1) + "\n";
            }
            MessageBox.Show(SqlOutput);
            
            
            

            
            


        }
    }
}
