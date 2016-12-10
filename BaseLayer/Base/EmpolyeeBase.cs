using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Base
{
    public class EmpolyeeBase
    {
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <param name="isflag">是否显示禁用：true显示所有禁用状态的信息，false仅显示未禁用状态的信息</param>
        /// <returns></returns>
        public DataTable SelEmpolyee(bool isflag)
        {
            string sql = "";
            DataSet ds = null;
            try
            {
                sql = @"select emp.code as 员工工号,
            emp.name as 姓名,
            r.name as 角色,
            cityName as 地址,
            cardCode as 卡号,
            dep.name as 所属部门,
            sex as 性别,
            identityCard as 身份证号,
            phone as 联系电话,
            bankCard as 银行卡号,
            openBank as 开户行,
            birthday 出生年月,
            email as 邮箱,
            education as 最高学历,
            school as 毕业院校,
            entryTime as 入职时间,
            jobStatus as 就职状态,
            isEnable as 禁用状态  
            from T_BaseEmpolyee emp,
            T_BaseRole r,
            T_BaseDepartment dep 
            where emp.isClear=1 
            and emp.departmentCode=dep.code 
            and emp.roleCode=r.code";
                if (isflag == false)
                {
                    sql += " and isEnable=1";
                }
                ds=DbHelperSQL.Query(sql);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ds.Tables[0];
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
                sql = "select * from T_BaseEmpolyee";
                if (strWhere.Trim() != "")
                {
                    sql += " where " + strWhere;
                }
                ds = DbHelperSQL.Query(sql);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ds.Tables[0];
        }
        /// <summary>
        /// 判断该客户编号判断是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Exists(string name, string pwd)
        {
            bool isflag = false;
            string sql = "";
            try
            {
                sql = string.Format("select count(1) from T_BaseEmpolyee where name='{0}' and password='{1}'", name, pwd);
                isflag = DbHelperSQL.Exists(sql);
            }
            catch (Exception ex)
            {
                isflag = false;
                throw ex;
            }
            return false;
        }
        /// <summary>
        /// false不存在，true存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from [T_BaseEmpolyee]");
            strSql.Append(" where code=@code ");

            SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar,50)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
