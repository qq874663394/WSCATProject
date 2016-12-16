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
    public class MaterialInterface
    {
        MaterialLogic _dal = new MaterialLogic();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseMaterial model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseMaterial model)
        {
            return _dal.Update(model);
        }
        public int SetMaterialNumber(string materialCode, string price)
        {
            return _dal.SetMaterialNumber(materialCode, price);
        }
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">012模糊查询0:materialDaima,1:name,2:zhujima,3:code</param>
        /// <param name="fieldValue">条件值</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return _dal.GetList(fieldName, fieldValue);
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
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string code)
        {
            return _dal.Delete(code);
        }
        /// <summary>
        /// 删除全部数据
        /// </summary>
        public bool DeleteAll()
        {
            return _dal.DeleteAll();
        }
    }
}
