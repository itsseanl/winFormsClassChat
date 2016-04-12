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
    public partial class Home : Form
    {
        //sql server connection variables
        private SqlConnection conn = new SqlConnection();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private SqlCommand cmd = new SqlCommand();
        private DataSet dSet = new DataSet();
        //list of class buttons
        List<Button> buttons = new List<Button>();

        public Home(string lblUser)
        {
            InitializeComponent();
            lblUserName.Text = lblUser;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            //close login form classChat.cs
            classChat frm1 = new classChat();
            frm1.Close();
            //load buttons for each registered course
            loadCourseButtons();
        }

        private void loadCourseButtons()
        {
            //database connection string - local
            //conn.ConnectionString = "Data Source= (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\lyonss2\\Documents\\ClassChat.mdf; Integrated Security = True; Connect Timeout = 30";
            //database connection string - Tom's Server
            conn.ConnectionString = "Removed for security reasons";
            cmd.Parameters.AddWithValue("@pUN", lblUserName.Text);
            cmd.CommandText = "SELECT * FROM CollegeInfo WHERE UserName = @pUN";
            cmd.CommandType = CommandType.Text;
            //create and configure the data adapter
            dataAdapter.SelectCommand = cmd;
            dataAdapter.SelectCommand.Connection = conn;

            //fill the dataset
            dataAdapter.Fill(dSet, "CollegeInfo");

            if (dSet.Tables["CollegeInfo"].Rows.Count == 0)
            {
                int buttonLeft = 10;
                //int buttonTop = 20;
                Button plus = new Button();
                plus.Text = "+";
                plus.Height = 75;
                plus.Width = 75;
                plus.Top = 20;
                plus.Left = buttonLeft;
                groupBox1.Controls.Add(plus);
                plus.Click += (s, a) =>
                {
                    txtAddCourse.Visible = true;
                    lblNewCourse.Visible = true;
                    lblAddNote.Visible = true;
                    btnAddCourse.Visible = true;
                };

            }
            else
            {
                //create butons from courses that redirect to 'classroom'
                int buttonLeft = 10;
                int buttonTop = 20;
                foreach (System.Data.DataRow item in dSet.Tables["CollegeInfo"].Rows)
                {
                    string className = item["CourseName"].ToString();
                    Button button = new Button();
                    button.Text = className;
                    button.Height = 75;
                    button.Width = 75;
                    button.Top = buttonTop;
                    button.Left = buttonLeft;
                    groupBox1.Controls.Add(button);
                    button.Click += (s, a) =>
                    { //open 'home' form, sending lblMsg.Text in order to use it to query database
                        ClassRoom f3 = new ClassRoom(className, lblUserName.Text);
                        f3.Show();
                    };
                    buttons.Add(button);
                    buttonLeft = buttonLeft + 95;
                }
                //listView1.Items.Add("+");
                Button plus = new Button();
                plus.Text = "+";
                plus.Height = 75;
                plus.Width = 75;
                plus.Top = 20;
                plus.Left = buttonLeft;
                groupBox1.Controls.Add(plus);
                plus.Click += (s, a) =>
                {
                    txtAddCourse.Visible = true;
                    lblNewCourse.Visible = true;
                    lblAddNote.Visible = true;
                    btnAddCourse.Visible = true;
                    txtAddCourse.Focus();
                };
                buttons.Add(plus);

            }
        }

        private void bbtnAddCourse_Click(object sender, EventArgs e)
        {
            if (txtAddCourse.Text == " ")
            {
                MessageBox.Show("Please enter course name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddCourse.Focus();
            }
            else
            {
                try
                {
                    cmd.Parameters.Clear();
                    conn.Open();
                    cmd.CommandText = "SELECT CollegeName FROM Accounts WHERE UserName = @pUN";
                    cmd.Parameters.AddWithValue("@pUN", lblUserName.Text);
                    string collegeName = cmd.ExecuteScalar().ToString();
                    conn.Close();
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInsertClass";
                    cmd.Parameters.AddWithValue("@UserName", lblUserName.Text);
                    cmd.Parameters.AddWithValue("@CollegeName", collegeName);
                    cmd.Parameters.AddWithValue("@CourseName", txtAddCourse.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    lblAddNote.Visible = false;
                    lblNewCourse.Visible = false;
                    txtAddCourse.Visible = false;
                    btnAddCourse.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //reload buttons
                    foreach (Button button in buttons)
                    {
                        button.Dispose();
                    }
                    //clears dataset so buttons can be reloaded from query without duplication
                    dSet.Clear();
                    //reload buttons
                    loadCourseButtons();
                }
            }
        }

        //unused methods
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //blank
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //blank
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //blank
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //blank
        }

    }
}
