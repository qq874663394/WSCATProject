using LogicLayer.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Purchase
{
    public class PurchaseDetailInterface
    {
        PurchaseDetailLogic pdi = new PurchaseDetailLogic();
        public DataTable GetList(string purchaseCode, string zhujima)
        {
            return pdi.GetList(purchaseCode, zhujima);
        }
        public decimal GetCheckNumber(string purchaseCode, string code)
        {
            return pdi.GetCheckNumber(purchaseCode, code);
        }
        public DataTable GetListAndMaterial(string fieldValue)
        {
            return pdi.GetListAndMaterial(fieldValue);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return pdi.Exists(code);
        }
    }
}
