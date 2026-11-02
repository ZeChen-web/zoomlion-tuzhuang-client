using RS.BLL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadingClient
{
    public partial class FrmMaterialSet : Form
    {
        int i01 = 0;
        int i02 = 0;
        int i03 = 0;
        int i18 = 0;

        int i04 = 0;
        int i05 = 0;
        int i06 = 0;
        int i07 = 0;
        int i08 = 0;
        int i09 = 0;

        int i10 = 0;
        int i11 = 0;
        int i12 = 0;
        int i13 = 0;

        int i14 = 0;
        int i15 = 0;
        int i16 = 0;
        int i17 = 0;

        string TZ01 = "TZ01";
        string TZ02 = "TZ02";
        string TC1 = "TC1%";
        string TC2 = "TC3%";
        string TC3 = "TC1%";
        string TC4 = "TC4%";

        List<string> tc_type1 = new List<string>();
        List<string> tc_type2 = new List<string>();
        List<string> tc_type3 = new List<string>();
        List<string> tc_type4 = new List<string>();

        BSpecifyToStore bSpecifyToStore = new BSpecifyToStore();
        UIPage UIPage = new UIPage();
        public FrmMaterialSet()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialSet_Load(object sender, EventArgs e)
        {
            tc_type1 = bSpecifyToStore.t_ts_cache_stop(TZ01, TC1);
            tc_type2 = bSpecifyToStore.t_ts_cache_stop(TZ01, TC2);
            tc_type3 = bSpecifyToStore.t_ts_cache_stop(TZ02, TC3);
            tc_type4 = bSpecifyToStore.t_ts_cache_stop(TZ02, TC4);

            #region 添加下拉
            
            DataTable dtNameAndCode1 = new DataTable();
            dtNameAndCode1.Columns.Add("ToAddrCode", typeof(string));
            dtNameAndCode1.Columns.Add("ToAddrName", typeof(string));
            dtNameAndCode1.Rows.Add("14", "动臂");
            dtNameAndCode1.Rows.Add("15", "斗杆");
            dtNameAndCode1.Rows.Add("00", "空吊具");

            DataTable dtNameAndCode2 = new DataTable();
            dtNameAndCode2.Columns.Add("ToAddrCode", typeof(string));
            dtNameAndCode2.Columns.Add("ToAddrName", typeof(string));
            dtNameAndCode2.Rows.Add("17", "履带");
            dtNameAndCode2.Rows.Add("07", "转台");
            dtNameAndCode2.Rows.Add("00", "空吊具");

            cacheBox1_1.DataSource = dtNameAndCode1;
            cacheBox1_1.DisplayMember = "ToAddrName";
            cacheBox1_1.ValueMember = "ToAddrCode";
            cacheBox1_1.SelectedIndex = 0;

            cacheBox1_2.DataSource = dtNameAndCode1;
            cacheBox1_2.DisplayMember = "ToAddrName";
            cacheBox1_2.ValueMember = "ToAddrCode";
            cacheBox1_2.SelectedIndex = 0;

            cacheBox1_3.DataSource = dtNameAndCode1;
            cacheBox1_3.DisplayMember = "ToAddrName";
            cacheBox1_3.ValueMember = "ToAddrCode";
            cacheBox1_3.SelectedIndex = 0;

            cacheBox1_4.DataSource = dtNameAndCode1;
            cacheBox1_4.DisplayMember = "ToAddrName";
            cacheBox1_4.ValueMember = "ToAddrCode";
            cacheBox1_4.SelectedIndex = 0;

            cacheBox2_1.DataSource = dtNameAndCode1;
            cacheBox2_1.DisplayMember = "ToAddrName";
            cacheBox2_1.ValueMember = "ToAddrCode";
            cacheBox2_1.SelectedIndex = 0;

            cacheBox2_2.DataSource = dtNameAndCode1;
            cacheBox2_2.DisplayMember = "ToAddrName";
            cacheBox2_2.ValueMember = "ToAddrCode";
            cacheBox2_2.SelectedIndex = 0;

            cacheBox2_3.DataSource = dtNameAndCode1;
            cacheBox2_3.DisplayMember = "ToAddrName";
            cacheBox2_3.ValueMember = "ToAddrCode";
            cacheBox2_3.SelectedIndex = 0;

            cacheBox2_4.DataSource = dtNameAndCode1;
            cacheBox2_4.DisplayMember = "ToAddrName";
            cacheBox2_4.ValueMember = "ToAddrCode";
            cacheBox2_4.SelectedIndex = 0;

            cacheBox2_5.DataSource = dtNameAndCode1;
            cacheBox2_5.DisplayMember = "ToAddrName";
            cacheBox2_5.ValueMember = "ToAddrCode";
            cacheBox2_5.SelectedIndex = 0;

            cacheBox2_6.DataSource = dtNameAndCode1;
            cacheBox2_6.DisplayMember = "ToAddrName";
            cacheBox2_6.ValueMember = "ToAddrCode";
            cacheBox2_6.SelectedIndex = 0;

            cacheBox3_1.DataSource = dtNameAndCode2;
            cacheBox3_1.DisplayMember = "ToAddrName";
            cacheBox3_1.ValueMember = "ToAddrCode";
            cacheBox3_1.SelectedIndex = 0;

            cacheBox3_2.DataSource = dtNameAndCode2;
            cacheBox3_2.DisplayMember = "ToAddrName";
            cacheBox3_2.ValueMember = "ToAddrCode";
            cacheBox3_2.SelectedIndex = 0;

            cacheBox3_3.DataSource = dtNameAndCode2;
            cacheBox3_3.DisplayMember = "ToAddrName";
            cacheBox3_3.ValueMember = "ToAddrCode";
            cacheBox3_3.SelectedIndex = 0;

            cacheBox3_4.DataSource = dtNameAndCode2;
            cacheBox3_4.DisplayMember = "ToAddrName";
            cacheBox3_4.ValueMember = "ToAddrCode";
            cacheBox3_4.SelectedIndex = 0;

            cacheBox4_1.DataSource = dtNameAndCode2;
            cacheBox4_1.DisplayMember = "ToAddrName";
            cacheBox4_1.ValueMember = "ToAddrCode";
            cacheBox4_1.SelectedIndex = 0;

            cacheBox4_2.DataSource = dtNameAndCode2;
            cacheBox4_2.DisplayMember = "ToAddrName";
            cacheBox4_2.ValueMember = "ToAddrCode";
            cacheBox4_2.SelectedIndex = 0;

            cacheBox4_3.DataSource = dtNameAndCode2;
            cacheBox4_3.DisplayMember = "ToAddrName";
            cacheBox4_3.ValueMember = "ToAddrCode";
            cacheBox4_3.SelectedIndex = 0;

            cacheBox4_4.DataSource = dtNameAndCode2;
            cacheBox4_4.DisplayMember = "ToAddrName";
            cacheBox4_4.ValueMember = "ToAddrCode";
            cacheBox4_4.SelectedIndex = 0;

            #endregion 添加下拉

            #region 赋值显示

            cacheBox1_1.SelectedValue = tc_type1[0];
            cacheBox1_2.SelectedValue = tc_type1[1];
            cacheBox1_3.SelectedValue = tc_type1[2];
            cacheBox1_4.SelectedValue = tc_type1[3];
            cacheBox2_1.SelectedValue = tc_type2[0];
            cacheBox2_2.SelectedValue = tc_type2[1];
            cacheBox2_3.SelectedValue = tc_type2[2];
            cacheBox2_4.SelectedValue = tc_type2[3];
            cacheBox2_5.SelectedValue = tc_type2[4];
            cacheBox2_6.SelectedValue = tc_type2[5];
            cacheBox3_1.SelectedValue = tc_type3[0];
            cacheBox3_2.SelectedValue = tc_type3[1];
            cacheBox3_3.SelectedValue = tc_type3[2];
            cacheBox3_4.SelectedValue = tc_type3[3];
            cacheBox4_1.SelectedValue = tc_type4[0];
            cacheBox4_2.SelectedValue = tc_type4[1];
            cacheBox4_3.SelectedValue = tc_type4[2];
            cacheBox4_4.SelectedValue = tc_type4[3];

            cacheBox1_1.Text = keyValuePairs[cacheBox1_1.SelectedValue.ToString()];
            cacheBox1_2.Text = keyValuePairs[cacheBox1_2.SelectedValue.ToString()];
            cacheBox1_3.Text = keyValuePairs[cacheBox1_3.SelectedValue.ToString()];
            cacheBox1_4.Text = keyValuePairs[cacheBox1_4.SelectedValue.ToString()];
            cacheBox2_1.Text = keyValuePairs[cacheBox2_1.SelectedValue.ToString()];
            cacheBox2_2.Text = keyValuePairs[cacheBox2_2.SelectedValue.ToString()];
            cacheBox2_3.Text = keyValuePairs[cacheBox2_3.SelectedValue.ToString()];
            cacheBox2_4.Text = keyValuePairs[cacheBox2_4.SelectedValue.ToString()];
            cacheBox2_5.Text = keyValuePairs[cacheBox2_5.SelectedValue.ToString()];
            cacheBox2_6.Text = keyValuePairs[cacheBox2_6.SelectedValue.ToString()];
            cacheBox3_1.Text = keyValuePairs[cacheBox3_1.SelectedValue.ToString()];
            cacheBox3_2.Text = keyValuePairs[cacheBox3_2.SelectedValue.ToString()];
            cacheBox3_3.Text = keyValuePairs[cacheBox3_3.SelectedValue.ToString()];
            cacheBox3_4.Text = keyValuePairs[cacheBox3_4.SelectedValue.ToString()];
            cacheBox4_1.Text = keyValuePairs[cacheBox4_1.SelectedValue.ToString()];
            cacheBox4_2.Text = keyValuePairs[cacheBox4_2.SelectedValue.ToString()];
            cacheBox4_3.Text = keyValuePairs[cacheBox4_3.SelectedValue.ToString()];
            cacheBox4_4.Text = keyValuePairs[cacheBox4_4.SelectedValue.ToString()];

            #endregion 赋值显示
        }

        #region 下拉按钮

        private void cacheBox1_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i01 < 3)
            {
                i01 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ01, "TC1-1", cacheBox1_1.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("TC1-1更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("TC1-1更改失败");
            }
        }

        private void cacheBox1_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i02 < 3)
            {
                i02 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ01, "TC1-2", cacheBox1_2.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("TC1-2更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("TC1-2更改失败");
            }
        }

        private void cacheBox1_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i03 < 3)
            {
                i03 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ01, "TC1-3", cacheBox1_3.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("TC1-3更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("TC1-3更改失败");
            }
        }

        private void cacheBox1_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i18 < 3)
            {
                i18 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ01, "TC1-4", cacheBox1_4.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("TC1-4更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("TC1-4更改失败");
            }
        }

        private void cacheBox2_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i04 < 3)
            {
                i04 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ01, "TC3-1", cacheBox2_1.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("TC3-1更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("TC3-1更改失败");
            }
        }

        private void cacheBox2_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i05 < 3)
            {
                i05 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ01, "TC3-2", cacheBox2_2.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("TC3-2更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("TC3-2更改失败");
            }
        }

        private void cacheBox2_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i06 < 3)
            {
                i06 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ01, "TC3-3", cacheBox2_3.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("TC3-3更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("TC3-3更改失败");
            }
        }

        private void cacheBox2_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i07 < 3)
            {
                i07 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ01, "TC3-4", cacheBox2_4.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("TC3-4更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("TC3-4更改失败");
            }
        }

        private void cacheBox2_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i08 < 3)
            {
                i08 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ01, "TC3-5", cacheBox2_5.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("TC3-5更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("TC3-5更改失败");
            }
        }

        private void cacheBox2_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i09 < 3)
            {
                i09 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ01, "TC3-6", cacheBox2_6.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("TC3-6更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("TC3-6更改失败");
            }
        }

        private void cacheBox3_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i10 < 3)
            {
                i10 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ02, "TC1-1", cacheBox3_1.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("更改失败");
            }
        }

        private void cacheBox3_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i11 < 3)
            {
                i11 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ02, "TC1-2", cacheBox3_2.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("更改失败");
            }
        }

        private void cacheBox3_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i12 < 3)
            {
                i12 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ02, "TC1-3", cacheBox3_3.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("更改失败");
            }
        }

        private void cacheBox3_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i13 < 3)
            {
                i13 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ02, "TC1-4", cacheBox3_4.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("更改失败");
            }
        }

        private void cacheBox4_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i14 < 3)
            {
                i14 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ02, "TC4-1", cacheBox4_1.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("更改失败");
            }
        }

        private void cacheBox4_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i15 < 3)
            {
                i15 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ02, "TC4-2", cacheBox4_2.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("更改失败");
            }
        }

        private void cacheBox4_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i16 < 3)
            {
                i16 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ02, "TC4-3", cacheBox4_3.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("更改失败");
            }
        }

        private void cacheBox4_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i17 < 3)
            {
                i17 += 1;
                return;
            }
            bool update = bSpecifyToStore.updateType(TZ02, "TC4-4", cacheBox4_4.SelectedValue.ToString());
            if (update)
            {
                UIPage.ShowSuccessDialog("更改成功");
            }
            else
            {
                UIPage.ShowErrorDialog("更改失败");
            }
        }

        #endregion 下拉按钮

        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
        {
            { "14","动臂" },
            { "15","斗杆"},
            { "17","履带"},
            { "07","转台"},
            { "00","空吊具"}
        };

    }
}
