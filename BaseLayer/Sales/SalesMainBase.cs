using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Sales
{
    public class SalesMainBase
    {
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            DataTable dt = null;
            string sql = "select * from T_SalesMain";
            try
            {
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
        /// 查询id和code列
        /// </summary>
        /// <param name="clientCode">客户code</param>
        /// <returns></returns>
        public DataTable GetTableByClientCode(string clientCode)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format("select id,code from T_SalesMain where clientCode='{0}'", clientCode);
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object AddToMainOrDetail(SalesMain model, List<SalesDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("insert into [T_SalesMain] (");
                sqlMain.Append("isClear,code,type,date,salesOrderState,checkState,operationMan,checkMan,salesMan,payState,payMathod,oddAllMoney,accountCode,collectMoney,lastMoney,clientAddress,clientCode,clientName,clientPhone,linkMan,urgentState,expireDate,updateDate,remark,reserved1,reserved2,receiptDate,invoiceType,invoiceNumber,Preferentialsubjects,disInvoiceMoney,invoiceMoney)");
                sqlMain.Append(" values (");
                sqlMain.Append("@isClear,@code,@type,@date,@salesOrderState,@checkState,@operationMan,@checkMan,@salesMan,@payState,@payMathod,@oddAllMoney,@accountCode,@collectMoney,@lastMoney,@clientAddress,@clientCode,@clientName,@clientPhone,@linkMan,@urgentState,@expireDate,@updateDate,@remark,@reserved1,@reserved2,@receiptDate,@invoiceType,@invoiceNumber,@Preferentialsubjects,@disInvoiceMoney,@invoiceMoney)");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@type", SqlDbType.NVarChar,16),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@salesOrderState", SqlDbType.Int,4),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@operationMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@payState", SqlDbType.Int,4),
                    new SqlParameter("@payMathod", SqlDbType.NVarChar,40),
                    new SqlParameter("@oddAllMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@collectMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@lastMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@clientAddress", SqlDbType.NVarChar,200),
                    new SqlParameter("@clientCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@clientName", SqlDbType.NVarChar,40),
                    new SqlParameter("@clientPhone", SqlDbType.NVarChar,40),
                    new SqlParameter("@linkMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@urgentState", SqlDbType.Int,4),
                    new SqlParameter("@expireDate", SqlDbType.DateTime),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@receiptDate", SqlDbType.DateTime),
                    new SqlParameter("@invoiceType", SqlDbType.NVarChar,40),
                    new SqlParameter("@invoiceNumber", SqlDbType.NVarChar,40),
                    new SqlParameter("@Preferentialsubjects", SqlDbType.NVarChar,40),
                    new SqlParameter("@disInvoiceMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@invoiceMoney", SqlDbType.Decimal,9)
                };
                spsMain[0].Value = model.isClear;
                spsMain[1].Value = model.code;
                spsMain[2].Value = model.type;
                spsMain[3].Value = model.date;
                spsMain[4].Value = model.salesOrderState;
                spsMain[5].Value = model.checkState;
                spsMain[6].Value = model.operationMan;
                spsMain[7].Value = model.checkMan;
                spsMain[8].Value = model.salesMan;
                spsMain[9].Value = model.payState;
                spsMain[10].Value = model.payMathod;
                spsMain[11].Value = model.oddAllMoney;
                spsMain[12].Value = model.accountCode;
                spsMain[13].Value = model.collectMoney;
                spsMain[14].Value = model.lastMoney;
                spsMain[15].Value = model.clientAddress;
                spsMain[16].Value = model.clientCode;
                spsMain[17].Value = model.clientName;
                spsMain[18].Value = model.clientPhone;
                spsMain[19].Value = model.linkMan;
                spsMain[20].Value = model.urgentState;
                spsMain[21].Value = model.expireDate;
                spsMain[22].Value = model.updateDate;
                spsMain[23].Value = model.remark;
                spsMain[24].Value = model.reserved1;
                spsMain[25].Value = model.reserved2;
                spsMain[26].Value = model.receiptDate;
                spsMain[27].Value = model.invoiceType;
                spsMain[28].Value = model.invoiceNumber;
                spsMain[29].Value = model.Preferentialsubjects;
                spsMain[30].Value = model.disInvoiceMoney;
                spsMain[31].Value = model.invoiceMoney;

                hashTable.Add(sqlMain, spsMain);

                sqlDetail.Append("insert into [T_SalesDetail] (");
                sqlDetail.Append("isClear,code,mainCode,storageCode,storageName,materialDaima,materialCode,materialName,materiaModel,unit,needNumber,actualNumber,lostNumber,discountBeforePrice,discount,discountAfterPrice,money,reserved1,reserved2,remark,updateDate,productionDate,qualityDate,effectiveDate,zhujima,barCode,VATRate,discountMoney,tax,leviedMoney,costPrice,costMoney,ReturnsNumber,sourceCode)");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@isClear,@code,@mainCode,@storageCode,@storageName,@materialDaima,@materialCode,@materialName,@materiaModel,@unit,@needNumber,@actualNumber,@lostNumber,@discountBeforePrice,@discount,@discountAfterPrice,@money,@reserved1,@reserved2,@remark,@updateDate,@productionDate,@qualityDate,@effectiveDate,@zhujima,@barCode,@VATRate,@discountMoney,@tax,@leviedMoney,@costPrice,@costMoney,@ReturnsNumber,@sourceCode)");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                        new SqlParameter("@isClear", SqlDbType.Int,4),
                        new SqlParameter("@code", SqlDbType.NVarChar,45),
                        new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@storageCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@storageName", SqlDbType.NVarChar,60),
                        new SqlParameter("@materialDaima", SqlDbType.NVarChar,45),
                        new SqlParameter("@materialCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@materialName", SqlDbType.NVarChar,100),
                        new SqlParameter("@materiaModel", SqlDbType.NVarChar,100),
                        new SqlParameter("@unit", SqlDbType.NVarChar,16),
                        new SqlParameter("@needNumber", SqlDbType.Decimal,9),
                        new SqlParameter("@actualNumber", SqlDbType.Decimal,9),
                        new SqlParameter("@lostNumber", SqlDbType.Decimal,9),
                        new SqlParameter("@discountBeforePrice", SqlDbType.Decimal,9),
                        new SqlParameter("@discount", SqlDbType.Decimal,9),
                        new SqlParameter("@discountAfterPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@money", SqlDbType.Decimal,9),
                        new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                        new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                        new SqlParameter("@remark", SqlDbType.NVarChar,400),
                        new SqlParameter("@updateDate", SqlDbType.DateTime),
                        new SqlParameter("@productionDate", SqlDbType.DateTime),
                        new SqlParameter("@qualityDate", SqlDbType.Decimal,9),
                        new SqlParameter("@effectiveDate", SqlDbType.DateTime),
                        new SqlParameter("@zhujima", SqlDbType.NVarChar,45),
                        new SqlParameter("@barCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@VATRate", SqlDbType.Decimal,9),
                        new SqlParameter("@discountMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@tax", SqlDbType.Decimal,9),
                        new SqlParameter("@leviedMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@costPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@costMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@ReturnsNumber", SqlDbType.Decimal,9),
                        new SqlParameter("@sourceCode", SqlDbType.NVarChar,50)
                    };
                    spsDetail[0].Value = item.isClear;
                    spsDetail[1].Value = item.code;
                    spsDetail[2].Value = item.mainCode;
                    spsDetail[3].Value = item.storageCode;
                    spsDetail[4].Value = item.storageName;
                    spsDetail[5].Value = item.materialDaima;
                    spsDetail[6].Value = item.materialCode;
                    spsDetail[7].Value = item.materialName;
                    spsDetail[8].Value = item.materiaModel;
                    spsDetail[9].Value = item.unit;
                    spsDetail[10].Value = item.needNumber;
                    spsDetail[11].Value = item.actualNumber;
                    spsDetail[12].Value = item.lostNumber;
                    spsDetail[13].Value = item.discountBeforePrice;
                    spsDetail[14].Value = item.discount;
                    spsDetail[15].Value = item.discountAfterPrice;
                    spsDetail[16].Value = item.money;
                    spsDetail[17].Value = item.reserved1;
                    spsDetail[18].Value = item.reserved2;
                    spsDetail[19].Value = item.remark;
                    spsDetail[20].Value = item.updateDate;
                    spsDetail[21].Value = item.productionDate;
                    spsDetail[22].Value = item.qualityDate;
                    spsDetail[23].Value = item.effectiveDate;
                    spsDetail[24].Value = item.zhujima;
                    spsDetail[25].Value = item.barCode;
                    spsDetail[26].Value = item.VATRate;
                    spsDetail[27].Value = item.discountMoney;
                    spsDetail[28].Value = item.tax;
                    spsDetail[29].Value = item.leviedMoney;
                    spsDetail[30].Value = item.costPrice;
                    spsDetail[31].Value = item.costMoney;
                    spsDetail[32].Value = item.ReturnsNumber;
                    spsDetail[33].Value = item.sourceCode;
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
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object UpdateToMainOrDetail(SalesMain model, List<SalesDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            try
            {
                sqlMain.Append("update [T_SalesMain] set ");
                sqlMain.Append("isClear=@isClear,");
                sqlMain.Append("type=@type,");
                sqlMain.Append("date=@date,");
                sqlMain.Append("salesOrderState=@salesOrderState,");
                sqlMain.Append("checkState=@checkState,");
                sqlMain.Append("operationMan=@operationMan,");
                sqlMain.Append("checkMan=@checkMan,");
                sqlMain.Append("salesMan=@salesMan,");
                sqlMain.Append("payState=@payState,");
                sqlMain.Append("payMathod=@payMathod,");
                sqlMain.Append("oddAllMoney=@oddAllMoney,");
                sqlMain.Append("accountCode=@accountCode,");
                sqlMain.Append("collectMoney=@collectMoney,");
                sqlMain.Append("lastMoney=@lastMoney,");
                sqlMain.Append("clientAddress=@clientAddress,");
                sqlMain.Append("clientCode=@clientCode,");
                sqlMain.Append("clientName=@clientName,");
                sqlMain.Append("clientPhone=@clientPhone,");
                sqlMain.Append("linkMan=@linkMan,");
                sqlMain.Append("urgentState=@urgentState,");
                sqlMain.Append("expireDate=@expireDate,");
                sqlMain.Append("updateDate=@updateDate,");
                sqlMain.Append("remark=@remark,");
                sqlMain.Append("reserved1=@reserved1,");
                sqlMain.Append("reserved2=@reserved2,");
                sqlMain.Append("receiptDate=@receiptDate,");
                sqlMain.Append("invoiceType=@invoiceType,");
                sqlMain.Append("invoiceNumber=@invoiceNumber,");
                sqlMain.Append("Preferentialsubjects=@Preferentialsubjects,");
                sqlMain.Append("disInvoiceMoney=@disInvoiceMoney,");
                sqlMain.Append("invoiceMoney=@invoiceMoney");
                sqlMain.Append(" where code=@code ");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@type", SqlDbType.NVarChar,16),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@salesOrderState", SqlDbType.Int,4),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@operationMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@payState", SqlDbType.Int,4),
                    new SqlParameter("@payMathod", SqlDbType.NVarChar,40),
                    new SqlParameter("@oddAllMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@collectMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@lastMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@clientAddress", SqlDbType.NVarChar,200),
                    new SqlParameter("@clientCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@clientName", SqlDbType.NVarChar,40),
                    new SqlParameter("@clientPhone", SqlDbType.NVarChar,40),
                    new SqlParameter("@linkMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@urgentState", SqlDbType.Int,4),
                    new SqlParameter("@expireDate", SqlDbType.DateTime),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@receiptDate", SqlDbType.DateTime),
                    new SqlParameter("@invoiceType", SqlDbType.NVarChar,40),
                    new SqlParameter("@invoiceNumber", SqlDbType.NVarChar,40),
                    new SqlParameter("@Preferentialsubjects", SqlDbType.NVarChar,40),
                    new SqlParameter("@disInvoiceMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@invoiceMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@code", SqlDbType.NVarChar,50)
                };

                hashTable.Add(sqlMain, spsMain);

                sqlDetail.Append("update [T_SalesDetail] set ");
                sqlDetail.Append("isClear=@isClear,");
                sqlDetail.Append("mainCode=@mainCode,");
                sqlDetail.Append("storageCode=@storageCode,");
                sqlDetail.Append("storageName=@storageName,");
                sqlDetail.Append("materialDaima=@materialDaima,");
                sqlDetail.Append("materialCode=@materialCode,");
                sqlDetail.Append("materialName=@materialName,");
                sqlDetail.Append("materiaModel=@materiaModel,");
                sqlDetail.Append("unit=@unit,");
                sqlDetail.Append("needNumber=@needNumber,");
                sqlDetail.Append("actualNumber=@actualNumber,");
                sqlDetail.Append("lostNumber=@lostNumber,");
                sqlDetail.Append("discountBeforePrice=@discountBeforePrice,");
                sqlDetail.Append("discount=@discount,");
                sqlDetail.Append("discountAfterPrice=@discountAfterPrice,");
                sqlDetail.Append("money=@money,");
                sqlDetail.Append("reserved1=@reserved1,");
                sqlDetail.Append("reserved2=@reserved2,");
                sqlDetail.Append("remark=@remark,");
                sqlDetail.Append("updateDate=@updateDate,");
                sqlDetail.Append("productionDate=@productionDate,");
                sqlDetail.Append("qualityDate=@qualityDate,");
                sqlDetail.Append("effectiveDate=@effectiveDate,");
                sqlDetail.Append("zhujima=@zhujima,");
                sqlDetail.Append("barCode=@barCode,");
                sqlDetail.Append("VATRate=@VATRate,");
                sqlDetail.Append("discountMoney=@discountMoney,");
                sqlDetail.Append("tax=@tax,");
                sqlDetail.Append("leviedMoney=@leviedMoney,");
                sqlDetail.Append("costPrice=@costPrice,");
                sqlDetail.Append("costMoney=@costMoney,");
                sqlDetail.Append("ReturnsNumber=@ReturnsNumber,");
                sqlDetail.Append("sourceCode=@sourceCode");
                sqlDetail.Append(" where mainCode=@mainCode and code=@code ");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                        new SqlParameter("@isClear", SqlDbType.Int,4),
                        new SqlParameter("@code", SqlDbType.NVarChar,45),
                        new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@storageCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@storageName", SqlDbType.NVarChar,60),
                        new SqlParameter("@materialDaima", SqlDbType.NVarChar,45),
                        new SqlParameter("@materialCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@materialName", SqlDbType.NVarChar,100),
                        new SqlParameter("@materiaModel", SqlDbType.NVarChar,100),
                        new SqlParameter("@unit", SqlDbType.NVarChar,16),
                        new SqlParameter("@needNumber", SqlDbType.Decimal,9),
                        new SqlParameter("@actualNumber", SqlDbType.Decimal,9),
                        new SqlParameter("@lostNumber", SqlDbType.Decimal,9),
                        new SqlParameter("@discountBeforePrice", SqlDbType.Decimal,9),
                        new SqlParameter("@discount", SqlDbType.Decimal,9),
                        new SqlParameter("@discountAfterPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@money", SqlDbType.Decimal,9),
                        new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                        new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                        new SqlParameter("@remark", SqlDbType.NVarChar,400),
                        new SqlParameter("@updateDate", SqlDbType.DateTime),
                        new SqlParameter("@productionDate", SqlDbType.DateTime),
                        new SqlParameter("@qualityDate", SqlDbType.Decimal,9),
                        new SqlParameter("@effectiveDate", SqlDbType.DateTime),
                        new SqlParameter("@zhujima", SqlDbType.NVarChar,45),
                        new SqlParameter("@barCode", SqlDbType.NVarChar,45),
                        new SqlParameter("@VATRate", SqlDbType.Decimal,9),
                        new SqlParameter("@discountMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@tax", SqlDbType.Decimal,9),
                        new SqlParameter("@leviedMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@costPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@costMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@ReturnsNumber", SqlDbType.Decimal,9),
                        new SqlParameter("@sourceCode", SqlDbType.NVarChar,50)
                    };
                    spsDetail[0].Value = item.isClear;
                    spsDetail[1].Value = item.code;
                    spsDetail[2].Value = item.mainCode;
                    spsDetail[3].Value = item.storageCode;
                    spsDetail[4].Value = item.storageName;
                    spsDetail[5].Value = item.materialDaima;
                    spsDetail[6].Value = item.materialCode;
                    spsDetail[7].Value = item.materialName;
                    spsDetail[8].Value = item.materiaModel;
                    spsDetail[9].Value = item.unit;
                    spsDetail[10].Value = item.needNumber;
                    spsDetail[11].Value = item.actualNumber;
                    spsDetail[12].Value = item.lostNumber;
                    spsDetail[13].Value = item.discountBeforePrice;
                    spsDetail[14].Value = item.discount;
                    spsDetail[15].Value = item.discountAfterPrice;
                    spsDetail[16].Value = item.money;
                    spsDetail[17].Value = item.reserved1;
                    spsDetail[18].Value = item.reserved2;
                    spsDetail[19].Value = item.remark;
                    spsDetail[20].Value = item.updateDate;
                    spsDetail[21].Value = item.productionDate;
                    spsDetail[22].Value = item.qualityDate;
                    spsDetail[23].Value = item.effectiveDate;
                    spsDetail[24].Value = item.zhujima;
                    spsDetail[25].Value = item.barCode;
                    spsDetail[26].Value = item.VATRate;
                    spsDetail[27].Value = item.discountMoney;
                    spsDetail[28].Value = item.tax;
                    spsDetail[29].Value = item.leviedMoney;
                    spsDetail[30].Value = item.costPrice;
                    spsDetail[31].Value = item.costMoney;
                    spsDetail[32].Value = item.ReturnsNumber;
                    spsDetail[33].Value = item.sourceCode;
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_BaseBankAccount]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public DataTable GetExamineAndPay(string clientCode)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select sm.type,sm.code,sm.clientName,sm.date,sm.oddAllMoney,(oddAllMoney-lastMoney) as firstMoney,lastMoney,sm.remark from T_SalesMain sm,T_SalesDetail sd
where sm.code = sd.mainCode and checkState = 1 and payState = 0  and clientCode = '{0}'", clientCode);
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetExamineAndPay(string clientCode, string salesCode)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select sm.type,sm.code,sm.clientName,sm.date,sm.oddAllMoney,(oddAllMoney-lastMoney) as firstMoney,lastMoney,sm.remark from T_SalesMain sm,T_SalesDetail sd
where sm.code = sd.mainCode and checkState = 1 and payState = 0  and clientCode = '{0}' and sm.code='{1}'",clientCode,salesCode);
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public int SetPayState(int payState, string code)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(string.Format("DELETE FROM T_FinanceCollection set payState={0} where code={1}", payState, code));
            result = DbHelperSQL.ExecuteSql(strSql.ToString());
            return result;
        }
    }
}