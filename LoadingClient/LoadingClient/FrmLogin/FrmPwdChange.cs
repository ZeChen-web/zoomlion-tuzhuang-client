using RS.BLL;
using RS.Common;
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
    public partial class FrmPwdChange : Form
    {
        UIPage uiPage = new UIPage();
        public FrmPwdChange()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 验证输入密码信息
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (txtOldPwd.Text.Trim() == "")
            {
                this.loginError.SetError(txtOldPwd, "原密码不允许为空");
                return false;
            }
            else
            {
                this.loginError.SetError(txtOldPwd, "");
            }

            if (txtNewPwd.Text.Trim() == "")
            {
                this.loginError.SetError(txtNewPwd, "新密码不允许为空！");
                this.txtNewPwd.Focus();
                this.txtNewPwd.SelectAll();
                return false;
            }
            else
            {
                this.loginError.SetError(txtNewPwd, "");
            }

            if (txtVerifyNewPwd.Text.Trim() == "")
            {
                this.loginError.SetError(txtNewPwd, "确认密码不允许为空！");
                this.txtVerifyNewPwd.Focus();
                this.txtVerifyNewPwd.SelectAll();
                return false;
            }
            else
            {
                this.loginError.SetError(txtVerifyNewPwd, "");
            }

            return true;
        }
        /// <summary>
        /// 确认修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;

            string oldPwd = txtOldPwd.Text.Trim();
            string newPwd = txtNewPwd.Text.Trim();
            string verifyNewPwd = txtVerifyNewPwd.Text.Trim();
            string md5OldPwd = Md5Util.Encrypt(oldPwd);
            if (md5OldPwd == PublicParams.G_OperatorInfo.F_OPERATORPWD.Trim())
            {
                if (newPwd == verifyNewPwd)
                {
                    string md5VarifyNewPwd = Md5Util.Encrypt(verifyNewPwd);
                    string loggingCard = PublicParams.G_OperatorInfo.F_LOGGINGCARD;
                    PublicParams.G_OperatorInfo.F_OPERATORPWD = md5VarifyNewPwd;

                    BPMOperatorInfo dalOperatorInfo = new BPMOperatorInfo();  //操作员基础信息查询类  
                    bool bEdit = dalOperatorInfo.EditOperatorInfo(PublicParams.G_OperatorInfo);
                    if (!bEdit)
                    {
                        PublicParams.G_OperatorInfo.F_OPERATORPWD = md5OldPwd;
                    }
                    else
                    {
                        uiPage.ShowSuccessTip("用户密码更新成功！");
                    }


                    this.Close();
                }
            }
            else
            {
                uiPage.ShowErrorDialog("原密码错误，请重新输入！");
                this.loginError.SetError(txtOldPwd, "");
            }
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
