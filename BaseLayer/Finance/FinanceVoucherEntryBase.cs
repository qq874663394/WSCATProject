using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model.Finance;
using System.Data.SqlClient;
using System.Collections;

namespace BaseLayer.Base
{
    public class FinanceVoucherEntryBase
    {
        /// <summary>
        /// 获取上一单数据
        /// </summary>
        /// <param name="entryCode"></param>
        /// <returns></returns>
        public DataTable GetLastDetail(string entryCode)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select fvem.code,
fvem.date,
fvem.examine,
fvem.posting,
fvem.makeMan,
fvem.examineState,
fved.code,
fved.summary,
fved.subject,
fved.debitAmount,
fved.creditAmount,
fved.id
 from T_FinanceVoucherEntryMain fvem,T_FinanceVoucherEntryDetail fved
where fvem.code=fved.mainCode and 
fvem.code= (select top 1 code from T_FinanceVoucherEntryMain where id <
(select id from T_FinanceVoucherEntryMain where code = '{0}') order by id desc)", entryCode);
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        /// <summary>
        /// 默认的上一单数据
        /// </summary>
        /// <param name="entryCode"></param>
        /// <returns></returns>
        public DataTable GetFLastDetail(string entryCode)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select fvem.code,
fvem.date,
fvem.examine,
fvem.posting,
fvem.makeMan,
fvem.examineState,
fved.code,
fved.summary,
fved.subject,
fved.debitAmount,
fved.creditAmount,
fved.id
 from T_FinanceVoucherEntryMain fvem,T_FinanceVoucherEntryDetail fved
where fvem.code=fved.mainCode and 
fvem.code= (select top 1 code from T_FinanceVoucherEntryMain where id =
(select id from T_FinanceVoucherEntryMain where code = '{0}') order by id desc)", entryCode);
                dt = DbHelperSQL.Query(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取下一单数据
        /// </summary>
        /// <param name="entryCode"></param>
        /// <returns></returns>
        public DataTable GetNextDetail(string entryCode)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select fvem.code,
fvem.date,
fvem.examine,
fvem.posting,
fvem.makeMan,
fvem.examineState,
fved.code,
fved.summary,
fved.subject,
fved.debitAmount,
fved.creditAmount,
fved.id
 from T_FinanceVoucherEntryMain fvem,T_FinanceVoucherEntryDetail fved
where fvem.code=fved.mainCode and 
fvem.code= (select top 1 code from T_FinanceVoucherEntryMain where id >
(select id from T_FinanceVoucherEntryMain where code = '{0}'))", entryCode);
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        /// <summary>
        /// 获取最新的code
        /// </summary>
        /// <returns></returns>
        public string GetNewCode()
        {
            string sql = "";
            object result = null;
            try
            {
                sql = "select top 1 code from  T_FinanceVoucherEntryMain order by id desc";
                result = DbHelperSQL.GetSingle(sql);
                if (result == null)
                {
                    return "";
                }
                else
                {
                    return result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object AddToMainOrDetail(FinanceVoucherEntryMain model, List<FinanceVoucherEntryDetail> modelDetail)
        {
            Hashtable hashTable = new Hashtable();//主表sql语句和语句的参数
            List<SqlParameter[]> list = new List<SqlParameter[]>();//从表的参数
            StringBuilder sqlMain = new StringBuilder();//主表sql语句
            StringBuilder sqlDetail = new StringBuilder();//从表sql语句
            object result = null;//操作结果,默认null
            try
            {
                sqlMain.Append("insert into [T_FinanceVoucherEntryMain] (");
                sqlMain.Append("code,date,examine,posting,makeMan,examineState,isClear)");
                sqlMain.Append(" values (");
                sqlMain.Append("@code,@date,@examine,@posting,@makeMan,@examineState,@isClear)");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@examine", SqlDbType.NVarChar,20),
                    new SqlParameter("@posting", SqlDbType.NVarChar,20),
                    new SqlParameter("@makeMan", SqlDbType.NVarChar,20),
                    new SqlParameter("@examineState", SqlDbType.Int,4),
                    new SqlParameter("@isClear", SqlDbType.Int,4)
                };
                spsMain[0].Value = model.code;
                spsMain[1].Value = model.date;
                spsMain[2].Value = model.examine;
                spsMain[3].Value = model.posting;
                spsMain[4].Value = model.makeMan;
                spsMain[5].Value = model.examineState;
                spsMain[6].Value = model.isClear;

                hashTable.Add(sqlMain, spsMain);

                sqlDetail.Append("insert into [T_FinanceVoucherEntryDetail] (");
                sqlDetail.Append("code,mainCode,summary,subject,debitAmount,creditAmount)");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@code,@mainCode,@summary,@subject,@debitAmount,@creditAmount)");
                sqlDetail.Append(";select @@IDENTITY");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                        new SqlParameter("@code", SqlDbType.NVarChar,50),
                        new SqlParameter("@mainCode", SqlDbType.NVarChar,50),
                        new SqlParameter("@summary", SqlDbType.NVarChar,200),
                        new SqlParameter("@subject", SqlDbType.NVarChar,50),
                        new SqlParameter("@debitAmount", SqlDbType.Decimal,9),
                        new SqlParameter("@creditAmount", SqlDbType.Decimal,9)
                    };
                    spsDetail[0].Value = item.code;
                    spsDetail[1].Value = item.mainCode;
                    spsDetail[2].Value = item.summary;
                    spsDetail[3].Value = item.subject;
                    spsDetail[4].Value = item.debitAmount;
                    spsDetail[5].Value = item.creditAmount;
                    list.Add(spsDetail);
                }
                result = DbHelperSQL.ExecuteSqlTranScalar(hashTable, sqlDetail.ToString(), list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object UpdateToMainOrDetail(FinanceVoucherEntryMain model, List<FinanceVoucherEntryDetail> modelDetail)
        {
            Hashtable hashTable = new Hashtable();//主表sql语句和语句的参数
            List<SqlParameter[]> list = new List<SqlParameter[]>();//从表的参数
            StringBuilder sqlMain = new StringBuilder();//主表sql语句
            StringBuilder sqlDetail = new StringBuilder();//从表sql语句
            object result = null;//操作结果,默认null
            try
            {
                sqlMain.Append("update [T_FinanceVoucherEntryMain] set ");
                sqlMain.Append("date=@date,");
                sqlMain.Append("examine=@examine,");
                sqlMain.Append("posting=@posting,");
                sqlMain.Append("makeMan=@makeMan,");
                sqlMain.Append("examineState=@examineState,");
                sqlMain.Append("isClear=@isClear");
                sqlMain.Append(" where code=@code ");
                SqlParameter[] spsMain = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@examine", SqlDbType.NVarChar,20),
                    new SqlParameter("@posting", SqlDbType.NVarChar,20),
                    new SqlParameter("@makeMan", SqlDbType.NVarChar,20),
                    new SqlParameter("@examineState", SqlDbType.Int,4),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@date", SqlDbType.DateTime)};
                spsMain[0].Value = model.code;
                spsMain[1].Value = model.examine;
                spsMain[2].Value = model.posting;
                spsMain[3].Value = model.makeMan;
                spsMain[4].Value = model.examineState;
                spsMain[5].Value = model.isClear;
                spsMain[6].Value = model.date;

                hashTable.Add(sqlMain, spsMain);

                sqlDetail.Append("update [T_FinanceVoucherEntryDetail] set ");
                //sqlDetail.Append("mainCode=@mainCode,");
                sqlDetail.Append("summary=@summary,");
                sqlDetail.Append("subject=@subject,");
                sqlDetail.Append("debitAmount=@debitAmount,");
                sqlDetail.Append("creditAmount=@creditAmount");
                sqlDetail.Append(" where id=@id ");
                //sqlDetail.Append(";select @@IDENTITY");

                StringBuilder sqlInsert = new StringBuilder();
                sqlInsert.Append("insert into [T_FinanceVoucherEntryDetail] (");
                sqlInsert.Append("code,mainCode,summary,subject,debitAmount,creditAmount)");
                sqlInsert.Append(" values (");
                sqlInsert.Append("@code,@mainCode,@summary,@subject,@debitAmount,@creditAmount)");
                sqlInsert.Append(";select @@IDENTITY");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@summary", SqlDbType.NVarChar,200),
                    new SqlParameter("@subject", SqlDbType.NVarChar,50),
                    new SqlParameter("@debitAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@creditAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@id", SqlDbType.Int)
                    };
                    spsDetail[0].Value = item.mainCode;
                    spsDetail[1].Value = item.summary;
                    spsDetail[2].Value = item.subject;
                    spsDetail[3].Value = item.debitAmount;
                    spsDetail[4].Value = item.creditAmount;
                    spsDetail[5].Value = item.id;
                    list.Add(spsDetail);
                }
                result = DbHelperSQL.ExecuteSqlTranScalar(hashTable, sqlDetail.ToString(), sqlInsert.ToString(), list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 判断指定数据是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_FinanceVoucherEntryMain]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
