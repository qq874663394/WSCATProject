using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Base
{
    public class MaterialBase
    {
        public int SetMaterialNumber(string materialCode, string price)
        {
            string sql = "";
            int result = 0;
            try
            {
                sql = string.Format(@"update T_BaseMaterial set price={0} where code='{1}'", price, materialCode);
                result = DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
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
                sql = "select * from T_BaseMaterial";
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
        /// <summary>
        /// false不存在，true存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_BaseMasterial]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
