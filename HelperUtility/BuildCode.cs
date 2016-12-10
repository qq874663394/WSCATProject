using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtility
{
    public class BuildCode
    {
        /// <summary>
        /// 生成"模块简写-时间"格式的编码
        /// </summary>
        /// <param name="module">模块的简写</param>
        /// <returns></returns>
        public static string ModuleCode(string module)
        {
            string code = "";
            string datetime = DateTime.Now.ToString("yyMMddHHmmssff");
            code = module + datetime;
            return code;
        }

        /// <summary>
        /// 生成"模块简写-用户id-时间"格式的编码
        /// </summary>
        /// <param name="module">模块的简写</param>
        /// <returns></returns>
        public static string ModuleAndUserCode(string module)
        {
            string code = "";
            string userid = "";
            string datetime = DateTime.Now.ToString("yyMMddHHmmssff");
            code = module + "-" + userid + "-" + datetime;
            return code;
        }
    }
}
