using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Sales
{
    public class SalesDetailBase
    {
        public DataTable GetList(string strWhere)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = "select * from T_SalesDetail";
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
        public DataTable GetDetailByMainCode(string SalesCode, string strWhere)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select whm.enaNumber,whm.floorNumber,sd.productionDate,sd.qualityDate,sd.effectiveDate,sd.id,sd.code,bm.materialDaima,sd.materialCode,sd.unit,sd.needNumber,whd.storageRackLocation,money,discountAfterPrice,sd.remark,bm.zhujima,materialName,sd.materiaModel,   
bm.barCode from T_SalesMain sm, T_SalesDetail sd,T_WarehouseMain whm, T_BaseMaterial bm,T_WarehouseDetail whd
where sm.code = sd.MainCode and sd.materialCode = whm.materialCode and sd.materialCode = bm.code and 
whm.code = whd.mainCode and sd.MainCode = '{0}'", SalesCode);
                if (!string.IsNullOrWhiteSpace(strWhere))
                {
                    sql += " and " + strWhere;
                }
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_PurchaseMain]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}