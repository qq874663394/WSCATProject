using BaseLayer.Warehouse;
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
    public class WareHouseInventoryProfitBase
    {
        public DataTable Search(string strWhere)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = "SELECT id FROM T_WareHouseInventoryProfit";
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

        public object Add(WarehouseInventoryProfit warehouseInventoryProfit, List<WarehouseInventoryProfitDetail> warehouseInventoryProfitDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            string sqlDetail = "";
            string sqlMain = "";
            try
            {
                sqlMain = @"INSERT INTO T_WarehouseInventoryProfit
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
                new SqlParameter("@code",warehouseInventoryProfit.code),
                new SqlParameter("@type",warehouseInventoryProfit.type),
                new SqlParameter("@date",warehouseInventoryProfit.date),
                new SqlParameter("@checkState",warehouseInventoryProfit.checkState),
                new SqlParameter("@operation",warehouseInventoryProfit.operation),
                new SqlParameter("@makeMan",warehouseInventoryProfit.makeMan),
                new SqlParameter("@examine",warehouseInventoryProfit.makeMan),
                new SqlParameter("@isClear",warehouseInventoryProfit.isClear),
                new SqlParameter("@remark",warehouseInventoryProfit.remark),
                new SqlParameter("@reserved1",warehouseInventoryProfit.reserved1),
                new SqlParameter("@reserved2",warehouseInventoryProfit.reserved2),
                new SqlParameter("@updatetime",warehouseInventoryProfit.updatetime)
                };
                hashTable.Add(sqlMain, spsMain);
                sqlDetail = @"INSERT INTO T_WarehouseInventoryProfitDetail
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
           ,profitNumber
           ,profitMoney
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
           ,@profitNumber
           ,@profitMoney
           ,@productionDate
           ,@qualityDate
           ,@effectiveDate
           ,@isClear
           ,@updateDate
           ,@reserved1
           ,@reserved2);select SCOPE_IDENTITY();";

                foreach (var item in warehouseInventoryProfitDetail)
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
                        new SqlParameter("@profitNumber",item.profitNumber),
                        new SqlParameter("@profitMoney",item.profitMoney),
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

        public object Modify(WarehouseInventoryProfit warehouseInventoryProfit, List<WarehouseInventoryProfitDetail> warehouseInventoryProfitDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            string sqlDetail = "";
            string sqlMain = "";
            try
            {
                sqlMain = @"UPDATE T_WareHouseInventoryProfit
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
                    new SqlParameter("@code",warehouseInventoryProfit.code),
                    new SqlParameter("@type",warehouseInventoryProfit.type),
                    new SqlParameter("@date",warehouseInventoryProfit.date),
                    new SqlParameter("@checkState",warehouseInventoryProfit.checkState),
                    new SqlParameter("@operation",warehouseInventoryProfit.operation),
                    new SqlParameter("@makeMan",warehouseInventoryProfit.makeMan),
                    new SqlParameter("@examine",warehouseInventoryProfit.makeMan),
                    new SqlParameter("@isClear",warehouseInventoryProfit.isClear),
                    new SqlParameter("@remark",warehouseInventoryProfit.remark),
                    new SqlParameter("@reserved1",warehouseInventoryProfit.reserved1),
                    new SqlParameter("@reserved2",warehouseInventoryProfit.reserved2),
                    new SqlParameter("@updatetime",warehouseInventoryProfit.updatetime)
                };
                hashTable.Add(sqlMain, spsMain);
                sqlDetail = @"UPDATE T_WarehouseInventoryProfitDetail
SET code=@code
,mainCode=@mainCode
,barCode=@barCode
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
,profitNumber=@profitNumber
,profitMoney=@profitMoney
,productionDate=@productionDate
,qualityDate=@qualityDate
,effectiveDate=@effectiveDate
,isClear=@isClear
,updateDate=@updateDate
,reserved1=@reserved1
,reserved2=@reserved2;select SCOPE_IDENTITY();";

                foreach (var item in warehouseInventoryProfitDetail)
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
                        new SqlParameter("@inventoryNumber",item.inventoryNumber),
                        new SqlParameter("@profitNumber",item.profitNumber),
                        new SqlParameter("@profitMoney",item.profitMoney),
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
                sql = string.Format("select count(1) from T_WarehouseInventoryProfit where code='{0}'", code);
                isflag = DbHelperSQL.Exists(sql);
            }
            catch (Exception ex)
            {
                isflag = false;
                throw ex;
            }
            return false;
        }
    }
}
