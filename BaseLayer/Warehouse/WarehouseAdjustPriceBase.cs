using Model;
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
    public class WarehouseAdjustPriceBase
    {
        public DataTable Search(string strWhere)
        {
            string sql = ""; 
            DataTable dt = null;
            try
            {
                sql = "select * from T_WarehouseAdjustPriceDetail";
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
        public object Add(WarehouseAdjustPrice model, List<WarehouseAdjustPriceDetail> listModel)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            string sqlDetail = "";
            string sqlMain = "";
            try
            {
                sqlMain = @"INSERT INTO [T_WarehouseAdjustPrice]
([code]
,[type]
,[date]
,[operationMan]
,[makeMan]
,[checkMan]
,[checkState]
,[isClear]
,[updateDate]
,[remark]
,[reserved1]
,[reserved2])
VALUES
(@code 
,@type 
,@date 
,@operationMan
,@makeMan
,@checkMan
,@checkState
,@isClear
,@updateDate
,@remark 
,@reserved1
,@reserved2);select scope_identity();";
                SqlParameter[] spsMain =
                {
                new SqlParameter("@code",model.code),
                new SqlParameter("@type",model.type),
                new SqlParameter("@date",model.date),
                new SqlParameter("@operationMan",model.operationMan),
                new SqlParameter("@makeMan",model.makeMan),
                new SqlParameter("@checkMan",model.checkMan),
                new SqlParameter("@checkState",model.checkState),
                new SqlParameter("@isClear",model.isClear),
                new SqlParameter("@updateDate",model.updateDate),
                new SqlParameter("@remark",model.remark),
                new SqlParameter("@reserved1",model.reserved1),
                new SqlParameter("@reserved2",model.reserved2),
                };
                hashTable.Add(sqlMain, spsMain);
                sqlDetail = @"INSERT INTO [T_WarehouseAdjustPriceDetail]
           ([code]
           ,[mainCode]
           ,[materialDaima]
           ,[barCode]
           ,[materialCode]
           ,[materialName]
           ,[materialModel]
           ,[materialUnit]
           ,[stockcode]
           ,[stockName]
           ,[number]
           ,[curPrice]
           ,[curMoney]
           ,[scale]
           ,[price]
           ,[money]
           ,[lostMoney]
           ,[cause]
           ,[isClear]
           ,[updateDate]
           ,[reserved1]
           ,[reserved2]
           ,[remark])
     VALUES
			   (@code
           ,@mainCode
      ,@materialDaima
            ,@barCode
       ,@materialCode
       ,@materialName
      ,@materialModel
       ,@materialUnit
          ,@stockCode
          ,@stockName
             ,@number
           ,@curPrice
           ,@curMoney
	 	      ,@scale
	  	      ,@price
		      ,@money
		  ,@lostMoney
		      ,@cause
		    ,@isClear
         ,@updateDate
 	      ,@reserved1
          ,@reserved2
		     ,@remark);select SCOPE_IDENTITY();";

                foreach (var item in listModel)
                {
                    SqlParameter[] spsDetail =
                    {
                        new SqlParameter("@code",item.code),
                        new SqlParameter("@mainCode",item.mainCode),
                        new SqlParameter("@materialDaima",item.materiaDaima),
                        new SqlParameter("@barCode",item.barCode),
                        new SqlParameter("@materialCode",item.materialCode),
                        new SqlParameter("@materialName",item.materialName),
                        new SqlParameter("@materialModel",item.materialModel),
                        new SqlParameter("@materialUnit",item.materialUnit),
                        new SqlParameter("@stockCode",item.stockCode),
                        new SqlParameter("@stockName",item.stockName),
                        new SqlParameter("@number",item.number),
                        new SqlParameter("@curPrice",item.curPrice),
                        new SqlParameter("@curMoney",item.curMoney),
                        new SqlParameter("@scale",item.scale),
                        new SqlParameter("@price",item.price),
                        new SqlParameter("@money",item.money),
                        new SqlParameter("@lostMoney",item.lostMoney),
                        new SqlParameter("@cause",item.cause),
                        new SqlParameter("@isClear",item.isClear),
                        new SqlParameter("@updateDate",item.updateDate),
                        new SqlParameter("@reserved1",item.reserved1),
                        new SqlParameter("@reserved2",item.reserved2),
                        new SqlParameter("@remark",item.remark)
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
        public object Modify(WarehouseAdjustPrice model, List<WarehouseAdjustPriceDetail> listModel)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            string sqlDetail = "";
            string sqlMain = "";
            try
            {
                sqlMain = @"UPDATE [T_WarehouseAdjustPrice]
   SET [type] = @type
		,[date] = @date
,[operationMan] = @operationMan
	 ,[makeMan] = @makeMan
    ,[checkMan] = @checkMan 
  ,[checkState] = @checkState
     ,[isClear] = @isClear
  ,[updateDate] = @updateDate 
	  ,[remark] = @remark
   ,[reserved1] = @reserved1
   ,[reserved2] = @reserved2 where [code] = @code;select scope_identity();";
                SqlParameter[] spsMain =
                {
                new SqlParameter("@code",model.code),
                new SqlParameter("@type",model.type),
                new SqlParameter("@date",model.date),
                new SqlParameter("@operationMan",model.operationMan),
                new SqlParameter("@makeMan",model.makeMan),
                new SqlParameter("@checkMan",model.checkMan),
                new SqlParameter("@checkState",model.checkState),
                new SqlParameter("@isClear",model.isClear),
                new SqlParameter("@updateDate",model.updateDate),
                new SqlParameter("@remark",model.remark),
                new SqlParameter("@reserved1",model.reserved1),
                new SqlParameter("@reserved2",model.reserved2),
                };
                hashTable.Add(sqlMain, spsMain);
                sqlDetail = @"update [T_WarehouseAdjustPriceDetail] set 
[materialDaima] = @materialDaima,
[barCode] = @barCode,
[materialCode] = @materialCode,
[materialName] = @materialName,
[materialModel] = @materialModel,
[materialUnit] = @materialUnit,
[stockCode] = @stockCode,
[stockName] = @stockName,
[number] = @number,
[curPrice] = @curPrice,
[curMoney] = @curMoney,
[scale] = @scale,
[price] = @price,
[money] = @money,
[lostMoney] = @lostMoney,
[cause] = @cause,
[isClear] = @isClear,
[updateDate] = @updateDate,
[reserved1] = @reserved1,
[reserved2] = @reserved2,
[remark] = @remark where mainCode=@mainCode and code=@code;select SCOPE_IDENTITY();";

                foreach (var item in listModel)
                {
                    SqlParameter[] spsDetail =
                    {
                        new SqlParameter("@stockCode", item.stockCode) ,
                        new SqlParameter("@stockName",item.stockName ) ,
                        new SqlParameter("@number", item.number) ,
                        new SqlParameter("@curPrice", item.curPrice) ,
                        new SqlParameter("@curMoney", item.curMoney) ,
                        new SqlParameter("@scale", item.scale) ,
                        new SqlParameter("@price", item.price) ,
                        new SqlParameter("@money", item.money) ,
                        new SqlParameter("@lostMoney", item.lostMoney) ,
                        new SqlParameter("@cause", item.cause) ,
                        new SqlParameter("@code", item.code) ,
                        new SqlParameter("@isClear", item.isClear) ,
                        new SqlParameter("@updateDate", item.updateDate) ,
                        new SqlParameter("@reserved1", item.reserved1) ,
                        new SqlParameter("@reserved2", item.reserved2) ,
                        new SqlParameter("@remark", item.remark) ,
                        new SqlParameter("@mainCode", item.mainCode) ,
                        new SqlParameter("@materialDaima",item.materiaDaima) ,
                        new SqlParameter("@barCode",item.barCode) ,
                        new SqlParameter("@materialCode",item.materialCode) ,
                        new SqlParameter("@materialName",item.materialName) ,
                        new SqlParameter("@materialModel",item.materialModel) ,
                        new SqlParameter("@materialUnit",item.materialUnit)
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
                sql = string.Format("select count(1) from T_WarehouseAdjustPrice where code='{0}'", code);
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