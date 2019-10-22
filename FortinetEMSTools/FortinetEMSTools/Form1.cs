using System;
using System.Data.SqlClient;
using System.Windows.Forms;


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
                button3.Visible = true;
                button4.Visible = true;
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


            //HRADCODED data
            string connectionString = @"Data Source=.\SQLLOCALDB;Initial Catalog=FCM_root;User ID=sa;Password='!Fddd89829'";



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
            //to enable afterwards
            //string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", //ConnectionTimeout=2, CommandTimeout = 2, add 2-5 sectimoeut to quic reaction
            //comboBoxSqlInstance.Text, textBoxDbName.Text, textBoxUsername.Text, textBoxPassword.Text);

            //HRADCODED data
            //string connectionString = @"Data Source=.\SQLLOCALDB;Initial Catalog=AdventureWorks;User ID=sa;Password='!Fddd89829'";

            //String SqlOutput = "";

            //SqlConnection connSQL = new SqlConnection(connectionString);
            //connSQL.Open();


            //SqlCommand command = new SqlCommand("UPDATE Person.Person SET PersonType = 'GC' where BusinessEntityId = 1", connSQL);
            //SqlCommand commandSelect = new SqlCommand("SELECT PersonType FROM Person.Person where BusinessEntityId = 1", connSQL);

            //SqlDataReader dataReader = commandSelect.ExecuteReader(); //System.Data.SqlClient.SqlException: 'String or binary data would be truncated.
            ////The statement has been terminated.' !!!!


            //while (dataReader.Read())
            //{
            //    SqlOutput = SqlOutput + dataReader.GetValue(0) + "\n";
            //}
            //MessageBox.Show(SqlOutput);



            //!!!!!!!!!!!
            //// https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqldatareader?view=netframework-4.8 !!!!!!!!!!!!!
            try
            {
                string connectionString = @"Data Source=.\SQLLOCALDB;Initial Catalog=FCM;User ID=sa;Password='!Fddd89829'";
                string sqlOutput = "";

                //SqlConnection connectSql = new SqlConnection(connectionString);
                //SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [FCM].[dbo].[admin_user]", connectSql);

                //SqlDataReader data = sqlCommand.ExecuteReader();

                //using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                //{
                //    if (sqlDataReader.HasRows)
                //    {

                //    }
                //}

                using (SqlConnection sqlConnect = new SqlConnection(connectionString)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [FCM].[dbo].[admin_user]",sqlConnect);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("There was some error");
            }
            finally
            {
                MessageBox.Show("It has been updated");
            }







        }

        private void checkBoxAdvancedOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAdvancedOptions.Checked)
            {
                button3.Visible = true;
                button4.Visible = true;
            }
            else
            {
                button3.Visible = false;
                button4.Visible = false;
            }
            
        }
    }
}
