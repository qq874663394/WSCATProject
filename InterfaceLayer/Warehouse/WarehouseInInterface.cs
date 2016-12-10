using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer;
using System.Data;
using Model;
using System.Collections;
using System.Data.SqlClient;

namespace InterfaceLayer.Warehouse
{
    public class WarehouseInInterface
    {
        WarehouseInLogic warehouseInLogic = new WarehouseInLogic();

        /// <summary>
        /// 根据审核状态查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetListToIn(int state)
        {
            return warehouseInLogic.GetListToIn(state);
        }
        /// <summary>
        /// 事务修改
        /// </summary>
        /// <param name="hashTable">主表的sql和parameter</param>
        /// <param name="sql">子表sql</param>
        /// <param name="list">子表的parameter</param>
        public void UpdateList(Hashtable hashTable, string sql, List<SqlParameter[]> list)
        {
            warehouseInLogic.UpdateList(hashTable, sql, list);
        }
        /// <summary>
        /// 事务新增
        /// </summary>
        public object AddWarehouseOrToDetail(WarehouseIn warehouseIn, List<WarehouseInDetail> warehouseInDetail)
        {
            return warehouseInLogic.AddWarehouseOrToDetail(warehouseIn, warehouseInDetail);
        }

        /// <summary>
        /// 获取入库数据列表
        /// </summary>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
        public DataSet GetList(int fieldName, string fieldValue)
        {
            return warehouseInLogic.GetList(fieldName, fieldValue);
        }

        /// <summary>
        /// 根据code删除一条数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int deleteWarehouseInByCode(string code)
        {
            return warehouseInLogic.deleteByCode(code);
        }
        /// <summary>
        /// 修改审核状态
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int updateByCode(WarehouseIn warehouseIn, List<WarehouseInDetail> list)
        {
            return warehouseInLogic.updateByCode(warehouseIn, list);
        }
        /// <summary>
        /// 上下一单
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="state">状态:0:下一单,1:上一单</param>
        /// <returns></returns>
        public WarehouseIn GetPreAndNext(int id, int state)
        {
            return warehouseInLogic.GetPreAndNext(id, state);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return warehouseInLogic.Exists(code);
        }
    }
}
