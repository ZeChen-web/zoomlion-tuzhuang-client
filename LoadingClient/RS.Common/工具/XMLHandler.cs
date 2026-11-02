using System;
using System.IO;
using System.Xml.Serialization;

namespace RS.Common
{
    /// <summary>
    /// Xml序列化与反序列化
    /// </summary>
    public class XSerializer
    {
        #region 反序列化

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                // 返回异常
                throw new Exception(e.Message.ToString());
            }
        }

        /// <summary>
        /// 数据流反序列化
        /// </summary>
        /// <param name="type"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }

        #endregion 反序列化

        #region 序列化

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer<T>(T t)
        {
            using (StringWriter sw = new StringWriter())

            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                XmlSerializer xz = new XmlSerializer(t.GetType());

                xz.Serialize(sw, t, ns);

                return sw.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n", "").Replace("\r\n", "").Replace("  ", "");
            }
        }

        #endregion 序列化
    }
}