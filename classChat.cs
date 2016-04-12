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

namespace winFormsClassChat
{
    public partial class classChat : Form
    {
        private SqlConnection conn = new SqlConnection();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private SqlCommand cmd = new SqlCommand();
        private DataSet dSet = new DataSet();

        public classChat()
        {
            InitializeComponent();
        }

        private void classChat_Load(object sender, EventArgs e)
        {
            //create connection string
            // conn.ConnectionString = "Data Source= (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\lyonss2\\Documents\\ClassChat.mdf; Integrated Security = True; Connect Timeout = 30";
            conn.ConnectionString = "Removed for security reasons";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPW.Text == "")
            {
                MessageBox.Show("Please enter a username and password", "Data error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
            }
            else
            {
                //create sql command object as parameter query
                cmd.Parameters.Add(new SqlParameter("pUN", txtUserName.Text));
                cmd.Parameters.Add(new SqlParameter("pPW", txtPW.Text));

                //create your sql command
                cmd.CommandText = "SELECT * FROM Accounts WHERE UserName = @pUN AND Password = @pPW";
                //create and configure the data adapter
                dataAdapter.SelectCommand = cmd;
                dataAdapter.SelectCommand.Connection = conn;

                try
                {
                    //fill the dataset
                    dataAdapter.Fill(dSet, "Accounts");
                    //plae the dataset contents in the labels and picture box
                    if (dSet.Tables["Accounts"].Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow item in dSet.Tables["Accounts"].Rows)
                        {
                            string firstName = item["UserName"].ToString();
                            //string lastName = item["Email"].ToString();
                            lblMsg.Text = firstName;

                            //open 'home' form, sending lblMsg.Text in order to use it to query database
                            Home f2 = new Home(lblMsg.Text);
                            f2.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Record not found", "Address Book");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cmd.Parameters.Clear();
                    dSet.Clear();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //set controls to visible
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            txtRePass.Visible = true;
            txtCollegeName.Visible = true;
            txtEmail.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean ErrorCode = DataValidation();
            if (ErrorCode == false)
            {
                return;
            }
            //create insert command object
            SqlCommand insertCmd = new SqlCommand();
            //set connection string of insertCmd
            insertCmd.Connection = conn;
            //set insert command to stored procedure and set stored procedure as cmdText
            insertCmd.CommandType = CommandType.StoredProcedure;
            insertCmd.CommandText = "spInsertUser";
            //set input param values
            insertCmd.Parameters.AddWithValue("UserName", txtUserName.Text);
            insertCmd.Parameters.AddWithValue("Password", txtPW.Text);
            insertCmd.Parameters.AddWithValue("CollegeName", txtCollegeName.Text);
            insertCmd.Parameters.AddWithValue("Email", txtEmail.Text);
            insertCmd.Parameters.Add("@Error", SqlDbType.Int);
            insertCmd.Parameters["@Error"].Direction = ParameterDirection.ReturnValue;

            try
            {
                conn.Open();
                insertCmd.ExecuteNonQuery();
                if((int) insertCmd.Parameters["@Error"].Value == 0)
                {
                    MessageBox.Show("Welcome to our Application " + Environment.NewLine + txtUserName.Text, "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //redirect to home.cs
                    Home f2 = new Home(txtUserName.Text);
                    f2.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Add Failure", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                insertCmd.Parameters.Clear();
            }

        }

        private Boolean DataValidation()
        {
            //check data in the textboxes and return a value of true if all the data is valid or false if the data is invalid
            Boolean ErrorCode;
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter your username", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorCode = false;
                txtUserName.Focus();
                return ErrorCode;
            }
            else if (txtPW.Text == "")
            {
                MessageBox.Show("Please insert your password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorCode = false;
                txtPW.Focus();
                return ErrorCode;

            }
            else if (txtRePass.Text != txtPW.Text)
            {
                MessageBox.Show("Passwords to not match", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorCode = false;
                txtRePass.Focus();
                return ErrorCode;

            }
            else if (txtCollegeName.Text == "")
            {
                MessageBox.Show("Please enter your first name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorCode = false;
                txtCollegeName.Focus();
                return ErrorCode;

            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter your last name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorCode = false;
                txtEmail.Focus();
                return ErrorCode;

            }
            else
            {
                //all data validation is dank
                ErrorCode = true;
            }
            return ErrorCode;
        }
    }
}
