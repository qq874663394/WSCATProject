using Model.Warehouse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Warehouse
{
    public class WarehouseInventoryLossBase
    {
        public DataTable Search(string strWhere)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = "select * from T_WarehouseInventoryloss";
                if (!string.IsNullOrWhiteSpace(strWhere))
                {
                    sql += " where " + strWhere;
                }
                sql += " order by id";
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public object Add(WarehouseInventoryLoss warehouseInventoryLoss, List<WarehouseInventoryLossDetail> warehouseInventoryLossDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            string sqlDetail = "";
            string sqlMain = "";
            try
            {
                sqlMain = @"INSERT INTO T_WarehouseInventoryLoss
               (code
               , type
               , date
               , checkState
               , operation
               , makeMan
               , examine
               , isClear
               , remark
               , reserved1
               , reserved2
               , updatetime)
                VALUES
               (@code
               , @type
               , @date
               , @checkState
               , @operation
               , @makeMan
               , @examine
               , @isClear
               , @remark
               , @reserved1
               , @reserved2
               , @updatetime);select scope_identity()";
                SqlParameter[] spsMain =
                {
                new SqlParameter("@code",warehouseInventoryLoss.code),
                new SqlParameter("@type",warehouseInventoryLoss.type),
                new SqlParameter("@date",warehouseInventoryLoss.date),
                new SqlParameter("@checkState",warehouseInventoryLoss.checkState),
                new SqlParameter("@operation",warehouseInventoryLoss.operation),
                new SqlParameter("@makeMan",warehouseInventoryLoss.makeMan),
                new SqlParameter("@examine",warehouseInventoryLoss.makeMan),
                new SqlParameter("@isClear",warehouseInventoryLoss.isClear),
                new SqlParameter("@remark",warehouseInventoryLoss.remark),
                new SqlParameter("@reserved1",warehouseInventoryLoss.reserved1),
                new SqlParameter("@reserved2",warehouseInventoryLoss.reserved2),
                new SqlParameter("@updatetime",warehouseInventoryLoss.updatetime)
                };
                hashTable.Add(sqlMain, spsMain);
                sqlDetail = @"INSERT INTO T_WarehouseInventoryLossDetail
           (code
           ,mainCode
           ,barCode
           ,materialDaima
           ,materialCode
           ,materialName
           ,materialModel
           ,materialUnit
           ,warehouseCode
           ,warehouseName
           ,price
           ,number
           ,inventoryNumber
           ,lossNumber
           ,lossMoney
           ,productionDate
           ,qualityDate
           ,effectiveDate
           ,isClear
           ,updateDate
           ,reserved1
           ,reserved2)
     VALUES
           (@code
           ,@mainCode
           ,@barCode
           ,@materialDaima
           ,@materialCode
           ,@materialName
           ,@materialModel
           ,@materialUnit
           ,@warehouseCode
           ,@warehouseName
           ,@price
           ,@number
           ,@inventoryNumber
           ,@lossNumber
           ,@lossMoney
           ,@productionDate
           ,@qualityDate
           ,@effectiveDate
           ,@isClear
           ,@updateDate
           ,@reserved1
           ,@reserved2);select SCOPE_IDENTITY();";

                foreach (var item in warehouseInventoryLossDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                        new SqlParameter("@code",item.code),
                        new SqlParameter("@mainCode",item.mainCode),
                        new SqlParameter("@barCode",item.barCode),
                        new SqlParameter("@materialDaima",item.materialDaima),
                        new SqlParameter("@materialCode",item.materialCode),
                        new SqlParameter("@materialName",item.materialName),
                        new SqlParameter("@materialModel",item.materialModel),
                        new SqlParameter("@materialUnit",item.materialUnit),
                        new SqlParameter("@warehouseCode",item.warehouseCode),
                        new SqlParameter("@warehouseName",item.warehouseName),
                        new SqlParameter("@price",item.price),
                        new SqlParameter("@number",item.number),
                        new SqlParameter("@inventoryNumber",item.inventoryNumber),
                        new SqlParameter("@lossNumber",item.lossNumber),
                        new SqlParameter("@lossMoney",item.lossMoney),
                        new SqlParameter("@productionDate",item.productionDate),
                        new SqlParameter("@qualityDate",item.qualityDate),
                        new SqlParameter("@effectiveDate",item.effectiveDate),
                        new SqlParameter("@isClear",item.isClear),
                        new SqlParameter("@updateDate",item.updateDate),
                        new SqlParameter("@reserved1",item.reserved1),
                        new SqlParameter("@reserved2",item.reserved2)
                    };
                    list.Add(spsDetail);
                }
                result = DbHelperSQL.ExecuteSqlTranScalar(hashTable, sqlDetail, list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public object Modify(WarehouseInventoryLoss warehouseInventoryLoss, List<WarehouseInventoryLossDetail> warehouseInventoryLossDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            string sqlDetail = "";
            string sqlMain = "";
            try
            {
                sqlMain = @"UPDATE T_WarehouseInventoryLoss
                SET type = @type
                , date = @date
                , checkState = @checkState
                , operation = @operation
                , makeMan = @makeMan
                , examine = @examine
                , isClear = @isClear
                , remark = @remark
                , reserved1 = @reserved1
                , reserved2 = @reserved2
                , updatetime = @updatetime
                WHERE  code = @code;select SCOPE_IDENTITY();";
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@code",warehouseInventoryLoss.code),
                    new SqlParameter("@type",warehouseInventoryLoss.type),
                    new SqlParameter("@date",warehouseInventoryLoss.date),
                    new SqlParameter("@checkState",warehouseInventoryLoss.checkState),
                    new SqlParameter("@operation",warehouseInventoryLoss.operation),
                    new SqlParameter("@makeMan",warehouseInventoryLoss.makeMan),
                    new SqlParameter("@examine",warehouseInventoryLoss.makeMan),
                    new SqlParameter("@isClear",warehouseInventoryLoss.isClear),
                    new SqlParameter("@remark",warehouseInventoryLoss.remark),
                    new SqlParameter("@reserved1",warehouseInventoryLoss.reserved1),
                    new SqlParameter("@reserved2",warehouseInventoryLoss.reserved2),
                    new SqlParameter("@updatetime",warehouseInventoryLoss.updatetime)
                };
                hashTable.Add(sqlMain, spsMain);
                sqlDetail = @"UPDATE T_WarehouseInventoryLossDetail
SET barCode=@barCode
,materialDaima=@materialDaima
,materialCode=@materialCode
,materialName=@materialName
,materialModel=@materialModel
,materialUnit=@materialUnit
,warehouseCode=@warehouseCode
,warehouseName=@warehouseName
,price=@price
,number=@number
,inventoryNumber=@inventoryNumber
,lossNumber=@lossNumber
,lossMoney=@lossMoney
,productionDate=@productionDate
,qualityDate=@qualityDate
,effectiveDate=@effectiveDate
,isClear=@isClear
,updateDate=@updateDate
,reserved1=@reserved1
,reserved2=@reserved2 where mainCode=@mainCode and code=@code;select SCOPE_IDENTITY();";

                foreach (var item in warehouseInventoryLossDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                        new SqlParameter("@code",item.code),
                        new SqlParameter("@mainCode",item.mainCode),
                        new SqlParameter("@barCode",item.barCode),
                        new SqlParameter("@materialDaima",item.materialDaima),
                        new SqlParameter("@materialCode",item.materialCode),
                        new SqlParameter("@materialName",item.materialName),
                        new SqlParameter("@materialModel",item.materialModel),
                        new SqlParameter("@materialUnit",item.materialUnit),
                        new SqlParameter("@warehouseCode",item.warehouseCode),
                        new SqlParameter("@warehouseName",item.warehouseName),
                        new SqlParameter("@price",item.price),
                        new SqlParameter("@number",item.number),
                        new SqlParameter("@inventoryNumber",item.inventoryNumber),
                        new SqlParameter("@lossNumber",item.lossNumber),
                        new SqlParameter("@lossMoney",item.lossMoney),
                        new SqlParameter("@productionDate",item.productionDate),
                        new SqlParameter("@qualityDate",item.qualityDate),
                        new SqlParameter("@effectiveDate",item.effectiveDate),
                        new SqlParameter("@isClear",item.isClear),
                        new SqlParameter("@updateDate",item.updateDate),
                        new SqlParameter("@reserved1",item.reserved1),
                        new SqlParameter("@reserved2",item.reserved2),
                    };
                    list.Add(spsDetail);
                }
                result = DbHelperSQL.ExecuteSqlTranScalar(hashTable, sqlDetail, list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 判断该客户编号判断是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            bool isflag = false;
            string sql = "";
            try
            {
                sql = string.Format("select count(1) from T_WarehouseInventoryLoss where code='{0}'", code);
                isflag = DbHelperSQL.Exists(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}
