using Model;
using Model.Sales;
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
    public class SalesOrderBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object AddSalesOrToDetail(SalesOrder model, List<SalesOrderDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            StringBuilder sqlDetail = new StringBuilder();
            object result = null;
            string sqlMain = "";
            try
            {

                sqlMain = @"INSERT INTO [T_SalesOrder] ( 
[clientCode] ,
[deliversDate] ,
[deliversMethod] ,
[remark] ,
[code] ,
[date] ,
[deliversLocation] ,
[operation] ,
[makeMan] ,
[examine] ,
[checkState] ) VALUES (
@clientCode,
@deliversDate,
@deliversMethod,
@remark,
@code,
@date,
@deliversLocation,
@operation,
@makeMan,
@examine,
@checkState
);select scope_identity()";
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@clientCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@deliversDate", SqlDbType.Date,3),
                    new SqlParameter("@deliversMethod", SqlDbType.Int,4),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.Date,3),
                    new SqlParameter("@deliversLocation", SqlDbType.NVarChar,50),
                    new SqlParameter("@operation", SqlDbType.NVarChar,40),
                    new SqlParameter("@makeMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@examine", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkState", SqlDbType.Int,4)
                };
                spsMain[0].Value = model.clientCode;
                spsMain[1].Value = model.deliversDate;
                spsMain[2].Value = model.deliversMethod;
                spsMain[3].Value = model.remark;
                spsMain[4].Value = model.code;
                spsMain[5].Value = model.date;
                spsMain[6].Value = model.deliversLocation;
                spsMain[7].Value = model.operation;
                spsMain[8].Value = model.makeMan;
                spsMain[9].Value = model.examine;
                spsMain[10].Value = model.checkState;

                hashTable.Add(sqlMain, spsMain);
                sqlDetail.Append("insert into[T_SalesOrderDetail] (");

                sqlDetail.Append("materialCode,materialNumber,materialPrice,materialMoney,discountRate,VATRate,discountMoney,tax,taxTotal,remark,deliveryNumber,mainCode,code)");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@materialCode,@materialNumber,@materialPrice,@materialMoney,@discountRate,@VATRate,@discountMoney,@tax,@taxTotal,@remark,@deliveryNumber,@mainCode,@code)");
                sqlDetail.Append(";select @@IDENTITY");

                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@materialCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@materialNumber", SqlDbType.Decimal,9),
                    new SqlParameter("@materialPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@materialMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@discountRate", SqlDbType.Decimal,9),
                    new SqlParameter("@VATRate", SqlDbType.Decimal,9),
                    new SqlParameter("@discountMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@tax", SqlDbType.Decimal,9),
                    new SqlParameter("@taxTotal", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@deliveryNumber", SqlDbType.Decimal,9),
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@code", SqlDbType.NVarChar,50)
                    };
                    spsDetail[0].Value = item.materialCode;
                    spsDetail[1].Value = item.materialNumber;
                    spsDetail[2].Value = item.materialPrice;
                    spsDetail[3].Value = item.materialMoney;
                    spsDetail[4].Value = item.discountRate;
                    spsDetail[5].Value = item.VATRate;
                    spsDetail[6].Value = item.discountMoney;
                    spsDetail[7].Value = item.tax;
                    spsDetail[8].Value = item.taxTotal;
                    spsDetail[9].Value = item.remark;
                    spsDetail[10].Value = item.deliveryNumber;
                    spsDetail[11].Value = item.mainCode;
                    spsDetail[12].Value = item.code;
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
        public object UpdateSalesOrToDetail(SalesOrder model, List<SalesOrderDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            try
            {
                sqlMain.Append("update [T_SalesOrder] set ");
                sqlMain.Append("clientCode=@clientCode,");
                sqlMain.Append("deliversDate=@deliversDate,");
                sqlMain.Append("deliversMethod=@deliversMethod,");
                sqlMain.Append("remark=@remark,");
                sqlMain.Append("code=@code,");
                sqlMain.Append("date=@date,");
                sqlMain.Append("deliversLocation=@deliversLocation,");
                sqlMain.Append("operation=@operation,");
                sqlMain.Append("makeMan=@makeMan,");
                sqlMain.Append("examine=@examine,");
                sqlMain.Append("checkState=@checkState");
                sqlMain.Append(" where code=@code ");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@clientCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@deliversDate", SqlDbType.Date,3),
                    new SqlParameter("@deliversMethod", SqlDbType.Int,4),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.Date,3),
                    new SqlParameter("@deliversLocation", SqlDbType.NVarChar,50),
                    new SqlParameter("@operation", SqlDbType.NVarChar,40),
                    new SqlParameter("@makeMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@examine", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkState", SqlDbType.Int,4)
                };
                spsMain[0].Value = model.clientCode;
                spsMain[1].Value = model.deliversDate;
                spsMain[2].Value = model.deliversMethod;
                spsMain[3].Value = model.remark;
                spsMain[4].Value = model.code;
                spsMain[5].Value = model.date;
                spsMain[6].Value = model.deliversLocation;
                spsMain[7].Value = model.operation;
                spsMain[8].Value = model.makeMan;
                spsMain[9].Value = model.examine;
                spsMain[10].Value = model.checkState;

                hashTable.Add(sqlMain, spsMain);
                sqlDetail.Append("update [T_SalesOrderDetail] set ");
                sqlDetail.Append("materialCode=@materialCode,");
                sqlDetail.Append("materialNumber=@materialNumber,");
                sqlDetail.Append("materialPrice=@materialPrice,");
                sqlDetail.Append("materialMoney=@materialMoney,");
                sqlDetail.Append("discountRate=@discountRate,");
                sqlDetail.Append("VATRate=@VATRate,");
                sqlDetail.Append("discountMoney=@discountMoney,");
                sqlDetail.Append("tax=@tax,");
                sqlDetail.Append("taxTotal=@taxTotal,");
                sqlDetail.Append("remark=@remark,");
                sqlDetail.Append("deliveryNumber=@deliveryNumber");
                sqlDetail.Append(" where mainCode=@mainCode and code=@code");

                string sqlInsert=@"insert into[T_SalesOrderDetail] 
(materialCode,materialNumber,materialPrice,
materialMoney,discountRate,VATRate,discountMoney,tax,taxTotal,
remark,deliveryNumber,mainCode,code)
values (@materialCode,@materialNumber,
@materialPrice,@materialMoney,@discountRate,
@VATRate,@discountMoney,@tax,@taxTotal,@remark,
@deliveryNumber,@mainCode,@code)
select @@IDENTITY";

                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@materialCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@materialNumber", SqlDbType.Decimal,9),
                    new SqlParameter("@materialPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@materialMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@discountRate", SqlDbType.Decimal,9),
                    new SqlParameter("@VATRate", SqlDbType.Decimal,9),
                    new SqlParameter("@discountMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@tax", SqlDbType.Decimal,9),
                    new SqlParameter("@taxTotal", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@deliveryNumber", SqlDbType.Decimal,9),
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@code", SqlDbType.NVarChar,50)
                    };
                    spsDetail[0].Value = item.materialCode;
                    spsDetail[1].Value = item.materialNumber;
                    spsDetail[2].Value = item.materialPrice;
                    spsDetail[3].Value = item.materialMoney;
                    spsDetail[4].Value = item.discountRate;
                    spsDetail[5].Value = item.VATRate;
                    spsDetail[6].Value = item.discountMoney;
                    spsDetail[7].Value = item.tax;
                    spsDetail[8].Value = item.taxTotal;
                    spsDetail[9].Value = item.remark;
                    spsDetail[10].Value = item.deliveryNumber;
                    spsDetail[11].Value = item.mainCode;
                    spsDetail[12].Value = item.code;
                    list.Add(spsDetail);
                }
                result = DbHelperSQL.ExecuteSqlTranScalar(hashTable, sqlDetail.ToString(), sqlInsert, list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            string sql = "";
            try
            {
                sql = string.Format("select count(1) from T_SalesOrder where code='{0}'", code);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return DbHelperSQL.Exists(sql);
        }
        public DataTable GetSalesDetailJoinSearch()
        {
            DataTable dt = null;
            string sql = @"select 
sod.code as code,
bm.materialDaima as materialDaima,
bm.name as name,
bm.model as model,
bm.barCode as barCode,
bm.unit as unit,
sod.materialNumber as number,
sod.discountRate as discountRate,
sod.materialPrice as materialPrice,
sod.discountMoney as discountMoney,
sod.materialMoney as materialMoney,
sod.tax as tax,
sod.deliveryNumber as deliveryNumber,
sod.mainCode as MainCode,
wm.allNumber as allNumber
from 
T_SalesOrderDetail sod,T_BaseMaterial bm,T_WarehouseMain wm
where 
sod.materialCode=bm.code and       
wm.materialCode=sod.materialCode and
wm.materialCode=bm.code";
            dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }
        public DataTable GetSalesJoinSearch(string clientcode)
        {
            DataTable dt = null;
            string sql = @"select 
                so.code as code,
                so.date as date,
                client.name as name,
                client.mobilePhone as mobilephone,
                client.fax as fax,
                so.deliversMethod as deliversMethod,
                so.deliversDate as deliversDate,
                so.remark as remark,
                --定金
                so.operation as operation,
                --部门code  部门表+code 命名
                so.makeMan as makeMan,
                so.examine as examine,
                --审核日期examineDate
                so.checkState as checkState
                 from T_SalesOrder so,T_BaseClient client where so.clientCode=client.code and client.code='" + clientcode + "'";
            dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }
        public DataTable GetSelectedDetail(string salesCode, string salesDetailCode)
        {
            string sql = "";
            DataTable dt = null;
            sql = string.Format(@"select sod.code,
bm.materialDaima,
bm.name,
bm.barCode,
bm.unit,
bm.model,
bm.isDouble,
sod.materialCode,
sod.materialNumber,
sod.materialPrice,
sod.discountRate,
sod.VATRate,
sod.discountMoney,
sod.materialMoney,
sod.tax,
sod.taxTotal,
bm.inPrice,
(bm.inPrice*sod.materialNumber) as inMoney,
bm.productionDate,
bm.effectiveDate,
bm.qualityDate,
bm.remark
 from T_SalesOrder so,T_SalesOrderDetail sod,T_BaseMaterial bm
where so.code=sod.mainCode and sod.materialCode=bm.code and 
so.code='{0}' and sod.code='{1}'", salesCode, salesDetailCode);
            dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }
    }
}