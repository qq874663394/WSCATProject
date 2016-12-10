using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtility.Encrypt
{
    public class XYEEncoding
    {
        /// <summary>
        /// 将Hex码再加密成HEX形式
        /// </summary>
        /// <param name="strCodeHex">需要加密的字符串</param>
        /// <returns></returns>
        public static string strHexCodeHex(string strCodeHex)
        {
            string strCode = "";
            byte[] strBytes = new byte[strCodeHex.Length / 2];
            byte[] codeBytes = new byte[strCodeHex.Length / 2];
            int key1 = 861;
            int key2 = 19;
            for (int i = 0; i < strBytes.Length; i++)
            {
                try
                {
                    strBytes[i] = byte.Parse(strCodeHex.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
                    byte code = strBytes[i];
                    code = (byte)(((code & 0x0f) << 4) + ((code & 0xf0) >> 4));
                    code = (byte)~code;
                    byte code2 = (byte)~(key1 ^ key2);
                    code = (byte)(code ^ code2);
                    code = (byte)(((code & 0x0f) << 4) + ((code & 0xf0) >> 4));
                    codeBytes[i] = code;
                }
                catch
                {
                    return "";
                }
            }
            if (codeBytes.Length >= 1)
                strCode = BitConverter.ToString(codeBytes).Replace("-", "");
            return strCode;
        }

        /// <summary>
        /// 将字符串编码加密成Hex码
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns></returns>
        public static string strCodeHex(object str)
        {
            if (str==null)
            {
                return "";
            }
            if (string.IsNullOrWhiteSpace(str.ToString()) == true)
            {
                return "";
            }
            string strCode = "";
            byte[] strBytes = System.Text.UTF8Encoding.Default.GetBytes(str.ToString());
            byte[] codeBytes = new byte[strBytes.Length];
            int key1 = 861;
            int key2 = 19;
            for (int i = 0; i < strBytes.Length; i++)
            {
                try
                 {
                    byte code = strBytes[i];
                    code = (byte)(((code & 0x0f) << 4) + ((code & 0xf0) >> 4));
                    code = (byte)~code;
                    byte code2 = (byte)~(key1 ^ key2);
                    code = (byte)(code ^ code2);
                    code = (byte)(((code & 0x0f) << 4) + ((code & 0xf0) >> 4));
                    codeBytes[i] = code;
                }
                catch
                {
                    return "";
                }
            }
            if (codeBytes.Length >= 1)
                strCode = BitConverter.ToString(codeBytes).Replace("-", "");

            return strCode;
        }

        /// <summary>
        /// 将按Hex编码加密后的字符串转译回UTF8
        /// </summary>
        /// <param name="strDecodeHex">需要转移的字符串</param>
        /// <returns></returns>
        public static string strHexDecode(object strDecodeHex)
        {
            if (strDecodeHex == null)
            {
                return "";
            }
            if (string.IsNullOrWhiteSpace(strDecodeHex.ToString()) == true)
            {
                return "";
            }
            string strDecode = "";
            byte[] strBytes = new byte[strDecodeHex.ToString().Length / 2];
            byte[] decodeBytes = new byte[strDecodeHex.ToString().Length / 2];
            int key1 = 861;
            int key2 = 19;
            for (int i = 0; i < strBytes.Length; i++)
            {
                try
                {
                    strBytes[i] = byte.Parse(strDecodeHex.ToString().Substring(i * 2, 2),
                                        System.Globalization.NumberStyles.HexNumber);
                    byte code = strBytes[i];
                    code = (byte)(((code & 0x0f) << 4) + ((code & 0xf0) >> 4));
                    code = (byte)~code;
                    byte code2 = (byte)~(key1 ^ key2);
                    code = (byte)(code ^ code2);
                    code = (byte)(((code & 0x0f) << 4) + ((code & 0xf0) >> 4));
                    decodeBytes[i] = code;
                }
                catch
                {
                    return "";
                }
            }
            if (decodeBytes.Length >= 1)
                strDecode = UTF8Encoding.Default.GetString(decodeBytes, 0, decodeBytes.Length);
            return strDecode;
        }

        /// <summary>
        /// 将Hex编码反编译回一次Hex编码
        /// 若此前该Hex多次加密成Hex应调用同等次数的此方法转译
        /// </summary>
        /// <param name="strDecodeHex">需要转译的字符串</param>
        /// <returns></returns>
        public static string strHexDecodeHex(string strDecodeHex)
        {
            string strDecode = "";
            byte[] strBytes = new byte[strDecodeHex.Length / 2];
            byte[] decodeBytes = new byte[strDecodeHex.Length / 2];
            int key1 = 861;
            int key2 = 19;
            for (int i = 0; i < strBytes.Length; i++)
            {
                try
                {
                    strBytes[i] = byte.Parse(strDecodeHex.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
                    byte code = strBytes[i];
                    code = (byte)(((code & 0x0f) << 4) + ((code & 0xf0) >> 4));
                    code = (byte)~code;
                    byte code2 = (byte)~(key1 ^ key2);
                    code = (byte)(code ^ code2);
                    code = (byte)(((code & 0x0f) << 4) + ((code & 0xf0) >> 4));
                    decodeBytes[i] = code;
                }
                catch
                {
                    return "";
                }
            }
            if (decodeBytes.Length >= 1)
                strDecode = BitConverter.ToString(decodeBytes).Replace("-", "");
            return strDecode;
        }
    }
}
