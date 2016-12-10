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
    public class WarehouseAllotInterface
    {
        WarehouseAllotLogic _dal = new WarehouseAllotLogic();
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return _dal.GetList(fieldName, fieldValue);
        }
        public object AddAndModify(WarehouseAllot model, List<WarehouseAllotDetail> modelDetail)
        {
            return _dal.AddAndModify(model, modelDetail);
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
