using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Finance
{
    public class FinanceOtherExpensesOutBase
    {
        public object AddToMainOrDetail(FinanceOtherExpensesOut model, List<FinanceOtherExpensesOutDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("insert into [T_FinanceOtherExpensesOut] (");
                sqlMain.Append("code,type,supplierCode,clientCode,accountCode,settlementType,settlementNumber,settlementMoney,date,salesCode,salesMan,operationMan,checkMan,abstract,isClear,updateDate)");
                sqlMain.Append(" values (");
                sqlMain.Append("@code,@type,@supplierCode,@clientCode,@accountCode,@settlementType,@settlementNumber,@settlementMoney,@date,@salesCode,@salesMan,@operationMan,@checkMan,@abstract,@isClear,@updateDate)");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@type", SqlDbType.NVarChar,40),
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@clientCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@settlementType", SqlDbType.NVarChar,50),
                    new SqlParameter("@settlementNumber", SqlDbType.NVarChar,50),
                    new SqlParameter("@settlementMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@salesCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@operationMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@abstract", SqlDbType.NVarChar,400),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@updateDate", SqlDbType.DateTime)
                };
                spsMain[0].Value = model.code;
                spsMain[1].Value = model.type;
                spsMain[2].Value = model.supplierCode;
                spsMain[3].Value = model.clientCode;
                spsMain[4].Value = model.accountCode;
                spsMain[5].Value = model.settlementType;
                spsMain[6].Value = model.settlementNumber;
                spsMain[7].Value = model.settlementMoney;
                spsMain[8].Value = model.date;
                spsMain[9].Value = model.salesCode;
                spsMain[10].Value = model.salesMan;
                spsMain[11].Value = model.operationMan;
                spsMain[12].Value = model.checkMan;
                spsMain[13].Value = model.Abstract;
                spsMain[14].Value = model.isClear;
                spsMain[15].Value = model.updateDate;

                hashTable.Add(sqlMain, spsMain);

                sqlDetail.Append("insert into [T_FinanceOtherExpensesOutDetail] (");
                sqlDetail.Append("outCode,projectOutCode,money,material,remark,Reserved1,updateDate)");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@outCode,@projectOutCode,@money,@material,@remark,@Reserved1,@updateDate)");
                sqlDetail.Append(";select @@IDENTITY");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                        new SqlParameter("@outCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@projectOutCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@money", SqlDbType.Decimal,9),
                        new SqlParameter("@material", SqlDbType.NVarChar,400),
                        new SqlParameter("@remark", SqlDbType.NVarChar,400),
                        new SqlParameter("@Reserved1", SqlDbType.NVarChar,50),
                        new SqlParameter("@updateDate", SqlDbType.DateTime)
                    };
                    spsDetail[0].Value = item.outCode;
                    spsDetail[1].Value = item.projectOutCode;
                    spsDetail[2].Value = item.money;
                    spsDetail[3].Value = item.material;
                    spsDetail[4].Value = item.remark;
                    spsDetail[5].Value = item.Reserved1;
                    spsDetail[6].Value = item.updateDate;

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
        public object UpdateToMainOrDetail(FinanceOtherExpensesOut model, List<FinanceOtherExpensesOutDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("update [T_FinanceOtherExpensesOut] set ");
                sqlMain.Append("type=@type,");
                sqlMain.Append("supplierCode=@supplierCode,");
                sqlMain.Append("clientCode=@clientCode,");
                sqlMain.Append("accountCode=@accountCode,");
                sqlMain.Append("settlementType=@settlementType,");
                sqlMain.Append("settlementNumber=@settlementNumber,");
                sqlMain.Append("settlementMoney=@settlementMoney,");
                sqlMain.Append("date=@date,");
                sqlMain.Append("salesCode=@salesCode,");
                sqlMain.Append("salesMan=@salesMan,");
                sqlMain.Append("operationMan=@operationMan,");
                sqlMain.Append("checkMan=@checkMan,");
                sqlMain.Append("abstract=@abstract,");
                sqlMain.Append("isClear=@isClear,");
                sqlMain.Append("updateDate=@updateDate,");
                sqlMain.Append("checkState=@checkState");
                sqlMain.Append(" where code=@code");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@type", SqlDbType.NVarChar,40),
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@clientCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@settlementType", SqlDbType.NVarChar,50),
                    new SqlParameter("@settlementNumber", SqlDbType.NVarChar,50),
                    new SqlParameter("@settlementMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@salesCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@operationMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@abstract", SqlDbType.NVarChar,400),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@checkState", SqlDbType.Int,4)
                };
                spsMain[0].Value = model.code;
                spsMain[1].Value = model.type;
                spsMain[2].Value = model.supplierCode;
                spsMain[3].Value = model.clientCode;
                spsMain[4].Value = model.accountCode;
                spsMain[5].Value = model.settlementType;
                spsMain[6].Value = model.settlementNumber;
                spsMain[7].Value = model.settlementMoney;
                spsMain[8].Value = model.date;
                spsMain[9].Value = model.salesCode;
                spsMain[10].Value = model.salesMan;
                spsMain[11].Value = model.operationMan;
                spsMain[12].Value = model.checkMan;
                spsMain[13].Value = model.Abstract;
                spsMain[14].Value = model.isClear;
                spsMain[15].Value = model.updateDate;
                spsMain[16].Value = model.checkState;

                hashTable.Add(sqlMain, spsMain);

                StringBuilder strInsert = new StringBuilder();
                strInsert.Append("insert into [T_FinanceOtherExpensesOutDetail] (");
                strInsert.Append("outCode,projectOutCode,money,material,remark,Reserved1,updateDate)");
                strInsert.Append(" values (");
                strInsert.Append("@outCode,@projectOutCode,@money,@material,@remark,@Reserved1,@updateDate)");

                sqlDetail.Append("update [T_FinanceOtherExpensesOutDetail] set ");
                //sqlDetail.Append("outCode=@outCode,");
                //sqlDetail.Append("projectOutCode=@projectOutCode,");
                sqlDetail.Append("money=@money,");
                sqlDetail.Append("material=@material,");
                sqlDetail.Append("remark=@remark,");
                sqlDetail.Append("Reserved1=@Reserved1,");
                sqlDetail.Append("updateDate=@updateDate");
                sqlDetail.Append(" where projectOutCode=@projectOutCode ");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@outCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@projectOutCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@money", SqlDbType.Decimal,9),
                    new SqlParameter("@material", SqlDbType.NVarChar,400),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@Reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@updateDate", SqlDbType.DateTime)
                    };
                    spsDetail[0].Value = item.outCode;
                    spsDetail[1].Value = item.projectOutCode;
                    spsDetail[2].Value = item.money;
                    spsDetail[3].Value = item.material;
                    spsDetail[4].Value = item.remark;
                    spsDetail[5].Value = item.Reserved1;
                    spsDetail[6].Value = item.updateDate;
                    list.Add(spsDetail);
                }
                result = DbHelperSQL.ExecuteSqlTranScalar(hashTable, sqlDetail.ToString(), strInsert.ToString(), list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_FinanceOtherExpensesOut]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

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
                sql = string.Format(@"select foe.*,foed.*
 from T_FinanceOtherExpensesOut foe,T_FinanceOtherExpensesOutDetail foed
where foe.code=foed.outCode and 
foe.code= (select top 1 code from T_FinanceOtherExpensesOut where id <
(select id from T_FinanceOtherExpensesOut where code = '{0}') order by id desc)", entryCode);
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
                sql = string.Format(@"select foe.*,foed.*
 from T_FinanceOtherExpensesOut foe,T_FinanceOtherExpensesOutDetail foed
where foe.code=foed.outCode and 
foe.code= (select top 1 code from T_FinanceOtherExpensesOut where id =
(select id from T_FinanceOtherExpensesOut where code = '{0}') order by id desc)", entryCode);
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
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
                sql = string.Format(@"select foe.*,foed.*
 from T_FinanceOtherExpensesOut foe,T_FinanceOtherExpensesOutDetail foed
where foe.code=foed.outCode and 
foe.code= (select top 1 code from T_FinanceOtherExpensesOut where id >
(select id from T_FinanceOtherExpensesOut where code = '{0}'))", entryCode);
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
                sql = "select top 1 code from  T_FinanceOtherExpensesOut order by id desc";
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
    }
}
