using BaseLayer;
using BaseLayer.Finance;
using HelperUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateManagerLayer;

namespace LogicLayer.Finance
{
    public class FinanceOtherExpensesOutLogic
    {
        FinanceOtherExpensesOutBase _dal = new FinanceOtherExpensesOutBase();
        LogBase _logDal = new LogBase();
        FinanceUpdataManager _update = new FinanceUpdataManager();
        public object AddOrUpdateToMainOrDetail(FinanceOtherExpensesOut model, List<FinanceOtherExpensesOutDetail> modelDetail)
        {
            object result = 0;
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_FinanceOtherExpensesOut/T_FinanceOtherExpensesOutDetail",
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
                    logModel.operationContent = "新增T_FinanceOtherExpensesOut和T_FinanceOtherExpensesOutDetail表的数据";
                }
                else
                {
                    result = _dal.UpdateToMainOrDetail(model, modelDetail);
                    logModel.objective = "修改上班时刻信息,修改上班时刻详情";
                    logModel.operationContent = "修改T_FinanceOtherExpensesOut和T_FinanceOtherExpensesOutDetail表的数据";
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
                operationTable = "T_FinanceOtherExpensesOut",
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

        /// <summary>
        /// 上一单
        /// </summary>
        /// <param name="clientCode">客户code</param>
        /// <returns></returns>
        public DataTable GetLastDetail(string code)
        {
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                objective = "获取上一单数据",
                operationContent = "查询T_FinanceOtherExpensesOut数据,条件:code=" + code,
                operationTable = "T_FinanceOtherExpensesOut",
                operationTime = DateTime.Now,
                result = 0
            };
            DataTable dt = null;
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("-2");
                }
                dt = _dal.GetLastDetail(code);
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _logDal.Add(logModel);
            }
            return dt;
        }

        /// <summary>
        /// 默认的上一单
        /// </summary>
        /// <param name="clientCode">客户code</param>
        /// <returns></returns>
        public DataTable GetFLastDetail(string code)
        {
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                objective = "获取上一单数据",
                operationContent = "code=" + code,
                operationTable = "T_FinanceOtherExpensesOut",
                operationTime = DateTime.Now,
                result = 0
            };
            DataTable dt = null;
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("-2");
                }
                dt = _dal.GetFLastDetail(code);
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _logDal.Add(logModel);
            }
            return dt;
        }

        /// <summary>
        /// 下一单
        /// </summary>
        /// <param name="clientCode">客户code</param>
        /// <returns></returns>
        public DataTable GetNextDetail(string code)
        {
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                objective = "获取下一单数据",
                operationContent = "code=" + code,
                operationTable = "T_FinanceOtherExpensesOut",
                operationTime = DateTime.Now,
                result = 0
            };
            DataTable dt = null;
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("-2");
                }
                dt = _dal.GetNextDetail(code);
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _logDal.Add(logModel);
            }
            return dt;
        }

        /// <summary>
        /// 获取最新的code
        /// </summary>
        /// <returns></returns>
        public string GetNewCode()
        {
            string code = "";
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                objective = "获取最新一条数据",
                operationContent = "",
                operationTable = "T_FinanceOtherExpensesOut",
                operationTime = DateTime.Now,
                result = 0
            };
            try
            {
                code = _dal.GetNewCode();
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("-3");
                }
                else
                {
                    logModel.result = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _logDal.Add(logModel);
            }
            return code;
        }
    }
}
