using BaseLayer;
using BaseLayer.Base;
using HelperUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Base
{
    public class ProjectInCostLogic
    {
        ProjectInCostBase _dal = new ProjectInCostBase();
        LogBase _logDal = new LogBase();
        /// <summary>
        /// 自定义条件取得列表
        /// </summary>
        /// <param name="strWhere">where后面的条件</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            string strWhere = "";
            DataTable dt = null;
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseProjectInCost",
                operationTime = DateTime.Now,
                objective = "查询其他项目收入信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("projectCode like '%{0}%'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("name like '%{0}%'", fieldValue);
                        break;
                }
                model.operationContent = "T_BaseProjectInCost,条件:" + strWhere;
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
                _logDal.Add(model);
            }
            return dt;
        }
    }
}
