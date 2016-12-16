using Model.Purchase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Purchase
{
    public class PurchaseOrderBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object AddPurchaseOrderOrToDetail(PurchaseOrder model, List<PurchaseOrderDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            try
            {
                sqlMain.Append("insert into [T_PurchaseOrder] (");
                sqlMain.Append("supplierCode,deliversDate,deliversMethod,remark,code,date,deliversLocation,operation,makeMan,examine,checkState,depositReceived)");
                sqlMain.Append(" values (");
                sqlMain.Append("@supplierCode,@deliversDate,@deliversMethod,@remark,@code,@date,@deliversLocation,@operation,@makeMan,@examine,@checkState,@depositReceived)");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@deliversDate", SqlDbType.Date,3),
                    new SqlParameter("@deliversMethod", SqlDbType.Int,4),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.Date,3),
                    new SqlParameter("@deliversLocation", SqlDbType.NVarChar,50),
                    new SqlParameter("@operation", SqlDbType.NVarChar,40),
                    new SqlParameter("@makeMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@examine", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@depositReceived", SqlDbType.Decimal,9)
                };
                spsMain[0].Value = model.supplierCode;
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
                spsMain[11].Value = model.depositReceived;

                hashTable.Add(sqlMain, spsMain);

                sqlDetail.Append("insert into [T_PurchaseOrderDetail] (");
                sqlDetail.Append("materialCode,materialNumber,materialPrice,materialMoney,discountRate,VATRate,discountMoney,purchaseAmount,tax,taxTotal,remark,deliveryNumber,mainCode,code,amount)");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@materialCode,@materialNumber,@materialPrice,@materialMoney,@discountRate,@VATRate,@discountMoney,@purchaseAmount,@tax,@taxTotal,@remark,@deliveryNumber,@mainCode,@code,@amount)");
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
                    new SqlParameter("@purchaseAmount", SqlDbType.NVarChar,10),
                    new SqlParameter("@tax", SqlDbType.Decimal,9),
                    new SqlParameter("@taxTotal", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@deliveryNumber", SqlDbType.Decimal,9),
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@amount", SqlDbType.NVarChar,10)
                    };
                    spsDetail[0].Value = item.materialCode;
                    spsDetail[1].Value = item.materialNumber;
                    spsDetail[2].Value = item.materialPrice;
                    spsDetail[3].Value = item.materialMoney;
                    spsDetail[4].Value = item.discountRate;
                    spsDetail[5].Value = item.VATRate;
                    spsDetail[6].Value = item.discountMoney;
                    spsDetail[7].Value = item.purchaseAmount;
                    spsDetail[8].Value = item.tax;
                    spsDetail[9].Value = item.taxTotal;
                    spsDetail[10].Value = item.remark;
                    spsDetail[11].Value = item.deliveryNumber;
                    spsDetail[12].Value = item.mainCode;
                    spsDetail[13].Value = item.code;
                    spsDetail[14].Value = item.amount;

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
        public object UpdateSalesOrToDetail(PurchaseOrder model, List<PurchaseOrderDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            try
            {
                sqlMain.Append("update [T_PurchaseOrder] set ");
                sqlMain.Append("supplierCode=@supplierCode,");
                sqlMain.Append("deliversDate=@deliversDate,");
                sqlMain.Append("deliversMethod=@deliversMethod,");
                sqlMain.Append("remark=@remark,");
                sqlMain.Append("date=@date,");
                sqlMain.Append("deliversLocation=@deliversLocation,");
                sqlMain.Append("operation=@operation,");
                sqlMain.Append("makeMan=@makeMan,");
                sqlMain.Append("examine=@examine,");
                sqlMain.Append("checkState=@checkState,");
                sqlMain.Append("depositReceived=@depositReceived");
                sqlMain.Append(" where code=@code");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@deliversDate", SqlDbType.Date,3),
                    new SqlParameter("@deliversMethod", SqlDbType.Int,4),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@date", SqlDbType.Date,3),
                    new SqlParameter("@deliversLocation", SqlDbType.NVarChar,50),
                    new SqlParameter("@operation", SqlDbType.NVarChar,40),
                    new SqlParameter("@makeMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@examine", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@depositReceived", SqlDbType.Decimal,9),
                };
                spsMain[0].Value = model.supplierCode;
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
                spsMain[11].Value = model.depositReceived;

                hashTable.Add(sqlMain, spsMain);
                sqlDetail.Append("update [T_PurchaseOrderDetail] set ");
                sqlDetail.Append("materialCode=@materialCode,");
                sqlDetail.Append("materialNumber=@materialNumber,");
                sqlDetail.Append("materialPrice=@materialPrice,");
                sqlDetail.Append("materialMoney=@materialMoney,");
                sqlDetail.Append("discountRate=@discountRate,");
                sqlDetail.Append("VATRate=@VATRate,");
                sqlDetail.Append("discountMoney=@discountMoney,");
                sqlDetail.Append("purchaseAmount=@purchaseAmount,");
                sqlDetail.Append("tax=@tax,");
                sqlDetail.Append("taxTotal=@taxTotal,");
                sqlDetail.Append("remark=@remark,");
                sqlDetail.Append("deliveryNumber=@deliveryNumber,");
                sqlDetail.Append("amount=@amount");
                sqlDetail.Append(" where code = @code ");
                //sqlDetail.Append(";select id from T_PurchaseOrderDetail where code=@code");

                StringBuilder sqlInsert = new StringBuilder();
                sqlInsert.Append("insert into [T_PurchaseOrderDetail] (");
                sqlInsert.Append("materialCode,materialNumber,materialPrice,materialMoney,discountRate,VATRate,discountMoney,purchaseAmount,tax,taxTotal,remark,deliveryNumber,mainCode,code,amount)");
                sqlInsert.Append(" values (");
                sqlInsert.Append(@"@materialCode,@materialNumber,@materialPrice,@materialMoney,@discountRate,
                    @VATRate,@discountMoney,@purchaseAmount,@tax,@taxTotal,@remark,@deliveryNumber,@mainCode,@code,@amount)");
                //sqlInsert.Append(";select @@identity");

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
                    new SqlParameter("@purchaseAmount", SqlDbType.NVarChar,10),
                    new SqlParameter("@tax", SqlDbType.Decimal,9),
                    new SqlParameter("@taxTotal", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,200),
                    new SqlParameter("@deliveryNumber", SqlDbType.Decimal,9),
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@code", SqlDbType.NVarChar,50),
                    new SqlParameter("@amount", SqlDbType.NVarChar,10)
                    };
                    spsDetail[0].Value = item.materialCode;
                    spsDetail[1].Value = item.materialNumber;
                    spsDetail[2].Value = item.materialPrice;
                    spsDetail[3].Value = item.materialMoney;
                    spsDetail[4].Value = item.discountRate;
                    spsDetail[5].Value = item.VATRate;
                    spsDetail[6].Value = item.discountMoney;
                    spsDetail[7].Value = item.purchaseAmount;
                    spsDetail[8].Value = item.tax;
                    spsDetail[9].Value = item.taxTotal;
                    spsDetail[10].Value = item.remark;
                    spsDetail[11].Value = item.deliveryNumber;
                    spsDetail[12].Value = item.mainCode;
                    spsDetail[13].Value = item.code;
                    spsDetail[14].Value = item.amount;
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
        public DataTable GetMainTable(string supplierCode)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = @"select po.date,
                po.depositReceived,
                po.code,
                po.checkState,
                po.supplierCode,
                bs.name,
                bs.linkMan,
                bs.phone,
                bs.fax,
                po.deliversMethod,
                po.deliversLocation,
                po.deliversDate,
                po.examine,
                po.remark
                from 
                T_PurchaseOrder po,
                T_PurchaseOrderDetail pod,
                T_BaseSupplier bs
                where 
                po.code=pod.mainCode and 
                po.supplierCode=bs.code and po.supplierCode='" + supplierCode + "'";
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetMinorTable()
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = @"select bm.materialDaima,
                        bm.code as materialcode,
                        bm.name,
                        bm.model,
                        bm.barCode,
                        bm.unit,
                        pod.materialNumber,
                        bm.price,
                        pod.discountRate,
                        pod.VATRate,
                        pod.mainCode,
                        pod.materialMoney,
                        pod.code,
                        wm.allNumber 
                        from T_PurchaseOrderDetail pod,T_BaseMaterial bm,T_WarehouseMain wm
                        where pod.materialCode = bm.code and wm.materialCode = pod.materialCode";
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetJoinSearch(string code, string detailCode)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select bm.materialDaima,
                bm.code as materialCode,
                bm.name,
                bm.model,
                bm.barCode,
                bm.unit,
                bm.isDouble,
                pod.materialNumber,
                pod.materialPrice,
                pod.discountRate,
                pod.VATRate,
                pod.discountMoney,
                pod.materialMoney,
                pod.tax,
                pod.purchaseAmount,
                pod.taxTotal,
                bm.createDate,
                bm.qualityDate,
                bm.effectiveDate,
                pod.remark,
                pod.mainCode,
                pod.code from T_BaseMaterial bm,T_PurchaseOrderDetail pod
                where bm.code=pod.materialCode and pod.mainCode='{0}' and pod.code='{1}'", code, detailCode);
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_PurchaseOrder]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 默认的上一单
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetFLastData(string code)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select po.* ,pod.*
 from T_PurchaseOrder po,T_PurchaseOrderDetail pod
where po.code=pod.mainCode and 
po.code= (select top 1 code from T_PurchaseOrder where id =
(select id from T_PurchaseOrder where code = '{0}') order by id desc)", code);
                dt = DbHelperSQL.Query(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取上一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetLastData(string code)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select po.* ,pod.*
 from T_PurchaseOrder po,T_PurchaseOrderDetail pod
where po.code=pod.mainCode and 
po.code= (select top 1 code from T_PurchaseOrder where id <
(select id from T_PurchaseOrder where code = '{0}') order by id desc)", code);
                dt = DbHelperSQL.Query(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 下一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetNextData(string code)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select po.* ,pod.*
 from T_PurchaseOrder po,T_PurchaseOrderDetail pod
where po.code=pod.mainCode and 
po.code= (select top 1 code from T_PurchaseOrder where id >
(select id from T_PurchaseOrder where code = '{0}'))", code);
                dt = DbHelperSQL.Query(sql).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                sql = "select top 1 code from  T_PurchaseOrder order by id desc";
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
