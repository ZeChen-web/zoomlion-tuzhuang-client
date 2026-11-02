namespace LoadingClient
{
    partial class FrmPwdChange
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPwdChange));
            this.loginError = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOK = new Sunny.UI.UISymbolButton();
            this.btnClose = new Sunny.UI.UISymbolButton();
            this.txtNewPwd = new Sunny.UI.UITextBox();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.txtOldPwd = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txtVerifyNewPwd = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.loginError)).BeginInit();
            this.SuspendLayout();
            // 
            // loginError
            // 
            this.loginError.ContainerControl = this;
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnOK.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnOK.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnOK.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOK.Location = new System.Drawing.Point(261, 189);
            this.btnOK.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnOK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnOK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnOK.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnOK.Size = new System.Drawing.Size(81, 35);
            this.btnOK.Style = Sunny.UI.UIStyle.Green;
            this.btnOK.StyleCustomMode = true;
            this.btnOK.TabIndex = 73;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClose.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btnClose.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnClose.Location = new System.Drawing.Point(46, 189);
            this.btnClose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClose.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btnClose.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.Size = new System.Drawing.Size(81, 35);
            this.btnClose.Style = Sunny.UI.UIStyle.Red;
            this.btnClose.StyleCustomMode = true;
            this.btnClose.Symbol = 61453;
            this.btnClose.TabIndex = 72;
            this.btnClose.Text = "退出";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.CanEmpty = true;
            this.txtNewPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPwd.FillColor = System.Drawing.Color.White;
            this.txtNewPwd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtNewPwd.Location = new System.Drawing.Point(121, 77);
            this.txtNewPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNewPwd.Maximum = 9D;
            this.txtNewPwd.Minimum = 0D;
            this.txtNewPwd.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Padding = new System.Windows.Forms.Padding(5);
            this.txtNewPwd.Size = new System.Drawing.Size(221, 29);
            this.txtNewPwd.TabIndex = 71;
            this.txtNewPwd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtNewPwd.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtNewPwd.Watermark = "";
            // 
            // uiLabel3
            // 
            this.uiLabel3.AutoSize = true;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(42, 82);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(62, 21);
            this.uiLabel3.TabIndex = 70;
            this.uiLabel3.Text = "新密码:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.CanEmpty = true;
            this.txtOldPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldPwd.FillColor = System.Drawing.Color.White;
            this.txtOldPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOldPwd.Location = new System.Drawing.Point(121, 23);
            this.txtOldPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOldPwd.Maximum = 9D;
            this.txtOldPwd.Minimum = 0D;
            this.txtOldPwd.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Padding = new System.Windows.Forms.Padding(5);
            this.txtOldPwd.Size = new System.Drawing.Size(221, 29);
            this.txtOldPwd.TabIndex = 69;
            this.txtOldPwd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtOldPwd.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtOldPwd.Watermark = "";
            // 
            // uiLabel2
            // 
            this.uiLabel2.AutoSize = true;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(20, 133);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(94, 21);
            this.uiLabel2.TabIndex = 68;
            this.uiLabel2.Text = "确认新密码:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVerifyNewPwd
            // 
            this.txtVerifyNewPwd.CanEmpty = true;
            this.txtVerifyNewPwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVerifyNewPwd.FillColor = System.Drawing.Color.White;
            this.txtVerifyNewPwd.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtVerifyNewPwd.Location = new System.Drawing.Point(121, 130);
            this.txtVerifyNewPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVerifyNewPwd.Maximum = 9D;
            this.txtVerifyNewPwd.Minimum = 0D;
            this.txtVerifyNewPwd.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtVerifyNewPwd.Name = "txtVerifyNewPwd";
            this.txtVerifyNewPwd.Padding = new System.Windows.Forms.Padding(5);
            this.txtVerifyNewPwd.Size = new System.Drawing.Size(221, 29);
            this.txtVerifyNewPwd.TabIndex = 67;
            this.txtVerifyNewPwd.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtVerifyNewPwd.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.txtVerifyNewPwd.Watermark = "";
            // 
            // uiLabel1
            // 
            this.uiLabel1.AutoSize = true;
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(42, 28);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(62, 21);
            this.uiLabel1.TabIndex = 66;
            this.uiLabel1.Text = "原密码:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmPwdChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(372, 247);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtNewPwd);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.txtVerifyNewPwd);
            this.Controls.Add(this.uiLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPwdChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码修改";
            ((System.ComponentModel.ISupportInitialize)(this.loginError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider loginError;
        private Sunny.UI.UISymbolButton btnOK;
        private Sunny.UI.UISymbolButton btnClose;
        private Sunny.UI.UITextBox txtNewPwd;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox txtOldPwd;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtVerifyNewPwd;
        private Sunny.UI.UILabel uiLabel1;
    }
}