using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Purchase
{
    public class PurchaseDetailBase
    {
        public DataTable GetList(string strWhere)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = "select * from T_PurechaseDetail";
                if (!string.IsNullOrWhiteSpace(strWhere))
                {
                    sql += " where " + strWhere;
                }
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetList(string purchaseCode, string materialDaima)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = "select * from T_PurchaseDetail";
                if (!string.IsNullOrWhiteSpace(purchaseCode) || !string.IsNullOrWhiteSpace(materialDaima))
                {
                    sql += " where ";
                    if (!string.IsNullOrWhiteSpace(purchaseCode))
                    {
                        sql += string.Format("PurchaseCode='{0}'", purchaseCode);
                    }
                    if (!string.IsNullOrWhiteSpace(purchaseCode) && !string.IsNullOrWhiteSpace(materialDaima))
                    {
                        sql += " and ";
                    }
                    if (!string.IsNullOrWhiteSpace(materialDaima))
                    {
                        sql += string.Format("materialDaima like '%{0}%'", materialDaima);
                    }
                }
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public decimal GetCheckNumber(string purchaseCode, string code)
        {
            string sql = "";
            decimal result = 0;
            try
            {
                sql = string.Format("select number from T_PurchaseDetail where purchaseCode='{0}' and code='{1}'", purchaseCode, code);
                result = Convert.ToDecimal(DbHelperSQL.GetSingle(sql));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// false不存在，true存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_PurchaseDetail]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}