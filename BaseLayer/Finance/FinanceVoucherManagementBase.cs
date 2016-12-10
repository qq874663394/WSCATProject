using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Finance
{
    public class FinanceVoucherManagementBase
    {
        /// <summary>
        /// 获取修改按钮所选行的data
        /// </summary>
        /// <param name="entryCode"></param>
        /// <returns></returns>
        public DataTable GetUpdateData(string updateCode)
        {
            string sql = "";
            DataTable dt = null;
            sql = string.Format(@"select fvem.code,
fvem.date,
fvem.examine,
fvem.posting,
fvem.makeMan,
fvem.examineState,
fved.code,
fved.summary,
fved.subject,
fved.debitAmount,
fved.creditAmount
 from T_FinanceVoucherEntryMain fvem,T_FinanceVoucherEntryDetail fved
where fvem.code=fved.mainCode and 
fvem.code= '{0}' and fved.mainCode = '{1}'", updateCode, updateCode);
            dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 通过code删除所选的那行数据
        /// </summary>
        /// <param name="entryCode"></param>
        /// <returns></returns>
        public int DeleteData(string proc,string code)
        {
            int flag = DbHelperSQL.ExecuteSqlPar(proc,code);
            return flag;
        }

        /// <summary>
        /// 获取enrtyMain和detail表的数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable SelectData()
        {
            string sql = "select fvem.*,fved.subject,fved.summary,fved.debitAmount,fved.creditAmount from "
            + "T_FinanceVoucherEntryMain fvem join T_FinanceVoucherEntryDetail fved on fvem.code = fved.mainCode order by fvem.id desc ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }
    }
}
