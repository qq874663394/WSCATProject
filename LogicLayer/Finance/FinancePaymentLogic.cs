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
using UpdateManagerLayer;

namespace LogicLayer.Finance
{
    public class FinancePaymentLogic
    {
        FinancePaymentBase _dal = new FinancePaymentBase();
        FinanceUpdataManager _update = new FinanceUpdataManager();
        LogBase _logDal = new LogBase();
        public object AddOrUpdateToMainOrDetail(FinancePayment model, List<FinancePaymentDetail> modelDetail)
        {
            object result = 0;
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_FinancePayment/T_FinancePaymentDetail",
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
        public bool Exists(string code)
        {
            bool isflag = false;
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_FinancePayment",
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
        public DataTable GetList(int fieldName, string fieldValue)
        {
            string strWhere = "";
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_FinancePayment",
                operationTime = DateTime.Now,
                objective = "查询信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format(" supplierCode='{0}' and tf.code=pd.mainCode", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format(" tf.code='{0}' and tf.code=pd.mainCode", fieldValue);
                        break;
                }
                model.operationContent = "查询T_FinancePayment表的所有数据,条件:" + strWhere;
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
    }
}
