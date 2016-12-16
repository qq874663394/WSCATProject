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
    public class BorrowBase
    {
        /// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_BaseBorrow]");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BaseBorrow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [T_BaseBorrow] (");
            strSql.Append("name,updateDate)");
            strSql.Append(" values (");
            strSql.Append("@name,@updateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@name", SqlDbType.NVarChar,25),
                    new SqlParameter("@updateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.updateDate;

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
        public int Update(BaseBorrow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [T_BaseBorrow] set ");
            strSql.Append("name=@name,");
            strSql.Append("updateDate=@updateDate");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@name", SqlDbType.NVarChar,25),
                    new SqlParameter("@updateDate", SqlDbType.DateTime),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.updateDate;
            parameters[2].Value = model.id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [T_BaseBorrow] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        public bool DeleteAll(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [T_BaseBorrow] ");
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
            strSql.Append(" FROM [T_BaseBorrow] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
    }
}
