using Model.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Finance;

namespace InterfaceLayer.Finance
{
    public class FinanceVoucherEntryInterface
    {
        FinanceVoucherEntryLogic srl = new FinanceVoucherEntryLogic();
        /// <summary>
        /// 上一单
        /// </summary>
        /// <param name="srb"></param>
        /// <returns></returns>
        public DataTable GetLastDetail(string code)
        {
            return srl.GetLastDetail(code);
        }

        /// <summary>
        /// 默认的上一单
        /// </summary>
        /// <param name="srb"></param>
        /// <returns></returns>
        public DataTable GetFLastDetail(string code)
        {
            return srl.GetFLastDetail(code);
        }

        /// <summary>
        /// 下一单
        /// </summary>
        /// <param name="srb"></param>
        /// <returns></returns>
        public DataTable GetNextDetail(string code)
        {
            return srl.GetNextDetail(code);
        }

        /// <summary>
        /// 获取最新的code
        /// </summary>
        /// <returns></returns>
        public string GetNewCode()
        {
            return srl.GetNewCode();
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object AddOrUpdateToMainOrDetail(FinanceVoucherEntryMain model,
            List<FinanceVoucherEntryDetail> modelDetail)
        {
            return srl.AddOrUpdateToMainOrDetail(model,modelDetail);
        }

        /// <summary>
        /// 判断指定数据是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return srl.Exists(code);
        }
    }
}
