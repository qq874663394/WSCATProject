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
    public class MaterialTypeBase
    {
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_BaseMaterialType]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseMaterialType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_BaseMaterialType] (");
            strSql.Append("code,name,parentId,isEnable,isClear,updateDate)");
            strSql.Append(" values (");
            strSql.Append("@code,@name,@parentId,@isEnable,@isClear,@updateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@name", SqlDbType.NVarChar,58),
                    new SqlParameter("@parentId", SqlDbType.NVarChar,45),
                    new SqlParameter("@isEnable", SqlDbType.Int,4),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@updateDate", SqlDbType.DateTime)};
            parameters[0].Value =model.code;
            parameters[1].Value =model.name;
            parameters[2].Value =model.parentId;
            parameters[3].Value =model.isEnable;
            parameters[4].Value =model.isClear;
            parameters[5].Value = model.updateDate;

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
        public bool Update(BaseMaterialType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseMaterialType] set ");
            strSql.Append("name=@name,");
            strSql.Append("parentId=@parentId,");
            strSql.Append("isEnable=@isEnable,");
            strSql.Append("isClear=@isClear,");
            strSql.Append("updateDate=@updateDate");
            strSql.Append(" where code=@code ");
            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,45),
                    new SqlParameter("@name", SqlDbType.NVarChar,58),
                    new SqlParameter("@parentId", SqlDbType.NVarChar,45),
                    new SqlParameter("@isEnable", SqlDbType.Int,4),
                    new SqlParameter("@isClear", SqlDbType.Int,4),
                    new SqlParameter("@updateDate", SqlDbType.DateTime)};
            parameters[0].Value =model.code;
            parameters[1].Value =model.name;
            parameters[2].Value =model.parentId;
            parameters[3].Value =model.isEnable;
            parameters[4].Value =model.isClear;
            parameters[5].Value =model.updateDate;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseMaterialType] set isClear=0");
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
        /// 删除所有数据
        /// </summary>
        public bool DeleteAll(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseMaterialType] set isClear=0");
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
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_BaseMaterialType] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
    }
}
