using LogicLayer.Warehouse;
using Model.Warehouse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Warehouse
{
    public class WarehouseInventoryLossInterface
    {
        WarehouseInventoryLossLogic will = new WarehouseInventoryLossLogic();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:code,1:checkState,2:isClear</param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public DataTable Search(int fieldName, string fieldValue)
        {
            return will.Search(fieldName, fieldValue);
        }
        /// <summary>
        /// 新增和修改
        /// </summary>
        /// <param name="warehouseInventoryProfit"></param>
        /// <param name="warehouseInventoryProfitDetail"></param>
        /// <returns></returns>
        public object AddAndModify(WarehouseInventoryLoss warehouseInventoryLoss, List<WarehouseInventoryLossDetail> warehouseInventoryLossDetail)
        {
            return will.AddAndModify(warehouseInventoryLoss, warehouseInventoryLossDetail);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return will.Exists(code);
        }
    }
}