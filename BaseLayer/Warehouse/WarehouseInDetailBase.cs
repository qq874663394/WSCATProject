
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Model;
using System.Collections.Generic;

namespace BaseLayer
{
    /// <summary>
    /// 数据访问类:T_WarehouseInDetail
    /// </summary>
    public partial class WarehouseInDetailBase
    {
        public WarehouseInDetailBase()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WarehouseInDetail model)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            try
            {
                strSql.Append("insert into T_WarehouseInDetail(");
                strSql.Append("code,materiaName,zhujima,materiaModel,materiaUnit,number,price,money,remark,reserved1,reserved2,isClear,barcode,rfid,updateDate,state,date,warehouseCode,warehouseName,mainCode)");
                strSql.Append(" values (");
                strSql.Append("@code,@materiaName,@zhujima,@materiaModel,@materiaUnit,@number,@price,@money,@remark,@reserved1,@reserved2,@isClear,@barcode,@rfid,@updateDate,@state,@date,@warehouseCode,@warehouseName,@mainCode)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = new SqlParameter[19];
                parameters[0] = new SqlParameter("@code", SqlDbType.NVarChar, 45);
                parameters[1] = new SqlParameter("@materiaName", SqlDbType.NVarChar, 100);
                parameters[2] = new SqlParameter("@materiaModel", SqlDbType.NVarChar, 100);
                parameters[3] = new SqlParameter("@materiaUnit", SqlDbType.NVarChar, 10);
                parameters[4] = new SqlParameter("@number", SqlDbType.Decimal, 9);
                parameters[5] = new SqlParameter("@price", SqlDbType.Decimal, 9);
                parameters[6] = new SqlParameter("@money", SqlDbType.Decimal, 9);
                parameters[7] = new SqlParameter("@remark", SqlDbType.NVarChar, 400);
                parameters[8] = new SqlParameter("@reserved1", SqlDbType.NVarChar, 50);
                parameters[9] = new SqlParameter("@reserved2", SqlDbType.NVarChar, 50);
                parameters[10] = new SqlParameter("@isClear", SqlDbType.Int, 4);
                parameters[11] = new SqlParameter("@barcode", SqlDbType.NVarChar, 100);
                parameters[12] = new SqlParameter("@rfid", SqlDbType.NVarChar, 100);
                parameters[13] = new SqlParameter("@updateDate", SqlDbType.DateTime);
                parameters[14] = new SqlParameter("@state", SqlDbType.Int, 4);
                parameters[15] = new SqlParameter("@date", SqlDbType.DateTime);
                parameters[16] = new SqlParameter("@warehouseCode", SqlDbType.NVarChar, 45);
                parameters[17] = new SqlParameter("@warehouseName", SqlDbType.NVarChar, 40);
                parameters[18] = new SqlParameter("@mainCode", SqlDbType.NVarChar, 45);
                parameters[19] = new SqlParameter("@zhujima", SqlDbType.NVarChar, 45);
                parameters[0].Value = model.code;
                parameters[1].Value = model.materiaName;
                parameters[2].Value = model.materiaModel;
                parameters[3].Value = model.materiaUnit;
                parameters[4].Value = model.number;
                parameters[5].Value = model.price;
                parameters[6].Value = model.money;
                parameters[7].Value = model.remark;
                parameters[8].Value = model.reserved1;
                parameters[9].Value = model.reserved2;
                parameters[10].Value = model.isClear;
                parameters[11].Value = model.barcode;
                parameters[12].Value = model.rfid;
                parameters[13].Value = model.updateDate;
                parameters[14].Value = model.state;
                parameters[15].Value = model.date;
                parameters[16].Value = model.warehouseCode;
                parameters[17].Value = model.warehouseName;
                parameters[18].Value = model.mainCode;
                parameters[19].Value = model.zhujima;
                result = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 根据code删除数据
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns></returns>
        public int deleteByCode(string code)
        {
            string deleteStr = "";
            int result = 0;
            try
            {
                deleteStr = "delete T_WarehouseInDetail where code = '" + code + "'";
                result = DbHelperSQL.ExecuteSql(deleteStr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 根据code更新数据
        /// </summary>
        /// <param name="wid">入库详细列表</param>
        /// <returns></returns>
        public int updateByCode(WarehouseInDetail wid)
        {
            string updateStr = "";
            try
            {
                updateStr = string.Format("update T_WarehouseInDetail set materiaName='{0}',zhujima='{22}',"
                    + "materiaModel='{1}',materiaUnit='{2}',number={3},price={4},money={5},barcode='{6}',"
                    + "rfid='{7}',updateDate='{8}',state={9},date='{10}',isClear={11},remark='{12}',"
                    + "reserved1='{13}',reserved2='{14}',storageRackName='{15}',storageRackCode='{16}',"
                    + "isArrive={17},warehouseCode='{18}',warehouseName='{19}',mainCode='{20}' where code='{21}'",
                    wid.materiaName,
                    wid.materiaModel,
                    wid.materiaUnit,
                    wid.number,
                    wid.price,
                    wid.money,
                    wid.barcode,
                    wid.rfid,
                    wid.updateDate,
                    wid.state,
                    wid.date,
                    wid.isClear,
                    wid.remark,
                    wid.reserved1,
                    wid.reserved2,
                    wid.storageRackName,
                    wid.storageRackName,
                    wid.isArrive,
                    wid.warehouseCode,
                    wid.warehouseName,
                    wid.mainCode,
                    wid.code,
                    wid.zhujima);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            int result = DbHelperSQL.ExecuteSql(updateStr);
            return result;
        }

        public DataSet getList(string strWhere)
        {
            DataSet ds = null;
            StringBuilder strSql = new StringBuilder();
            try
            {
                strSql.Append("select id,code,materiaName,zhujima,materiaModel,materiaUnit,number,price,money,barcode,rfid,updateDate,state,date,isClear,remark,reserved1,reserved2,storageRackName,storageRackCode,isArrive,warehouseCode,warehouseName,mainCode ");
                strSql.Append(" FROM T_WarehouseInDetail ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                ds = DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getListByMainCode(string mainCode)
        {
            DataSet ds = null;
            StringBuilder strSql = new StringBuilder();
            try
            {
                strSql.Append("select id,code,materiaName,zhujima,materialDaima,materiaModel,materiaUnit,number,price,money,barcode,rfid,updateDate,state,date,isClear,remark,reserved1,reserved2,storageRackName,storageRackCode,isArrive,warehouseCode,warehouseName,mainCode,productionDate,qualityDate,effectiveDate ");
                strSql.Append(" FROM T_WarehouseInDetail ");
                strSql.Append(" where mainCode = '" + mainCode + "'");
                ds = DbHelperSQL.Query(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int updateByCode(string code)
        {
            string updateStr = "";
            int result = 0;
            try
            {
                updateStr = string.Format("update T_WarehouseInDetail set state=1 where code='{0}'", code);
                result = DbHelperSQL.ExecuteSql(updateStr);
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
                sql = string.Format("select count(1) from T_WarehouseInDetail where code='{0}'", code);
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