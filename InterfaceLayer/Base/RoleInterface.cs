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
    public class RoleInterface
    {
        RoleLogic _dal = new RoleLogic();
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
		public int Add(BaseRole model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseRole model)
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
		public DataTable GetList(int fieldName, string fieldValue, bool isClear)
        {
            return _dal.GetList(fieldName, fieldValue, isClear);
        }
    }
}
