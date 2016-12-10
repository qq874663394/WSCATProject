using BaseLayer;
using BaseLayer.Finance;
using HelperUtility;
using Model;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Finance
{
    public class FinanceCategoriesDialogLogic
    {
        FinanceSummaryLibraryBase _dal = new FinanceSummaryLibrary();
        LogBase _logDal = new LogBase();
        public object AddOrUpdateToMainOrDetail(string name)
        {
            object result = 0;
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_FinanceSummaryLibrary",
                operationTime = DateTime.Now
            };
            try
            {
                if (model == null)
                {
                    throw new Exception("-2");
                }
                if (_dal.Exists(model.code) == false)
                {
                    result = _dal.AddToMainOrDetail(model, modelDetail);
                    logModel.objective = "新增收款单,新增收款详情";
                    logModel.operationContent = "新增T_FinancePayment和T_FinancePaymentDetail表的数据";
                }
                else
                {
                    result = _dal.UpdateToMainOrDetail(model, modelDetail);
                    logModel.objective = "修改收款,修改收款详情";
                    logModel.operationContent = "修改T_FinancePayment和T_FinancePaymentDetail表的数据";
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
    }
}
