using Newtonsoft.Json;
using RS.BLL;
using RS.Model;
using RS.RealTimeDBO;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LoadingClient
{
    public partial class FrmCacheInfoOut1 : Form
    {
        UIPage uiPage = new UIPage();
        BCacheOut bCacheOut = new BCacheOut();
        RedisHelper rdsReal = new RedisHelper(10); //指定连接的库，默认是10
        string strRedisKeyRealValue1 = "YunTongColCache1";//存储缓存板链
        List<JsonMaterialInfo> cacheJsonMaterialInfos1 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos2 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos3 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos4 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos5 = new List<JsonMaterialInfo>();
        List<List<JsonMaterialInfo>> cacheJsonMaterialInfos = new List<List<JsonMaterialInfo>>();

        string xc_id = null;
        string whether = "1";
        string cache_area = "1";
        string aisle = null;
        Dictionary<string,int> keyValuePairs = new Dictionary<string,int>();

        public FrmCacheInfoOut1()
        {
            InitializeComponent();
        }

        private void FrmCacheInfoOut1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            addMaterial();
        }
        /// <summary>
        /// 添加出库顺序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoice_Click(object sender, EventArgs e)
        {
            MCacheOut mCacheOut = new MCacheOut();
            mCacheOut.xc_id = this.xc_id;
            mCacheOut.whether = "1";
            mCacheOut.cache_area = this.cache_area;
            mCacheOut.aisle = this.aisle;
            mCacheOut.type = "1";
            mCacheOut.time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (!bCacheOut.WhietherInCacheOut(mCacheOut))
            {
                bool bSet=bCacheOut.InsertCacheOut(mCacheOut);
                if (bSet)
                {
                    uiPage.ShowSuccessNotifier("设置成功!");
                    addMaterial();
                }
            }
            else
            {
                uiPage.ShowErrorDialog("当前工件已经设置了出库顺序!");
            }
        }
        /// <summary>
        /// 删除出库顺序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            MCacheOut mCacheOut = new MCacheOut();
            mCacheOut.xc_id = this.xc_id;
            mCacheOut.whether = "3";
            mCacheOut.cache_area = this.cache_area;
            mCacheOut.aisle = this.aisle;
            mCacheOut.type = "2";
            mCacheOut.time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (bCacheOut.WhietherInCacheOut(mCacheOut))
            {
                bool bSet = bCacheOut.DeleteCacheOut(mCacheOut);
                if (bSet)
                {
                    uiPage.ShowSuccessNotifier("删除成功!");
                    addMaterial();
                }
            }
            else
            {
                uiPage.ShowErrorDialog("当前工件还未设置了出库顺序!");
            }
        }
        /// <summary>
        /// 倒库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            MCacheOut mCacheOut = new MCacheOut();
            mCacheOut.xc_id = this.xc_id;
            mCacheOut.whether = "1";
            mCacheOut.cache_area = this.cache_area;
            mCacheOut.aisle = this.aisle;
            mCacheOut.type = "2";
            mCacheOut.time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (!bCacheOut.WhietherInCacheOut(mCacheOut))
            {
                bool bSet = bCacheOut.InsertCacheOut(mCacheOut);
                if (bSet)
                {
                    uiPage.ShowSuccessNotifier("设置成功!");
                    addMaterial();
                }
                else
                {
                    uiPage.ShowSuccessNotifier("失败!");
                }
            }
            else
            {
                uiPage.ShowErrorDialog("当前工件已经设置了出库顺序!");
            }
        }

        void addMaterial()
        {
            #region 清空文字信息

            MaterialInfo1_0.Text = null;
            MaterialInfo1_1.Text = null;
            MaterialInfo1_2.Text = null;
            MaterialInfo1_3.Text = null;
            MaterialInfo1_4.Text = null;
            MaterialInfo1_5.Text = null;
            MaterialInfo1_6.Text = null;
            MaterialInfo1_7.Text = null;
            MaterialInfo1_8.Text = null;
            MaterialInfo1_9.Text = null;

            MaterialInfo2_0.Text = null;
            MaterialInfo2_1.Text = null;
            MaterialInfo2_2.Text = null;
            MaterialInfo2_3.Text = null;
            MaterialInfo2_4.Text = null;
            MaterialInfo2_5.Text = null;
            MaterialInfo2_6.Text = null;
            MaterialInfo2_7.Text = null;
            MaterialInfo2_8.Text = null;
            MaterialInfo2_9.Text = null;

            MaterialInfo3_0.Text = null;
            MaterialInfo3_1.Text = null;
            MaterialInfo3_2.Text = null;
            MaterialInfo3_3.Text = null;
            MaterialInfo3_4.Text = null;
            MaterialInfo3_5.Text = null;
            MaterialInfo3_6.Text = null;
            MaterialInfo3_7.Text = null;
            MaterialInfo3_8.Text = null;
            MaterialInfo3_9.Text = null;

            MaterialInfo4_0.Text = null;
            MaterialInfo4_1.Text = null;
            MaterialInfo4_2.Text = null;
            MaterialInfo4_3.Text = null;
            MaterialInfo4_4.Text = null;
            MaterialInfo4_5.Text = null;
            MaterialInfo4_6.Text = null;
            MaterialInfo4_7.Text = null;
            MaterialInfo4_8.Text = null;
            MaterialInfo4_9.Text = null;

            MaterialInfo5_0.Text = null;
            MaterialInfo5_1.Text = null;
            MaterialInfo5_2.Text = null;
            MaterialInfo5_3.Text = null;
            MaterialInfo5_4.Text = null;
            MaterialInfo5_5.Text = null;
            MaterialInfo5_6.Text = null;
            MaterialInfo5_7.Text = null;
            MaterialInfo5_8.Text = null;
            MaterialInfo5_9.Text = null;

            #endregion 清空文字信息

            #region 按钮按下
            MaterialInfo1_0.Enabled = false;
            MaterialInfo1_1.Enabled = false;
            MaterialInfo1_2.Enabled = false;
            MaterialInfo1_3.Enabled = false;
            MaterialInfo1_4.Enabled = false;
            MaterialInfo1_5.Enabled = false;
            MaterialInfo1_6.Enabled = false;
            MaterialInfo1_7.Enabled = false;
            MaterialInfo1_8.Enabled = false;
            MaterialInfo1_9.Enabled = false;

            MaterialInfo2_0.Enabled = false;
            MaterialInfo2_1.Enabled = false;
            MaterialInfo2_2.Enabled = false;
            MaterialInfo2_3.Enabled = false;
            MaterialInfo2_4.Enabled = false;
            MaterialInfo2_5.Enabled = false;
            MaterialInfo2_6.Enabled = false;
            MaterialInfo2_7.Enabled = false;
            MaterialInfo2_8.Enabled = false;
            MaterialInfo2_9.Enabled = false;

            MaterialInfo3_0.Enabled = false;
            MaterialInfo3_1.Enabled = false;
            MaterialInfo3_2.Enabled = false;
            MaterialInfo3_3.Enabled = false;
            MaterialInfo3_4.Enabled = false;
            MaterialInfo3_5.Enabled = false;
            MaterialInfo3_6.Enabled = false;
            MaterialInfo3_7.Enabled = false;
            MaterialInfo3_8.Enabled = false;
            MaterialInfo3_9.Enabled = false;

            MaterialInfo4_0.Enabled = false;
            MaterialInfo4_1.Enabled = false;
            MaterialInfo4_2.Enabled = false;
            MaterialInfo4_3.Enabled = false;
            MaterialInfo4_4.Enabled = false;
            MaterialInfo4_5.Enabled = false;
            MaterialInfo4_6.Enabled = false;
            MaterialInfo4_7.Enabled = false;
            MaterialInfo4_8.Enabled = false;
            MaterialInfo4_9.Enabled = false;

            MaterialInfo5_0.Enabled = false;
            MaterialInfo5_1.Enabled = false;
            MaterialInfo5_2.Enabled = false;
            MaterialInfo5_3.Enabled = false;
            MaterialInfo5_4.Enabled = false;
            MaterialInfo5_5.Enabled = false;
            MaterialInfo5_6.Enabled = false;
            MaterialInfo5_7.Enabled = false;
            MaterialInfo5_8.Enabled = false;
            MaterialInfo5_9.Enabled = false;

            #endregion 

            keyValuePairs = bCacheOut.xc_id_seq("1");

            string strJsonArmCacheRealValue = rdsReal.GetStrValue(strRedisKeyRealValue1);
            if (!string.IsNullOrEmpty(strJsonArmCacheRealValue))
            {
                cacheJsonMaterialInfos = JsonConvert.DeserializeObject<List<List<JsonMaterialInfo>>>(strJsonArmCacheRealValue);
                if (cacheJsonMaterialInfos.Count >= 5)
                {
                    cacheJsonMaterialInfos1 = cacheJsonMaterialInfos[0];
                    cacheJsonMaterialInfos2 = cacheJsonMaterialInfos[1];
                    cacheJsonMaterialInfos3 = cacheJsonMaterialInfos[2];
                    cacheJsonMaterialInfos4 = cacheJsonMaterialInfos[3];
                    cacheJsonMaterialInfos5 = cacheJsonMaterialInfos[4];
                }
            }

            #region 判断小车号是否重复或者空

            List<string> strings = new List<string>();

            if (cacheJsonMaterialInfos1 != null && cacheJsonMaterialInfos1.Count > 0)
            {
                for (int i = 0; i < cacheJsonMaterialInfos1.Count; i++)
                {
                    if (i > 9) break;
                    JsonMaterialInfo JsonMaterialInfo = cacheJsonMaterialInfos1[i];
                    string btn = "MaterialInfo1_" + i;
                    object obj = this.GetType().GetField(btn, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    UIButton uIButton = (UIButton)obj;
                    uIButton.Enabled = true;
                    if (string.IsNullOrEmpty(JsonMaterialInfo.SlingNo) || strings.Contains(JsonMaterialInfo.SlingNo))
                    {
                        uiPage.ShowErrorDialog("有空小车号或者重复小车号，请先修改！");
                        this.Close();
                        return;
                    }
                    else
                    {
                        strings.Add(JsonMaterialInfo.SlingNo);
                        if (keyValuePairs !=null && (keyValuePairs.ContainsKey(JsonMaterialInfo.SlingNo)))
                            uIButton.Text = JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode + "\n" + keyValuePairs[JsonMaterialInfo.SlingNo];
                        else
                            uIButton.Text = JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                    }
                }
            }
            if (cacheJsonMaterialInfos2 != null && cacheJsonMaterialInfos2.Count > 0)
            {
                for (int i = 0; i < cacheJsonMaterialInfos2.Count; i++)
                {
                    if (i > 9) break;
                    JsonMaterialInfo JsonMaterialInfo = cacheJsonMaterialInfos2[i];
                    string btn = "MaterialInfo2_" + i;
                    object obj = this.GetType().GetField(btn, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    UIButton uIButton = (UIButton)obj;
                    uIButton.Enabled = true;
                    if (string.IsNullOrEmpty(JsonMaterialInfo.SlingNo) || strings.Contains(JsonMaterialInfo.SlingNo))
                    {
                        uiPage.ShowErrorDialog("有空小车号或者重复小车号，请先修改！");
                        this.Close();
                        return;
                    }
                    else
                    {
                        strings.Add(JsonMaterialInfo.SlingNo);
                        if (keyValuePairs != null && (keyValuePairs.ContainsKey(JsonMaterialInfo.SlingNo)))
                            uIButton.Text = JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode + "\n" + keyValuePairs[JsonMaterialInfo.SlingNo];
                        else
                            uIButton.Text = JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                    }
                }
            }
            if (cacheJsonMaterialInfos3 != null && cacheJsonMaterialInfos3.Count > 0)
            {
                for (int i = 0; i < cacheJsonMaterialInfos3.Count; i++)
                {
                    if (i > 9) break;
                    JsonMaterialInfo JsonMaterialInfo = cacheJsonMaterialInfos3[i];
                    string btn = "MaterialInfo3_" + i;
                    object obj = this.GetType().GetField(btn, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    UIButton uIButton = (UIButton)obj;
                    uIButton.Enabled = true;
                    if (string.IsNullOrEmpty(JsonMaterialInfo.SlingNo) || strings.Contains(JsonMaterialInfo.SlingNo))
                    {
                        uiPage.ShowErrorDialog("有空小车号或者重复小车号，请先修改！");
                        this.Close();
                        return;
                    }
                    else
                    {
                        strings.Add(JsonMaterialInfo.SlingNo);
                        if (keyValuePairs != null && (keyValuePairs.ContainsKey(JsonMaterialInfo.SlingNo)))
                            uIButton.Text = JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode + "\n" + keyValuePairs[JsonMaterialInfo.SlingNo];
                        else
                            uIButton.Text = JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                    }
                }
            }
            if (cacheJsonMaterialInfos4 != null && cacheJsonMaterialInfos4.Count > 0)
            {
                for (int i = 0; i < cacheJsonMaterialInfos4.Count; i++)
                {
                    if (i > 9) break;
                    JsonMaterialInfo JsonMaterialInfo = cacheJsonMaterialInfos4[i];
                    string btn = "MaterialInfo4_" + i;
                    object obj = this.GetType().GetField(btn, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    UIButton uIButton = (UIButton)obj;
                    uIButton.Enabled = true;
                    if (string.IsNullOrEmpty(JsonMaterialInfo.SlingNo) || strings.Contains(JsonMaterialInfo.SlingNo))
                    {
                        uiPage.ShowErrorDialog("有空小车号或者重复小车号，请先修改！");
                        this.Close();
                        return;
                    }
                    else
                    {
                        strings.Add(JsonMaterialInfo.SlingNo);
                        if (keyValuePairs != null && (keyValuePairs.ContainsKey(JsonMaterialInfo.SlingNo)))
                            uIButton.Text = JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode + "\n" + keyValuePairs[JsonMaterialInfo.SlingNo];
                        else
                            uIButton.Text = JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                    }
                }
            }

            #endregion 判断小车号是否重复或者空

        }

        #region 按钮功能

        private void MaterialInfo1_0_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo1_0.Text.Trim().Substring(0, 3);
            aisle = "0";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo1_1_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo1_1.Text.Trim().Substring(0, 3);
            aisle = "0"; 
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo1_2_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo1_2.Text.Trim().Substring(0, 3);
            aisle = "0";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo1_3_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo1_3.Text.Trim().Substring(0, 3);
            aisle = "0";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo1_4_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo1_4.Text.Trim().Substring(0, 3);
            aisle = "0";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo1_5_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo1_5.Text.Trim().Substring(0, 3);
            aisle = "0";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo1_6_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo1_6.Text.Trim().Substring(0, 3);
            aisle = "0";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo1_7_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo1_7.Text.Trim().Substring(0, 3);
            aisle = "0";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo1_8_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo1_8.Text.Trim().Substring(0, 3);
            aisle = "0";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo1_9_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo1_9.Text.Trim().Substring(0, 3);
            aisle = "0";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo2_0_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo2_0.Text.Trim().Substring(0, 3);
            aisle = "1";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo2_1_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo2_1.Text.Trim().Substring(0, 3);
            aisle = "1";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo2_2_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo2_2.Text.Trim().Substring(0, 3);
            aisle = "1";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo2_3_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo2_3.Text.Trim().Substring(0, 3);
            aisle = "1";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo2_4_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo2_4.Text.Trim().Substring(0, 3);
            aisle = "1";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo2_5_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo2_5.Text.Trim().Substring(0, 3);
            aisle = "1";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo2_6_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo2_6.Text.Trim().Substring(0, 3);
            aisle = "1";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo2_7_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo2_7.Text.Trim().Substring(0, 3);
            aisle = "1";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo2_8_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo2_8.Text.Trim().Substring(0, 3);
            aisle = "1";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo2_9_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo2_9.Text.Trim().Substring(0, 3);
            aisle = "1";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo3_0_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo3_0.Text.Trim().Substring(0, 3);
            aisle = "2";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo3_1_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo3_1.Text.Trim().Substring(0, 3);
            aisle = "2";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo3_2_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo3_2.Text.Trim().Substring(0, 3);
            aisle = "2";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo3_3_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo3_3.Text.Trim().Substring(0, 3);
            aisle = "2";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo3_4_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo3_4.Text.Trim().Substring(0, 3);
            aisle = "2";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo3_5_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo3_5.Text.Trim().Substring(0, 3);
            aisle = "2";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo3_6_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo3_6.Text.Trim().Substring(0, 3);
            aisle = "2";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo3_7_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo3_7.Text.Trim().Substring(0, 3);
            aisle = "2";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo3_8_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo3_8.Text.Trim().Substring(0, 3);
            aisle = "2";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo3_9_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo3_9.Text.Trim().Substring(0, 3);
            aisle = "2";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo4_0_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo4_0.Text.Trim().Substring(0, 3);
            aisle = "3";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo4_1_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo4_1.Text.Trim().Substring(0, 3);
            aisle = "3";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo4_2_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo4_2.Text.Trim().Substring(0, 3);
            aisle = "3";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo4_3_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo4_3.Text.Trim().Substring(0, 3);
            aisle = "3";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo4_4_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo4_4.Text.Trim().Substring(0, 3);
            aisle = "3";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo4_5_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo4_5.Text.Trim().Substring(0, 3);
            aisle = "3";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo4_6_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo4_6.Text.Trim().Substring(0, 3);
            aisle = "3";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo4_7_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo4_7.Text.Trim().Substring(0, 3);
            aisle = "3";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo4_8_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo4_8.Text.Trim().Substring(0, 3);
            aisle = "3";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }

        private void MaterialInfo4_9_Click(object sender, EventArgs e)
        {
            xc_id = MaterialInfo4_9.Text.Trim().Substring(0, 3);
            aisle = "3";
            uiPage.ShowSuccessTip("已选择小车号" + xc_id);
        }
        #endregion 按钮功能

        private void btnHandleResult_Click(object sender, EventArgs e)
        {
            addMaterial();
        }
    }
}
