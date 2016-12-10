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
    public class WarehouseAssemblyBase
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            DataTable dt = null;
            StringBuilder strSql = new StringBuilder();
            try
            {
                strSql.Append("select * ");
                strSql.Append(" FROM [T_WarehouseAssembly] ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public object Add(WarehouseAssembly model, List<WarehouseAssemblyDetail> modelList)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            StringBuilder sqlDetail = new StringBuilder();
            StringBuilder sqlMain = new StringBuilder();
            try
            {
                sqlMain.Append("insert into [T_WarehouseAssembly]");
                sqlMain.Append(" values (");
                sqlMain.Append("@code,@type,@assemblyCost,@date,@abstract,@materialCode,@materialDaima,@barCode,@materialName,@materialMode,@materialUnit,@stockCode,@stockName,@number,@materialremark,@checkState,@operation,@makeMan,@examine,@isClear,@updatetime,@reserved1,@reserved2)");
                sqlMain.Append(";select @@IDENTITY");
                SqlParameter[] spsMain =
                {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@type", SqlDbType.NVarChar,40),
                    new SqlParameter("@assemblyCost", SqlDbType.Decimal,9),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@abstract", SqlDbType.NVarChar,400),
                    new SqlParameter("@materialCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@materialDaima", SqlDbType.NVarChar,45),
                    new SqlParameter("@barCode", SqlDbType.NVarChar,100),
                    new SqlParameter("@materialName", SqlDbType.NVarChar,40),
                    new SqlParameter("@materialMode", SqlDbType.NVarChar,40),
                    new SqlParameter("@materialUnit", SqlDbType.NVarChar,40),
                    new SqlParameter("@stockCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@stockName", SqlDbType.NVarChar,40),
                    new SqlParameter("@number", SqlDbType.Decimal,9),
                    new SqlParameter("@materialremark", SqlDbType.NVarChar,400),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@operation", SqlDbType.NVarChar,40),
                    new SqlParameter("@makeMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@examine", SqlDbType.NVarChar,40),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@updatetime", SqlDbType.DateTime),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50)
                };
                spsMain[0].Value = model.code;
                spsMain[1].Value = model.type;
                spsMain[2].Value = model.assemblyCost;
                spsMain[3].Value = model.date;
                spsMain[4].Value = model.Abstract;
                spsMain[5].Value = model.materialCode;
                spsMain[6].Value = model.materialDaima;
                spsMain[7].Value = model.barCode;
                spsMain[8].Value = model.materialName;
                spsMain[9].Value = model.materialMode;
                spsMain[10].Value = model.materialUnit;
                spsMain[11].Value = model.stockCode;
                spsMain[12].Value = model.stockName;
                spsMain[13].Value = model.number;
                spsMain[14].Value = model.materialremark;
                spsMain[15].Value = model.checkState;
                spsMain[16].Value = model.operation;
                spsMain[17].Value = model.makeMan;
                spsMain[18].Value = model.examine;
                spsMain[19].Value = model.isClear;
                spsMain[20].Value = model.updatetime;
                spsMain[21].Value = model.reserved1;
                spsMain[22].Value = model.reserved2;
                hashTable.Add(sqlMain, spsMain);

                sqlDetail.Append("insert into [T_WarehouseAssemblyDetail]");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@code,@mainCode,@materialCode,@materialDaima,@barCode,@materialName,@materialMode,@materialUnit,@stockCode,@stockName,@number,@price,@money,@remark,@isClear,@updatetime,@reserved1,@reserved2)");
                sqlDetail.Append(";select @@IDENTITY");

                foreach (var item in modelList)
                {
                    SqlParameter[] spsDetail =
                    {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@materialCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@materialDaima", SqlDbType.NVarChar,45),
                    new SqlParameter("@barCode", SqlDbType.NVarChar,100),
                    new SqlParameter("@materialName", SqlDbType.NVarChar,40),
                    new SqlParameter("@materialMode", SqlDbType.NVarChar,40),
                    new SqlParameter("@materialUnit", SqlDbType.NVarChar,40),
                    new SqlParameter("@stockCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@stockName", SqlDbType.NVarChar,40),
                    new SqlParameter("@number", SqlDbType.Decimal,9),
                    new SqlParameter("@price", SqlDbType.Decimal,9),
                    new SqlParameter("@money", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@updatetime", SqlDbType.DateTime),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50)
                    };
                    spsDetail[0].Value = item.code;
                    spsDetail[1].Value = item.mainCode;
                    spsDetail[2].Value = item.materialCode;
                    spsDetail[3].Value = item.materialDaima;
                    spsDetail[4].Value = item.barCode;
                    spsDetail[5].Value = item.materialName;
                    spsDetail[6].Value = item.materialMode;
                    spsDetail[7].Value = item.materialUnit;
                    spsDetail[8].Value = item.stockCode;
                    spsDetail[9].Value = item.stockName;
                    spsDetail[10].Value = item.number;
                    spsDetail[11].Value = item.price;
                    spsDetail[12].Value = item.money;
                    spsDetail[13].Value = item.remark;
                    spsDetail[14].Value = item.isClear;
                    spsDetail[15].Value = item.updatetime;
                    spsDetail[16].Value = item.reserved1;
                    spsDetail[17].Value = item.reserved2;
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code)
        {
            bool isflag = false;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from [T_WarehouseAssembly]");
                strSql.Append(" where Code=@Code ");

                SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,-1)};
                parameters[0].Value = code;
                isflag = DbHelperSQL.Exists(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isflag;
        }
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public object Modify(WarehouseAssembly model, List<WarehouseAssemblyDetail> modelList)
        {
            List<SqlParameter[]> list = new List<SqlParameter[]>();
            Hashtable hashTable = new Hashtable();
            object result = null;
            StringBuilder sqlMain = new StringBuilder();
            StringBuilder sqlDetail = new StringBuilder();
            try
            {
                sqlMain.Append("update [T_WarehouseAssembly] set ");
                sqlMain.Append("code=@code,");
                sqlMain.Append("type=@type,");
                sqlMain.Append("assemblyCost=@assemblyCost,");
                sqlMain.Append("date=@date,");
                sqlMain.Append("abstract=@abstract,");
                sqlMain.Append("materialCode=@materialCode,");
                sqlMain.Append("materialDaima=@materialDaima,");
                sqlMain.Append("barCode=@barCode,");
                sqlMain.Append("materialName=@materialName,");
                sqlMain.Append("materialMode=@materialMode,");
                sqlMain.Append("materialUnit=@materialUnit,");
                sqlMain.Append("stockCode=@stockCode,");
                sqlMain.Append("stockName=@stockName,");
                sqlMain.Append("number=@number,");
                sqlMain.Append("materialremark=@materialremark,");
                sqlMain.Append("checkState=@checkState,");
                sqlMain.Append("operation=@operation,");
                sqlMain.Append("makeMan=@makeMan,");
                sqlMain.Append("examine=@examine,");
                sqlMain.Append("isClear=@isClear,");
                sqlMain.Append("updatetime=@updatetime,");
                sqlMain.Append("reserved1=@reserved1,");
                sqlMain.Append("reserved2=@reserved2");
                sqlMain.Append(" where code='{0}'");
                SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@type", SqlDbType.NVarChar,40),
                    new SqlParameter("@assemblyCost", SqlDbType.Decimal,9),
                    new SqlParameter("@date", SqlDbType.DateTime),
                    new SqlParameter("@abstract", SqlDbType.NVarChar,400),
                    new SqlParameter("@materialCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@materialDaima", SqlDbType.NVarChar,45),
                    new SqlParameter("@barCode", SqlDbType.NVarChar,100),
                    new SqlParameter("@materialName", SqlDbType.NVarChar,40),
                    new SqlParameter("@materialMode", SqlDbType.NVarChar,40),
                    new SqlParameter("@materialUnit", SqlDbType.NVarChar,40),
                    new SqlParameter("@stockCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@stockName", SqlDbType.NVarChar,40),
                    new SqlParameter("@number", SqlDbType.Decimal,9),
                    new SqlParameter("@materialremark", SqlDbType.NVarChar,400),
                    new SqlParameter("@checkState", SqlDbType.Int,4),
                    new SqlParameter("@operation", SqlDbType.NVarChar,40),
                    new SqlParameter("@makeMan", SqlDbType.NVarChar,40),
                    new SqlParameter("@examine", SqlDbType.NVarChar,40),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@updatetime", SqlDbType.DateTime),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50)
                };
                parameters[0].Value = model.code;
                parameters[1].Value = model.type;
                parameters[2].Value = model.assemblyCost;
                parameters[3].Value = model.date;
                parameters[4].Value = model.Abstract;
                parameters[5].Value = model.materialCode;
                parameters[6].Value = model.materialDaima;
                parameters[7].Value = model.barCode;
                parameters[8].Value = model.materialName;
                parameters[9].Value = model.materialMode;
                parameters[10].Value = model.materialUnit;
                parameters[11].Value = model.stockCode;
                parameters[12].Value = model.stockName;
                parameters[13].Value = model.number;
                parameters[14].Value = model.materialremark;
                parameters[15].Value = model.checkState;
                parameters[16].Value = model.operation;
                parameters[17].Value = model.makeMan;
                parameters[18].Value = model.examine;
                parameters[19].Value = model.isClear;
                parameters[20].Value = model.updatetime;
                parameters[21].Value = model.reserved1;
                parameters[22].Value = model.reserved2;

                hashTable.Add(sqlMain, parameters);
                sqlDetail.Append("insert into [T_WarehouseAssemblyDetail] ");
                sqlDetail.Append(" values (");
                sqlDetail.Append("@code,@mainCode,@materialCode,@materialDaima,@barCode,@materialName,@materialMode,@materialUnit,@stockCode,@stockName,@number,@price,@money,@remark,@isClear,@updatetime,@reserved1,@reserved2)");
                sqlDetail.Append(";select @@IDENTITY");

                foreach (var item in modelList)
                {
                    SqlParameter[] spsDetail = {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@mainCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@materialCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@materialDaima", SqlDbType.NVarChar,45),
                    new SqlParameter("@barCode", SqlDbType.NVarChar,100),
                    new SqlParameter("@materialName", SqlDbType.NVarChar,40),
                    new SqlParameter("@materialMode", SqlDbType.NVarChar,40),
                    new SqlParameter("@materialUnit", SqlDbType.NVarChar,40),
                    new SqlParameter("@stockCode", SqlDbType.NVarChar,45),
                    new SqlParameter("@stockName", SqlDbType.NVarChar,40),
                    new SqlParameter("@number", SqlDbType.Decimal,9),
                    new SqlParameter("@price", SqlDbType.Decimal,9),
                    new SqlParameter("@money", SqlDbType.Decimal,9),
                    new SqlParameter("@remark", SqlDbType.NVarChar,400),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@updatetime", SqlDbType.DateTime),
                    new SqlParameter("@reserved1", SqlDbType.NVarChar,50),
                    new SqlParameter("@reserved2", SqlDbType.NVarChar,50)};
                    parameters[0].Value = item.code;
                    parameters[1].Value = item.mainCode;
                    parameters[2].Value = item.materialCode;
                    parameters[3].Value = item.materialDaima;
                    parameters[4].Value = item.barCode;
                    parameters[5].Value = item.materialName;
                    parameters[6].Value = item.materialMode;
                    parameters[7].Value = item.materialUnit;
                    parameters[8].Value = item.stockCode;
                    parameters[9].Value = item.stockName;
                    parameters[10].Value = item.number;
                    parameters[11].Value = item.price;
                    parameters[12].Value = item.money;
                    parameters[13].Value = item.remark;
                    parameters[14].Value = item.isClear;
                    parameters[15].Value = item.updatetime;
                    parameters[16].Value = item.reserved1;
                    parameters[17].Value = item.reserved2;
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
    }
}
