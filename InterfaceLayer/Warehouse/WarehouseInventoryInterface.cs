using LogicLayer.Warehouse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Warehouse
{
    public class WarehouseInventoryInterface
    {
        WarehouseInventoryLogic iface = new WarehouseInventoryLogic();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:code,1:stockName,2:checkMan,3:stockCode</param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return iface.GetList(fieldName, fieldValue);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return iface.Exists(code);
        }
    }
}
