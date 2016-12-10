using Model.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Finance
{
    public class FinanceAccountingSubjectsBase
    {
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
                sql = "select * from T_FinanceAccountingSubjects";
                if (strWhere.Trim() != "")
                {
                    sql += " where " + strWhere;
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
        /// 添加节点
        /// </summary>
        /// <returns></returns>
        public int AddParentNode(FinanceAccountingSubjects fas)
        {
            string sql = "";
            //添加类别
            if (string.IsNullOrWhiteSpace(fas.parentCode))
            {
                sql = string.Format("insert into T_FinanceAccountingSubjects (code,name,nodeType) values('{0}','{1}',{2})", fas.code, fas.name, fas.nodeType);
            }
            //添加科目
            else
            {
                sql = string.Format("insert into T_FinanceAccountingSubjects (code,name,parentCode,hotKey,nodeType) values('{0}','{1}','{2}','{3}',{4})", fas.code, fas.name, fas.parentCode, fas.hotKey, fas.nodeType);
            }
            return DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <returns></returns>
        public int UpdateNode(FinanceAccountingSubjects fas)
        {
            string sql = "";
            //添加类别
            if (string.IsNullOrWhiteSpace(fas.hotKey))
            {
                sql = string.Format("update T_FinanceAccountingSubjects set name = '{0}' where code ='{1}' ", fas.name, fas.code);
            }
            //添加科目
            else
            {
                sql = string.Format("update T_FinanceAccountingSubjects set name = '{0}',hotKey = '{1}' where code ='{2}' ", fas.name, fas.hotKey, fas.code);
            }
            return DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <returns></returns>
        public int DelNode(string code)
        {
            string sql = "delete from T_FinanceAccountingSubjects where code = '" + code + "'";
            return DbHelperSQL.ExecuteSql(sql);
        }
    }
}
