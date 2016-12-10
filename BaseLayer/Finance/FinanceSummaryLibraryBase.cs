using Model.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Finance
{
    public class FinanceSummaryLibraryBase
    {
        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <returns></returns>
        public DataTable SeleteTreeDate()
        {
            string sql = "select * from T_FinanceSummaryLibrary";
            DataTable dt = new DataTable();
            dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <returns></returns>
        public int AddParentNode(FinanceSummaryLibrary fsl)
        {
            string sql = "";
            //添加类别
            if (string.IsNullOrWhiteSpace(fsl.parentCode))
            {
                sql = string.Format("insert into T_FinanceSummaryLibrary (code,name) values('{0}','{1}')", fsl.code, fsl.name);
            }
            //添加摘要
            else
            {
                sql = string.Format("insert into T_FinanceSummaryLibrary (code,name,parentCode,hotKey) values('{0}','{1}','{2}','{3}')", fsl.code, fsl.name, fsl.parentCode, fsl.hotKey);
            }
            return DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <returns></returns>
        public int UpdateNode(FinanceSummaryLibrary fsl)
        {
            string sql = "";
            //修改类别
            if (string.IsNullOrWhiteSpace(fsl.hotKey))
            {
                sql = string.Format("update T_FinanceSummaryLibrary set name = '{0}' where code ='{1}' ", fsl.name, fsl.code);
            }
            //修改摘要
            else
            {
                sql = string.Format("update T_FinanceSummaryLibrary set name = '{0}',hotKey = '{1}' where code ='{2}' ", fsl.name, fsl.hotKey, fsl.code);
            }
            return DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <returns></returns>
        public int DelNode(string code)
        {
            string sql = "delete from T_FinanceSummaryLibrary where code = '" + code + "'";
            return DbHelperSQL.ExecuteSql(sql);
        }
    }
}
