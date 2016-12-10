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
    public class FinanceOtherExpensesInBase
    {
        public object AddToMainOrDetail(FinanceOtherExpensesIn model, List<FinanceOtherExpenseInDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("insert into [T_FinanceOtherExpensesIn] (");
                sqlMain.Append("code,type,supplierCode,clientCode,accountCode,settlementType,settlementNumber,date,salesCode,salesMan,operationMan,checkMan,abstract,isClear,updateDate)");
                sqlMain.Append(" values (");
                sqlMain.Append("@code,@type,@supplierCode,@clientCode,@accountCode,@settlementType,@settlementNumber,@date,@salesCode,@salesMan,@operationMan,@checkMan,@abstract,@isClear,@updateDate)");
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
                spsMain[7].Value = model.date;
                spsMain[8].Value = model.salesCode;
                spsMain[9].Value = model.salesMan;
                spsMain[10].Value = model.operationMan;
                spsMain[11].Value = model.checkMan;
                spsMain[12].Value = model.Abstract;
                spsMain[13].Value = model.isClear;
                spsMain[14].Value = model.updateDate;

                hashTable.Add(sqlMain, spsMain);

                sqlDetail.Append("insert into [T_FinanceOtherExpensesInDetail] (");
                sqlDetail.Append("code,mainCode,projectInCode,money,abstract,remark,updateDate)");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@code,@mainCode,@projectInCode,@money,@abstract,@remark,@updateDate)");
                sqlDetail.Append(";select @@IDENTITY");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                        new SqlParameter("@code", SqlDbType.NVarChar,45),
                        new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@projectInCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@money", SqlDbType.Decimal,9),
                        new SqlParameter("@abstract", SqlDbType.NVarChar,400),
                        new SqlParameter("@remark", SqlDbType.NVarChar,400),
                        new SqlParameter("@updateDate", SqlDbType.DateTime)
                    };
                    spsDetail[0].Value = item.mainCode;
                    spsDetail[0].Value = item.code;
                    spsDetail[1].Value = item.mainCode;
                    spsDetail[2].Value = item.projectInCode;
                    spsDetail[3].Value = item.money;
                    spsDetail[4].Value = item.Abstract;
                    spsDetail[5].Value = item.remark;
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
        public object UpdateToMainOrDetail(FinanceOtherExpensesIn model, List<FinanceOtherExpenseInDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("update [T_FinanceOtherExpensesIn] set ");
                sqlMain.Append("type=@type,");
                sqlMain.Append("supplierCode=@supplierCode,");
                sqlMain.Append("clientCode=@clientCode,");
                sqlMain.Append("accountCode=@accountCode,");
                sqlMain.Append("settlementType=@settlementType,");
                sqlMain.Append("settlementNumber=@settlementNumber,");
                sqlMain.Append("date=@date,");
                sqlMain.Append("salesCode=@salesCode,");
                sqlMain.Append("salesMan=@salesMan,");
                sqlMain.Append("operationMan=@operationMan,");
                sqlMain.Append("checkMan=@checkMan,");
                sqlMain.Append("abstract=@abstract,");
                sqlMain.Append("isClear=@isClear,");
                sqlMain.Append("updateDate=@updateDate");
                sqlMain.Append(" where code=@code ");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@type", SqlDbType.NVarChar,40),
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@clientCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@settlementType", SqlDbType.NVarChar,50),
                    new SqlParameter("@settlementNumber", SqlDbType.NVarChar,50),
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
                spsMain[0].Value = model.code;
                spsMain[1].Value = model.type;
                spsMain[2].Value = model.supplierCode;
                spsMain[3].Value = model.clientCode;
                spsMain[4].Value = model.accountCode;
                spsMain[5].Value = model.settlementType;
                spsMain[6].Value = model.settlementNumber;
                spsMain[7].Value = model.date;
                spsMain[8].Value = model.salesCode;
                spsMain[9].Value = model.salesMan;
                spsMain[10].Value = model.operationMan;
                spsMain[11].Value = model.checkMan;
                spsMain[12].Value = model.Abstract;
                spsMain[13].Value = model.isClear;
                spsMain[14].Value = model.updateDate;

                hashTable.Add(sqlMain, spsMain);

                StringBuilder strInsert = new StringBuilder();
                strInsert.Append("insert into [T_FinanceOtherExpensesInDetail] (");
                strInsert.Append("code,mainCode,projectInCode,money,abstract,remark,updateDate)");
                strInsert.Append(" values (");
                strInsert.Append("@code,@mainCode,@projectInCode,@money,@abstract,@remark,@updateDate)");
                strInsert.Append(";select @@IDENTITY");


                sqlDetail.Append("update [T_FinanceOtherExpensesInDetail] set ");
                sqlDetail.Append("mainCode=@mainCode,");
                sqlDetail.Append("projectInCode=@projectInCode,");
                sqlDetail.Append("money=@money,");
                sqlDetail.Append("abstract=@abstract,");
                sqlDetail.Append("remark=@remark,");
                sqlDetail.Append("updateDate=@updateDate");
                sqlDetail.Append(" where code=@code ");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@projectInCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@money", SqlDbType.Decimal,9),
                    new SqlParameter("@abstract", SqlDbType.NVarChar,400),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@updateDate", SqlDbType.DateTime)
                    };
                    spsDetail[0].Value = item.code;
                    spsDetail[1].Value = item.mainCode;
                    spsDetail[2].Value = item.projectInCode;
                    spsDetail[3].Value = item.money;
                    spsDetail[4].Value = item.Abstract;
                    spsDetail[5].Value = item.remark;
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
            strSql.Append("select count(1) from [T_FinanceOtherExpensesIn]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
