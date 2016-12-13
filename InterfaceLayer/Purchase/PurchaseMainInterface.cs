using LogicLayer.Purchase;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Purchase
{
    public class PurchaseMainInterface
    {
        PurchaseMainLogic _dal = new PurchaseMainLogic();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:模糊name,1:模糊supplierName,2:supplierCode</param>
        /// <param name="fieldValue">条件值</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return _dal.GetList(fieldName, fieldValue);
        }
        public object AddOrUpdateToMainOrDetail(PurchaseMain model, List<PurchaseDetail> modelDetail)
        {
            return _dal.AddOrUpdateToMainOrDetail(model, modelDetail);
        }
        public bool Exists(string code)
        {
            return _dal.Exists(code);
        }

        /// <summary>
        /// 获取最新的code
        /// </summary>
        /// <returns></returns>
        public string GetNewCode()
        {
            return _dal.GetNewCode();
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
    }
}