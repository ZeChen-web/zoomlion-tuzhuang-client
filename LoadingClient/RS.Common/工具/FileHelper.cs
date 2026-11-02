using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RS.Common
{
    public class FileHelper
    {
        /// <summary>
        /// 寻找文件夹下的扩展名相同的文件名列表
        /// </summary>
        /// <param name="srcStrPathFolder">文件夹路径</param>
        /// <param name="fileExName">扩展名</param>
        /// <returns></returns>
        public List<string> GetFileNamesByFolderPath(string srcStrPathFolder,string fileExName)
        {
            List<string> lstFileName = null;

            try
            {
                if (Directory.Exists(srcStrPathFolder))   //判断本地是否存在该文件夹
                {
                    //得到文件
                    string[] fileNames = Directory.GetFiles(srcStrPathFolder);
                    if (fileNames != null)
                    {
                        lstFileName = new List<string>();
                        foreach (string file in fileNames)//循环文件
                        {
                            if (file.Trim() != "")
                            {
                                string exname = file.Substring(file.LastIndexOf(".") + 1);//得到后缀名

                                if (fileExName.IndexOf(exname) <= 0)//如果后缀名为.扩展名文件
                                {
                                    lstFileName.Add(file);//把.txt文件全名加人到FileInfo对象
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return lstFileName;
        }



    }
}
