using Model;
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
    public class WarehouseAllotBase
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_WarehouseAllot] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_WarehouseAllot]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                new SqlParameter("@code", SqlDbType.NVarChar,45)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public object Add(WarehouseAllot model, List<WarehouseAllotDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            StringBuilder sqlDetail = new StringBuilder();
            StringBuilder sqlMain = new StringBuilder();
            try
            {
                #region 主表语句和参数
                sqlMain.Append("insert into [T_WarehouseAllot] (");
                sqlMain.Append("code,date,operationMan,checkMan,cause,updateDate,isClear,reserved1,reserved2,remark,allotGap,checkState,allotType,makeMan)");
                sqlMain.Append(" values (");
                sqlMain.Append("@code,@date,@operationMan,@checkMan,@cause,@updateDate,@isClear,@reserved1,@reserved2,@remark,@allotGap,@checkState,@allotType,@makeMan)");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain = {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@operationMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@cause", SqlDbType.NVarChar,100),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@allotGap", SqlDbType.Decimal,9),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@allotType", SqlDbType.NVarChar,100),
                    new SqlParameter("@makeMan", SqlDbType.NVarChar,40)};
                spsMain[0].Value = model.code;
                spsMain[1].Value = model.date;
                spsMain[2].Value = model.operationMan;
                spsMain[3].Value = model.checkMan;
                spsMain[4].Value = model.cause;
                spsMain[5].Value = model.updateDate;
                spsMain[6].Value = model.isClear;
                spsMain[7].Value = model.reserved1;
                spsMain[8].Value = model.reserved2;
                spsMain[9].Value = model.remark;
                spsMain[10].Value = model.allotGap;
                spsMain[11].Value = model.checkState;
                spsMain[12].Value = model.allotType;
                spsMain[13].Value = model.makeMan;
                #endregion
                hashTable.Add(sqlMain, spsMain);
                #region 从表语句和参数
                sqlDetail.Append("insert into [T_WarehouseAllotDetail] (");
                sqlDetail.Append("code,mainCode,materialCode,materialDaima,materiaName,materiaModel,barcode,materiaUnit,curNumber,stoIncode,stoInName,stoOutcode,stoOutName,allotInPrice,allotInSummoney,allotOutPrice,allotOutSummoney,productionDate,qualityDate,effectiveDate,isClear,reserved1,reserved2,remark,updateDate)");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@code,@mainCode,@materialCode,@materialDaima,@materiaName,@materiaModel,@barcode,@materiaUnit,@curNumber,@stoIncode,@stoInName,@stoOutcode,@stoOutName,@allotInPrice,@allotInSummoney,@allotOutPrice,@allotOutSummoney,@productionDate,@qualityDate,@effectiveDate,@isClear,@reserved1,@reserved2,@remark,@updateDate)");
                sqlDetail.Append(";select @@IDENTITY");

                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail = {
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
                    spsDetail[0].Value = item.code;
                    spsDetail[1].Value = item.mainCode;
                    spsDetail[2].Value = item.materialCode;
                    spsDetail[3].Value = item.materialDaima;
                    spsDetail[4].Value = item.materiaName;
                    spsDetail[5].Value = item.materiaModel;
                    spsDetail[6].Value = item.barcode;
                    spsDetail[7].Value = item.materiaUnit;
                    spsDetail[8].Value = item.curNumber;
                    spsDetail[9].Value = item.stoIncode;
                    spsDetail[10].Value = item.stoInName;
                    spsDetail[11].Value = item.stoOutcode;
                    spsDetail[12].Value = item.stoOutName;
                    spsDetail[13].Value = item.allotInPrice;
                    spsDetail[14].Value = item.allotInSummoney;
                    spsDetail[15].Value = item.allotOutPrice;
                    spsDetail[16].Value = item.allotOutSummoney;
                    spsDetail[17].Value = item.productionDate;
                    spsDetail[18].Value = item.qualityDate;
                    spsDetail[19].Value = item.effectiveDate;
                    spsDetail[20].Value = item.isClear;
                    spsDetail[21].Value = item.reserved1;
                    spsDetail[22].Value = item.reserved2;
                    spsDetail[23].Value = item.remark;
                    spsDetail[24].Value = item.updateDate;
                    list.Add(spsDetail);
                }
                #endregion
                result = DbHelperSQL.ExecuteSqlTranScalar(hashTable, sqlDetail.ToString(), list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public object Modify(WarehouseAllot model, List<WarehouseAllotDetail> modelDetail)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            StringBuilder sqlDetail = new StringBuilder();
            StringBuilder sqlMain = new StringBuilder();
            try
            {
                #region 主表语句和参数
                sqlMain.Append("update [T_WarehouseAllot] set ");
                sqlMain.Append("date=@date,");
                sqlMain.Append("operationMan=@operationMan,");
                sqlMain.Append("checkMan=@checkMan,");
                sqlMain.Append("cause=@cause,");
                sqlMain.Append("updateDate=@updateDate,");
                sqlMain.Append("isClear=@isClear,");
                sqlMain.Append("reserved1=@reserved1,");
                sqlMain.Append("reserved2=@reserved2,");
                sqlMain.Append("remark=@remark,");
                sqlMain.Append("allotGap=@allotGap,");
                sqlMain.Append("checkState=@checkState,");
                sqlMain.Append("allotType=@allotType,");
                sqlMain.Append("makeMan=@makeMan");
                sqlMain.Append(" where code=@code ");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain = {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@operationMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@checkMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@cause", SqlDbType.NVarChar,100),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@allotGap", SqlDbType.Decimal,9),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@allotType", SqlDbType.NVarChar,100),
                    new SqlParameter("@makeMan", SqlDbType.NVarChar,40)};
                spsMain[0].Value = model.code;
                spsMain[1].Value = model.date;
                spsMain[2].Value = model.operationMan;
                spsMain[3].Value = model.checkMan;
                spsMain[4].Value = model.cause;
                spsMain[5].Value = model.updateDate;
                spsMain[6].Value = model.isClear;
                spsMain[7].Value = model.reserved1;
                spsMain[8].Value = model.reserved2;
                spsMain[9].Value = model.remark;
                spsMain[10].Value = model.allotGap;
                spsMain[11].Value = model.checkState;
                spsMain[12].Value = model.allotType;
                spsMain[13].Value = model.makeMan;
                #endregion
                hashTable.Add(sqlMain, spsMain);
                #region 从表语句和参数
                sqlDetail.Append("update [T_WarehouseAllotDetail] set ");
                sqlDetail.Append("materialDaima=@materialDaima,");
                sqlDetail.Append("materiaName=@materiaName,");
                sqlDetail.Append("materiaModel=@materiaModel,");
                sqlDetail.Append("barcode=@barcode,");
                sqlDetail.Append("materiaUnit=@materiaUnit,");
                sqlDetail.Append("curNumber=@curNumber,");
                sqlDetail.Append("stoIncode=@stoIncode,");
                sqlDetail.Append("stoInName=@stoInName,");
                sqlDetail.Append("stoOutcode=@stoOutcode,");
                sqlDetail.Append("stoOutName=@stoOutName,");
                sqlDetail.Append("allotInPrice=@allotInPrice,");
                sqlDetail.Append("allotInSummoney=@allotInSummoney,");
                sqlDetail.Append("allotOutPrice=@allotOutPrice,");
                sqlDetail.Append("allotOutSummoney=@allotOutSummoney,");
                sqlDetail.Append("productionDate=@productionDate,");
                sqlDetail.Append("qualityDate=@qualityDate,");
                sqlDetail.Append("effectiveDate=@effectiveDate,");
                sqlDetail.Append("isClear=@isClear,");
                sqlDetail.Append("reserved1=@reserved1,");
                sqlDetail.Append("reserved2=@reserved2,");
                sqlDetail.Append("remark=@remark,");
                sqlDetail.Append("updateDate=@updateDate");
                sqlDetail.Append(" where mainCode=@mainCode and code=@code");
                sqlDetail.Append(";select @@IDENTITY");
                foreach (var item in modelDetail)
                {
                    SqlParameter[] spsDetail = {
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
                    spsDetail[0].Value = item.code;
                    spsDetail[1].Value = item.mainCode;
                    spsDetail[2].Value = item.materialCode;
                    spsDetail[3].Value = item.materialDaima;
                    spsDetail[4].Value = item.materiaName;
                    spsDetail[5].Value = item.materiaModel;
                    spsDetail[6].Value = item.barcode;
                    spsDetail[7].Value = item.materiaUnit;
                    spsDetail[8].Value = item.curNumber;
                    spsDetail[9].Value = item.stoIncode;
                    spsDetail[10].Value = item.stoInName;
                    spsDetail[11].Value = item.stoOutcode;
                    spsDetail[12].Value = item.stoOutName;
                    spsDetail[13].Value = item.allotInPrice;
                    spsDetail[14].Value = item.allotInSummoney;
                    spsDetail[15].Value = item.allotOutPrice;
                    spsDetail[16].Value = item.allotOutSummoney;
                    spsDetail[17].Value = item.productionDate;
                    spsDetail[18].Value = item.qualityDate;
                    spsDetail[19].Value = item.effectiveDate;
                    spsDetail[20].Value = item.isClear;
                    spsDetail[21].Value = item.reserved1;
                    spsDetail[22].Value = item.reserved2;
                    spsDetail[23].Value = item.remark;
                    spsDetail[24].Value = item.updateDate;
                    spsDetail[25].Value = item.id;
                    list.Add(spsDetail);
                }
                #endregion
                result = DbHelperSQL.ExecuteSqlTranScalar(hashTable, sqlDetail.ToString(), list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
