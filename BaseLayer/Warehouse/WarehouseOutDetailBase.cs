using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer
{
    public class WarehouseOutDetailBase
    {
        public DataSet GetList(string strWhere)
        {
            DataSet ds = null;
            StringBuilder strSql = new StringBuilder();
            try
            {
                strSql.Append("select *");
                strSql.Append(" FROM T_WarehouseOutDetail ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                ds = DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        /// <summary>
        /// 判断该客户编号判断是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            bool isflag = false;
            string sql = "";
            try
            {
                sql = string.Format("select count(1) from T_WarehouseMain where code='{0}'", code);
                isflag = DbHelperSQL.Exists(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isflag;
        }
    }
}
