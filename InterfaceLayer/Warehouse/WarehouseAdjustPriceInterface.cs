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
    public class WarehouseAdjustPriceInterface
    {
        WarehouseAdjustPriceLogic dal = new WarehouseAdjustPriceLogic();
        /// <summary>
        /// 查询调价单信息
        /// </summary>
        /// <param name="fieldName">0:code,1:MainCode,2:模糊materialDaima,3:模糊materialName</param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public DataTable Search(int fieldName, string fieldValue)
        {
            return dal.Search(fieldName, fieldValue);
        }
        /// <summary>
        /// 新增盘亏信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="listModel"></param>
        /// <returns></returns>
        public object AddAndModify(WarehouseAdjustPrice model, List<WarehouseAdjustPriceDetail> listModel)
        {
            return dal.AddAndModify(model, listModel);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
    }
}