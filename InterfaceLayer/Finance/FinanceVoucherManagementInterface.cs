using LogicLayer.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Finance
{
    public class FinanceVoucherManagementInterface
    {
        FinanceVoucherManagementLogic fvm = new FinanceVoucherManagementLogic();
        /// <summary>
        /// 获取修改code所在的数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetUpdateData(string code)
        {
            return fvm.GetUpdateData(code);
        }

        /// <summary>
        /// 删除code所在的数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int DeleteData(string proc,string code)
        {
            return fvm.DeleteData(proc,code);
        }

        /// <summary>
        /// 获取enrtyMain和detail表的数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable SelectData()
        {
            return fvm.SelectData();
        }
    }
}
