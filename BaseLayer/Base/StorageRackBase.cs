using Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BaseLayer.Base
{
    public class StorageRackBase
    {
        /// <summary>
        /// 根据父级ID查询货架信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public DataTable SelStorageRackByCode(string parentId)
        {
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = string.Format("SELECT * FROM T_BaseStorageRack where isClear=1 and parentId='{0}' order by id", parentId);
                ds = DbHelperSQL.Query(sql);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ds.Tables[0];
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public DataTable SelStorageRack()
        {
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = string.Format("SELECT * FROM T_BaseStorageRack where isClear=1 order by id");
                ds = DbHelperSQL.Query(sql);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ds.Tables[0];
        }
        /// <summary>
        /// 假删除
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int DelStorageRackByCode(string code)
        {
            string sql = "";
            int result = 0;
            try
            {
                sql = string.Format("update from T_BaseStorageRack set isClear=0 where code='{1}'", code);
                result = DbHelperSQL.ExecuteSql(sql);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 根据条件修改
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">修改后的值</param>
        /// <param name="code">编码</param>
        /// <returns></returns>
        public int UpdateStorageRackByCode(string fieldName, string fieldValue, string code)
        {
            string sql = "";
            int result = 0;
            try
            {
                sql = string.Format("update from T_BaseStorageRack set {0}='{1}' where code='{2}'", fieldName, fieldValue, code);
                result = DbHelperSQL.ExecuteSql(sql);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 新增货架信息
        /// </summary>
        /// <param name="srb"></param>
        /// <returns></returns>
        public int InsStorageRack(BaseStorageRack srb)
        {
            string sql = "";
            int result = 0;
            SqlParameter[] sps;
            try
            {
                sql = "insert into T_BaseStorageRack values(@code,@name,@parentId,@isEnable,@isClear,@updateDate)";
                sps = new SqlParameter[]
                {
                    new SqlParameter("@code", srb.code),
                    new SqlParameter("@name", srb.name),
                    new SqlParameter("@parentId", srb.parentId),
                    new SqlParameter("@isEnable", srb.isEnable),
                    new SqlParameter("@isClear", srb.isClear),
                    new SqlParameter("@updateDate", srb.updateDate)
                };
                result=DbHelperSQL.ExecuteSql(sql, sps);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// false不存在，true存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_BaseStorageRack]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}