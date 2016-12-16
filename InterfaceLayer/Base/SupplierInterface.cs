using LogicLayer.Base;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Base
{
    public class SupplierInterface
    {
        SupplierLogic sl = new SupplierLogic();
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <returns>所有数据以DataTable的形式返回</returns>
        public DataTable SelSupplierTable()
        {
            return sl.SelSupplierTable();
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BaseSupplier model)
        {
            return sl.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BaseSupplier model)
        {
            return sl.Update(model);
        }
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">字段名:0:模糊查询name 1:模糊查询cityName 4:code 5:name</param>
        /// <param name="fieldValue"></param>
        /// <param name="isClear">true检索所有,false只检索未禁用</param>
        /// <param name="isEnable">true检索所有,false只检索未禁用</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue, bool isClear, bool isEnable)
        {
            return sl.GetList(fieldName, fieldValue, isClear, isEnable);
        }
        /// <summary>
        /// 根据供应商code查询所有采购单
        /// </summary>
        /// <param name="code">供应商code</param>
        /// <returns></returns>
        public DataTable GetPurchaseList(string code)
        {
            return sl.GetPurchaseList(code);
        }
        /// <summary>
        /// 自定义where查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelSupplierByWhere(string SQLWhere)
        {
            return sl.SelSupplierByWhere(SQLWhere);
        }
        /// <summary>
        /// 删除全部数据
        /// </summary>
        public bool DeleteAll()
        {
            return sl.DeleteAll();
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string code)
        {
            return sl.Delete(code);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return sl.Exists(code);
        }
    }
}
