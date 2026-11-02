using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RS.Common
{
    /// <summary>
    /// 图片对象比较、缩放、缩略图、水印、压缩、转换、编码等操作辅助类
    /// </summary>
    public class ImageHelper
    {
        #region 图片转换

        /// <summary>
        /// 转换成一个字节数组中指定的 <see cref="System.Drawing.Image"/> into an array of bytes
        /// </summary>
        /// <param name="image"><see cref="System.Drawing.Image"/></param>
        /// <returns>字节数组</returns>
        public static byte[] ImageToBytes(System.Drawing.Image image)
        {
            byte[] bytes = null;
            if (image != null)
            {
                lock (image)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    using (ms)
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        bytes = ms.GetBuffer();
                    }
                }
            }
            return bytes;
        }

        /// <summary>
        /// 转换成一个字节数组 <see cref="System.Drawing.Image"/>
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>由此产生的<see cref="System.Drawing.Image"/></returns>
        public static System.Drawing.Image ImageFromBytes(byte[] bytes)
        {
            System.Drawing.Image image = null;
            try
            {
                if (bytes != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes, false);
                    using (ms)
                    {
                        image = ImageFromStream(ms);
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return image;
        }

        /// <summary>
        /// 转换成一个URL（文件系统或网络）<see cref="System.Drawing.Image"/>
        /// </summary>
        /// <param name="url">图像的URL路径</param>
        /// <returns>由此产生的 <see cref="System.Drawing.Image"/></returns>
        public static System.Drawing.Image ImageFromUrl(string url)
        {
            System.Drawing.Image image = null;
            try
            {
                if (!String.IsNullOrEmpty(url))
                {
                    Uri uri = new Uri(url);
                    if (uri.IsFile)
                    {
                        System.IO.FileStream fs = new System.IO.FileStream(uri.LocalPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                        using (fs)
                        {
                            image = ImageFromStream(fs);
                        }
                    }
                    else
                    {
                        System.Net.WebClient wc = new System.Net.WebClient();  
                        using (wc)
                        {
                            byte[] bytes = wc.DownloadData(uri);
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes, false);
                            using (ms)
                            {
                                image = ImageFromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return image;
        }

        /// <summary>
        /// 流转换为图片
        /// </summary>
        private static System.Drawing.Image ImageFromStream(System.IO.Stream stream)
        {
            System.Drawing.Image image = null;
            try
            {
                stream.Position = 0;
                System.Drawing.Image tempImage = System.Drawing.Bitmap.FromStream(stream);
                // 但不要关闭流，首先要创建一个副本
                using (tempImage)
                {
                    image = new Bitmap(tempImage);
                }
            }
            catch
            {
                // 该文件可能是由Image类可用。ico文件，所以尝试，以防万一
                try
                {
                    stream.Position = 0;
                    Icon icon = new Icon(stream);
                    if (icon != null) image = icon.ToBitmap();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return image;
        }

        #endregion 图片转换
    }
}