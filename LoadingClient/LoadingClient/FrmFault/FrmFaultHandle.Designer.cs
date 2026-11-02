namespace LoadingClient
{
    partial class FrmFaultHandle
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
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.btnClose = new Sunny.UI.UISymbolButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnHandleResult = new Sunny.UI.UISymbolButton();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.txtDealOperator = new Sunny.UI.UITextBox();
            this.cmbCallNo = new Sunny.UI.UIComboBox();
            this.cmbStationNo = new Sunny.UI.UIComboBox();
            this.txtExceptionType = new Sunny.UI.UITextBox();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txtHandleDesc = new Sunny.UI.UITextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFaultDesc = new Sunny.UI.UITextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLabel7
            // 
            this.uiLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(3, 0);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(992, 50);
            this.uiLabel7.TabIndex = 7;
            this.uiLabel7.Text = "异常呼叫处理";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClose.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btnClose.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnClose.Location = new System.Drawing.Point(3, 3);
            this.btnClose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnClose.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(127)))), ((int)(((byte)(128)))));
            this.btnClose.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(87)))), ((int)(((byte)(89)))));
            this.btnClose.Size = new System.Drawing.Size(152, 35);
            this.btnClose.Style = Sunny.UI.UIStyle.Red;
            this.btnClose.Symbol = 61453;
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关  闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.tableLayoutPanel2.Controls.Add(this.btnClose, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnHandleResult, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 594);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(992, 41);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnHandleResult
            // 
            this.btnHandleResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHandleResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHandleResult.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnHandleResult.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnHandleResult.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnHandleResult.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnHandleResult.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnHandleResult.Location = new System.Drawing.Point(841, 3);
            this.btnHandleResult.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnHandleResult.Name = "btnHandleResult";
            this.btnHandleResult.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(190)))), ((int)(((byte)(40)))));
            this.btnHandleResult.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(202)))), ((int)(((byte)(81)))));
            this.btnHandleResult.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnHandleResult.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(168)))), ((int)(((byte)(35)))));
            this.btnHandleResult.Size = new System.Drawing.Size(148, 35);
            this.btnHandleResult.Style = Sunny.UI.UIStyle.Green;
            this.btnHandleResult.TabIndex = 0;
            this.btnHandleResult.Text = "结果提交";
            this.btnHandleResult.Click += new System.EventHandler(this.btnHandleResult_Click);
            // 
            // uiLabel4
            // 
            this.uiLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel4.Location = new System.Drawing.Point(532, 43);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(162, 39);
            this.uiLabel4.TabIndex = 22;
            this.uiLabel4.Text = "处理人";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel3.Location = new System.Drawing.Point(532, 2);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(162, 39);
            this.uiLabel3.TabIndex = 21;
            this.uiLabel3.Text = "异常类型";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel2.Location = new System.Drawing.Point(5, 43);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(216, 39);
            this.uiLabel2.TabIndex = 20;
            this.uiLabel2.Text = "异常编号";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDealOperator
            // 
            this.txtDealOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDealOperator.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDealOperator.FillColor = System.Drawing.Color.White;
            this.txtDealOperator.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtDealOperator.Location = new System.Drawing.Point(703, 48);
            this.txtDealOperator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDealOperator.Maximum = 2147483647D;
            this.txtDealOperator.Minimum = -2147483648D;
            this.txtDealOperator.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtDealOperator.Name = "txtDealOperator";
            this.txtDealOperator.Padding = new System.Windows.Forms.Padding(5);
            this.txtDealOperator.Size = new System.Drawing.Size(283, 29);
            this.txtDealOperator.TabIndex = 18;
            this.txtDealOperator.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCallNo
            // 
            this.cmbCallNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCallNo.DataSource = null;
            this.cmbCallNo.FillColor = System.Drawing.Color.White;
            this.cmbCallNo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbCallNo.Location = new System.Drawing.Point(230, 48);
            this.cmbCallNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCallNo.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbCallNo.Name = "cmbCallNo";
            this.cmbCallNo.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbCallNo.Size = new System.Drawing.Size(293, 29);
            this.cmbCallNo.TabIndex = 16;
            this.cmbCallNo.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmbCallNo.SelectedIndexChanged += new System.EventHandler(this.cmbCallNo_SelectedIndexChanged);
            // 
            // cmbStationNo
            // 
            this.cmbStationNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStationNo.DataSource = null;
            this.cmbStationNo.FillColor = System.Drawing.Color.White;
            this.cmbStationNo.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cmbStationNo.Location = new System.Drawing.Point(230, 7);
            this.cmbStationNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbStationNo.MinimumSize = new System.Drawing.Size(63, 0);
            this.cmbStationNo.Name = "cmbStationNo";
            this.cmbStationNo.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cmbStationNo.Size = new System.Drawing.Size(293, 29);
            this.cmbStationNo.TabIndex = 15;
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
            this.txtExceptionType.Location = new System.Drawing.Point(703, 7);
            this.txtExceptionType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExceptionType.Maximum = 2147483647D;
            this.txtExceptionType.Minimum = -2147483648D;
            this.txtExceptionType.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtExceptionType.Name = "txtExceptionType";
            this.txtExceptionType.Padding = new System.Windows.Forms.Padding(5);
            this.txtExceptionType.Size = new System.Drawing.Size(283, 29);
            this.txtExceptionType.TabIndex = 17;
            this.txtExceptionType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(2, 1);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(128, 23);
            this.uiLabel6.TabIndex = 1;
            this.uiLabel6.Text = "处理结果:";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.uiLabel6);
            this.panel1.Location = new System.Drawing.Point(3, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 30);
            this.panel1.TabIndex = 3;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(5, 0);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(128, 23);
            this.uiLabel5.TabIndex = 0;
            this.uiLabel5.Text = "呼叫描述:";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(5, 2);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(216, 39);
            this.uiLabel1.TabIndex = 19;
            this.uiLabel1.Text = "机台编号";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHandleDesc
            // 
            this.txtHandleDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHandleDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHandleDesc.FillColor = System.Drawing.Color.White;
            this.txtHandleDesc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtHandleDesc.Location = new System.Drawing.Point(4, 255);
            this.txtHandleDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHandleDesc.Maximum = 2147483647D;
            this.txtHandleDesc.Minimum = -2147483648D;
            this.txtHandleDesc.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtHandleDesc.Multiline = true;
            this.txtHandleDesc.Name = "txtHandleDesc";
            this.txtHandleDesc.Padding = new System.Windows.Forms.Padding(5);
            this.txtHandleDesc.Radius = 10;
            this.txtHandleDesc.Size = new System.Drawing.Size(984, 185);
            this.txtHandleDesc.StyleCustomMode = true;
            this.txtHandleDesc.TabIndex = 8;
            this.txtHandleDesc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.txtHandleDesc, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.txtFaultDesc, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 143);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(992, 445);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.uiLabel5);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(134, 29);
            this.panel2.TabIndex = 6;
            // 
            // txtFaultDesc
            // 
            this.txtFaultDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFaultDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFaultDesc.FillColor = System.Drawing.Color.White;
            this.txtFaultDesc.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtFaultDesc.Location = new System.Drawing.Point(4, 42);
            this.txtFaultDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFaultDesc.Maximum = 2147483647D;
            this.txtFaultDesc.Minimum = -2147483648D;
            this.txtFaultDesc.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtFaultDesc.Multiline = true;
            this.txtFaultDesc.Name = "txtFaultDesc";
            this.txtFaultDesc.Padding = new System.Windows.Forms.Padding(5);
            this.txtFaultDesc.Radius = 10;
            this.txtFaultDesc.Size = new System.Drawing.Size(984, 167);
            this.txtFaultDesc.StyleCustomMode = true;
            this.txtFaultDesc.TabIndex = 7;
            this.txtFaultDesc.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.68396F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.20853F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.84834F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.37915F));
            this.tableLayoutPanel3.Controls.Add(this.uiLabel4, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.uiLabel3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.uiLabel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtDealOperator, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbCallNo, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.cmbStationNo, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtExceptionType, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.uiLabel1, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(992, 84);
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
            this.tableLayoutPanel1.Controls.Add(this.uiLabel7, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 451F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(998, 638);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // FrmFaultHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 638);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmFaultHandle";
            this.Text = "异常呼叫处理";
            this.Load += new System.EventHandler(this.FrmFaultHandle_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UISymbolButton btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Sunny.UI.UISymbolButton btnHandleResult;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox txtDealOperator;
        private Sunny.UI.UIComboBox cmbCallNo;
        private Sunny.UI.UIComboBox cmbStationNo;
        private Sunny.UI.UITextBox txtExceptionType;
        private Sunny.UI.UILabel uiLabel6;
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtHandleDesc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel2;
        private Sunny.UI.UITextBox txtFaultDesc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}