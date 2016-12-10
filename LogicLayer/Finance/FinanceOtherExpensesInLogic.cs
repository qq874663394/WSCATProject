using BaseLayer;
using BaseLayer.Finance;
using HelperUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateManagerLayer;

namespace LogicLayer.Finance
{
    public class FinanceOtherExpensesInLogic
    {
        FinanceOtherExpensesInBase _dal = new FinanceOtherExpensesInBase();
        LogBase _logDal = new LogBase();
        FinanceUpdataManager _update = new FinanceUpdataManager();
        public object AddOrUpdateToMainOrDetail(FinanceOtherExpensesIn model, List<FinanceOtherExpenseInDetail> modelDetail)
        {
            object result = 0;
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_FinanceOtherExpensesIn/T_FinanceOtherExpensesInDetail",
                operationTime = DateTime.Now
            };
            try
            {
                if (model == null || modelDetail == null)
                {
                    throw new Exception("-2");
                }
                if (_dal.Exists(model.code) == false)
                {
                    result = _dal.AddToMainOrDetail(model, modelDetail);
                    logModel.objective = "新增上班时刻信息,新增上班时刻详情";
                    logModel.operationContent = "新增T_FinanceOtherExpensesIn和T_FinanceOtherExpensesInDetail表的数据";
                }
                else
                {
                    result = _dal.UpdateToMainOrDetail(model, modelDetail);
                    logModel.objective = "修改上班时刻信息,修改上班时刻详情";
                    logModel.operationContent = "修改T_FinanceOtherExpensesIn和T_FinanceOtherExpensesInDetail表的数据";
                }
                if (result == null)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                _update.add(model.code, logModel.operationTable, modelDetail.Count + 1, "", logModel.operationTime);
            }
            catch (Exception ex)
            {
                logModel.result = 0;
                throw ex;
            }
            finally
            {
                _logDal.Add(logModel);
            }
            return result;
        }
        public bool Exists(string code)
        {
            bool isflag = false;
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_FinanceOtherExpensesIn",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                isflag=_dal.Exists(code);
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
            return isflag;
        }
    }
}
