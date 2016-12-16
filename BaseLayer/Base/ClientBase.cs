using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BaseLayer.Base
{
    public class ClientBase
    {
        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <param name="isflag">true显示全部 false显示未禁用</param>
        /// <returns></returns>
        public DataTable GetClientByBool(bool isflag)
        {
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "select * from T_BaseClient";
                if (isflag == false)
                {
                    sql += " where enable=1 ";
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
		/// 增加一条数据
		/// </summary>
		public int Add(BaseClient model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_BaseClient] (");
            strSql.Append("code,fingerPrints,name,picName,mobilePhone,fixedPhone,fax,cityCode,cityName,address,linkMan,companyName,typeCode,typeName,discountCode,bankCard,openBank,initialSalesTime,initialReturnTime,lastReturnTime,lastSalesTime,createTime,availableBalance,balance,statementDate,receivables,moneyReceipt,advanceReceipts,remark,reserved1,reserved2,enable,updateDate)");
            strSql.Append(" values (");
            strSql.Append("@code,@fingerPrints,@name,@picName,@mobilePhone,@fixedPhone,@fax,@cityCode,@cityName,@address,@linkMan,@companyName,@typeCode,@typeName,@discountCode,@bankCard,@openBank,@initialSalesTime,@initialReturnTime,@lastReturnTime,@lastSalesTime,@createTime,@availableBalance,@balance,@statementDate,@receivables,@moneyReceipt,@advanceReceipts,@remark,@reserved1,@reserved2,@enable,@updateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@fingerPrints", SqlDbType.NVarChar,-1),
                    new SqlParameter("@name", SqlDbType.NVarChar,16),
                    new SqlParameter("@picName", SqlDbType.NVarChar,40),
                    new SqlParameter("@mobilePhone", SqlDbType.NVarChar,22),
                    new SqlParameter("@fixedPhone", SqlDbType.NVarChar,26),
                    new SqlParameter("@fax", SqlDbType.NVarChar,26),
                    new SqlParameter("@cityCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@cityName", SqlDbType.NVarChar,58),
                    new SqlParameter("@address", SqlDbType.NVarChar,58),
                    new SqlParameter("@linkMan", SqlDbType.NVarChar,16),
                    new SqlParameter("@companyName", SqlDbType.NVarChar,48),
                    new SqlParameter("@typeCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@typeName", SqlDbType.NVarChar,16),
                    new SqlParameter("@discountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@bankCard", SqlDbType.NVarChar,45),
                    new SqlParameter("@openBank", SqlDbType.NVarChar,40),
                    new SqlParameter("@initialSalesTime", SqlDbType.DateTime),
                    new SqlParameter("@initialReturnTime", SqlDbType.DateTime),
                    new SqlParameter("@lastReturnTime", SqlDbType.DateTime),
                    new SqlParameter("@lastSalesTime", SqlDbType.DateTime),
                    new SqlParameter("@createTime", SqlDbType.DateTime),
                    new SqlParameter("@availableBalance", SqlDbType.Decimal,9),
                    new SqlParameter("@balance", SqlDbType.Decimal,9),
                    new SqlParameter("@statementDate", SqlDbType.DateTime),
                    new SqlParameter("@receivables", SqlDbType.Decimal,9),
                    new SqlParameter("@moneyReceipt", SqlDbType.Decimal,9),
                    new SqlParameter("@advanceReceipts", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@enable", SqlDbType.Int,4),
                    new SqlParameter("@updateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.code;
            parameters[1].Value = model.fingerPrints;
            parameters[2].Value = model.name;
            parameters[3].Value = model.picName;
            parameters[4].Value = model.mobilePhone;
            parameters[5].Value = model.fixedPhone;
            parameters[6].Value = model.fax;
            parameters[7].Value = model.cityCode;
            parameters[8].Value = model.cityName;
            parameters[9].Value = model.address;
            parameters[10].Value = model.linkMan;
            parameters[11].Value = model.companyName;
            parameters[12].Value = model.typeCode;
            parameters[13].Value = model.typeName;
            parameters[14].Value = model.discountCode;
            parameters[15].Value = model.bankCard;
            parameters[16].Value = model.openBank;
            parameters[17].Value = model.initialSalesTime;
            parameters[18].Value = model.initialReturnTime;
            parameters[19].Value = model.lastReturnTime;
            parameters[20].Value = model.lastSalesTime;
            parameters[21].Value = model.createTime;
            parameters[22].Value = model.availableBalance;
            parameters[23].Value = model.balance;
            parameters[24].Value = model.statementDate;
            parameters[25].Value = model.receivables;
            parameters[26].Value = model.moneyReceipt;
            parameters[27].Value = model.advanceReceipts;
            parameters[28].Value = model.remark;
            parameters[29].Value = model.reserved1;
            parameters[30].Value = model.reserved2;
            parameters[31].Value = model.enable;
            parameters[32].Value = model.updateDate;

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
		public bool Update(BaseClient model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseClient] set ");
            strSql.Append("fingerPrints=@fingerPrints,");
            strSql.Append("name=@name,");
            strSql.Append("picName=@picName,");
            strSql.Append("mobilePhone=@mobilePhone,");
            strSql.Append("fixedPhone=@fixedPhone,");
            strSql.Append("fax=@fax,");
            strSql.Append("cityCode=@cityCode,");
            strSql.Append("cityName=@cityName,");
            strSql.Append("address=@address,");
            strSql.Append("linkMan=@linkMan,");
            strSql.Append("companyName=@companyName,");
            strSql.Append("typeCode=@typeCode,");
            strSql.Append("typeName=@typeName,");
            strSql.Append("discountCode=@discountCode,");
            strSql.Append("bankCard=@bankCard,");
            strSql.Append("openBank=@openBank,");
            strSql.Append("initialSalesTime=@initialSalesTime,");
            strSql.Append("initialReturnTime=@initialReturnTime,");
            strSql.Append("lastReturnTime=@lastReturnTime,");
            strSql.Append("lastSalesTime=@lastSalesTime,");
            strSql.Append("createTime=@createTime,");
            strSql.Append("availableBalance=@availableBalance,");
            strSql.Append("balance=@balance,");
            strSql.Append("statementDate=@statementDate,");
            strSql.Append("receivables=@receivables,");
            strSql.Append("moneyReceipt=@moneyReceipt,");
            strSql.Append("advanceReceipts=@advanceReceipts,");
            strSql.Append("remark=@remark,");
            strSql.Append("reserved1=@reserved1,");
            strSql.Append("reserved2=@reserved2,");
            strSql.Append("enable=@enable,");
            strSql.Append("updateDate=@updateDate");
            strSql.Append(" where code=@code ");
            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@fingerPrints", SqlDbType.NVarChar,-1),
                    new SqlParameter("@name", SqlDbType.NVarChar,16),
                    new SqlParameter("@picName", SqlDbType.NVarChar,40),
                    new SqlParameter("@mobilePhone", SqlDbType.NVarChar,22),
                    new SqlParameter("@fixedPhone", SqlDbType.NVarChar,26),
                    new SqlParameter("@fax", SqlDbType.NVarChar,26),
                    new SqlParameter("@cityCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@cityName", SqlDbType.NVarChar,58),
                    new SqlParameter("@address", SqlDbType.NVarChar,58),
                    new SqlParameter("@linkMan", SqlDbType.NVarChar,16),
                    new SqlParameter("@companyName", SqlDbType.NVarChar,48),
                    new SqlParameter("@typeCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@typeName", SqlDbType.NVarChar,16),
                    new SqlParameter("@discountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@bankCard", SqlDbType.NVarChar,45),
                    new SqlParameter("@openBank", SqlDbType.NVarChar,40),
                    new SqlParameter("@initialSalesTime", SqlDbType.DateTime),
                    new SqlParameter("@initialReturnTime", SqlDbType.DateTime),
                    new SqlParameter("@lastReturnTime", SqlDbType.DateTime),
                    new SqlParameter("@lastSalesTime", SqlDbType.DateTime),
                    new SqlParameter("@createTime", SqlDbType.DateTime),
                    new SqlParameter("@availableBalance", SqlDbType.Decimal,9),
                    new SqlParameter("@balance", SqlDbType.Decimal,9),
                    new SqlParameter("@statementDate", SqlDbType.DateTime),
                    new SqlParameter("@receivables", SqlDbType.Decimal,9),
                    new SqlParameter("@moneyReceipt", SqlDbType.Decimal,9),
                    new SqlParameter("@advanceReceipts", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@enable", SqlDbType.Int,4),
                    new SqlParameter("@updateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.code;
            parameters[1].Value = model.fingerPrints;
            parameters[2].Value = model.name;
            parameters[3].Value = model.picName;
            parameters[4].Value = model.mobilePhone;
            parameters[5].Value = model.fixedPhone;
            parameters[6].Value = model.fax;
            parameters[7].Value = model.cityCode;
            parameters[8].Value = model.cityName;
            parameters[9].Value = model.address;
            parameters[10].Value = model.linkMan;
            parameters[11].Value = model.companyName;
            parameters[12].Value = model.typeCode;
            parameters[13].Value = model.typeName;
            parameters[14].Value = model.discountCode;
            parameters[15].Value = model.bankCard;
            parameters[16].Value = model.openBank;
            parameters[17].Value = model.initialSalesTime;
            parameters[18].Value = model.initialReturnTime;
            parameters[19].Value = model.lastReturnTime;
            parameters[20].Value = model.lastSalesTime;
            parameters[21].Value = model.createTime;
            parameters[22].Value = model.availableBalance;
            parameters[23].Value = model.balance;
            parameters[24].Value = model.statementDate;
            parameters[25].Value = model.receivables;
            parameters[26].Value = model.moneyReceipt;
            parameters[27].Value = model.advanceReceipts;
            parameters[28].Value = model.remark;
            parameters[29].Value = model.reserved1;
            parameters[30].Value = model.reserved2;
            parameters[31].Value = model.enable;
            parameters[32].Value = model.updateDate;

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
                sql = "select * from T_BaseClient";
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
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_BaseClient]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}