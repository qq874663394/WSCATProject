using BaseLayer;
using BaseLayer.Finance;
using HelperUtility;
using Model;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Finance
{
    public class FinanceAccountingSubjectsLogic
    {
        FinanceAccountingSubjectsBase _dal = new FinanceAccountingSubjectsBase();
        /// <summary>
        /// 自定义条件取得列表
        /// </summary>
        /// <param name="nodeType">选项卡索引</param>
        /// <returns></returns>
        public DataTable GetList(int type, int nodeType)
        {
            string strWhere = "";
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_FinanceAccountingSubjects",
                operationTime = DateTime.Now,
                objective = "查询信息"
            };
            try
            {
                switch (type)
                {
                    case 0:
                        strWhere = string.Format("nodeType = {0}", nodeType);
                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                }
                model.operationContent = "查询T_FinanceAccountingSubjects表的所有数据,条件:" + strWhere;
                dt = _dal.GetList(strWhere);
                model.result = 1;
            }
            catch (Exception ex)
            {
                model.result = 0;
                throw ex;
            }
            finally
            {
                lb.Add(model);
            }
            return dt;
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <returns></returns>
        public int AddParentNode(FinanceAccountingSubjects fas)
        {
            return _dal.AddParentNode(fas);
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <returns></returns>
        public int UpdateNode(FinanceAccountingSubjects fas)
        {
            return _dal.UpdateNode(fas);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <returns></returns>
        public int DelNode(string code)
        {
            return _dal.DelNode(code);
        }
    }
}
