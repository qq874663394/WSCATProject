using BaseLayer.Base;
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
    public class DepartmentInterface
    {
        DepartmentLogic _dal = new DepartmentLogic();
        /// <summary>
        /// 删除全部数据
        /// </summary>
        public bool DeleteAll()
        {
            return _dal.DeleteAll();
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code)
        {
            return _dal.Exists(code);
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BaseDepartment model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseDepartment model)
        {
            return _dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string code)
        {
            return _dal.Delete(code);
        }
        /// <summary>
		/// 获得数据列表
        /// </summary>
        /// <param name="fieldName">字段名 0:code 1:name 2:模糊查询name 3:roleCode</param>
        /// <param name="fieldValue"></param>
        /// <param name="isClear">true检索所有,false只检索禁用</param>
        /// <returns></returns>
		public DataTable GetList(int fieldName, string fieldValue, bool isClear)
        {
            return _dal.GetList(fieldName, fieldValue, isClear);
        }
    }
}
