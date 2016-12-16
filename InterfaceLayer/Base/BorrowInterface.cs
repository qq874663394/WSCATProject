using LogicLayer.Base;
using Model;
using System.Data;

namespace InterfaceLayer.Base
{
    public class BorrowInterface
    {
        BorrowLogic _dal = new BorrowLogic();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return _dal.Exists(id);
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BaseBorrow model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BaseBorrow model)
        {
            return _dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return _dal.Delete(id);
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(int fieldName, string fieldValue)
        {
            return _dal.GetList(fieldName, fieldValue);
        }
    }
}
