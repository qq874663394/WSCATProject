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
    public class WarehouseDisassemblyInterface
    {
        WarehouseDisassemblyLogic _dal = new WarehouseDisassemblyLogic();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:code,2:materialDaima,3:materialName</param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return _dal.GetList(fieldName, fieldValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="listModel"></param>
        /// <returns></returns>
        public object AddAndModify(WarehouseDisassembly model, List<WarehouseDisassemblyDetail> listModel)
        {
            return _dal.AddAndModify(model, listModel);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return _dal.Exists(code);
        }
    }
}
