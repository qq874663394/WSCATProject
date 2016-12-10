using BaseLayer.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Finance
{
    public class FinanceVoucherManagementLogic
    {
        FinanceVoucherManagementBase fvmb = new FinanceVoucherManagementBase();
        /// <summary>
        /// 获取修改code所在的数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetUpdateData(string code)
        {
            return fvmb.GetUpdateData(code);
        }

        /// <summary>
        /// 删除code所在的数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int DeleteData(string proc, string code)
        {
            return fvmb.DeleteData(proc, code);
        }

        /// <summary>
        /// 获取enrtyMain和detail表的数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable SelectData()
        {
            return fvmb.SelectData();
        }
    }
}
