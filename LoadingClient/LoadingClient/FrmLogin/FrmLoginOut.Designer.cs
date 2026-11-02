namespace LoadingClient
{
    partial class FrmLoginOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoginOut));
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
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.btnLogout = new Sunny.UI.UIButton();
            this.lstViewLoginOperator = new System.Windows.Forms.ListView();
            this.btnClose = new Sunny.UI.UISymbolButton();
            this.btnOK = new Sunny.UI.UISymbolButton();
            this.uiListBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
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
            this.uiListBox1.Location = new System.Drawing.Point(4, 10);
            this.uiListBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiListBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiListBox1.Name = "uiListBox1";
            this.uiListBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiListBox1.Size = new System.Drawing.Size(846, 218);
            this.uiListBox1.TabIndex = 28;
            this.uiListBox1.Text = "请刷卡登录";
            this.uiListBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnLogin.Location = new System.Drawing.Point(659, 99);
            this.btnLogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Radius = 10;
            this.btnLogin.Size = new System.Drawing.Size(100, 35);
            this.btnLogin.TabIndex = 28;
            this.btnLogin.Text = "登入";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.CanEmpty = true;
            this.txtOperatorName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOperatorName.FillColor = System.Drawing.Color.White;
            this.txtOperatorName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtOperatorName.Location = new System.Drawing.Point(228, 108);
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
            this.uiLabel3.Location = new System.Drawing.Point(149, 113);
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
            this.txtLoginCard.Location = new System.Drawing.Point(228, 54);
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
            this.uiLabel2.Location = new System.Drawing.Point(149, 165);
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
            this.txtPwd.Location = new System.Drawing.Point(228, 161);
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
            this.uiLabel1.Location = new System.Drawing.Point(149, 59);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(46, 21);
            this.uiLabel1.TabIndex = 22;
            this.uiLabel1.Text = "工号:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(93, 54);
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
            this.pictureBox2.Location = new System.Drawing.Point(93, 159);
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
            this.pictureBox3.Location = new System.Drawing.Point(93, 108);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.btnLogout);
            this.uiGroupBox1.Controls.Add(this.lstViewLoginOperator);
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiGroupBox1.Location = new System.Drawing.Point(4, 243);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(846, 218);
            this.uiGroupBox1.TabIndex = 29;
            this.uiGroupBox1.Text = "已登录的协同人员";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnLogout.Location = new System.Drawing.Point(659, 111);
            this.btnLogout.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Radius = 10;
            this.btnLogout.Size = new System.Drawing.Size(100, 35);
            this.btnLogout.TabIndex = 29;
            this.btnLogout.Text = "登出";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lstViewLoginOperator
            // 
            this.lstViewLoginOperator.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstViewLoginOperator.Location = new System.Drawing.Point(7, 44);
            this.lstViewLoginOperator.Name = "lstViewLoginOperator";
            this.lstViewLoginOperator.Size = new System.Drawing.Size(594, 173);
            this.lstViewLoginOperator.TabIndex = 22;
            this.lstViewLoginOperator.UseCompatibleStateImageBehavior = false;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClose.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btnClose.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnClose.Location = new System.Drawing.Point(68, 496);
            this.btnClose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClose.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btnClose.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.Size = new System.Drawing.Size(100, 50);
            this.btnClose.Style = Sunny.UI.UIStyle.Red;
            this.btnClose.StyleCustomMode = true;
            this.btnClose.Symbol = 61453;
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "退出";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnOK.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnOK.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnOK.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOK.Location = new System.Drawing.Point(663, 496);
            this.btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnOK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnOK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnOK.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnOK.Size = new System.Drawing.Size(100, 50);
            this.btnOK.Style = Sunny.UI.UIStyle.Green;
            this.btnOK.StyleCustomMode = true;
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmLoginOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(855, 564);
            this.Controls.Add(this.uiListBox1);
            this.Controls.Add(this.uiGroupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmLoginOut";
            this.Text = "协同人员登录";
            this.Load += new System.EventHandler(this.FrmLoginOut_Load);
            this.uiListBox1.ResumeLayout(false);
            this.uiListBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
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
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIButton btnLogout;
        private System.Windows.Forms.ListView lstViewLoginOperator;
        private Sunny.UI.UISymbolButton btnClose;
        private Sunny.UI.UISymbolButton btnOK;
    }
}