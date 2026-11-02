namespace LoadingClient
{
    partial class FrmLoadingClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoadingClient));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toollblLoginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toollblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCurrentDate = new Sunny.UI.UILabel();
            this.lblCurrentTime = new Sunny.UI.UILabel();
            this.lblTitle = new Sunny.UI.UILabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFaultCall = new Sunny.UI.UIHeaderButton();
            this.btnPwdChange = new Sunny.UI.UIHeaderButton();
            this.btnLogInOut = new Sunny.UI.UIHeaderButton();
            this.btnSysCanle = new Sunny.UI.UIHeaderButton();
            this.btnSysClose = new Sunny.UI.UIHeaderButton();
            this.plMain = new System.Windows.Forms.Panel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1942, 1102);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLabel4,
            this.toollblLoginName,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolLabel2,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel8,
            this.toollblTime,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1070);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 25, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1942, 32);
            this.statusStrip1.TabIndex = 201;
            // 
            // toolLabel4
            // 
            this.toolLabel4.AutoSize = false;
            this.toolLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolLabel4.ForeColor = System.Drawing.Color.White;
            this.toolLabel4.Name = "toolLabel4";
            this.toolLabel4.Size = new System.Drawing.Size(74, 26);
            this.toolLabel4.Text = "登录用户:";
            this.toolLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toollblLoginName
            // 
            this.toollblLoginName.AutoSize = false;
            this.toollblLoginName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toollblLoginName.ForeColor = System.Drawing.Color.White;
            this.toollblLoginName.LinkColor = System.Drawing.Color.Black;
            this.toollblLoginName.Name = "toollblLoginName";
            this.toollblLoginName.Size = new System.Drawing.Size(120, 26);
            this.toollblLoginName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(374, 26);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel12555555552222222222";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(364, 26);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2111111111111111111";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(184, 26);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.ForeColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(184, 26);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // toolLabel2
            // 
            this.toolLabel2.AutoSize = false;
            this.toolLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolLabel2.ForeColor = System.Drawing.Color.White;
            this.toolLabel2.Name = "toolLabel2";
            this.toolLabel2.Size = new System.Drawing.Size(100, 26);
            this.toolLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.AutoSize = false;
            this.toolStripStatusLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel6.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(150, 26);
            this.toolStripStatusLabel6.Text = "                                                                                 " +
    "       ";
            this.toolStripStatusLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toollblTime
            // 
            this.toollblTime.AutoSize = false;
            this.toollblTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toollblTime.ForeColor = System.Drawing.Color.White;
            this.toollblTime.Name = "toollblTime";
            this.toollblTime.Size = new System.Drawing.Size(150, 26);
            this.toollblTime.Text = "                                                                                 " +
    "       ";
            this.toollblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.AutoSize = false;
            this.toolStripStatusLabel7.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(225, 26);
            this.toolStripStatusLabel7.Text = "无锡睿思智能科技有限公司";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(184, 23);
            this.toolStripStatusLabel5.Text = "toolStripStatusLabel5";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 191F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCurrentDate, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCurrentTime, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTitle, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1934, 48);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentDate.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentDate.ForeColor = System.Drawing.Color.White;
            this.lblCurrentDate.Location = new System.Drawing.Point(1640, 0);
            this.lblCurrentDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(183, 48);
            this.lblCurrentDate.StyleCustomMode = true;
            this.lblCurrentDate.TabIndex = 5;
            this.lblCurrentDate.Text = "2021-06-29";
            this.lblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentTime.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTime.Location = new System.Drawing.Point(1831, 0);
            this.lblCurrentTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(99, 48);
            this.lblCurrentTime.StyleCustomMode = true;
            this.lblCurrentTime.TabIndex = 6;
            this.lblCurrentTime.Text = "11:06:29";
            this.lblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(253, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1379, 48);
            this.lblTitle.StyleCustomMode = true;
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "运通物料查询客户端";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.plMain, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 60);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1934, 1006);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel4.Controls.Add(this.btnFaultCall, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnPwdChange, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnLogInOut, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnSysCanle, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnSysClose, 4, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1922, 117);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btnFaultCall
            // 
            this.btnFaultCall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFaultCall.CircleColor = System.Drawing.Color.White;
            this.btnFaultCall.CircleHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnFaultCall.FillColor = System.Drawing.Color.Transparent;
            this.btnFaultCall.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(137)))));
            this.btnFaultCall.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.btnFaultCall.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.btnFaultCall.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnFaultCall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnFaultCall.Location = new System.Drawing.Point(388, 4);
            this.btnFaultCall.Margin = new System.Windows.Forms.Padding(4);
            this.btnFaultCall.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFaultCall.Name = "btnFaultCall";
            this.btnFaultCall.Padding = new System.Windows.Forms.Padding(0, 10, 0, 4);
            this.btnFaultCall.Radius = 0;
            this.btnFaultCall.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.btnFaultCall.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnFaultCall.Size = new System.Drawing.Size(376, 109);
            this.btnFaultCall.Style = Sunny.UI.UIStyle.Custom;
            this.btnFaultCall.Symbol = 162002;
            this.btnFaultCall.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnFaultCall.TabIndex = 11;
            this.btnFaultCall.Text = "异常呼叫";
            this.btnFaultCall.Click += new System.EventHandler(this.btnFaultCall_Click);
            // 
            // btnPwdChange
            // 
            this.btnPwdChange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPwdChange.CircleColor = System.Drawing.Color.White;
            this.btnPwdChange.CircleHoverColor = System.Drawing.Color.White;
            this.btnPwdChange.FillColor = System.Drawing.Color.Transparent;
            this.btnPwdChange.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(174)))), ((int)(((byte)(86)))));
            this.btnPwdChange.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(137)))), ((int)(((byte)(43)))));
            this.btnPwdChange.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(137)))), ((int)(((byte)(43)))));
            this.btnPwdChange.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnPwdChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(166)))), ((int)(((byte)(212)))));
            this.btnPwdChange.Location = new System.Drawing.Point(772, 4);
            this.btnPwdChange.Margin = new System.Windows.Forms.Padding(4);
            this.btnPwdChange.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnPwdChange.Name = "btnPwdChange";
            this.btnPwdChange.Padding = new System.Windows.Forms.Padding(0, 10, 0, 4);
            this.btnPwdChange.Radius = 0;
            this.btnPwdChange.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.btnPwdChange.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnPwdChange.Size = new System.Drawing.Size(376, 109);
            this.btnPwdChange.Style = Sunny.UI.UIStyle.Custom;
            this.btnPwdChange.Symbol = 62014;
            this.btnPwdChange.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(166)))), ((int)(((byte)(212)))));
            this.btnPwdChange.TabIndex = 5;
            this.btnPwdChange.Text = "密码修改";
            this.btnPwdChange.Click += new System.EventHandler(this.btnPwdChange_Click);
            // 
            // btnLogInOut
            // 
            this.btnLogInOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogInOut.CircleColor = System.Drawing.Color.White;
            this.btnLogInOut.CircleHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnLogInOut.FillColor = System.Drawing.Color.Transparent;
            this.btnLogInOut.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(137)))));
            this.btnLogInOut.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.btnLogInOut.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.btnLogInOut.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnLogInOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnLogInOut.Location = new System.Drawing.Point(4, 4);
            this.btnLogInOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogInOut.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLogInOut.Name = "btnLogInOut";
            this.btnLogInOut.Padding = new System.Windows.Forms.Padding(0, 10, 0, 4);
            this.btnLogInOut.Radius = 0;
            this.btnLogInOut.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.btnLogInOut.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnLogInOut.Size = new System.Drawing.Size(376, 109);
            this.btnLogInOut.Style = Sunny.UI.UIStyle.Custom;
            this.btnLogInOut.Symbol = 362720;
            this.btnLogInOut.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnLogInOut.TabIndex = 4;
            this.btnLogInOut.Text = "协同登录";
            this.btnLogInOut.Click += new System.EventHandler(this.btnLogInOut_Click);
            // 
            // btnSysCanle
            // 
            this.btnSysCanle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSysCanle.CircleColor = System.Drawing.Color.White;
            this.btnSysCanle.CircleHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnSysCanle.FillColor = System.Drawing.Color.Transparent;
            this.btnSysCanle.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(137)))));
            this.btnSysCanle.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.btnSysCanle.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.btnSysCanle.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSysCanle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(166)))), ((int)(((byte)(212)))));
            this.btnSysCanle.Location = new System.Drawing.Point(1156, 4);
            this.btnSysCanle.Margin = new System.Windows.Forms.Padding(4);
            this.btnSysCanle.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSysCanle.Name = "btnSysCanle";
            this.btnSysCanle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 4);
            this.btnSysCanle.Radius = 0;
            this.btnSysCanle.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.btnSysCanle.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnSysCanle.Size = new System.Drawing.Size(376, 109);
            this.btnSysCanle.Style = Sunny.UI.UIStyle.Custom;
            this.btnSysCanle.Symbol = 61470;
            this.btnSysCanle.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(166)))), ((int)(((byte)(212)))));
            this.btnSysCanle.TabIndex = 3;
            this.btnSysCanle.Text = "系统注销";
            this.btnSysCanle.Click += new System.EventHandler(this.btnSysCanle_Click);
            // 
            // btnSysClose
            // 
            this.btnSysClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSysClose.CircleColor = System.Drawing.Color.White;
            this.btnSysClose.CircleHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnSysClose.FillColor = System.Drawing.Color.Transparent;
            this.btnSysClose.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(226)))), ((int)(((byte)(137)))));
            this.btnSysClose.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.btnSysClose.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(137)))));
            this.btnSysClose.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSysClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(166)))), ((int)(((byte)(212)))));
            this.btnSysClose.Location = new System.Drawing.Point(1540, 4);
            this.btnSysClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnSysClose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSysClose.Name = "btnSysClose";
            this.btnSysClose.Padding = new System.Windows.Forms.Padding(0, 10, 0, 4);
            this.btnSysClose.Radius = 0;
            this.btnSysClose.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.btnSysClose.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.btnSysClose.Size = new System.Drawing.Size(378, 109);
            this.btnSysClose.Style = Sunny.UI.UIStyle.Custom;
            this.btnSysClose.Symbol = 62163;
            this.btnSysClose.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(166)))), ((int)(((byte)(212)))));
            this.btnSysClose.TabIndex = 12;
            this.btnSysClose.Text = "系统关闭";
            this.btnSysClose.Click += new System.EventHandler(this.btnSysClose_Click);
            // 
            // plMain
            // 
            this.plMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plMain.BackColor = System.Drawing.Color.Transparent;
            this.plMain.Location = new System.Drawing.Point(6, 133);
            this.plMain.Margin = new System.Windows.Forms.Padding(4);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(1922, 867);
            this.plMain.TabIndex = 1;
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.AutoSize = false;
            this.toolStripStatusLabel8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel8.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(150, 26);
            this.toolStripStatusLabel8.Text = "                                                                                 " +
    "       ";
            this.toolStripStatusLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmLoadingClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLoadingClient";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLoadingClient_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toollblLoginName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toollblTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Sunny.UI.UILabel lblCurrentDate;
        private Sunny.UI.UILabel lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Sunny.UI.UIHeaderButton btnPwdChange;
        private Sunny.UI.UIHeaderButton btnLogInOut;
        private Sunny.UI.UIHeaderButton btnSysCanle;
        public System.Windows.Forms.Panel plMain;
        private Sunny.UI.UIHeaderButton btnFaultCall;
        private Sunny.UI.UIHeaderButton btnSysClose;
        private Sunny.UI.UILabel lblCurrentTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
    }
}

