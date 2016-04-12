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
using System.Collections;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace winFormsClassChat
{
    public partial class ClassRoom : Form
    {
        private SqlConnection conn = new SqlConnection();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        private SqlCommand cmd = new SqlCommand();
        private DataSet dSet = new DataSet();
        private string collegeName;
        const int PORT_NO = 1435;
        //resolve IP from domain
        IPHostEntry SERVERIP = Dns.GetHostEntry("removed for security reasons");
        TcpClient client;
        NetworkStream nwStream;

        public ClassRoom(String lblCourseName, string lblUser)
        {
            InitializeComponent();
            lblClassName.Text = lblCourseName;
            lblUserName.Text = lblUser;
        }

        private void ClassRoom_Load(object sender, EventArgs e)
        {
            //database connection string
            //conn.ConnectionString = "Data Source= (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\lyonss2\\Documents\\ClassChat.mdf; Integrated Security = True; Connect Timeout = 30";
            conn.ConnectionString = "removed for security reasons";
            cmd.Parameters.AddWithValue("@pUN", lblUserName.Text);
            cmd.Parameters.AddWithValue("@pCN", lblClassName.Text);
            cmd.CommandText = @"SELECT CollegeName FROM CollegeInfo WHERE UserName = @pUN AND CourseName = @pCN";
            cmd.Connection = conn;
            conn.Open();
             collegeName = (string) cmd.ExecuteScalar();
            conn.Close();

            //resolve IP from domain
            if (SERVERIP.AddressList.Length> 0)
            {
                var SERVER_IP = SERVERIP.AddressList[0];
                //---create a TCPClient object at the IP and port no.---
                client = new TcpClient(SERVER_IP.ToString(), PORT_NO);
            }
          
            nwStream = client.GetStream();

            Thread receiveThread = new Thread(() => receiveMsg(client, nwStream));
            receiveThread.Start();

            if (client.Connected)
            {
                string sendMessage = collegeName + lblClassName.Text;
                txtSend.Clear();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(sendMessage);
                //send message over networkstream
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            }

        }
        //delegate and invoke method to make thread-safe call to txtChatBox WinForm Control
        delegate void setCallbackText(string received);
        private void setText(string received)
        {
            if (this.txtChatBox.InvokeRequired)
            {
                setCallbackText d = new setCallbackText(setText);
                this.Invoke(d, new object[] { received });
            }
            else
            {
                this.txtChatBox.Text += Environment.NewLine + received;
            }
        }
        public void receiveMsg(TcpClient client, NetworkStream nwStream)
        {
            byte[] bytesToRead;
            int bytesRead;

            while (client.Connected)
            {
                Thread.Sleep(100);
                if (nwStream.DataAvailable)
                {

                    //---read back the text-- -
                    bytesToRead = new byte[client.ReceiveBufferSize];
                    bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                    string received = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
                    setText(received);

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] bytesToRead;
            //int bytesRead;
            if (client.Connected)
            {

                //---message to be sent---
                if (txtSend.Text != "")
                {
                    string sendMessage = lblUserName.Text + ": " + txtSend.Text;
                    //closes client connection when written... bad code, should be reworked
                    if (sendMessage == "disconnect")
                    {
                        client.Close();
                    }
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(sendMessage);
                    //---send message over networkstream---
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                    //clears textbox after sending message
                    txtSend.Clear();

                }   
            }
        }

        private void txtChatBox_TextChanged(object sender, EventArgs e)
        {
            //blank
        }
    }
}
