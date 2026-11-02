namespace LoadingClient
{
    partial class FrmFaultInfo
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
            this.lbltitle = new Sunny.UI.UILabel();
            this.btnFinish = new Sunny.UI.UISymbolButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReport = new Sunny.UI.UISymbolButton();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.cmbJobOrderNo = new Sunny.UI.UIComboBox();
            this.cmbStationNo = new Sunny.UI.UIComboBox();
            this.txtExceptionType = new Sunny.UI.UITextBox();
            this.txtDealOperator = new Sunny.UI.UITextBox();
            this.txtResultDesc = new Sunny.UI.UITextBox();
            this.uiLabel8 = new Sunny.UI.UILabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.txtReportOperator = new Sunny.UI.UITextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtExceptionDesc = new Sunny.UI.UITextBox();
            this.txtFaultNo = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltitle
            // 
            this.lbltitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltitle.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbltitle.Location = new System.Drawing.Point(3, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(927, 50);
            this.lbltitle.TabIndex = 7;
            this.lbltitle.Text = "异常呼叫";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnFinish.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btnFinish.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnFinish.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnFinish.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnFinish.Location = new System.Drawing.Point(3, 3);
            this.btnFinish.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnFinish.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btnFinish.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnFinish.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnFinish.Size = new System.Drawing.Size(152, 35);
            this.btnFinish.Style = Sunny.UI.UIStyle.Red;
            this.btnFinish.Symbol = 61529;
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "异常处理";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnFinish, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnReport, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 580);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(927, 41);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnReport.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnReport.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnReport.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnReport.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnReport.Location = new System.Drawing.Point(776, 3);
            this.btnReport.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnReport.Name = "btnReport";
            this.btnReport.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnReport.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnReport.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnReport.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnReport.Size = new System.Drawing.Size(148, 35);
            this.btnReport.Style = Sunny.UI.UIStyle.Green;
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "反   馈";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // uiLabel6
            // 
            this.uiLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel6.Location = new System.Drawing.Point(640, 41);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(92, 38);
            this.uiLabel6.TabIndex = 29;
            this.uiLabel6.Text = "派工单号";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel5.Location = new System.Drawing.Point(640, 2);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(92, 37);
            this.uiLabel5.TabIndex = 28;
            this.uiLabel5.Text = "机台编码";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(344, 41);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(101, 38);
            this.uiLabel4.TabIndex = 27;
            this.uiLabel4.Text = "处理人";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(344, 2);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(101, 37);
            this.uiLabel3.TabIndex = 26;
            this.uiLabel3.Text = "异常类型";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(5, 41);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(136, 38);
            this.uiLabel2.TabIndex = 25;
            this.uiLabel2.Text = "提交人";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbJobOrderNo
            // 
            this.cmbJobOrderNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbJobOrderNo.DataSource = null;
            this.cmbJobOrderNo.FillColor = System.Drawing.Color.White;
            this.cmbJobOrderNo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbJobOrderNo.Location = new System.Drawing.Point(741, 46);
            this.cmbJobOrderNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbJobOrderNo.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbJobOrderNo.Name = "cmbJobOrderNo";
            this.cmbJobOrderNo.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbJobOrderNo.Size = new System.Drawing.Size(180, 28);
            this.cmbJobOrderNo.TabIndex = 23;
            this.cmbJobOrderNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbJobOrderNo.SelectedIndexChanged += new System.EventHandler(this.cmbJobOrderNo_SelectedIndexChanged);
            // 
            // cmbStationNo
            // 
            this.cmbStationNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStationNo.DataSource = null;
            this.cmbStationNo.FillColor = System.Drawing.Color.White;
            this.cmbStationNo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbStationNo.Location = new System.Drawing.Point(741, 7);
            this.cmbStationNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStationNo.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbStationNo.Name = "cmbStationNo";
            this.cmbStationNo.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbStationNo.Size = new System.Drawing.Size(180, 27);
            this.cmbStationNo.TabIndex = 22;
            this.cmbStationNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbStationNo.SelectedIndexChanged += new System.EventHandler(this.cmbStationNo_SelectedIndexChanged);
            // 
            // txtExceptionType
            // 
            this.txtExceptionType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExceptionType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtExceptionType.FillColor = System.Drawing.Color.White;
            this.txtExceptionType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtExceptionType.Location = new System.Drawing.Point(454, 7);
            this.txtExceptionType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExceptionType.Maximum = 2147483647D;
            this.txtExceptionType.Minimum = -2147483648D;
            this.txtExceptionType.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtExceptionType.Name = "txtExceptionType";
            this.txtExceptionType.Padding = new System.Windows.Forms.Padding(5);
            this.txtExceptionType.Size = new System.Drawing.Size(177, 29);
            this.txtExceptionType.TabIndex = 21;
            this.txtExceptionType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDealOperator
            // 
            this.txtDealOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDealOperator.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDealOperator.FillColor = System.Drawing.Color.White;
            this.txtDealOperator.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtDealOperator.Location = new System.Drawing.Point(454, 46);
            this.txtDealOperator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDealOperator.Maximum = 2147483647D;
            this.txtDealOperator.Minimum = -2147483648D;
            this.txtDealOperator.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtDealOperator.Name = "txtDealOperator";
            this.txtDealOperator.Padding = new System.Windows.Forms.Padding(5);
            this.txtDealOperator.Size = new System.Drawing.Size(177, 29);
            this.txtDealOperator.TabIndex = 20;
            this.txtDealOperator.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResultDesc
            // 
            this.txtResultDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtResultDesc.FillColor = System.Drawing.Color.White;
            this.txtResultDesc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtResultDesc.Location = new System.Drawing.Point(4, 260);
            this.txtResultDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtResultDesc.Maximum = 2147483647D;
            this.txtResultDesc.Minimum = -2147483648D;
            this.txtResultDesc.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtResultDesc.Multiline = true;
            this.txtResultDesc.Name = "txtResultDesc";
            this.txtResultDesc.Padding = new System.Windows.Forms.Padding(5);
            this.txtResultDesc.Size = new System.Drawing.Size(919, 169);
            this.txtResultDesc.TabIndex = 8;
            this.txtResultDesc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel8
            // 
            this.uiLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel8.Location = new System.Drawing.Point(-2, -2);
            this.uiLabel8.Name = "uiLabel8";
            this.uiLabel8.Size = new System.Drawing.Size(136, 37);
            this.uiLabel8.TabIndex = 25;
            this.uiLabel8.Text = "处理结果:";
            this.uiLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.uiLabel8);
            this.panel2.Location = new System.Drawing.Point(3, 218);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(134, 34);
            this.panel2.TabIndex = 5;
            // 
            // uiLabel7
            // 
            this.uiLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel7.Location = new System.Drawing.Point(-2, -4);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(136, 37);
            this.uiLabel7.TabIndex = 25;
            this.uiLabel7.Text = "问题描述:";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtReportOperator
            // 
            this.txtReportOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportOperator.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReportOperator.FillColor = System.Drawing.Color.White;
            this.txtReportOperator.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtReportOperator.Location = new System.Drawing.Point(150, 46);
            this.txtReportOperator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtReportOperator.Maximum = 2147483647D;
            this.txtReportOperator.Minimum = -2147483648D;
            this.txtReportOperator.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtReportOperator.Name = "txtReportOperator";
            this.txtReportOperator.Padding = new System.Windows.Forms.Padding(5);
            this.txtReportOperator.Size = new System.Drawing.Size(185, 29);
            this.txtReportOperator.TabIndex = 19;
            this.txtReportOperator.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.txtExceptionDesc, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtResultDesc, 0, 3);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 140);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(927, 434);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.uiLabel7);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 31);
            this.panel1.TabIndex = 3;
            // 
            // txtExceptionDesc
            // 
            this.txtExceptionDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExceptionDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtExceptionDesc.FillColor = System.Drawing.Color.White;
            this.txtExceptionDesc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtExceptionDesc.Location = new System.Drawing.Point(4, 42);
            this.txtExceptionDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExceptionDesc.Maximum = 2147483647D;
            this.txtExceptionDesc.Minimum = -2147483648D;
            this.txtExceptionDesc.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtExceptionDesc.Multiline = true;
            this.txtExceptionDesc.Name = "txtExceptionDesc";
            this.txtExceptionDesc.Padding = new System.Windows.Forms.Padding(5);
            this.txtExceptionDesc.Size = new System.Drawing.Size(919, 168);
            this.txtExceptionDesc.TabIndex = 7;
            this.txtExceptionDesc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFaultNo
            // 
            this.txtFaultNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFaultNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFaultNo.FillColor = System.Drawing.Color.White;
            this.txtFaultNo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtFaultNo.Location = new System.Drawing.Point(150, 7);
            this.txtFaultNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFaultNo.Maximum = 2147483647D;
            this.txtFaultNo.Minimum = -2147483648D;
            this.txtFaultNo.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtFaultNo.Name = "txtFaultNo";
            this.txtFaultNo.Padding = new System.Windows.Forms.Padding(5);
            this.txtFaultNo.Size = new System.Drawing.Size(185, 29);
            this.txtFaultNo.TabIndex = 18;
            this.txtFaultNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(5, 2);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(136, 37);
            this.uiLabel1.TabIndex = 24;
            this.uiLabel1.Text = "异常编号";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.68396F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.20853F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.84834F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.37915F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.86376F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.21371F));
            this.tableLayoutPanel3.Controls.Add(this.uiLabel6, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.uiLabel5, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.uiLabel4, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.uiLabel3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.uiLabel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbJobOrderNo, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbStationNo, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtExceptionType, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtDealOperator, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtReportOperator, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtFaultNo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.uiLabel1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(927, 81);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.LightBlue;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbltitle, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 440F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(933, 624);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // FrmFaultInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(933, 624);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmFaultInfo";
            this.Text = "异常呼叫";
            this.Load += new System.EventHandler(this.FrmFaultInfo_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel lbltitle;
        private Sunny.UI.UISymbolButton btnFinish;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Sunny.UI.UISymbolButton btnReport;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIComboBox cmbJobOrderNo;
        private Sunny.UI.UIComboBox cmbStationNo;
        private Sunny.UI.UITextBox txtExceptionType;
        private Sunny.UI.UITextBox txtDealOperator;
        private Sunny.UI.UITextBox txtResultDesc;
        private Sunny.UI.UILabel uiLabel8;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UITextBox txtReportOperator;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UITextBox txtExceptionDesc;
        private Sunny.UI.UITextBox txtFaultNo;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}