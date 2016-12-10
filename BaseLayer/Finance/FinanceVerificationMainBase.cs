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
    public class FinanceVerificationMainBase
    {
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_FinanceVerificationMain]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public object AddToMainOrDetail(FinanceVerificationMain model, List<FinanceVerificationDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("insert into [T_FinanceVerificationMain] (");
                sqlMain.Append("summary,description,code,date,salesMan,departmentCode,operators,auditors,inClientCode,outClientCode,inSupplierCode,outSupplierCode,verificationType,checkState)");
                sqlMain.Append(" values (");
                sqlMain.Append("@summary,@description,@code,@date,@salesMan,@departmentCode,@operators,@auditors,@inClientCode,@outClientCode,@inSupplierCode,@outSupplierCode,@verificationType,@checkState)");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@summary", SqlDbType.NVarChar,400),
                    new SqlParameter("@description", SqlDbType.NVarChar,400),
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,20),
                    new SqlParameter("@departmentCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@operators", SqlDbType.NVarChar,20),
                    new SqlParameter("@auditors", SqlDbType.NVarChar,20),
                    new SqlParameter("@inClientCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@outClientCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@inSupplierCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@outSupplierCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@verificationType", SqlDbType.NVarChar,50),
                    new SqlParameter("@checkState",SqlDbType.Int)
                };
                spsMain[0].Value =model.summary;
                spsMain[1].Value =model.description;
                spsMain[2].Value =model.code;
                spsMain[3].Value =model.date;
                spsMain[4].Value =model.salesMan;
                spsMain[5].Value =model.departmentCode;
                spsMain[6].Value =model.operators;
                spsMain[7].Value =model.auditors;
                spsMain[8].Value =model.inClientCode;
                spsMain[9].Value = model.outClientCode;
                spsMain[10].Value =model.inSupplierCode;
                spsMain[11].Value =model.outSupplierCode;
                spsMain[12].Value = model.verificationType;
                spsMain[13].Value = model.checkState;

                hashTable.Add(sqlMain, spsMain);

                sqlDetail.Append("insert into [T_FinanceVerificationDetail] (");
                sqlDetail.Append("code,date,mainCode,sourceCode,sourceType,sourceAmount,alreadyVerificationAmount,notVerificationAmount,remark,theVerificationAmount)");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@code,@date,@mainCode,@sourceCode,@sourceType,@sourceAmount,@alreadyVerificationAmount,@notVerificationAmount,@remark,@theVerificationAmount)");
                sqlDetail.Append(";select @@IDENTITY");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@sourceCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@sourceType", SqlDbType.NVarChar,50),
                    new SqlParameter("@sourceAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@alreadyVerificationAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@notVerificationAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@theVerificationAmount",SqlDbType.Decimal,9)
                    };
                    spsDetail[0].Value =item.code;
                    spsDetail[1].Value =item.date;
                    spsDetail[2].Value =item.mainCode;
                    spsDetail[3].Value =item.sourceCode;
                    spsDetail[4].Value =item.sourceType;
                    spsDetail[5].Value =item.sourceAmount;
                    spsDetail[6].Value =item.alreadyVerificationAmount;
                    spsDetail[7].Value =item.notVerificationAmount;
                    spsDetail[8].Value = item.remark;
                    spsDetail[9].Value = item.theVerificationAmount;
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
        public object UpdateToMainOrDetail(FinanceVerificationMain model, List<FinanceVerificationDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("update [T_FinanceVerificationMain] set ");
                sqlMain.Append("summary=@summary,");
                sqlMain.Append("description=@description,");
                sqlMain.Append("date=@date,");
                sqlMain.Append("salesMan=@salesMan,");
                sqlMain.Append("departmentCode=@departmentCode,");
                sqlMain.Append("operators=@operators,");
                sqlMain.Append("auditors=@auditors,");
                sqlMain.Append("inClientCode=@inClientCode,");
                sqlMain.Append("outClientCode=@outClientCode,");
                sqlMain.Append("inSupplierCode=@inSupplierCode,");
                sqlMain.Append("outSupplierCode=@outSupplierCode,");
                sqlMain.Append("verificationType=@verificationType,");
                sqlMain.Append("checkState=@checkState");
                sqlMain.Append(" where code=@code ");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@summary", SqlDbType.NVarChar,400),
                    new SqlParameter("@description", SqlDbType.NVarChar,400),
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,20),
                    new SqlParameter("@departmentCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@operators", SqlDbType.NVarChar,20),
                    new SqlParameter("@auditors", SqlDbType.NVarChar,20),
                    new SqlParameter("@inClientCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@outClientCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@inSupplierCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@outSupplierCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@verificationType", SqlDbType.NVarChar,50),
                    new SqlParameter("@checkState",SqlDbType.Int)
                };
                spsMain[0].Value = model.summary;
                spsMain[1].Value = model.description;
                spsMain[2].Value = model.code;
                spsMain[3].Value = model.date;
                spsMain[4].Value = model.salesMan;
                spsMain[5].Value = model.departmentCode;
                spsMain[6].Value = model.operators;
                spsMain[7].Value = model.auditors;
                spsMain[8].Value = model.inClientCode;
                spsMain[9].Value = model.outClientCode;
                spsMain[10].Value = model.inSupplierCode;
                spsMain[11].Value = model.outSupplierCode;
                spsMain[12].Value = model.verificationType;
                spsMain[13].Value = model.checkState;

                hashTable.Add(sqlMain, spsMain);

                StringBuilder strInsert = new StringBuilder();
                strInsert.Append("insert into [T_FinanceVerificationDetail] (");
                strInsert.Append("code,date,mainCode,sourceCode,sourceType,sourceAmount,alreadyVerificationAmount,notVerificationAmount,remark,theVerificationAmount)");
                strInsert.Append(" values (");
                strInsert.Append("@code,@date,@mainCode,@sourceCode,@sourceType,@sourceAmount,@alreadyVerificationAmount,@notVerificationAmount,@remark,@theVerificationAmount)");
                strInsert.Append(";select @@IDENTITY");

                sqlDetail.Append("update [T_FinanceVerificationDetail] set ");
                sqlDetail.Append("date=@date,");
                sqlDetail.Append("mainCode=@mainCode,");
                sqlDetail.Append("sourceCode=@sourceCode,");
                sqlDetail.Append("sourceType=@sourceType,");
                sqlDetail.Append("sourceAmount=@sourceAmount,");
                sqlDetail.Append("alreadyVerificationAmount=@alreadyVerificationAmount,");
                sqlDetail.Append("notVerificationAmount=@notVerificationAmount,");
                sqlDetail.Append("remark=@remark,");
                sqlDetail.Append("theVerificationAmount=@theVerificationAmount");
                sqlDetail.Append(" where code=@code ");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@sourceCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@sourceType", SqlDbType.NVarChar,50),
                    new SqlParameter("@sourceAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@alreadyVerificationAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@notVerificationAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@theVerificationAmount",SqlDbType.Decimal,9)
                    };
                    spsDetail[0].Value = item.code;
                    spsDetail[1].Value = item.date;
                    spsDetail[2].Value = item.mainCode;
                    spsDetail[3].Value = item.sourceCode;
                    spsDetail[4].Value = item.sourceType;
                    spsDetail[5].Value = item.sourceAmount;
                    spsDetail[6].Value = item.alreadyVerificationAmount;
                    spsDetail[7].Value = item.notVerificationAmount;
                    spsDetail[8].Value = item.remark;
                    spsDetail[9].Value = item.theVerificationAmount;
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
    }
}
