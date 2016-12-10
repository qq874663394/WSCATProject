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
    public class FinanceCollectionBase
    {
        public object AddToMainOrDetail(FinanceCollection model, List<FinanceCollectionDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("insert into [T_FinanceCollection] (");
                sqlMain.Append("code,clientCode,clientName,accountCode,accountName,saleMainCode,date,operationMan,checkMan,salesMan,salesCode,checkState,remark,Reserved1,Reserved2,isClear,financeCollectionState,updatedate,type,settlementMethod,discount,totalCollection)");
                sqlMain.Append(" values (");
                sqlMain.Append("@code,@clientCode,@clientName,@accountCode,@accountName,@saleMainCode,@date,@operationMan,@checkMan,@salesMan,@salesCode,@checkState,@remark,@Reserved1,@Reserved2,@isClear,@financeCollectionState,@updatedate,@type,@settlementMethod,@discount,@totalCollection)");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@clientCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@clientName", SqlDbType.NVarChar,40),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@accountName", SqlDbType.NVarChar,40),
                    new SqlParameter("@saleMainCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@operationMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkMan", SqlDbType.NChar,10),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@salesCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@Reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@financeCollectionState", SqlDbType.Int,4),
                    new SqlParameter("@updatedate", SqlDbType.DateTime),
                    new SqlParameter("@type", SqlDbType.NVarChar,40),
                    new SqlParameter("@settlementMethod", SqlDbType.NVarChar,40),
                    new SqlParameter("@discount", SqlDbType.Decimal,9),
                    new SqlParameter("@totalCollection", SqlDbType.Decimal,9)
                };
                spsMain[0].Value = model.code;
                spsMain[1].Value = model.clientCode;
                spsMain[2].Value = model.clientName;
                spsMain[3].Value = model.accountCode;
                spsMain[4].Value = model.accountName;
                spsMain[5].Value = model.saleCode;
                spsMain[6].Value = model.date;
                spsMain[7].Value = model.operationMan;
                spsMain[8].Value = model.checkMan;
                spsMain[9].Value = model.salesMan;
                spsMain[10].Value = model.salesCode;
                spsMain[11].Value = model.checkState;
                spsMain[12].Value = model.remark;
                spsMain[13].Value = model.Reserved1;
                spsMain[14].Value = model.Reserved2;
                spsMain[15].Value = model.isClear;
                spsMain[16].Value = model.financeCollectionState;
                spsMain[17].Value = model.updatedate;
                spsMain[18].Value = model.type;
                spsMain[19].Value = model.settlementMethod;
                spsMain[20].Value = model.discount;
                spsMain[21].Value = model.totalCollection;

                hashTable.Add(sqlMain, spsMain);
                sqlDetail.Append("insert into [T_FinanceCollectionDetail] (");
                sqlDetail.Append("mainCode,code,saleCode,salesDate,salesType,amountReceivable,amountReceived,amountUnpaid,nowMoney,unCollection,remark)");
                sqlDetail.Append(" values (");
                sqlDetail.Append(@"@mainCode,
                    @code,
@saleCode,
@salesDate,
@salesType,
@amountReceivable,
@amountReceived,
@amountUnpaid,
@nowMoney,
@unCollection,@remark)");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@saleCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@salesDate", SqlDbType.DateTime),
                    new SqlParameter("@salesType", SqlDbType.NVarChar,40),
                    new SqlParameter("@amountReceivable", SqlDbType.Decimal,9),
                    new SqlParameter("@amountReceived", SqlDbType.Decimal,9),
                    new SqlParameter("@amountUnpaid", SqlDbType.Decimal,9),
                    new SqlParameter("@nowMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@unCollection", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400)
                    };
                    spsDetail[0].Value = item.mainCode;
                    spsDetail[1].Value = item.code;
                    spsDetail[2].Value = item.saleCode;
                    spsDetail[3].Value = item.salesDate;
                    spsDetail[4].Value = item.salesType;
                    spsDetail[5].Value = item.amountReceivable;
                    spsDetail[6].Value = item.amountReceived;
                    spsDetail[7].Value = item.amountUnpaid;
                    spsDetail[8].Value = item.nowMoney;
                    spsDetail[9].Value = item.unCollection;
                    spsDetail[10].Value = item.remark;
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
        public object UpdateToMainOrDetail(FinanceCollection model, List<FinanceCollectionDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {

                sqlDetail.Append("update [T_FinanceCollection] set ");
                sqlDetail.Append("clientCode=@clientCode,");
                sqlDetail.Append("clientName=@clientName,");
                sqlDetail.Append("accountCode=@accountCode,");
                sqlDetail.Append("accountName=@accountName,");
                sqlDetail.Append("saleMainCode=@saleMainCode,");
                sqlDetail.Append("date=@date,");
                sqlDetail.Append("operationMan=@operationMan,");
                sqlDetail.Append("checkMan=@checkMan,");
                sqlDetail.Append("salesMan=@salesMan,");
                sqlDetail.Append("salesCode=@salesCode,");
                sqlDetail.Append("checkState=@checkState,");
                sqlDetail.Append("remark=@remark,");
                sqlDetail.Append("Reserved1=@Reserved1,");
                sqlDetail.Append("Reserved2=@Reserved2,");
                sqlDetail.Append("isClear=@isClear,");
                sqlDetail.Append("financeCollectionState=@financeCollectionState,");
                sqlDetail.Append("updatedate=@updatedate,");
                sqlDetail.Append("type=@type,");
                sqlDetail.Append("settlementMethod=@settlementMethod,");
                sqlDetail.Append("discount=@discount,");
                sqlDetail.Append("totalCollection=@totalCollection");
                sqlDetail.Append(" where code=@code ");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@clientCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@clientName", SqlDbType.NVarChar,40),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@accountName", SqlDbType.NVarChar,40),
                    new SqlParameter("@saleMainCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@operationMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkMan", SqlDbType.NChar,10),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@salesCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@Reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@Reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@financeCollectionState", SqlDbType.Int,4),
                    new SqlParameter("@updatedate", SqlDbType.DateTime),
                    new SqlParameter("@type", SqlDbType.NVarChar,40),
                    new SqlParameter("@settlementMethod", SqlDbType.NVarChar,40),
                    new SqlParameter("@discount", SqlDbType.Decimal,9),
                    new SqlParameter("@totalCollection", SqlDbType.Decimal,9),
                    new SqlParameter("@code", SqlDbType.NVarChar,45)
                };
                spsMain[0].Value = model.code;
                spsMain[1].Value = model.clientCode;
                spsMain[2].Value = model.clientName;
                spsMain[3].Value = model.accountCode;
                spsMain[4].Value = model.accountName;
                spsMain[5].Value = model.saleCode;
                spsMain[6].Value = model.date;
                spsMain[7].Value = model.operationMan;
                spsMain[8].Value = model.checkMan;
                spsMain[9].Value = model.salesMan;
                spsMain[10].Value = model.salesCode;
                spsMain[11].Value = model.checkState;
                spsMain[12].Value = model.remark;
                spsMain[13].Value = model.Reserved1;
                spsMain[14].Value = model.Reserved2;
                spsMain[15].Value = model.isClear;
                spsMain[16].Value = model.financeCollectionState;
                spsMain[17].Value = model.updatedate;
                spsMain[18].Value = model.type;
                spsMain[19].Value = model.settlementMethod;
                spsMain[20].Value = model.discount;
                spsMain[21].Value = model.totalCollection;

                hashTable.Add(sqlMain, spsMain);
                StringBuilder strInsert = new StringBuilder();
                strInsert.Append("insert into [T_FinanceCollectionDetail] (");
                strInsert.Append("mainCode,code,saleCode,salesDate,salesType,amountReceivable,amountReceived,amountUnpaid,nowMoney,unCollection,remark)");
                strInsert.Append(" values (");
                strInsert.Append(@"@mainCode,
                    @code,
                    @saleCode,
                    @salesDate,
                    @salesType,
                    @amountReceivable,
                    @amountReceived,
                    @amountUnpaid,
                    @nowMoney,
                    @unCollection,@remark)");
strInsert.Append(";select @@IDENTITY");

                sqlMain.Append("update [T_FinanceCollectionDetail] set ");
                sqlMain.Append("mainCode=@mainCode,");
                sqlMain.Append("saleCode=@saleCode,");
                sqlMain.Append("salesDate=@salesDate,");
                sqlMain.Append("salesType=@salesType,");
                sqlMain.Append("amountReceivable=@amountReceivable,");
                sqlMain.Append("amountReceived=@amountReceived,");
                sqlMain.Append("amountUnpaid=@amountUnpaid,");
                sqlMain.Append("nowMoney=@nowMoney,");
                sqlMain.Append("unCollection=@unCollection,");
                sqlMain.Append("remark=@remark");
                sqlMain.Append(" where code=@code and mainCode=@mainCode");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@saleCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@salesDate", SqlDbType.DateTime),
                    new SqlParameter("@salesType", SqlDbType.NVarChar,40),
                    new SqlParameter("@amountReceivable", SqlDbType.Decimal,9),
                    new SqlParameter("@amountReceived", SqlDbType.Decimal,9),
                    new SqlParameter("@amountUnpaid", SqlDbType.Decimal,9),
                    new SqlParameter("@nowMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@unCollection", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@code", SqlDbType.NVarChar,45)
                    };
                    spsDetail[1].Value = item.mainCode;
                    spsDetail[2].Value = item.code;
                    spsDetail[3].Value = item.saleCode;
                    spsDetail[4].Value = item.salesDate;
                    spsDetail[5].Value = item.salesType;
                    spsDetail[6].Value = item.amountReceivable;
                    spsDetail[7].Value = item.amountReceived;
                    spsDetail[8].Value = item.amountUnpaid;
                    spsDetail[9].Value = item.nowMoney;
                    spsDetail[10].Value = item.unCollection;
                    spsDetail[11].Value = item.remark;
                    list.Add(spsDetail);
                }
                result = DbHelperSQL.ExecuteSqlTranScalar(hashTable, sqlDetail.ToString(),strInsert.ToString(), list);
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
            strSql.Append("select count(1) from [T_FinanceCollection]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
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
                sql = "select * from T_FinanceCollection fin,T_FinanceCollectionDetail tf";
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
