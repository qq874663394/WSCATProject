using LogicLayer.Warehouse;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Warehouse
{
    public class WarehouseInventoryDetailInterface
    {
        WarehouseInventoryDetailLogic widl = new WarehouseInventoryDetailLogic();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:code,1:materialDaima,2:stockCode,3:barCode,4:mainCode,5:盘亏,6:盘盈</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns></returns>
        public DataTable Search(int fieldName, string fieldValue)
        {
            return widl.Search(fieldName, fieldValue);
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public int Add(WarehouseInventoryDetail wid)
        {
            return widl.Add(wid);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public int Modify(WarehouseInventoryDetail wid)
        {
            return widl.Modify(wid);
        }
        /// <summary>
        /// 新增和修改同时进行
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public int AddAndModify(WarehouseInventoryDetail wid)
        {
            return widl.AddAndModify(wid);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return widl.Exists(code);
        }
    }
}
