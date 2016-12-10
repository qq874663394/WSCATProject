using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Base
{
    public class ProjectCostBase
    {
        /// <summary>
        /// 自定义条件取得列表
        /// </summary>
        /// <param name="strWhere">where后面的条件</param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "select * from T_BaseProjectCost";
                if (strWhere.Trim() != "")
                {
                    sql += " where " + strWhere;
                }
                ds = DbHelperSQL.Query(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds.Tables[0];
        }
    }
}
