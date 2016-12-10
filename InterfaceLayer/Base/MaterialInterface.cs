using LogicLayer.Base;
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
    }
}
