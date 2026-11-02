namespace RS.Common
{
    /// <summary>
    /// ModuleBus CRC校验帮助类
    /// </summary>
    public class CRCHelper
    {
        /// <summary>
        /// 计算命令行的CRC16校验码
        /// </summary>
        /// <param name="data">命令行</param>
        /// <returns>CRC[L,H]</returns>
        public static byte[] crc16(byte[] data)
        {
            //常数
            int Const = 0xa001;
            //设置CRC寄存器初始值
            int crc = 0xffff;
            for (int i = 0; i < data.Length; i++)
            {
                //CRC与命令字节异或
                crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((int)(crc & 0x1) == 1) //二进制末尾是1,进行右移和常数异或运算
                    {
                        crc >>= 1;
                        crc ^= Const;
                    }
                    else //二进制末尾为0,仅仅进行右移运算
                    {
                        crc >>= 1;
                    }
                }
            }
            byte[] result = new byte[2];
            result[0] = (byte)(crc & 0xFF);
            result[1] = (byte)(crc >> 8);
            return result;
        }

        /// <summary>
        /// 计算命令行的CRC16校验码
        /// </summary>
        /// <param name="data">命令行</param>
        /// <returns>CRC[L,H]</returns>
        public static byte[] addCrc16(byte[] data)
        {
            //常数
            int Const = 0xa001;
            //设置CRC寄存器初始值
            int crc = 0xffff;
            for (int i = 0; i < data.Length; i++)
            {
                //CRC与命令字节异或
                crc ^= data[i];
                for (int j = 0; j < 8; j++)
                {
                    if ((int)(crc & 0x1) == 1) //二进制末尾是1,进行右移和常数异或运算
                    {
                        crc >>= 1;
                        crc ^= Const;
                    }
                    else //二进制末尾为0,仅仅进行右移运算
                    {
                        crc >>= 1;
                    }
                }
            }
            byte[] result = new byte[data.Length + 2];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = data[i];
            }
            result[result.Length - 2] = (byte)(crc & 0xFF);
            result[result.Length - 1] = (byte)(crc >> 8);
            return result;
        }

        /// <summary>
        /// 检查命令行的校验码
        /// </summary>
        /// <param name="cmd">带校验码的命令行</param>
        /// <returns>true,false</returns>
        public static bool legalCrc(byte[] cmd)
        {
            byte[] cmddata = new byte[cmd.Length - 2];
            byte[] crc = { cmd[cmd.Length - 2], cmd[cmd.Length - 1] };
            for (int i = 0; i < cmd.Length - 2; i++)
            {
                cmddata[i] = cmd[i];
            }
            byte[] crctemp = crc16(cmddata);
            if (crctemp[0] == crc[0] && crctemp[1] == crc[1])
            {
                return true;
            }
            return false;
        }
    }
}