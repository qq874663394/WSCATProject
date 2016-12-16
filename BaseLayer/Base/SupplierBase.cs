using Model;
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
                    sql += " where 1=1 " + strWhere;
                }
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #region 自定义where查询
        /// <summary>
        /// 自定义where查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelSupplierByWhere(string SQLWhere)
        {
            string sql = string.Format("select * from T_BaseSupplier ");
            if (!string.IsNullOrWhiteSpace(SQLWhere))
            {
                sql = string.Format("{0} where {1} and isEnable=1 and isClear=1", sql, SQLWhere);
            }
            else
            {
                sql += SQLWhere + " where isEnable=1 and isClear=1";
            }
            return DbHelperSQL.Query(sql).Tables[0];
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BaseSupplier model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_BaseSupplier] (");
            strSql.Append("name,phone,address,fax,email,bankCard,openBank,industryInvolved,industryCode,creditRank,availableBalance,balance,statementDate,linkMan,mobilePhone,remark,isEnable,isClear,reserved1,reserved2,code,cityName,updateDate)");
            strSql.Append(" values (");
            strSql.Append("@name,@phone,@address,@fax,@email,@bankCard,@openBank,@industryInvolved,@industryCode,@creditRank,@availableBalance,@balance,@statementDate,@linkMan,@mobilePhone,@remark,@isEnable,@isClear,@reserved1,@reserved2,@code,@cityName,@updateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@name", SqlDbType.NVarChar,50),
                    new SqlParameter("@phone", SqlDbType.NVarChar,22),
                    new SqlParameter("@address", SqlDbType.NVarChar,58),
                    new SqlParameter("@fax", SqlDbType.NVarChar,26),
                    new SqlParameter("@email", SqlDbType.NVarChar,64),
                    new SqlParameter("@bankCard", SqlDbType.NVarChar,45),
                    new SqlParameter("@openBank", SqlDbType.NVarChar,40),
                    new SqlParameter("@industryInvolved", SqlDbType.NVarChar,16),
                    new SqlParameter("@industryCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@creditRank", SqlDbType.Int,4),
                    new SqlParameter("@availableBalance", SqlDbType.Decimal,9),
                    new SqlParameter("@balance", SqlDbType.Decimal,9),
                    new SqlParameter("@statementDate", SqlDbType.DateTime),
                    new SqlParameter("@linkMan", SqlDbType.NVarChar,16),
                    new SqlParameter("@mobilePhone", SqlDbType.NVarChar,22),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@isEnable", SqlDbType.Int,4),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@cityName", SqlDbType.NVarChar,58),
                    new SqlParameter("@updateDate", SqlDbType.DateTime)};
            parameters[0].Value =model.name;
            parameters[1].Value =model.phone;
            parameters[2].Value =model.address;
            parameters[3].Value =model.fax;
            parameters[4].Value =model.email;
            parameters[5].Value =model.bankCard;
            parameters[6].Value =model.openBank;
            parameters[7].Value =model.industryInvolved;
            parameters[8].Value =model.industryCode;
            parameters[9].Value = model.creditRank;
            parameters[10].Value =model.availableBalance;
            parameters[11].Value =model.balance;
            parameters[12].Value =model.statementDate;
            parameters[13].Value =model.linkMan;
            parameters[14].Value =model.mobilePhone;
            parameters[15].Value =model.remark;
            parameters[16].Value =model.isEnable;
            parameters[17].Value =model.isClear;
            parameters[18].Value =model.reserved1;
            parameters[19].Value =model.reserved2;
            parameters[20].Value =model.code;
            parameters[21].Value =model.cityName;
            parameters[22].Value = model.updateDate;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BaseSupplier model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseSupplier] set ");
            strSql.Append("name=@name,");
            strSql.Append("phone=@phone,");
            strSql.Append("address=@address,");
            strSql.Append("fax=@fax,");
            strSql.Append("email=@email,");
            strSql.Append("bankCard=@bankCard,");
            strSql.Append("openBank=@openBank,");
            strSql.Append("industryInvolved=@industryInvolved,");
            strSql.Append("industryCode=@industryCode,");
            strSql.Append("creditRank=@creditRank,");
            strSql.Append("availableBalance=@availableBalance,");
            strSql.Append("balance=@balance,");
            strSql.Append("statementDate=@statementDate,");
            strSql.Append("linkMan=@linkMan,");
            strSql.Append("mobilePhone=@mobilePhone,");
            strSql.Append("remark=@remark,");
            strSql.Append("isEnable=@isEnable,");
            strSql.Append("isClear=@isClear,");
            strSql.Append("reserved1=@reserved1,");
            strSql.Append("reserved2=@reserved2,");
            strSql.Append("cityName=@cityName,");
            strSql.Append("updateDate=@updateDate");
            strSql.Append(" where code=@code ");
            SqlParameter[] parameters = {
                    new SqlParameter("@name", SqlDbType.NVarChar,50),
                    new SqlParameter("@phone", SqlDbType.NVarChar,22),
                    new SqlParameter("@address", SqlDbType.NVarChar,58),
                    new SqlParameter("@fax", SqlDbType.NVarChar,26),
                    new SqlParameter("@email", SqlDbType.NVarChar,64),
                    new SqlParameter("@bankCard", SqlDbType.NVarChar,45),
                    new SqlParameter("@openBank", SqlDbType.NVarChar,40),
                    new SqlParameter("@industryInvolved", SqlDbType.NVarChar,16),
                    new SqlParameter("@industryCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@creditRank", SqlDbType.Int,4),
                    new SqlParameter("@availableBalance", SqlDbType.Decimal,9),
                    new SqlParameter("@balance", SqlDbType.Decimal,9),
                    new SqlParameter("@statementDate", SqlDbType.DateTime),
                    new SqlParameter("@linkMan", SqlDbType.NVarChar,16),
                    new SqlParameter("@mobilePhone", SqlDbType.NVarChar,22),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@isEnable", SqlDbType.Int,4),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@cityName", SqlDbType.NVarChar,58),
                    new SqlParameter("@updateDate", SqlDbType.DateTime)};
            parameters[0].Value =model.name;
            parameters[1].Value =model.phone;
            parameters[2].Value =model.address;
            parameters[3].Value =model.fax;
            parameters[4].Value =model.email;
            parameters[5].Value =model.bankCard;
            parameters[6].Value =model.openBank;
            parameters[7].Value =model.industryInvolved;
            parameters[8].Value =model.industryCode;
            parameters[9].Value = model.creditRank;
            parameters[10].Value =model.availableBalance;
            parameters[11].Value =model.balance;
            parameters[12].Value =model.statementDate;
            parameters[13].Value =model.linkMan;
            parameters[14].Value =model.mobilePhone;
            parameters[15].Value =model.remark;
            parameters[16].Value =model.isEnable;
            parameters[17].Value =model.isClear;
            parameters[18].Value =model.reserved1;
            parameters[19].Value =model.reserved2;
            parameters[20].Value =model.code;
            parameters[21].Value =model.cityName;
            parameters[22].Value =model.updateDate;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseSupplier] set isClear=0 ");
            strSql.Append(" where code=@code ");
            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除全部数据
        /// </summary>
        public bool DeleteAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseSupplier] set isClear=0 ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
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
