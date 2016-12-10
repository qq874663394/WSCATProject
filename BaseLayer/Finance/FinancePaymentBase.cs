using Model;
using Model.Finance;
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
    public class FinancePaymentBase
    {
        public object AddToMainOrDetail(FinancePayment model, List<FinancePaymentDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("insert into [T_FinancePayment] (");
                sqlMain.Append("code,supplierCode,supplierName,accountCode,accountName,saleCode,date,operationMan,checkMan,salesMan,salesCode,checkState,remark,Reserved1,Reserved2,isClear,financeCollectionState,updatedate,type,settlementMethod,discount,totalCollection)");
                sqlMain.Append(" values (");
                sqlMain.Append("@code,@supplierCode,@supplierName,@accountCode,@accountName,@saleCode,@date,@operationMan,@checkMan,@salesMan,@salesCode,@checkState,@remark,@Reserved1,@Reserved2,@isClear,@financeCollectionState,@updatedate,@type,@settlementMethod,@discount,@totalCollection)");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@supplierName", SqlDbType.NVarChar,40),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@accountName", SqlDbType.NVarChar,40),
                    new SqlParameter("@saleCode", SqlDbType.NVarChar,45),
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
                spsMain[1].Value = model.supplierCode;
                spsMain[2].Value = model.supplierName;
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

                sqlDetail.Append("insert into [T_FinancePaymentDetail] (");
                sqlDetail.Append("mainCode,code,purchaseCode,salesDate,salesType,amountReceivable,amountReceived,amountUnpaid,nowMoney,unCollection,remark)");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@mainCode,@code,@purchaseCode,@salesDate,@salesType,@amountReceivable,@amountReceived,@amountUnpaid,@nowMoney,@unCollection,@remark)");
                sqlDetail.Append(";select @@IDENTITY");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@purchaseCode", SqlDbType.NVarChar,45),
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
                    spsDetail[2].Value = item.purchaseCode;
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
        public object UpdateToMainOrDetail(FinancePayment model, List<FinancePaymentDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("update [T_FinancePayment] set ");
                sqlMain.Append("supplierCode=@supplierCode,");
                sqlMain.Append("supplierName=@supplierName,");
                sqlMain.Append("accountCode=@accountCode,");
                sqlMain.Append("accountName=@accountName,");
                sqlMain.Append("saleCode=@saleCode,");
                sqlMain.Append("date=@date,");
                sqlMain.Append("operationMan=@operationMan,");
                sqlMain.Append("checkMan=@checkMan,");
                sqlMain.Append("salesMan=@salesMan,");
                sqlMain.Append("salesCode=@salesCode,");
                sqlMain.Append("checkState=@checkState,");
                sqlMain.Append("remark=@remark,");
                sqlMain.Append("Reserved1=@Reserved1,");
                sqlMain.Append("Reserved2=@Reserved2,");
                sqlMain.Append("isClear=@isClear,");
                sqlMain.Append("financeCollectionState=@financeCollectionState,");
                sqlMain.Append("updatedate=@updatedate,");
                sqlMain.Append("type=@type,");
                sqlMain.Append("settlementMethod=@settlementMethod,");
                sqlMain.Append("discount=@discount,");
                sqlMain.Append("totalCollection=@totalCollection");
                sqlMain.Append(" where code=@code ");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@supplierName", SqlDbType.NVarChar,40),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@accountName", SqlDbType.NVarChar,40),
                    new SqlParameter("@saleCode", SqlDbType.NVarChar,45),
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
                spsMain[0].Value =model.code;
                spsMain[1].Value =model.supplierCode;
                spsMain[2].Value =model.supplierName;
                spsMain[3].Value =model.accountCode;
                spsMain[4].Value =model.accountName;
                spsMain[5].Value =model.saleCode;
                spsMain[6].Value =model.date;
                spsMain[7].Value =model.operationMan;
                spsMain[8].Value =model.checkMan;
                spsMain[9].Value = model.salesMan;
                spsMain[10].Value =model.salesCode;
                spsMain[11].Value =model.checkState;
                spsMain[12].Value =model.remark;
                spsMain[13].Value =model.Reserved1;
                spsMain[14].Value =model.Reserved2;
                spsMain[15].Value =model.isClear;
                spsMain[16].Value =model.financeCollectionState;
                spsMain[17].Value =model.updatedate;
                spsMain[18].Value =model.type;
                spsMain[19].Value =model.settlementMethod;
                spsMain[20].Value =model.discount;
                spsMain[21].Value = model.totalCollection;

                hashTable.Add(sqlMain, spsMain);
                StringBuilder strInsert = new StringBuilder();
                strInsert.Append("insert into [T_FinancePaymentDetail] (");
                strInsert.Append("mainCode,code,purchaseCode,salesDate,salesType,amountReceivable,amountReceived,amountUnpaid,nowMoney,unCollection,remark)");
                strInsert.Append(" values (");
                strInsert.Append("@mainCode,@code,@purchaseCode,@salesDate,@salesType,@amountReceivable,@amountReceived,@amountUnpaid,@nowMoney,@unCollection,@remark)");
                strInsert.Append(";select @@IDENTITY");

                sqlDetail.Append("update [T_FinancePaymentDetail] set ");
                sqlDetail.Append("mainCode=@mainCode,");
                sqlDetail.Append("purchaseCode=@purchaseCode,");
                sqlDetail.Append("salesDate=@salesDate,");
                sqlDetail.Append("salesType=@salesType,");
                sqlDetail.Append("amountReceivable=@amountReceivable,");
                sqlDetail.Append("amountReceived=@amountReceived,");
                sqlDetail.Append("amountUnpaid=@amountUnpaid,");
                sqlDetail.Append("nowMoney=@nowMoney,");
                sqlDetail.Append("unCollection=@unCollection,");
                sqlDetail.Append("remark=@remark");
                sqlDetail.Append(" where code=@code ");
                strInsert.Append(";select @@IDENTITY");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@purchaseCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@salesDate", SqlDbType.DateTime),
                    new SqlParameter("@salesType", SqlDbType.NVarChar,40),
                    new SqlParameter("@amountReceivable", SqlDbType.Decimal,9),
                    new SqlParameter("@amountReceived", SqlDbType.Decimal,9),
                    new SqlParameter("@amountUnpaid", SqlDbType.Decimal,9),
                    new SqlParameter("@nowMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@unCollection", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400)
                    };
                    spsDetail[0].Value =item.mainCode;
                    spsDetail[1].Value =item.code;
                    spsDetail[2].Value =item.purchaseCode;
                    spsDetail[3].Value =item.salesDate;
                    spsDetail[4].Value =item.salesType;
                    spsDetail[5].Value =item.amountReceivable;
                    spsDetail[6].Value =item.amountReceived;
                    spsDetail[7].Value =item.amountUnpaid;
                    spsDetail[8].Value =item.nowMoney;
                    spsDetail[9].Value = item.unCollection;
                    spsDetail[10].Value = item.remark;
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
        /// <summary>
        /// false不存在，true存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_FinancePayment]");
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
                sql = "select * from T_FinancePayment tf ,T_FinancePaymentDetail pd";
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