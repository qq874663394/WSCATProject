using LogicLayer.Warehouse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Warehouse
{
    public class WarehouseOutDetailInterface
    {
        WarehouseOutDetailLogic wodl = new WarehouseOutDetailLogic();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0：mainCode</param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public DataSet GetList(int fieldName, string fieldValue)
        {
            return wodl.GetList(fieldName,fieldValue);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return wodl.Exists(code);
        }
    }
}
