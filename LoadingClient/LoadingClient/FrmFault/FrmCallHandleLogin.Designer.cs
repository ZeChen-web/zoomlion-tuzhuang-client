namespace LoadingClient
{
    partial class FrmCallHandleLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCallHandleLogin));
            this.uiListBox1 = new Sunny.UI.UIGroupBox();
            this.btnLogin = new Sunny.UI.UIButton();
            this.txtOperatorName = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtLoginCard = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txtPwd = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.uiListBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // uiListBox1
            // 
            this.uiListBox1.Controls.Add(this.btnLogin);
            this.uiListBox1.Controls.Add(this.txtOperatorName);
            this.uiListBox1.Controls.Add(this.uiLabel3);
            this.uiListBox1.Controls.Add(this.txtLoginCard);
            this.uiListBox1.Controls.Add(this.uiLabel2);
            this.uiListBox1.Controls.Add(this.txtPwd);
            this.uiListBox1.Controls.Add(this.uiLabel1);
            this.uiListBox1.Controls.Add(this.pictureBox1);
            this.uiListBox1.Controls.Add(this.pictureBox2);
            this.uiListBox1.Controls.Add(this.pictureBox3);
            this.uiListBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiListBox1.Location = new System.Drawing.Point(-1, 7);
            this.uiListBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiListBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiListBox1.Name = "uiListBox1";
            this.uiListBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiListBox1.Size = new System.Drawing.Size(846, 218);
            this.uiListBox1.TabIndex = 26;
            this.uiListBox1.Text = "请刷卡登录";
            this.uiListBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnLogin.Location = new System.Drawing.Point(659, 80);
            this.btnLogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Radius = 10;
            this.btnLogin.Size = new System.Drawing.Size(113, 51);
            this.btnLogin.TabIndex = 28;
            this.btnLogin.Text = "登    入";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.CanEmpty = true;
            this.txtOperatorName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOperatorName.FillColor = System.Drawing.Color.White;
            this.txtOperatorName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtOperatorName.Location = new System.Drawing.Point(228, 99);
            this.txtOperatorName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOperatorName.Maximum = 9D;
            this.txtOperatorName.Minimum = 0D;
            this.txtOperatorName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.Padding = new System.Windows.Forms.Padding(5);
            this.txtOperatorName.ReadOnly = true;
            this.txtOperatorName.Size = new System.Drawing.Size(221, 29);
            this.txtOperatorName.TabIndex = 27;
            this.txtOperatorName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtOperatorName.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtOperatorName.Watermark = "";
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(149, 104);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(46, 21);
            this.uiLabel3.TabIndex = 26;
            this.uiLabel3.Text = "姓名:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLoginCard
            // 
            this.txtLoginCard.CanEmpty = true;
            this.txtLoginCard.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLoginCard.DoubleValue = 1001D;
            this.txtLoginCard.FillColor = System.Drawing.Color.White;
            this.txtLoginCard.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtLoginCard.IntValue = 1001;
            this.txtLoginCard.Location = new System.Drawing.Point(228, 45);
            this.txtLoginCard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLoginCard.Maximum = 9D;
            this.txtLoginCard.Minimum = 0D;
            this.txtLoginCard.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtLoginCard.Name = "txtLoginCard";
            this.txtLoginCard.Padding = new System.Windows.Forms.Padding(5);
            this.txtLoginCard.Size = new System.Drawing.Size(221, 29);
            this.txtLoginCard.TabIndex = 25;
            this.txtLoginCard.Text = "1001";
            this.txtLoginCard.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtLoginCard.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtLoginCard.Watermark = "";
            this.txtLoginCard.TextChanged += new System.EventHandler(this.txtLoginCard_TextChanged);
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(149, 156);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(46, 21);
            this.uiLabel2.TabIndex = 24;
            this.uiLabel2.Text = "密码:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPwd
            // 
            this.txtPwd.CanEmpty = true;
            this.txtPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPwd.DoubleValue = 123456D;
            this.txtPwd.FillColor = System.Drawing.Color.White;
            this.txtPwd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtPwd.IntValue = 123456;
            this.txtPwd.Location = new System.Drawing.Point(228, 152);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPwd.Maximum = 9D;
            this.txtPwd.Minimum = 0D;
            this.txtPwd.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Padding = new System.Windows.Forms.Padding(5);
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(221, 29);
            this.txtPwd.TabIndex = 23;
            this.txtPwd.Text = "123456";
            this.txtPwd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtPwd.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtPwd.Watermark = "水印文字";
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(149, 50);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(46, 21);
            this.uiLabel1.TabIndex = 22;
            this.uiLabel1.Text = "工号:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(93, 45);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(93, 150);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(93, 99);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // FrmCallHandleLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(845, 232);
            this.Controls.Add(this.uiListBox1);
            this.Name = "FrmCallHandleLogin";
            this.Text = "呼叫处理人员登录";
            this.Load += new System.EventHandler(this.FrmCallHandleLogin_Load);
            this.uiListBox1.ResumeLayout(false);
            this.uiListBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIGroupBox uiListBox1;
        private Sunny.UI.UIButton btnLogin;
        private Sunny.UI.UITextBox txtOperatorName;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtLoginCard;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtPwd;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}