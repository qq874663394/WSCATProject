using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Base
{
    public class MaterialBase
    {
        public int SetMaterialNumber(string materialCode, string price)
        {
            string sql = "";
            int result = 0;
            try
            {
                sql = string.Format(@"update T_BaseMaterial set price={0} where code='{1}'", price, materialCode);
                result = DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 自定义条件取得列表
        /// </summary>
        /// <param name="strWhere">where后面的条件</param>
        /// <returns></returns>
        public DataTable GetList(string strWhere)
        {
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = "select * from T_BaseMaterial";
                if (strWhere.Trim() != "")
                {
                    sql += " where " + strWhere;
                }
                ds = DbHelperSQL.Query(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds.Tables[0];
        }
        /// <summary>
        /// false不存在，true存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_BaseMasterial]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BaseMaterial model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_BaseMaterial] (");
            strSql.Append("picName,materialDaima,name,model,barCode,zhujima,code,typeID,typeName,price,peiceA,priceB,priceC,priceD,priceE,createDate,supplierName,supplierCode,number,unit,inPrice,outPrice,inDate,remark,isEnable,isClear,reserved1,reserved2,updateDate,productionDate,qualityDate,effectiveDate,isAssembly,isDouble)");
            strSql.Append(" values (");
            strSql.Append("@picName,@materialDaima,@name,@model,@barCode,@zhujima,@code,@typeID,@typeName,@price,@peiceA,@priceB,@priceC,@priceD,@priceE,@createDate,@supplierName,@supplierCode,@number,@unit,@inPrice,@outPrice,@inDate,@remark,@isEnable,@isClear,@reserved1,@reserved2,@updateDate,@productionDate,@qualityDate,@effectiveDate,@isAssembly,@isDouble)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@picName", SqlDbType.NVarChar,40),
                    new SqlParameter("@materialDaima", SqlDbType.NVarChar,45),
                    new SqlParameter("@name", SqlDbType.NVarChar,16),
                    new SqlParameter("@model", SqlDbType.NVarChar,100),
                    new SqlParameter("@barCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@zhujima", SqlDbType.NVarChar,45),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@typeID", SqlDbType.NVarChar,45),
                    new SqlParameter("@typeName", SqlDbType.NVarChar,20),
                    new SqlParameter("@price", SqlDbType.Decimal,9),
                    new SqlParameter("@peiceA", SqlDbType.Decimal,9),
                    new SqlParameter("@priceB", SqlDbType.Decimal,9),
                    new SqlParameter("@priceC", SqlDbType.Decimal,9),
                    new SqlParameter("@priceD", SqlDbType.Decimal,9),
                    new SqlParameter("@priceE", SqlDbType.Decimal,9),
                    new SqlParameter("@createDate", SqlDbType.DateTime),
                    new SqlParameter("@supplierName", SqlDbType.NVarChar,20),
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@number", SqlDbType.Decimal,9),
                    new SqlParameter("@unit", SqlDbType.NVarChar,8),
                    new SqlParameter("@inPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@outPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@inDate", SqlDbType.DateTime),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@isEnable", SqlDbType.Int,4),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@productionDate", SqlDbType.DateTime),
                    new SqlParameter("@qualityDate", SqlDbType.Decimal,9),
                    new SqlParameter("@effectiveDate", SqlDbType.DateTime),
                    new SqlParameter("@isAssembly", SqlDbType.Int,4),
                    new SqlParameter("@isDouble", SqlDbType.Int,4)};
            parameters[0].Value =model.picName;
            parameters[1].Value =model.materialDaima;
            parameters[2].Value =model.name;
            parameters[3].Value =model.model;
            parameters[4].Value =model.barCode;
            parameters[5].Value =model.zhujima;
            parameters[6].Value =model.code;
            parameters[7].Value =model.typeID;
            parameters[8].Value =model.typeName;
            parameters[9].Value = model.price;
            parameters[10].Value =model.peiceA;
            parameters[11].Value =model.priceB;
            parameters[12].Value =model.priceC;
            parameters[13].Value =model.priceD;
            parameters[14].Value =model.priceE;
            parameters[15].Value =model.createDate;
            parameters[16].Value =model.supplierName;
            parameters[17].Value =model.supplierCode;
            parameters[18].Value =model.number;
            parameters[19].Value =model.unit;
            parameters[20].Value =model.inPrice;
            parameters[21].Value =model.outPrice;
            parameters[22].Value =model.inDate;
            parameters[23].Value =model.remark;
            parameters[24].Value =model.isEnable;
            parameters[25].Value =model.isClear;
            parameters[26].Value =model.reserved1;
            parameters[27].Value =model.reserved2;
            parameters[28].Value =model.updateDate;
            parameters[29].Value =model.productionDate;
            parameters[30].Value =model.qualityDate;
            parameters[31].Value =model.effectiveDate;
            parameters[32].Value =model.isAssembly;
            parameters[33].Value = model.isDouble;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseMaterial] set isClear=0 ");
            strSql.Append(" where code=@code ");
            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除全部数据
        /// </summary>
        public bool DeleteAll()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseMaterial] set isClear=0 ");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BaseMaterial model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseMaterial] set ");
            strSql.Append("picName=@picName,");
            strSql.Append("materialDaima=@materialDaima,");
            strSql.Append("name=@name,");
            strSql.Append("model=@model,");
            strSql.Append("barCode=@barCode,");
            strSql.Append("zhujima=@zhujima,");
            strSql.Append("typeID=@typeID,");
            strSql.Append("typeName=@typeName,");
            strSql.Append("price=@price,");
            strSql.Append("peiceA=@peiceA,");
            strSql.Append("priceB=@priceB,");
            strSql.Append("priceC=@priceC,");
            strSql.Append("priceD=@priceD,");
            strSql.Append("priceE=@priceE,");
            strSql.Append("createDate=@createDate,");
            strSql.Append("supplierName=@supplierName,");
            strSql.Append("supplierCode=@supplierCode,");
            strSql.Append("number=@number,");
            strSql.Append("unit=@unit,");
            strSql.Append("inPrice=@inPrice,");
            strSql.Append("outPrice=@outPrice,");
            strSql.Append("inDate=@inDate,");
            strSql.Append("remark=@remark,");
            strSql.Append("isEnable=@isEnable,");
            strSql.Append("isClear=@isClear,");
            strSql.Append("reserved1=@reserved1,");
            strSql.Append("reserved2=@reserved2,");
            strSql.Append("updateDate=@updateDate,");
            strSql.Append("productionDate=@productionDate,");
            strSql.Append("qualityDate=@qualityDate,");
            strSql.Append("effectiveDate=@effectiveDate,");
            strSql.Append("isAssembly=@isAssembly,");
            strSql.Append("isDouble=@isDouble");
            strSql.Append(" where code=@code ");
            SqlParameter[] parameters = {
                    new SqlParameter("@picName", SqlDbType.NVarChar,40),
                    new SqlParameter("@materialDaima", SqlDbType.NVarChar,45),
                    new SqlParameter("@name", SqlDbType.NVarChar,16),
                    new SqlParameter("@model", SqlDbType.NVarChar,100),
                    new SqlParameter("@barCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@zhujima", SqlDbType.NVarChar,45),
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@typeID", SqlDbType.NVarChar,45),
                    new SqlParameter("@typeName", SqlDbType.NVarChar,20),
                    new SqlParameter("@price", SqlDbType.Decimal,9),
                    new SqlParameter("@peiceA", SqlDbType.Decimal,9),
                    new SqlParameter("@priceB", SqlDbType.Decimal,9),
                    new SqlParameter("@priceC", SqlDbType.Decimal,9),
                    new SqlParameter("@priceD", SqlDbType.Decimal,9),
                    new SqlParameter("@priceE", SqlDbType.Decimal,9),
                    new SqlParameter("@createDate", SqlDbType.DateTime),
                    new SqlParameter("@supplierName", SqlDbType.NVarChar,20),
                    new SqlParameter("@supplierCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@number", SqlDbType.Decimal,9),
                    new SqlParameter("@unit", SqlDbType.NVarChar,8),
                    new SqlParameter("@inPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@outPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@inDate", SqlDbType.DateTime),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@isEnable", SqlDbType.Int,4),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@productionDate", SqlDbType.DateTime),
                    new SqlParameter("@qualityDate", SqlDbType.Decimal,9),
                    new SqlParameter("@effectiveDate", SqlDbType.DateTime),
                    new SqlParameter("@isAssembly", SqlDbType.Int,4),
                    new SqlParameter("@isDouble", SqlDbType.Int,4)};
            parameters[0].Value =model.picName;
            parameters[1].Value =model.materialDaima;
            parameters[2].Value =model.name;
            parameters[3].Value =model.model;
            parameters[4].Value =model.barCode;
            parameters[5].Value =model.zhujima;
            parameters[6].Value =model.code;
            parameters[7].Value =model.typeID;
            parameters[8].Value =model.typeName;
            parameters[9].Value = model.price;
            parameters[10].Value =model.peiceA;
            parameters[11].Value =model.priceB;
            parameters[12].Value =model.priceC;
            parameters[13].Value =model.priceD;
            parameters[14].Value =model.priceE;
            parameters[15].Value =model.createDate;
            parameters[16].Value =model.supplierName;
            parameters[17].Value =model.supplierCode;
            parameters[18].Value =model.number;
            parameters[19].Value =model.unit;
            parameters[20].Value =model.inPrice;
            parameters[21].Value =model.outPrice;
            parameters[22].Value =model.inDate;
            parameters[23].Value =model.remark;
            parameters[24].Value =model.isEnable;
            parameters[25].Value =model.isClear;
            parameters[26].Value =model.reserved1;
            parameters[27].Value =model.reserved2;
            parameters[28].Value =model.updateDate;
            parameters[29].Value =model.productionDate;
            parameters[30].Value =model.qualityDate;
            parameters[31].Value =model.effectiveDate;
            parameters[32].Value =model.isAssembly;
            parameters[33].Value =model.isDouble;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
