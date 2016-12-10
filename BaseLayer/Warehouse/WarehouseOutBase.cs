using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using System.Collections;

namespace BaseLayer
{
    public class WarehouseOutBase
    {
        /// <summary>
        /// 根据审核状态查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetListToOut(int state)
        {
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = string.Format("select code,defaultType,salesCode as mainCode,date,state,operation,examine from T_WarehouseOut where checkState={0}", state);
                ds = DbHelperSQL.Query(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        /// <summary>
        /// 根据where条件获取出库单列表
        /// </summary>
        /// <param name="strWhere">where后面的条件</param>
        /// <returns>根据where条件获取出库单列表</returns>
        public DataTable GetList(string strWhere)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = "select * from T_WarehouseOut";
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
        /// 事务新增
        /// </summary>
        /// <param name="hashTable">主表的sql和parameter</param>
        /// <param name="sql">子表sql</param>
        /// <param name="list">子表的parameter</param>
        public object Add(WarehouseOut warehouseOut, List<WarehouseOutDetail> warehouseOutDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            string sqlDetail = "";
            string sqlMain = "";
            try
            {
                sqlMain = @"INSERT INTO T_WarehouseOut (code,type,stock,operation,examine,isClear,updateDate,state,salesCode
           ,date
           ,checkState
           ,remark
           ,reserved1
           ,reserved2
           ,delivey
           ,clientCode
           ,expressOdd
           ,expressMan
           ,expressPhone
           ,defaultType
            ,makeMan
            ,clientName
            ,salesPhone)
     VALUES
           (@code,@type,@stock,@operation,@examine,@isClear,@updateDate,@state,@salesCode
           ,@date
           ,@checkState
           ,@remark
           ,@reserved1
           ,@reserved2
           ,@delivey
           ,@clientCode
           ,@expressOdd
           ,@expressMan
           ,@expressPhone
           ,@defaultType
            ,@makeMan
            ,@clientName
            ,@salesPhone)select SCOPE_IDENTITY()";
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@code",warehouseOut.code),
                    new SqlParameter("@type",warehouseOut.type),
                    new SqlParameter("@stock",warehouseOut.stock),
                    new SqlParameter("@operation",warehouseOut.operation),
                    new SqlParameter("@examine",warehouseOut.examine),
                    new SqlParameter("@isClear",warehouseOut.isClear),
                    new SqlParameter("@updateDate",warehouseOut.updateDate),
                    new SqlParameter("@state",warehouseOut.state),
                    new SqlParameter("@salesCode",warehouseOut.salesCode),
                    new SqlParameter("@date",warehouseOut.date),
                    new SqlParameter("@checkState",warehouseOut.checkState),
                    new SqlParameter("@remark",warehouseOut.remark),
                    new SqlParameter("@reserved1",warehouseOut.reserved1),
                    new SqlParameter("@reserved2",warehouseOut.reserved2),
                    new SqlParameter("@delivey",warehouseOut.delivery),
                    new SqlParameter("@clientCode",warehouseOut.clientCode),
                    new SqlParameter("@expressOdd",warehouseOut.expressOdd),
                    new SqlParameter("@expressMan",warehouseOut.expressMan),
                    new SqlParameter("@expressPhone",warehouseOut.expressPhone),
                    new SqlParameter("@defaultType",warehouseOut.defaultType),
                    new SqlParameter("@makeMan",warehouseOut.MakeMan),
                    new SqlParameter("@clientName",warehouseOut.ClientName),
                    new SqlParameter("@salesPhone",warehouseOut.SalesPhone)
                };
                hashTable.Add(sqlMain, spsMain);
                sqlDetail = @"INSERT INTO T_WarehouseOutDetail(code,materialDaima,materialCode,materialName,materialModel,
                materiaUnit,number,price,money,barcode,rfid,updateDate,state,date,isClear,reserved1,reserved2,remark,storageRackName,
                storageRackCode,isArrive,warehouseCode,warehouseName,MainCode,productionDate,qualityDate,effectiveDate)
                VALUES(@code,@materialDaima,@materialCode,@materialName,@materialModel,@materiaUnit,@number,@price
                ,@money,@barcode,@rfid,@updateDate,@state,@date,@isClear,@reserved1,@reserved2,@remark,@storageRackName
                ,@storageRackCode,@isArrive,@warehouseCode,@warehouseName,@mainCode,@productionDate,@qualityDate,@effectiveDate)select SCOPE_IDENTITY()";
                //sqlDetail = @"INSERT INTO T_WarehouseOutDetail(code,materialDaima,materialCode,materiaName,materiaModel,
                //materiaUnit,number,price,money,barcode,rfid,updateDate,state,date,isClear,reserved1,reserved2,remark,storageRackName,
                //storageRackCode,isArrive,warehouseCode,warehouseName,MainCode,productionDate,qualityDate,effectiveDate)
                //VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7}
                //,{8},'{9}','{10}','{11}',{12},'{13}','{14}','{15}','{16}','{17}','{18}'
                //,'{19}',{20},'{21}','{22}','{23}','{24}','{25}','{26}')";
                foreach (var item in warehouseOutDetail)
                {
                    SqlParameter[] spsDetail =
                    {
                        new SqlParameter("@code",item.code),
                        new SqlParameter("@materialDaima",item.code),
                        new SqlParameter("@materialCode",item.materialCode),
                        new SqlParameter("@materialName",item.materialName),
                        new SqlParameter("@materialModel",item.materialModel),
                        new SqlParameter("@materiaUnit",item.materiaUnit),
                        new SqlParameter("@number",item.number),
                        new SqlParameter("@price",item.price),
                        new SqlParameter("@money",item.money),
                        new SqlParameter("@barcode",item.barcode),
                        new SqlParameter("@rfid",item.rfid),
                        new SqlParameter("@updateDate",item.updateDate),
                        new SqlParameter("@state",item.state),
                        new SqlParameter("@date",item.date),
                        new SqlParameter("@isClear",item.isClear),
                        new SqlParameter("@reserved1",item.reserved1),
                        new SqlParameter("@reserved2",item.reserved2),
                        new SqlParameter("@remark",item.remark),
                        new SqlParameter("@storageRackName",item.StorageRackName),
                        new SqlParameter("@storageRackCode",item.StorageRackCode),
                        new SqlParameter("@isArrive",item.IsArrive),
                        new SqlParameter("@warehouseCode",item.WarehouseCode),
                        new SqlParameter("@warehouseName",item.WarehouseName),
                        new SqlParameter("@mainCode",item.MainCode),
                        new SqlParameter("@productionDate",item.productionDate),
                        new SqlParameter("@qualityDate",item.qualityDate),
                        new SqlParameter("@effectiveDate",item.effectiveDate)
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
        /// 更新主表和从表
        /// </summary>
        /// <param name="warehouseOut">主表：只有一行数据</param>
        /// <param name="listModel">从表：多行，用List类型保存多条model的数据</param>
        public int update(WarehouseOut warehouseOut, List<WarehouseOutDetail> listModel)
        {
            int result = 0;
            //多条数据的
            string sqlToList = @"UPDATE T_WarehouseOutDetail
   SET code = @code
      , materialCode = @materialCode
      , materiaName = @materiaName
      , materiaModel = @materiaModel
      , materiaUnit = @materiaUnit
      , number = @number
      , price = @price
      , money = @money
      , barcode = @barcode
      , rfid = @rfid
      , updateDate = @updateDate
      , state = @state
      , date = @date
      , isClear = @isClear
      , reserved1 = @reserved1
      , reserved2 = @reserved2
      , remark = @remark
      , storageRackName = @storageRackName
      , storageRackCode = @storageRackCode
      , isArrive = @isArrive
      , warehouseCode = @warehouseCode
      , warehouseName = @warehouseName
      , productionDate = @productionDate
      , qualityDate = @qualityDate
      , effectiveDate = @effectiveDate where 
       mainCode = @mainCode";
            //多条数据的值  要添加到list里   就像普通的参数集  不过最后添加到list里了
            List<SqlParameter[]> listParameter = new List<SqlParameter[]>();//存储参数集合的list
            SqlParameter[] sps;  //定义一个参数集合
            foreach (var item in listModel)
            {
                sps = new SqlParameter[]
                {
                        new SqlParameter("@code",item.code),
                        new SqlParameter("@materialCode",item.WarehouseCode),
                        new SqlParameter("@materiaName",item.materialName),
                        new SqlParameter("@materiaModel",item.materialModel),
                        new SqlParameter("@materiaUnit",item.materiaUnit),
                        new SqlParameter("@number",item.number),
                        new SqlParameter("@price",item.price),
                        new SqlParameter("@money",item.money),
                        new SqlParameter("@barcode",item.barcode),
                        new SqlParameter("@rfid",item.rfid),
                        new SqlParameter("@updateDate",item.updateDate),
                        new SqlParameter("@state",item.state),
                        new SqlParameter("@date",item.date),
                        new SqlParameter("@isClear",item.isClear),
                        new SqlParameter("@reserved1",item.reserved1),
                        new SqlParameter("@reserved2",item.reserved2),
                        new SqlParameter("@remark",item.remark),
                        new SqlParameter("@storageRackName",item.StorageRackName),
                        new SqlParameter("@storageRackCode",item.StorageRackCode),
                        new SqlParameter("@isArrive",item.StorageRackCode),
                        new SqlParameter("@warehouseCode",item.WarehouseCode),
                        new SqlParameter("@warehouseName",item.WarehouseName),
                        new SqlParameter("@productionDate",item.productionDate),
                        new SqlParameter("@qualityDate",item.qualityDate),
                        new SqlParameter("@effectiveDate",item.effectiveDate),
                        new SqlParameter("@mainCode",item.MainCode)
                };
                listParameter.Add(sps);
            }

            Hashtable htKey = new Hashtable();  //参数要求
            string sqlInert = @"INSERT INTO T_WarehouseOutDetail(code,materialDaima,materialCode,materialName,materialModel,
                materiaUnit,number,price,money,barcode,rfid,updateDate,state,date,isClear,reserved1,reserved2,remark,storageRackName,
                storageRackCode,isArrive,warehouseCode,warehouseName,MainCode,productionDate,qualityDate,effectiveDate)
                VALUES(@code,@materialDaima,@materialCode,@materialName,@materialModel,@materiaUnit,@number,@price
                ,@money,@barcode,@rfid,@updateDate,@state,@date,@isClear,@reserved1,@reserved2,@remark,@storageRackName
                ,@storageRackCode,@isArrive,@warehouseCode,@warehouseName,@mainCode,@productionDate,@qualityDate,@effectiveDate)select SCOPE_IDENTITY()";
            string sql = @"UPDATE T_WarehouseOut
SET type = @type
,stock = @stock
,operation = @operation
,examine = @examine
,isClear = @isClear
,updateDate = @updateDate
,state = @state
,salesCode = @salesCode
,date = @date
,checkState = @checkState
,remark = @remark
,reserved1 = @reserved1
,reserved2 = @reserved2
,delivey = @delivey
,clientCode = @clientCode
,expressOdd = @expressOdd
,expressMan = @expressMan
,expressPhone = @expressPhone
,defaultType = @defaultType
,makeMan=@makeMan
,clientName=@clientName
,salesPhone=@salesPhone
WHERE code = @code";  //主表的
            SqlParameter[] parameters = //主表参数
            {
                            new SqlParameter("@code",warehouseOut.code),
                            new SqlParameter("@type",warehouseOut.type),
                            new SqlParameter("@stock",warehouseOut.stock),
                            new SqlParameter("@operation",warehouseOut.operation),
                            new SqlParameter("@examine",warehouseOut.examine),
                            new SqlParameter("@isClear",warehouseOut.isClear),
                            new SqlParameter("@updateDate",warehouseOut.updateDate),
                            new SqlParameter("@state",warehouseOut.state),
                            new SqlParameter("@salesCode",warehouseOut.salesCode),
                            new SqlParameter("@date",warehouseOut.date),
                            new SqlParameter("@checkState",warehouseOut.checkState),
                            new SqlParameter("@remark",warehouseOut.remark),
                            new SqlParameter("@reserved1",warehouseOut.reserved1),
                            new SqlParameter("@reserved2",warehouseOut.reserved2),
                            new SqlParameter("@delivey",warehouseOut.delivery),
                            new SqlParameter("@clientCode",warehouseOut.clientCode),
                            new SqlParameter("@expressOdd",warehouseOut.expressOdd),
                            new SqlParameter("@expressMan",warehouseOut.expressMan),
                            new SqlParameter("@expressPhone",warehouseOut.expressPhone),
                            new SqlParameter("@defaultType",warehouseOut.defaultType),
                            new SqlParameter("@makeMan",warehouseOut.MakeMan),
                            new SqlParameter("@clientName",warehouseOut.ClientName),
                            new SqlParameter("@salesPhone",warehouseOut.SalesPhone)
            };
            htKey.Add(sql, parameters);//sql语句和主表的参数集合
            try
            {
                result = Convert.ToInt32(DbHelperSQL.ExecuteSqlTranScalar(htKey, sqlToList,sqlInert, listParameter));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 上下一单
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="state">状态:0:下一单,1:上一单</param>
        /// <returns></returns>
        public WarehouseOut GetPreAndNext(int id, int state)
        {
            string sql = "";
            try
            {
                if (state == 0)
                {
                    sql = string.Format("select top 1 * from T_WarehouseOut where id>{0}", id);
                }
                else
                {
                    sql = string.Format("select top 1 * from T_WarehouseOut where id<{0} order by id desc", id);
                }

                SqlDataReader read = DbHelperSQL.ExecuteReader(sql);
                if (read.Read())
                {
                    WarehouseOut wo = new WarehouseOut()
                    {
                        id = Convert.ToInt32(read["id"]),
                        code = read["code"].ToString(),
                        type = read["type"].ToString(),
                        stock = read["stock"].ToString(),
                        operation = read["operation"].ToString(),
                        examine = read["examine"].ToString(),
                        isClear = Convert.ToInt32(read["isClear"]),
                        updateDate = Convert.ToDateTime(read["updateDate"]),
                        state = Convert.ToInt32(read["state"]),
                        salesCode = read["salesCode"].ToString(),
                        date = Convert.ToDateTime(read["date"]),
                        checkState = Convert.ToInt32(read["checkState"]),
                        remark = read["remark"].ToString(),
                        reserved1 = read["reserved1"].ToString(),
                        reserved2 = read["reserved2"].ToString(),
                        delivery = read["delivery"].ToString(),
                        clientCode = read["clientCode"].ToString(),
                        expressOdd = read["expressOdd"].ToString(),
                        expressMan = read["expressMan"].ToString(),
                        defaultType = read["defaultType"].ToString(),
                        expressPhone = read["expressPhone"].ToString(),
                        ClientName = read["clientName"].ToString(),
                        MakeMan = read["makeMan"].ToString(),
                        SalesPhone = read["salesPhone"].ToString()
                    };
                    return wo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
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
                sql = string.Format("select count(1) from T_WarehouseMain where code='{0}'", code);
                isflag = DbHelperSQL.Exists(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isflag;
        }
    }
}
