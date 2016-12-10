using LogicLayer.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Base
{
    public class ProjectInCostInterface
    {
        ProjectInCostLogic _dal = new ProjectInCostLogic();
        /// <summary>
        /// 自定义条件取得列表
        /// </summary>
        /// <param name="strWhere">where后面的条件</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return _dal.GetList(fieldName, fieldValue);
        }
    }
}
