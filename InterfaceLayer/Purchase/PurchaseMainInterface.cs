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
    }
}