using RS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadingClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 汉化服务
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.DoEvents();
            PublicParams.G_OperatorInfo = null;
            FrmClientLogin frmLogin = new FrmClientLogin();
            DialogResult result = DialogResult.OK;
            while (result == DialogResult.OK)
            {
                result = DialogResult.Cancel;
                if (frmLogin.ShowDialog() == DialogResult.OK)
                {
                    if (PublicParams.G_StationInfoList != null)
                    {
                        if (PublicParams.G_StationInfoList.Count == 1)
                        {
                            //FrmOneStationSpotWeldClient frmMain = new FrmOneStationSpotWeldClient();
                            //frmMain.ShowDialog();
                            FrmLoadingClient frmMain = new FrmLoadingClient();
                            ucOneStationWeldClient frmOneStationWeldClient = new ucOneStationWeldClient();
                            frmMain.plMain.Controls.Clear();
                            frmMain.plMain.Controls.Add(frmOneStationWeldClient);
                            frmMain.plMain.Show();
                            frmMain.ShowDialog();
                        }
                        else if (PublicParams.G_StationInfoList.Count == 2)
                        {
                            //FrmTwoStationSpotWeldClient frmMain = new FrmTwoStationSpotWeldClient();
                            //frmMain.ShowDialog();
                            FrmLoadingClient frmMain = new FrmLoadingClient();
                            ucOneStationWeldClient frmOneStationWeldClient = new ucOneStationWeldClient();
                            frmMain.plMain.Controls.Clear();
                            frmMain.plMain.Controls.Add(frmOneStationWeldClient);
                            frmMain.plMain.Show();
                            frmMain.ShowDialog();
                        }
                        else if (PublicParams.G_StationInfoList.Count == 3)
                        {
                            //FrmThreeStationSpotWeldClient frmMain = new FrmThreeStationSpotWeldClient();
                            //frmMain.ShowDialog();
                        }
                    }
                }
                else
                    Application.Exit();
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FrmLoadingClient());
        }
    }
}
