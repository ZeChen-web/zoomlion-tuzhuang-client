using System;
using System.Configuration;
using System.Xml;

namespace RS.Common
{
    /// <summary>
    /// XML操作公共类
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 获得App.xml配置内容
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetAppSettingsValue(string key)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return ConfigurationManager.AppSettings[key] ?? string.Empty;
        }

        /// <summary>
        /// 修改App.xml配置内容
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">程序配置文件缺失！</exception>
        public static bool UpdateAppSettings(string key, string value)
        {
            var _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!_config.HasFile)
            {
                throw new ArgumentException("程序配置文件缺失！");
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");
            XmlNode xNode;
            XmlElement xElemUID;
            xNode = xDoc.SelectSingleNode("//appSettings");
            xElemUID = (XmlElement)xNode.SelectSingleNode("//add[@key='" + key + "']");
            xElemUID.SetAttribute("value", value);
            xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
            return true;
        }
    }
}