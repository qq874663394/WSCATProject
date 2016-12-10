using LogicLayer.Finance;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Finance
{
    public class FinanceOtherExpensesOutInterface
    {
        FinanceOtherExpensesOutLogic _dal = new FinanceOtherExpensesOutLogic();
        public object AddOrUpdateToMainOrDetail(FinanceOtherExpensesOut model, List<FinanceOtherExpensesOutDetail> modelDetail)
        {
            return _dal.AddOrUpdateToMainOrDetail(model, modelDetail);
        }
        public bool Exists(string code)
        {
            return _dal.Exists(code);
        }

        /// <summary>
        /// 上一单
        /// </summary>
        /// <param name="srb"></param>
        /// <returns></returns>
        public DataTable GetLastDetail(string code)
        {
            return _dal.GetLastDetail(code);
        }

        /// <summary>
        /// 默认的上一单
        /// </summary>
        /// <param name="srb"></param>
        /// <returns></returns>
        public DataTable GetFLastDetail(string code)
        {
            return _dal.GetFLastDetail(code);
        }

        /// <summary>
        /// 下一单
        /// </summary>
        /// <param name="srb"></param>
        /// <returns></returns>
        public DataTable GetNextDetail(string code)
        {
            return _dal.GetNextDetail(code);
        }

        /// <summary>
        /// 获取最新的code
        /// </summary>
        /// <returns></returns>
        public string GetNewCode()
        {
            return _dal.GetNewCode();
        }
    }
}
