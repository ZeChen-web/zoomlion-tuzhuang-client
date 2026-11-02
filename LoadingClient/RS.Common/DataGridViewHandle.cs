using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace RS.Common
{
    /// <summary>
    /// 定义DataGrid显示
    /// </summary>
    public class DataGridField
    {
        /// <summary>
        /// 数据属性名
        /// </summary>
        public string DataPropertyName { get; set; }
        /// <summary>
        /// 标题文本
        /// </summary>
        public string HeaderText { get; set; }
        /// <summary>
        /// 宽
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 可见
        /// </summary>
        public bool Visible { get; set; }
    }

    public class CboItemEntity
    {
        /// <summary>
        /// 显示值
        /// </summary>
        public object Text { get; set; }

        /// <summary>
        /// 对象值
        /// </summary>
        public object Value { get; set; }
        public override string ToString()
        {
            return this.Text.ToString();
        }

    }
    public class ColumsFormat
    {
        public string FiledValue { get; set; }

        public List<CboItemEntity> Format { get; set; }
    }
    public class DataGridViewHandle
    {
        public List<DataGridField> _Fields = new List<DataGridField>();
        public List<ColumsFormat> _Formats = new List<ColumsFormat>();
        public DataGridView _dbgrid;
        public int _rowHandle = 0;
        public ToolStripComboBox _queryField_combox;
        public bool _setRow = false;

        /// <summary>
        /// 生成DataGridView基础设置
        /// </summary>
        /// <param name="RValueGridView">DataGridView实例</param>
        public void GenerateBaseDataGridView()
        {
            //列标题单元格的应用样式
            DataGridViewCellStyle ColumnHeadCellStyle = new DataGridViewCellStyle();
            ColumnHeadCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ColumnHeadCellStyle.BackColor = System.Drawing.Color.FromArgb(80, 160, 255);//System.Drawing.Color.Black;
            ColumnHeadCellStyle.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            ColumnHeadCellStyle.ForeColor = System.Drawing.Color.White;//System.Drawing.Color.DarkSlateBlue;
            ColumnHeadCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            ColumnHeadCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            ColumnHeadCellStyle.WrapMode = DataGridViewTriState.True;

            _dbgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;  //EnableResizing
            _dbgrid.ColumnHeadersHeight = 28;
            _dbgrid.ColumnHeadersDefaultCellStyle = ColumnHeadCellStyle;

            //DataGridView背景色
            _dbgrid.BackgroundColor = System.Drawing.Color.FromArgb(240, 240, 240);
            _dbgrid.AllowUserToResizeColumns = true;

            //设置列宽-自适应布满页面
            _dbgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dbgrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            //设置行标题不显示
            _dbgrid.RowHeadersVisible = false;
            _dbgrid.AllowUserToAddRows = false;  //消除最下面空行
            _dbgrid.AutoGenerateColumns = false;

            //行单元格的应用样式
            DataGridViewCellStyle RowDefaultCellStyle = new DataGridViewCellStyle();
            RowDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RowDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            RowDefaultCellStyle.ForeColor = System.Drawing.Color.Navy;
            RowDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            _dbgrid.RowsDefaultCellStyle = RowDefaultCellStyle;

            DataGridViewCellStyle DefaultCellStyle = new DataGridViewCellStyle();
            DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 192, 192);
            _dbgrid.RowTemplate.DefaultCellStyle = DefaultCellStyle;
            //奇数行颜色设置
            _dbgrid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 250, 225);


            #region 行模板

            //行分隔符高度
            _dbgrid.RowTemplate.DividerHeight = 1;
            //行高度
            _dbgrid.RowTemplate.Height = 28;

            #endregion 行模板

            #region  grid行各列显示
            foreach (DataGridField dg in _Fields)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = dg.DataPropertyName;
                col.HeaderText = dg.HeaderText;
                col.Visible = dg.Visible;
                col.Width = dg.Width;
                col.FillWeight = 10;
                col.ReadOnly = true;
                _dbgrid.Columns.Add(col);
                if (dg.Visible && _queryField_combox != null)
                {
                    CboItemEntity item = new CboItemEntity();
                    item.Text = dg.HeaderText;
                    item.Value = dg.DataPropertyName;
                    _queryField_combox.Items.Add(item);
                }
            }
            #endregion

            _dbgrid.CellFormatting += DataGridView_CellFormatting;
            _dbgrid.CellMouseDown += DataGridView__CellMouseDown;
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (ColumsFormat fm in _Formats)
            {
                if (fm.FiledValue == _dbgrid.Columns[e.ColumnIndex].DataPropertyName)
                {
                    foreach (CboItemEntity cim in fm.Format)
                    {
                        if (e.Value.ToString() == cim.Value.ToString())
                        {
                            e.Value = cim.Text;
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void DataGridView__CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _rowHandle = e.RowIndex;
        }

        public void RowSelected()
        {
            if (_rowHandle < _dbgrid.Rows.Count)
            {
                if (_rowHandle >= 0)
                {
                    _setRow = true;
                    _dbgrid.Rows[_rowHandle].Selected = true;
                    _setRow = false;
                }
            }
        }

        public DataRow GetDataRow()
        {
            if (_rowHandle < 0 || _rowHandle >= _dbgrid.Rows.Count) return null;
            if (_setRow)
                return (_dbgrid.Rows[_rowHandle].DataBoundItem as DataRowView).Row;
            else
                return (_dbgrid.CurrentRow.DataBoundItem as DataRowView).Row;
        }

    }
}
