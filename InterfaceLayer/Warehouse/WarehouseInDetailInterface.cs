using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;
using System.Data;
using Model;

namespace InterfaceLayer.Warehouse
{
   public  class WarehouseInDetailInterface
    {
        WarehouseInDetailLogic wdl = new WarehouseInDetailLogic();
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertWarehouseInDetailTable(WarehouseInDetail model)
        {
            return wdl.InsertWarehouseInDetailTable(model);
        }
        /// <summary>
        /// 根据code删除数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int deleteInDetailTable(string code)
        {
            return wdl.deleteInDetailTable(code);
        }
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:模糊zhujima,1:模糊materialName,2:state,3:isClear</param>
        /// <param name="fieldValue">条件值</param>
        /// <returns></returns>
        public DataSet getList(int fieldName, string fieldValue)
        {
            return wdl.getList(fieldName, fieldValue);
        }
        /// <summary>
        /// 根据主表code获取列表
        /// </summary>
        /// <param name="mainCode"></param>
        /// <returns></returns>
        public DataSet getListByMainCode(string mainCode)
        {
            return wdl.getListByMainCode(mainCode);
        }

        /// <summary>
        /// 根据code来更新入库状态
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int updateStateByCode(string code)
        {
            return wdl.updateByCode(code);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return wdl.Exists(code);
        }
    }
}
