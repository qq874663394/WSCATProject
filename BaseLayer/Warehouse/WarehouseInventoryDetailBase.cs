using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Warehouse
{
    public class WarehouseInventoryDetailBase
    {
        public DataTable Search(string strWhere)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = "select * from T_WarehouseInventoryDetail";
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
        public int Add(WarehouseInventoryDetail wid)
        {
            string sql = "";
            int result = 0;
            try
            {
               sql = @"INSERT INTO T_WarehouseInventoryDetail
               (code
               ,materialCode
               ,materialName
               ,materialModel
               ,materialUnit
               ,curNumber
               ,checkNumber
               ,profitNumber
               ,lossNumber
               ,price
               ,profitMoney
               ,lossMoney
               ,cause
               ,isClear
               ,updateDate
               ,reserved1
               ,reserved2
               ,remark
               ,stockCode
               ,stockName
               ,materialDaima
               ,barCode
               ,productionDate
               ,qualityDate
               ,mainCode
    )
         VALUES
               (@code
               ,@materialCode
               ,@materialName
               ,@materialModel
               ,@materialUnit
               ,@curNumber
               ,@checkNumber
               ,@profitNumber
               ,@lossNumber
               ,@price
               ,@profitMoney
               ,@lossMoney
               ,@cause
               ,@isClear
               ,@updateDate
               ,@reserved1
               ,@reserved2
               ,@remark
               ,@stockCode
               ,@stockName
               ,@materialDaima
               ,@barCode
               ,@productionDate
               ,@qualityDate
               ,@mainCode
)";
                SqlParameter[] sps =
                {
                new SqlParameter("@code",wid.code),
                new SqlParameter("@materialCode",wid.materialCode),
                new SqlParameter("@materialName",wid.materialName),
                new SqlParameter("@materialModel",wid.materialModel),
                new SqlParameter("@materialUnit",wid.materialUnit),
                new SqlParameter("@curNumber",wid.curNumber),
                new SqlParameter("@checkNumber",wid.checkNumber),
                new SqlParameter("@profitNumber",wid.profitNumber),
                new SqlParameter("@lossNumber",wid.lossNumber),
                new SqlParameter("@price",wid.price),
                new SqlParameter("@profitMoney",wid.profitMoney),
                new SqlParameter("@lossMoney",wid.lossMoney),
                new SqlParameter("@cause",wid.cause),
                new SqlParameter("@isClear",wid.isClear),
                new SqlParameter("@updateDate",wid.updateDate),
                new SqlParameter("@reserved1",wid.reserved1),
                new SqlParameter("@reserved2",wid.reserved2),
                new SqlParameter("@remark",wid.remark),
                new SqlParameter("@stockCode",wid.stockCode),
                new SqlParameter("@stockName",wid.stockName),
                new SqlParameter("@materialDaima",wid.materialDaima),
                new SqlParameter("@barCode",wid.barCode),
                new SqlParameter("@productionDate",wid.productionDate),
                new SqlParameter("@qualityDate",wid.qualityDate),
                new SqlParameter("@mainCode",wid.mainCode)
            };
                result = DbHelperSQL.ExecuteSql(sql, sps);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public int Modify(WarehouseInventoryDetail wid)
        {
            string sql = "";
            int result = 0;
            try
            {
                sql = @"UPDATE T_WarehouseInventoryDetail
                        SET materialCode = @materialCode
                        ,materialName = @materialName
                        ,materialModel = @materialModel
                        ,materialUnit = @materialUnit
                        ,curNumber = @curNumber
                        ,checkNumber = @checkNumber
                        ,profitNumber = @profitNumber
                        ,lossNumber = @lossNumber
                        ,price = @price
                        ,profitMoney = @profitMoney
                        ,lostMoney = @lostMoney
                        ,cause = @cause
                        ,isClear = @isClear
                        ,updateDate = @updateDate
                        ,reserved1 = @reserved1
                        ,reserved2 = @reserved2
                        ,remark = @remark 
                        ,stockCode = @stockCode 
                        ,stockName = @stockName 
                        ,materialDaima = @materialDaima 
                        ,barCode = @barCode 
                        ,productionDate = @productionDate 
                        ,qualityDate = @qualityDate 
                        ,mainCode = @mainCode 
                        where code = @code";
                SqlParameter[] sps =
                {
                new SqlParameter("@code",wid.code),
                new SqlParameter("@materialCode",wid.materialCode),
                new SqlParameter("@materialName",wid.materialName),
                new SqlParameter("@materialModel",wid.materialModel),
                new SqlParameter("@materialUnit",wid.materialUnit),
                new SqlParameter("@curNumber",wid.curNumber),
                new SqlParameter("@checkNumber",wid.checkNumber),
                new SqlParameter("@profitNumber",wid.profitNumber),
                new SqlParameter("@lossNumber",wid.lossNumber),
                new SqlParameter("@price",wid.price),
                new SqlParameter("@profitMoney",wid.profitMoney),
                new SqlParameter("@lossMoney",wid.lossMoney),
                new SqlParameter("@cause",wid.cause),
                new SqlParameter("@isClear",wid.isClear),
                new SqlParameter("@updateDate",wid.updateDate),
                new SqlParameter("@reserved1",wid.reserved1),
                new SqlParameter("@reserved2",wid.reserved2),
                new SqlParameter("@remark",wid.remark),
                new SqlParameter("@stockCode",wid.stockCode),
                new SqlParameter("@stockName",wid.stockName),
                new SqlParameter("@materialDaima",wid.materialDaima),
                new SqlParameter("@barCode",wid.barCode),
                new SqlParameter("@productionDate",wid.productionDate),
                new SqlParameter("@qualityDate",wid.qualityDate),
                new SqlParameter("@mainCode",wid.mainCode)
                };
                result = DbHelperSQL.ExecuteSql(sql, sps);
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
                sql = string.Format("select count(1) from T_WarehouseInventoryDetail where code='{0}'", code);
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
