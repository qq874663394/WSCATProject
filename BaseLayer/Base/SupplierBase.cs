using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Base
{
    public class SupplierBase
    {
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <returns>所有数据以DataTable的形式返回</returns>
        public DataTable SelSupplierTable()
        {
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = @"select 
                        code as 编码,
                        name as 单位名称,
                        address as 通讯地址,
                        linkMan as 联系人,
                        mobilePhone as 联系手机,
                        fax as 传真,
                        email as 邮箱,
                        creditRank as 信用等级,
                        availableBalance as 账款额度,
                        balance as 剩余额度,
                        statementDate as 月结日,
                        cityName as 城市,
                        remark as 备注,
                        isEnable
                        from T_BaseSupplier where isClear=1 and isEnable=1 order by id";
                ds = DbHelperSQL.Query(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds.Tables[0];
        }
        /// <summary>
        /// 自定义条件
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = "select * from T_BaseSupplier";
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
        /// <summary>
        /// 根据供应商code查询所有采购单
        /// </summary>
        /// <param name="code">供应商code</param>
        /// <returns></returns>
        public DataTable GetPurchaseList(string code)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = @"select pm.* from T_BaseSupplier su,T_PurchaseMain pm where pm.supplierCode = su.code and checkState=1 and purchaseOrderState=4 and (putStorageState=0 or putStorageState=1)";
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        /// <summary>
        /// false不存在，true存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_BaseSupplier]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
