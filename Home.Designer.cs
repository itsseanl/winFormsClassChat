namespace winFormsClassChat
{
    partial class Home
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNewCourse = new System.Windows.Forms.Label();
            this.txtAddCourse = new System.Windows.Forms.TextBox();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.lblAddNote = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(714, 7);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 13);
            this.lblUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(659, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome, ";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(771, 119);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your Schedule";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblNewCourse
            // 
            this.lblNewCourse.AutoSize = true;
            this.lblNewCourse.Location = new System.Drawing.Point(19, 177);
            this.lblNewCourse.Name = "lblNewCourse";
            this.lblNewCourse.Size = new System.Drawing.Size(68, 13);
            this.lblNewCourse.TabIndex = 4;
            this.lblNewCourse.Text = "New Course:";
            this.lblNewCourse.Visible = false;
            // 
            // txtAddCourse
            // 
            this.txtAddCourse.Location = new System.Drawing.Point(98, 174);
            this.txtAddCourse.Name = "txtAddCourse";
            this.txtAddCourse.Size = new System.Drawing.Size(145, 20);
            this.txtAddCourse.TabIndex = 5;
            this.txtAddCourse.Visible = false;
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.Location = new System.Drawing.Point(249, 172);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(75, 23);
            this.btnAddCourse.TabIndex = 6;
            this.btnAddCourse.Text = "Add Course";
            this.btnAddCourse.UseVisualStyleBackColor = true;
            this.btnAddCourse.Visible = false;
            this.btnAddCourse.Click += new System.EventHandler(this.bbtnAddCourse_Click);
            // 
            // lblAddNote
            // 
            this.lblAddNote.AutoSize = true;
            this.lblAddNote.Location = new System.Drawing.Point(19, 197);
            this.lblAddNote.Name = "lblAddNote";
            this.lblAddNote.Size = new System.Drawing.Size(239, 13);
            this.lblAddNote.TabIndex = 7;
            this.lblAddNote.Text = "Note: please enter exactly as written on transcript";
            this.lblAddNote.Visible = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(702, 216);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 8;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(794, 274);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnLogOut);
            this.tabPage1.Controls.Add(this.lblUserName);
            this.tabPage1.Controls.Add(this.lblAddNote);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnAddCourse);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtAddCourse);
            this.tabPage1.Controls.Add(this.lblNewCourse);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(786, 248);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(786, 248);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Classroom";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 278);
            this.Controls.Add(this.tabControl1);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNewCourse;
        private System.Windows.Forms.TextBox txtAddCourse;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Label lblAddNote;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}