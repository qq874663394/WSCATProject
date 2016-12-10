using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Warehouse
{
    public class WarehouseMainBase
    {
        /// <summary>
        /// 减少库存
        /// </summary>
        /// <param name="number"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int updateReduce(int number, string code)
        {
            string sql = "";
            int result = 0;
            try
            {
                sql = string.Format("update T_WarehouseMain set enaNumber=enaNumber-{0} where code='{1}'", number, code);
                result = DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 增加库存
        /// </summary>
        /// <param name="number"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int updateAug(int number, string code)
        {
            string sql = "";
            int result = 0;
            try
            {
                sql = string.Format("update T_WarehouseMain set enaNumber=enaNumber+{0} where code='{1}'", number, code);
                result = DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 林修改方法 查询库存商品
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetMaterialDetail(string fieldValue)
        {
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = @"select * from T_BaseMaterial bm,T_WarehouseMain tw,T_WarehouseDetail td 
                    where tw.materialCode=bm.code and tw.code=td.warehouseOrdercode";
                if (fieldValue.Trim() != "")
                {
                    sql += " and tw.storageCode='" + fieldValue + "' ";
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
        /// 根据查出来的仓库code查库存表，再根据库存表的商品code查物料信息表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable GetMaterialByMain(string code)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select * from T_WarehouseMain wm,T_BaseMaterial bm,T_WarehouseDetail wd ,T_WarehouseInventoryDetail  wi  
                    where  wm.materialCode=bm.code and wd.mainCode=wm.code  and wm.storageCode=wi.stockCode and storageCode='{0}'", code);
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable GetWMainAndMaterialByWMCode(string strWhere,string storageCode)
        {
            string sql = "";
            DataTable dt = null;
            try
            {
                sql = string.Format(@"select * from T_BaseMaterial,T_WarehouseMain
where T_WarehouseMain.materialCode = T_BaseMaterial.code and T_WarehouseMain.storageCode = '{0}'", storageCode);
                if (!string.IsNullOrWhiteSpace(strWhere))
                {
                    sql += string.Format(" and {0}",strWhere);
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
        /// <summary>
        /// 判断该客户编号判断是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable ExistsNumber(string code)
        {
            DataTable dt = null;
            string sql = "";
            try
            {
                sql = string.Format("select top 1 allNumber,enaNumber,floorNumber from T_WarehouseMain where code='{0}'", code);
                dt = DbHelperSQL.Query(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}