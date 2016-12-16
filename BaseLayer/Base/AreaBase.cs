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
    public class AreaBase
    {
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM [T_BaseArea] ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1  " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public int Add(BaseArea area)
        {
            string sql = "";
            int result = 0;
            try
            {
                sql = string.Format(@"INSERT INTO [T_BaseArea]
           ([code]
           ,[name]
           ,[parentId]
           ,[isEnable]
           ,[isClear]
           ,[updateDate])
     VALUES
           (@code
           ,@name
           ,@parentId
           ,@isEnable
           ,@isClear
           ,@updateDate)");
                SqlParameter[] sps =
                {
                    new SqlParameter("@code",area.code),
                    new SqlParameter("@name",area.name),
                    new SqlParameter("@parentId",area.parentId),
                    new SqlParameter("@isEnable",area.isEnable),
                    new SqlParameter("@isClear",area.isClear),
                    new SqlParameter("@updateDate",area.updateDate)
                };
                result = DbHelperSQL.ExecuteSql(sql, sps);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public int Update(BaseArea area)
        {
            string sql = "";
            int result = 0;
            try
            {
                sql = string.Format(@"update T_BaseArea set name=@name,
                parentId=@parentId,isEnable=@isEnable,isClear=@isClear,updateDate=@updateDate where code=@code");
                SqlParameter[] sps =
                {
                    new SqlParameter("@code",area.code),
                    new SqlParameter("@name",area.name),
                    new SqlParameter("@parentId",area.parentId),
                    new SqlParameter("@isEnable",area.isEnable),
                    new SqlParameter("@isClear",area.isClear),
                    new SqlParameter("@updateDate",area.updateDate)
                };
                result = DbHelperSQL.ExecuteSql(sql, sps);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public int UpdateAllClear(int isClearValue, string strWhere)
        {
            string sql = "";
            int result = 0;
            try
            {
                sql = string.Format(@"update T_BaseArea set isClear={0}", isClearValue);
                if (strWhere.Trim() != "")
                {
                    sql += " where 1=1  " + strWhere;
                }
                result = DbHelperSQL.ExecuteSql(sql);
            }
            catch (Exception ex)
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
            strSql.Append("select count(1) from [T_BaseArea]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据点击的节点用linq的lambda表达式检索数据 
        /// </summary>
        /// <param name="dt">所有数据列表</param>
        /// <param name="nodeText">查询的文本</param>
        /// <param name="field">查询的数据列</param>
        /// <returns></returns>
        public DataTable searchClientByNodeClick(DataTable dt, string nodeText, string field)
        {
            if (nodeText == "所有节点")
            {
                return dt;
            }
            else
            {
                string f = "";
                switch (field)
                {
                    case "客户名称":
                        f = "Cli_Name";
                        break;
                    case "单位名称":
                        f = "Cli_Company";
                        break;
                    case "联系人":
                        f = "Cli_LinkMan";
                        break;
                    case "手机号":
                        f = "Cli_Phone";
                        break;
                    case "地区":
                        f = "Cli_area";
                        break;
                }
                var result = dt.AsEnumerable().
                Where(c => c[f].ToString().Contains(nodeText));

                //为防止无法检索到任何数据的情况下无法复制结果datatable给新的datatable
                //故用中间量先进行检查
                DataTable resultDT = dt.Clone();
                if (result.Count() > 0)
                {
                    resultDT = result.CopyToDataTable();
                }
                return resultDT;
            }
        }
    }
}
