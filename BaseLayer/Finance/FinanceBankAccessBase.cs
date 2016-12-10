using HelperUtility;
using Model;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Finance
{
    public class FinanceBankAccessBase
    {
        public int Add(FinanceBankAccess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_FinanceBankAccess] (");
            strSql.Append("code,date,paymentAccount,receiptAccount,amount,summary,handled,departmentCode,operators,auditors,checkState)");
            strSql.Append(" values (");
            strSql.Append("@code,@date,@paymentAccount,@receiptAccount,@amount,@summary,@handled,@departmentCode,@operators,@auditors,@checkState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@paymentAccount", SqlDbType.NVarChar,50),
                    new SqlParameter("@receiptAccount", SqlDbType.NVarChar,50),
                    new SqlParameter("@amount", SqlDbType.Decimal,9),
                    new SqlParameter("@summary", SqlDbType.NVarChar,400),
                    new SqlParameter("@handled", SqlDbType.NVarChar,20),
                    new SqlParameter("@departmentCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@operators", SqlDbType.NVarChar,20),
                    new SqlParameter("@auditors", SqlDbType.NVarChar,20),
                    new SqlParameter("@checkState",SqlDbType.Int)
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.date;
            parameters[2].Value = model.paymentAccount;
            parameters[3].Value = model.receiptAccount;
            parameters[4].Value = model.amount;
            parameters[5].Value = model.summary;
            parameters[6].Value = model.handled;
            parameters[7].Value = model.departmentCode;
            parameters[8].Value = model.operators;
            parameters[9].Value = model.auditors;
            parameters[10].Value = model.checkState;
            try
            {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FinanceBankAccess model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_FinanceBankAccess] set ");
            strSql.Append("date=@date,");
            strSql.Append("paymentAccount=@paymentAccount,");
            strSql.Append("receiptAccount=@receiptAccount,");
            strSql.Append("amount=@amount,");
            strSql.Append("summary=@summary,");
            strSql.Append("handled=@handled,");
            strSql.Append("departmentCode=@departmentCode,");
            strSql.Append("operators=@operators,");
            strSql.Append("auditors=@auditors,");
            strSql.Append("checkState=@checkState");
            strSql.Append(" where code=@code ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@paymentAccount", SqlDbType.NVarChar,50),
                    new SqlParameter("@receiptAccount", SqlDbType.NVarChar,50),
                    new SqlParameter("@amount", SqlDbType.Decimal,9),
                    new SqlParameter("@summary", SqlDbType.NVarChar,400),
                    new SqlParameter("@handled", SqlDbType.NVarChar,20),
                    new SqlParameter("@departmentCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@operators", SqlDbType.NVarChar,20),
                    new SqlParameter("@auditors", SqlDbType.NVarChar,20),
                    new SqlParameter("@checkState",SqlDbType.Int)
                };
            parameters[0].Value = model.code;
            parameters[1].Value = model.date;
            parameters[2].Value = model.paymentAccount;
            parameters[3].Value = model.receiptAccount;
            parameters[4].Value = model.amount;
            parameters[5].Value = model.summary;
            parameters[6].Value = model.handled;
            parameters[7].Value = model.departmentCode;
            parameters[8].Value = model.operators;
            parameters[9].Value = model.auditors;
            parameters[10].Value = model.checkState;

            try
            {
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_FinanceBankAccess]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
