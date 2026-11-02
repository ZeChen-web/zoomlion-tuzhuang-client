using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Common
{
    public class ByteConvert
    {
        /// <summary>
        /// 十六进制字符串转字符串
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static string StrHex2Str(string strHex)
        {
            byte[] keyWord = new byte[strHex.Length / 2];
            string strResult = "";
            for (int i = 0; i < keyWord.Length; i++)
            {
                try
                {
                    keyWord[i] = (byte)(0xff & Convert.ToInt32(strHex.Substring(i * 2, 2), 16));
                    strResult += Convert.ToChar(keyWord[i]).ToString();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return strResult;
        }

        /// <summary>
        /// 字符串转16进制字符串
        /// </summary>
        /// <param name="strSrc"></param>
        /// <returns></returns>
        public static string Str2HexStr(string strSrc)
        {
            char[] chTemp = strSrc.ToCharArray();
            string strResult = "";
            foreach (var ch in chTemp)
            {
                int value = Convert.ToInt32(ch);
                strResult += String.Format("{0:X}", value);
            }
            strResult = "6000" + strResult; //写入48位数据
            return strResult;
        }

        /// <summary>
        /// 获取16进制字符串的字节数组
        /// </summary>
        /// <param name="hexString">hexString 16进制字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] ToByteByHexStr(string hexString)
        {
            if (hexString == null)
                return null;

            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }


        /// <summary>
        /// 根据高位优先的原理的两字节数据解析返回一个16为无符号整数
        /// </summary>
        /// <param name="value">原字节数组(含有两字节）</param>
        /// <returns>返回无符号整数</returns>
        public static ushort ToUInt16(byte[] value)
        {
            return (ushort)((value[0] << 8) | (value[1] & 0x00FF));
        }

        /// <summary>
        /// 根据高位优先的原理的两字节数据解析返回一个16为无符号整数
        /// </summary>
        /// <param name="value">原字节数组</param>
        /// <param name="offset">缓冲区偏移</param>
        /// <returns>返回无符号整数</returns>
        public static ushort ToUInt16(byte[] value, int offset)
        {
            return (ushort)((value[offset] << 8) | (value[offset + 1] & 0x00FF));
        }

        /// <summary>
        /// 16进制数高地位对调
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] Int16ToByteArray(Int16 value)   //16进制数高地位对调
        {
            byte[] bytesResult = new byte[2];
            byte[] temp = new byte[2];

            BitConverter.GetBytes(Convert.ToInt16(value)).CopyTo(temp, 0);

            bytesResult[0] = temp[1];
            bytesResult[1] = temp[0];

            return bytesResult;
        }


    }
}
