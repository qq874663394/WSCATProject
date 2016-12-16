using LogicLayer.Finance;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Finance
{
    public class FinancePaymentInterface
    {
        FinancePaymentLogic _dal = new FinancePaymentLogic();
        public object AddOrUpdateToMainOrDetail(FinancePayment model, List<FinancePaymentDetail> modelDetail)
        {
            return _dal.AddOrUpdateToMainOrDetail(model, modelDetail);
        }
        public bool Exists(string code)
        {
            return _dal.Exists(code);
        }
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return _dal.GetList(fieldName, fieldValue);
        }

        /// <summary>
        /// 获取默认的上一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetFLastData(string code)
        {
            return _dal.GetFLastData(code);
        }

        /// <summary>
        /// 获取上一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetLastData(string code)
        {
            return _dal.GetLastData(code);
        }

        /// <summary>
        /// 获取下一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetNextData(string code)
        {
            return _dal.GetNextData(code);
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
