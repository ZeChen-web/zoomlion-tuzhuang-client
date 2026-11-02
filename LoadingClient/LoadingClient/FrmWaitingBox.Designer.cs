namespace LoadingClient
{
    partial class FrmWaitingBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWaitingBox));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labTimer = new System.Windows.Forms.Label();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labMessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.labTimer);
            this.panel1.Controls.Add(this.pictureBoxCancel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labMessage);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 177);
            this.panel1.TabIndex = 1;
            // 
            // labTimer
            // 
            this.labTimer.AutoSize = true;
            this.labTimer.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTimer.ForeColor = System.Drawing.Color.Red;
            this.labTimer.Location = new System.Drawing.Point(187, 103);
            this.labTimer.Name = "labTimer";
            this.labTimer.Size = new System.Drawing.Size(30, 19);
            this.labTimer.TabIndex = 6;
            this.labTimer.Text = "0秒";
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCancel.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCancel.Image")));
            this.pictureBoxCancel.Location = new System.Drawing.Point(747, 143);
            this.pictureBoxCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(60, 30);
            this.pictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCancel.TabIndex = 5;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 125);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMessage.ForeColor = System.Drawing.Color.Black;
            this.labMessage.Location = new System.Drawing.Point(187, 51);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(182, 21);
            this.labMessage.TabIndex = 0;
            this.labMessage.Text = "正在处理数据，请稍后...";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmWaitingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(822, 187);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmWaitingBox";
            this.Text = "FrmWaitingBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWaitingBox_FormClosing);
            this.Shown += new System.EventHandler(this.frmWaitingBox_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labTimer;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labMessage;
        private System.Windows.Forms.Timer timer1;
    }
}