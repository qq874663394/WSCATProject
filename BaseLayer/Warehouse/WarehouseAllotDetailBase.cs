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
    public class WarehouseAllotDetailBase
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WarehouseAllotDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_WarehouseAllotDetail] (");
            strSql.Append("code,mainCode,materialCode,materialDaima,materiaName,materiaModel,barcode,materiaUnit,curNumber,stoIncode,stoInName,stoOutcode,stoOutName,allotInPrice,allotInSummoney,allotOutPrice,allotOutSummoney,productionDate,qualityDate,effectiveDate,isClear,reserved1,reserved2,remark,updateDate)");
            strSql.Append(" values (");
            strSql.Append("@code,@mainCode,@materialCode,@materialDaima,@materiaName,@materiaModel,@barcode,@materiaUnit,@curNumber,@stoIncode,@stoInName,@stoOutcode,@stoOutName,@allotInPrice,@allotInSummoney,@allotOutPrice,@allotOutSummoney,@productionDate,@qualityDate,@effectiveDate,@isClear,@reserved1,@reserved2,@remark,@updateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
     new SqlParameter("@code", SqlDbType.NVarChar,45),
     new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
     new SqlParameter("@materialCode", SqlDbType.NVarChar,45),
     new SqlParameter("@materialDaima", SqlDbType.NVarChar,50),
     new SqlParameter("@materiaName", SqlDbType.NVarChar,100),
     new SqlParameter("@materiaModel", SqlDbType.NVarChar,100),
     new SqlParameter("@barcode", SqlDbType.NVarChar,100),
     new SqlParameter("@materiaUnit", SqlDbType.NVarChar,10),
     new SqlParameter("@curNumber", SqlDbType.Decimal,9),
     new SqlParameter("@stoIncode", SqlDbType.NVarChar,45),
     new SqlParameter("@stoInName", SqlDbType.NVarChar,40),
     new SqlParameter("@stoOutcode", SqlDbType.NVarChar,45),
     new SqlParameter("@stoOutName", SqlDbType.NVarChar,40),
     new SqlParameter("@allotInPrice", SqlDbType.Decimal,9),
     new SqlParameter("@allotInSummoney", SqlDbType.Decimal,9),
     new SqlParameter("@allotOutPrice", SqlDbType.Decimal,9),
     new SqlParameter("@allotOutSummoney", SqlDbType.Decimal,9),
     new SqlParameter("@productionDate", SqlDbType.DateTime),
     new SqlParameter("@qualityDate", SqlDbType.Decimal,9),
     new SqlParameter("@effectiveDate", SqlDbType.DateTime),
     new SqlParameter("@isClear", SqlDbType.Int,4),
     new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
     new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
     new SqlParameter("@remark", SqlDbType.NVarChar,400),
     new SqlParameter("@updateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.code;
            parameters[1].Value = model.mainCode;
            parameters[2].Value = model.materialCode;
            parameters[3].Value = model.materialDaima;
            parameters[4].Value = model.materiaName;
            parameters[5].Value = model.materiaModel;
            parameters[6].Value = model.barcode;
            parameters[7].Value = model.materiaUnit;
            parameters[8].Value = model.curNumber;
            parameters[9].Value = model.stoIncode;
            parameters[10].Value = model.stoInName;
            parameters[11].Value = model.stoOutcode;
            parameters[12].Value = model.stoOutName;
            parameters[13].Value = model.allotInPrice;
            parameters[14].Value = model.allotInSummoney;
            parameters[15].Value = model.allotOutPrice;
            parameters[16].Value = model.allotOutSummoney;
            parameters[17].Value = model.productionDate;
            parameters[18].Value = model.qualityDate;
            parameters[19].Value = model.effectiveDate;
            parameters[20].Value = model.isClear;
            parameters[21].Value = model.reserved1;
            parameters[22].Value = model.reserved2;
            parameters[23].Value = model.remark;
            parameters[24].Value = model.updateDate;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(WarehouseAllotDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_WarehouseAllotDetail] set ");
            strSql.Append("code=@code,");
            strSql.Append("mainCode=@mainCode,");
            strSql.Append("materialCode=@materialCode,");
            strSql.Append("materialDaima=@materialDaima,");
            strSql.Append("materiaName=@materiaName,");
            strSql.Append("materiaModel=@materiaModel,");
            strSql.Append("barcode=@barcode,");
            strSql.Append("materiaUnit=@materiaUnit,");
            strSql.Append("curNumber=@curNumber,");
            strSql.Append("stoIncode=@stoIncode,");
            strSql.Append("stoInName=@stoInName,");
            strSql.Append("stoOutcode=@stoOutcode,");
            strSql.Append("stoOutName=@stoOutName,");
            strSql.Append("allotInPrice=@allotInPrice,");
            strSql.Append("allotInSummoney=@allotInSummoney,");
            strSql.Append("allotOutPrice=@allotOutPrice,");
            strSql.Append("allotOutSummoney=@allotOutSummoney,");
            strSql.Append("productionDate=@productionDate,");
            strSql.Append("qualityDate=@qualityDate,");
            strSql.Append("effectiveDate=@effectiveDate,");
            strSql.Append("isClear=@isClear,");
            strSql.Append("reserved1=@reserved1,");
            strSql.Append("reserved2=@reserved2,");
            strSql.Append("remark=@remark,");
            strSql.Append("updateDate=@updateDate");
            strSql.Append(" where id=@id and curNumber=@curNumber and stoIncode=@stoIncode and stoInName=@stoInName and stoOutcode=@stoOutcode and stoOutName=@stoOutName and allotInPrice=@allotInPrice and allotInSummoney=@allotInSummoney and allotOutPrice=@allotOutPrice and allotOutSummoney=@allotOutSummoney and productionDate=@productionDate and code=@code and qualityDate=@qualityDate and effectiveDate=@effectiveDate and isClear=@isClear and reserved1=@reserved1 and reserved2=@reserved2 and remark=@remark and updateDate=@updateDate and mainCode=@mainCode and materialCode=@materialCode and materialDaima=@materialDaima and materiaName=@materiaName and materiaModel=@materiaModel and barcode=@barcode and materiaUnit=@materiaUnit ");
            SqlParameter[] parameters = {
     new SqlParameter("@code", SqlDbType.NVarChar,45),
     new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
     new SqlParameter("@materialCode", SqlDbType.NVarChar,45),
     new SqlParameter("@materialDaima", SqlDbType.NVarChar,50),
     new SqlParameter("@materiaName", SqlDbType.NVarChar,100),
     new SqlParameter("@materiaModel", SqlDbType.NVarChar,100),
     new SqlParameter("@barcode", SqlDbType.NVarChar,100),
     new SqlParameter("@materiaUnit", SqlDbType.NVarChar,10),
     new SqlParameter("@curNumber", SqlDbType.Decimal,9),
     new SqlParameter("@stoIncode", SqlDbType.NVarChar,45),
     new SqlParameter("@stoInName", SqlDbType.NVarChar,40),
     new SqlParameter("@stoOutcode", SqlDbType.NVarChar,45),
     new SqlParameter("@stoOutName", SqlDbType.NVarChar,40),
     new SqlParameter("@allotInPrice", SqlDbType.Decimal,9),
     new SqlParameter("@allotInSummoney", SqlDbType.Decimal,9),
     new SqlParameter("@allotOutPrice", SqlDbType.Decimal,9),
     new SqlParameter("@allotOutSummoney", SqlDbType.Decimal,9),
     new SqlParameter("@productionDate", SqlDbType.DateTime),
     new SqlParameter("@qualityDate", SqlDbType.Decimal,9),
     new SqlParameter("@effectiveDate", SqlDbType.DateTime),
     new SqlParameter("@isClear", SqlDbType.Int,4),
     new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
     new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
     new SqlParameter("@remark", SqlDbType.NVarChar,400),
     new SqlParameter("@updateDate", SqlDbType.DateTime),
     new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.code;
            parameters[1].Value = model.mainCode;
            parameters[2].Value = model.materialCode;
            parameters[3].Value = model.materialDaima;
            parameters[4].Value = model.materiaName;
            parameters[5].Value = model.materiaModel;
            parameters[6].Value = model.barcode;
            parameters[7].Value = model.materiaUnit;
            parameters[8].Value = model.curNumber;
            parameters[9].Value = model.stoIncode;
            parameters[10].Value = model.stoInName;
            parameters[11].Value = model.stoOutcode;
            parameters[12].Value = model.stoOutName;
            parameters[13].Value = model.allotInPrice;
            parameters[14].Value = model.allotInSummoney;
            parameters[15].Value = model.allotOutPrice;
            parameters[16].Value = model.allotOutSummoney;
            parameters[17].Value = model.productionDate;
            parameters[18].Value = model.qualityDate;
            parameters[19].Value = model.effectiveDate;
            parameters[20].Value = model.isClear;
            parameters[21].Value = model.reserved1;
            parameters[22].Value = model.reserved2;
            parameters[23].Value = model.remark;
            parameters[24].Value = model.updateDate;
            parameters[25].Value = model.id;

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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_WarehouseAllotDetail] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_WarehouseAllotDetail]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
