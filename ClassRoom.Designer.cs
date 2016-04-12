namespace winFormsClassChat
{
    partial class ClassRoom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtChatBox = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lblClassName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUsersOnline = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtChatBox
            // 
            this.txtChatBox.Location = new System.Drawing.Point(124, 59);
            this.txtChatBox.Multiline = true;
            this.txtChatBox.Name = "txtChatBox";
            this.txtChatBox.Size = new System.Drawing.Size(540, 289);
            this.txtChatBox.TabIndex = 0;
            this.txtChatBox.TextChanged += new System.EventHandler(this.txtChatBox_TextChanged);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(124, 355);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(459, 58);
            this.txtSend.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(589, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(671, 59);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(174, 289);
            this.webBrowser1.TabIndex = 4;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.Location = new System.Drawing.Point(12, 9);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(198, 39);
            this.lblClassName.TabIndex = 5;
            this.lblClassName.Text = "ClassName";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(754, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 13);
            this.lblUserName.TabIndex = 6;
            // 
            // txtUsersOnline
            // 
            this.txtUsersOnline.Location = new System.Drawing.Point(4, 59);
            this.txtUsersOnline.Multiline = true;
            this.txtUsersOnline.Name = "txtUsersOnline";
            this.txtUsersOnline.Size = new System.Drawing.Size(114, 289);
            this.txtUsersOnline.TabIndex = 7;
            // 
            // ClassRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 423);
            this.Controls.Add(this.txtUsersOnline);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtChatBox);
            this.Name = "ClassRoom";
            this.Text = "ClassRoom";
            this.Load += new System.EventHandler(this.ClassRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChatBox;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUsersOnline;
    }
}