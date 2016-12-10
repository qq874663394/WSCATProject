using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;
using System.Collections;

namespace BaseLayer
{
    public class PurchaseMainBase
    {
        /// <summary>
        /// 获取入库仓库的商品列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = "select * from T_PurchaseMain";
                if (!string.IsNullOrWhiteSpace(strWhere))
                {
                    sql += string.Format(" where {0}", strWhere);
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
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object AddPurchaseOrderOrToDetail(PurchaseMain model, List<PurchaseDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            try
            {
                sqlMain.Append("insert into [T_PurchaseMain] (");
                sqlMain.Append("isClear,code,type,data,supplierCode,supplierName,purchaseOrderState,checkState,purchaseManCode,salesMan,operationMan,checkMan,isPay,payMethod,putStorageState,deliveryDate,logistics,logisticsCode,logisticsPhone,oddMoney,accountCode,inMoney,lastMoney,updateDate,urgentState,remark,reserved1,reserved2,examineDate,payDate,offersSubject,invoicedAmount,unbilledAmount,purchaseAmount)");
                sqlMain.Append(" values (");
                sqlMain.Append("@isClear,@code,@type,@data,@supplierCode,@supplierName,@purchaseOrderState,@checkState,@purchaseManCode,@salesMan,@operationMan,@checkMan,@isPay,@payMethod,@putStorageState,@deliveryDate,@logistics,@logisticsCode,@logisticsPhone,@oddMoney,@accountCode,@inMoney,@lastMoney,@updateDate,@urgentState,@remark,@reserved1,@reserved2,@examineDate,@payDate,@offersSubject,@invoicedAmount,@unbilledAmount,@purchaseAmount)");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@type", SqlDbType.NVarChar,512),
                    new SqlParameter("@data", SqlDbType.DateTime),
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@supplierName", SqlDbType.NVarChar,40),
                    new SqlParameter("@purchaseOrderState", SqlDbType.Int,4),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@purchaseManCode", SqlDbType.NVarChar,40),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@operationMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@isPay", SqlDbType.Int,4),
                    new SqlParameter("@payMethod", SqlDbType.NVarChar,40),
                    new SqlParameter("@putStorageState", SqlDbType.Int,4),
                    new SqlParameter("@deliveryDate", SqlDbType.DateTime),
                    new SqlParameter("@logistics", SqlDbType.NVarChar,32),
                    new SqlParameter("@logisticsCode", SqlDbType.NVarChar,40),
                    new SqlParameter("@logisticsPhone", SqlDbType.NVarChar,40),
                    new SqlParameter("@oddMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@inMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@lastMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@urgentState", SqlDbType.Int,4),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@examineDate", SqlDbType.DateTime),
                    new SqlParameter("@payDate", SqlDbType.DateTime),
                    new SqlParameter("@offersSubject", SqlDbType.NVarChar,40),
                    new SqlParameter("@invoicedAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@unbilledAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@purchaseAmount", SqlDbType.Decimal,9)
                };
                spsMain[0].Value =model.isClear;
                spsMain[1].Value =model.code;
                spsMain[2].Value =model.type;
                spsMain[3].Value =model.data;
                spsMain[4].Value =model.supplierCode;
                spsMain[5].Value =model.supplierName;
                spsMain[6].Value =model.purchaseOrderState;
                spsMain[7].Value =model.checkState;
                spsMain[8].Value =model.purchaseManCode;
                spsMain[9].Value = model.salesMan;
                spsMain[10].Value =model.operationMan;
                spsMain[11].Value =model.checkMan;
                spsMain[12].Value =model.isPay;
                spsMain[13].Value =model.payMethod;
                spsMain[14].Value =model.putStorageState;
                spsMain[15].Value =model.deliveryDate;
                spsMain[16].Value =model.logistics;
                spsMain[17].Value =model.logisticsCode;
                spsMain[18].Value =model.logisticsPhone;
                spsMain[19].Value =model.oddMoney;
                spsMain[20].Value =model.accountCode;
                spsMain[21].Value =model.inMoney;
                spsMain[22].Value =model.lastMoney;
                spsMain[23].Value =model.updateDate;
                spsMain[24].Value =model.urgentState;
                spsMain[25].Value =model.remark;
                spsMain[26].Value =model.reserved1;
                spsMain[27].Value =model.reserved2;
                spsMain[28].Value =model.examineDate;
                spsMain[29].Value =model.payDate;
                spsMain[30].Value =model.offersSubject;
                spsMain[31].Value =model.invoicedAmount;
                spsMain[32].Value =model.unbilledAmount;
                spsMain[33].Value = model.purchaseAmount;

                hashTable.Add(sqlMain, spsMain);

               sqlDetail.Append("insert into [T_PurchaseDetail] (");
                sqlDetail.Append("isClear,materialDaima,zhujima,barCode,code,purchaseCode,storageCode,storageName,materialCode,materialName,materialModel,unit,number,discountBeforePrice,discount,discountAfterPrice,money,remark,updateDate,reserved1,reserved2,productionDate,qualityDate,effectiveDate,VATRate,tax,taxTotal,discountMoney)");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@isClear,@materialDaima,@zhujima,@barCode,@code,@purchaseCode,@storageCode,@storageName,@materialCode,@materialName,@materialModel,@unit,@number,@discountBeforePrice,@discount,@discountAfterPrice,@money,@remark,@updateDate,@reserved1,@reserved2,@productionDate,@qualityDate,@effectiveDate,@VATRate,@tax,@taxTotal,@discountMoney)");
                sqlDetail.Append(";select @@IDENTITY");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                     new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@materialDaima", SqlDbType.NVarChar,45),
                    new SqlParameter("@zhujima", SqlDbType.NVarChar,45),
                    new SqlParameter("@barCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@purchaseCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@storageCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@storageName", SqlDbType.NVarChar,60),
                    new SqlParameter("@materialCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@materialName", SqlDbType.NVarChar,100),
                    new SqlParameter("@materialModel", SqlDbType.NVarChar,100),
                    new SqlParameter("@unit", SqlDbType.NVarChar,16),
                    new SqlParameter("@number", SqlDbType.Decimal,9),
                    new SqlParameter("@discountBeforePrice", SqlDbType.Decimal,9),
                    new SqlParameter("@discount", SqlDbType.Decimal,9),
                    new SqlParameter("@discountAfterPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@money", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@productionDate", SqlDbType.DateTime),
                    new SqlParameter("@qualityDate", SqlDbType.Decimal,9),
                    new SqlParameter("@effectiveDate", SqlDbType.DateTime),
                    new SqlParameter("@VATRate", SqlDbType.Decimal,9),
                    new SqlParameter("@tax", SqlDbType.Decimal,9),
                    new SqlParameter("@taxTotal", SqlDbType.Decimal,9),
                    new SqlParameter("@discountMoney", SqlDbType.Decimal,9)
                    };
                    spsDetail[0].Value =item.isClear;
                    spsDetail[1].Value =item.materialDaima;
                    spsDetail[2].Value =item.zhujima;
                    spsDetail[3].Value =item.barCode;
                    spsDetail[4].Value =item.code;
                    spsDetail[5].Value =item.purchaseCode;
                    spsDetail[6].Value =item.storageCode;
                    spsDetail[7].Value =item.storageName;
                    spsDetail[8].Value =item.materialCode;
                    spsDetail[9].Value = item.materialName;
                    spsDetail[10].Value =item.materialModel;
                    spsDetail[11].Value =item.unit;
                    spsDetail[12].Value =item.number;
                    spsDetail[13].Value =item.discountBeforePrice;
                    spsDetail[14].Value =item.discount;
                    spsDetail[15].Value =item.discountAfterPrice;
                    spsDetail[16].Value =item.money;
                    spsDetail[17].Value =item.remark;
                    spsDetail[18].Value =item.updateDate;
                    spsDetail[19].Value =item.reserved1;
                    spsDetail[20].Value =item.reserved2;
                    spsDetail[21].Value =item.productionDate;
                    spsDetail[22].Value =item.qualityDate;
                    spsDetail[23].Value =item.effectiveDate;
                    spsDetail[24].Value =item.VATRate;
                    spsDetail[25].Value =item.tax;
                    spsDetail[26].Value =item.taxTotal;
                    spsDetail[27].Value = item.discountMoney;

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
        public object UpdateSalesOrToDetail(PurchaseMain model, List<PurchaseDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            try
            {
                sqlMain.Append("update [T_PurchaseMain] set ");
                sqlMain.Append("isClear=@isClear,");
                sqlMain.Append("type=@type,");
                sqlMain.Append("data=@data,");
                sqlMain.Append("supplierCode=@supplierCode,");
                sqlMain.Append("supplierName=@supplierName,");
                sqlMain.Append("purchaseOrderState=@purchaseOrderState,");
                sqlMain.Append("checkState=@checkState,");
                sqlMain.Append("purchaseManCode=@purchaseManCode,");
                sqlMain.Append("salesMan=@salesMan,");
                sqlMain.Append("operationMan=@operationMan,");
                sqlMain.Append("checkMan=@checkMan,");
                sqlMain.Append("isPay=@isPay,");
                sqlMain.Append("payMethod=@payMethod,");
                sqlMain.Append("putStorageState=@putStorageState,");
                sqlMain.Append("deliveryDate=@deliveryDate,");
                sqlMain.Append("logistics=@logistics,");
                sqlMain.Append("logisticsCode=@logisticsCode,");
                sqlMain.Append("logisticsPhone=@logisticsPhone,");
                sqlMain.Append("oddMoney=@oddMoney,");
                sqlMain.Append("accountCode=@accountCode,");
                sqlMain.Append("inMoney=@inMoney,");
                sqlMain.Append("lastMoney=@lastMoney,");
                sqlMain.Append("updateDate=@updateDate,");
                sqlMain.Append("urgentState=@urgentState,");
                sqlMain.Append("remark=@remark,");
                sqlMain.Append("reserved1=@reserved1,");
                sqlMain.Append("reserved2=@reserved2,");
                sqlMain.Append("examineDate=@examineDate,");
                sqlMain.Append("payDate=@payDate,");
                sqlMain.Append("offersSubject=@offersSubject,");
                sqlMain.Append("invoicedAmount=@invoicedAmount,");
                sqlMain.Append("unbilledAmount=@unbilledAmount,");
                sqlMain.Append("purchaseAmount=@purchaseAmount");
                sqlMain.Append(" where code=@code ");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@type", SqlDbType.NVarChar,512),
                    new SqlParameter("@data", SqlDbType.DateTime),
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@supplierName", SqlDbType.NVarChar,40),
                    new SqlParameter("@purchaseOrderState", SqlDbType.Int,4),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@purchaseManCode", SqlDbType.NVarChar,40),
                    new SqlParameter("@salesMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@operationMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@isPay", SqlDbType.Int,4),
                    new SqlParameter("@payMethod", SqlDbType.NVarChar,40),
                    new SqlParameter("@putStorageState", SqlDbType.Int,4),
                    new SqlParameter("@deliveryDate", SqlDbType.DateTime),
                    new SqlParameter("@logistics", SqlDbType.NVarChar,32),
                    new SqlParameter("@logisticsCode", SqlDbType.NVarChar,40),
                    new SqlParameter("@logisticsPhone", SqlDbType.NVarChar,40),
                    new SqlParameter("@oddMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@accountCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@inMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@lastMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@urgentState", SqlDbType.Int,4),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@examineDate", SqlDbType.DateTime),
                    new SqlParameter("@payDate", SqlDbType.DateTime),
                    new SqlParameter("@offersSubject", SqlDbType.NVarChar,40),
                    new SqlParameter("@invoicedAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@unbilledAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@purchaseAmount", SqlDbType.Decimal,9)
                };
                spsMain[0].Value = model.isClear;
                spsMain[1].Value = model.code;
                spsMain[2].Value = model.type;
                spsMain[3].Value = model.data;
                spsMain[4].Value = model.supplierCode;
                spsMain[5].Value = model.supplierName;
                spsMain[6].Value = model.purchaseOrderState;
                spsMain[7].Value = model.checkState;
                spsMain[8].Value = model.purchaseManCode;
                spsMain[9].Value = model.salesMan;
                spsMain[10].Value = model.operationMan;
                spsMain[11].Value = model.checkMan;
                spsMain[12].Value = model.isPay;
                spsMain[13].Value = model.payMethod;
                spsMain[14].Value = model.putStorageState;
                spsMain[15].Value = model.deliveryDate;
                spsMain[16].Value = model.logistics;
                spsMain[17].Value = model.logisticsCode;
                spsMain[18].Value = model.logisticsPhone;
                spsMain[19].Value = model.oddMoney;
                spsMain[20].Value = model.accountCode;
                spsMain[21].Value = model.inMoney;
                spsMain[22].Value = model.lastMoney;
                spsMain[23].Value = model.updateDate;
                spsMain[24].Value = model.urgentState;
                spsMain[25].Value = model.remark;
                spsMain[26].Value = model.reserved1;
                spsMain[27].Value = model.reserved2;
                spsMain[28].Value = model.examineDate;
                spsMain[29].Value = model.payDate;
                spsMain[30].Value = model.offersSubject;
                spsMain[31].Value = model.invoicedAmount;
                spsMain[32].Value = model.unbilledAmount;
                spsMain[33].Value = model.purchaseAmount;

                hashTable.Add(sqlMain, spsMain);

                sqlDetail.Append("update [T_PurchaseDetail] set ");
                sqlDetail.Append("isClear=@isClear,");
                sqlDetail.Append("materialDaima=@materialDaima,");
                sqlDetail.Append("zhujima=@zhujima,");
                sqlDetail.Append("barCode=@barCode,");
                sqlDetail.Append("storageCode=@storageCode,");
                sqlDetail.Append("storageName=@storageName,");
                sqlDetail.Append("materialCode=@materialCode,");
                sqlDetail.Append("materialName=@materialName,");
                sqlDetail.Append("materialModel=@materialModel,");
                sqlDetail.Append("unit=@unit,");
                sqlDetail.Append("number=@number,");
                sqlDetail.Append("discountBeforePrice=@discountBeforePrice,");
                sqlDetail.Append("discount=@discount,");
                sqlDetail.Append("discountAfterPrice=@discountAfterPrice,");
                sqlDetail.Append("money=@money,");
                sqlDetail.Append("remark=@remark,");
                sqlDetail.Append("updateDate=@updateDate,");
                sqlDetail.Append("reserved1=@reserved1,");
                sqlDetail.Append("reserved2=@reserved2,");
                sqlDetail.Append("productionDate=@productionDate,");
                sqlDetail.Append("qualityDate=@qualityDate,");
                sqlDetail.Append("effectiveDate=@effectiveDate,");
                sqlDetail.Append("VATRate=@VATRate");
                sqlDetail.Append(" where code=@code and purchaseCode=@purchaseCode");
                sqlMain.Append(";select @@IDENTITY");

                StringBuilder sqlInsert = new StringBuilder();
                sqlMain.Append("insert into [T_PurchaseMain] (");
                sqlMain.Append("isClear,code,type,data,supplierCode,supplierName,purchaseOrderState,checkState,purchaseManCode,salesMan,operationMan,checkMan,isPay,payMethod,putStorageState,deliveryDate,logistics,logisticsCode,logisticsPhone,oddMoney,accountCode,inMoney,lastMoney,updateDate,urgentState,remark,reserved1,reserved2,examineDate,payDate,offersSubject,invoicedAmount,unbilledAmount,purchaseAmount)");
                sqlMain.Append(" values (");
                sqlMain.Append("@isClear,@code,@type,@data,@supplierCode,@supplierName,@purchaseOrderState,@checkState,@purchaseManCode,@salesMan,@operationMan,@checkMan,@isPay,@payMethod,@putStorageState,@deliveryDate,@logistics,@logisticsCode,@logisticsPhone,@oddMoney,@accountCode,@inMoney,@lastMoney,@updateDate,@urgentState,@remark,@reserved1,@reserved2,@examineDate,@payDate,@offersSubject,@invoicedAmount,@unbilledAmount,@purchaseAmount)");
                sqlMain.Append(";select @@IDENTITY");

                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@materialDaima", SqlDbType.NVarChar,45),
                    new SqlParameter("@zhujima", SqlDbType.NVarChar,45),
                    new SqlParameter("@barCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@purchaseCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@storageCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@storageName", SqlDbType.NVarChar,60),
                    new SqlParameter("@materialCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@materialName", SqlDbType.NVarChar,100),
                    new SqlParameter("@materialModel", SqlDbType.NVarChar,100),
                    new SqlParameter("@unit", SqlDbType.NVarChar,16),
                    new SqlParameter("@number", SqlDbType.Decimal,9),
                    new SqlParameter("@discountBeforePrice", SqlDbType.Decimal,9),
                    new SqlParameter("@discount", SqlDbType.Decimal,9),
                    new SqlParameter("@discountAfterPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@money", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@productionDate", SqlDbType.DateTime),
                    new SqlParameter("@qualityDate", SqlDbType.Decimal,9),
                    new SqlParameter("@effectiveDate", SqlDbType.DateTime),
                    new SqlParameter("@VATRate", SqlDbType.NChar,10),
                    new SqlParameter("@id", SqlDbType.Int,4)
                    };
                    spsDetail[0].Value = item.isClear;
                    spsDetail[1].Value = item.materialDaima;
                    spsDetail[2].Value = item.zhujima;
                    spsDetail[3].Value = item.barCode;
                    spsDetail[4].Value = item.code;
                    spsDetail[5].Value = item.purchaseCode;
                    spsDetail[6].Value = item.storageCode;
                    spsDetail[7].Value = item.storageName;
                    spsDetail[8].Value = item.materialCode;
                    spsDetail[9].Value = item.materialName;
                    spsDetail[10].Value = item.materialModel;
                    spsDetail[11].Value = item.unit;
                    spsDetail[12].Value = item.number;
                    spsDetail[13].Value = item.discountBeforePrice;
                    spsDetail[14].Value = item.discount;
                    spsDetail[15].Value = item.discountAfterPrice;
                    spsDetail[16].Value = item.money;
                    spsDetail[17].Value = item.remark;
                    spsDetail[18].Value = item.updateDate;
                    spsDetail[19].Value = item.reserved1;
                    spsDetail[20].Value = item.reserved2;
                    spsDetail[21].Value = item.productionDate;
                    spsDetail[22].Value = item.qualityDate;
                    spsDetail[23].Value = item.effectiveDate;
                    spsDetail[24].Value = item.VATRate;
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
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_PurchaseMain]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
