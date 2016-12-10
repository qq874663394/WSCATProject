using BaseLayer;
using BaseLayer.Base;
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
    public class FinanceVoucherEntryLogic
    {
        private readonly FinanceVoucherEntryBase _dal = new FinanceVoucherEntryBase();
        private readonly FinanceUpdataManager _updateDal = new FinanceUpdataManager();
        private readonly LogBase _logDal = new LogBase();
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
                operationContent = "查询T_FinanceVoucherEntry数据,条件:code=" + code,
                operationTable = "T_FinanceVoucherEntry",
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
                operationTable = "T_FinanceVoucherEntry",
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
                operationTable = "T_FinanceVoucherEntry",
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
                operationTable = "T_FinanceVoucherEntry",
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

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object AddOrUpdateToMainOrDetail(FinanceVoucherEntryMain model,
            List<FinanceVoucherEntryDetail> modelDetail)
        {
            object result = null;
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTime = DateTime.Now,
                operationTable = "T_FinanceVoucherEntryMain/T_FinanceVoucherEntryDetail",
                objective = "凭证录入",
                operationContent = "操作内容",
                result = 0
            };
            result = 0;
            try
            {
                if (_dal.Exists(model.code))    //如果存在这个主表code   就修改
                {
                    //存在,则修改
                    result = _dal.UpdateToMainOrDetail(model, modelDetail);
                    if (result == null)
                    {
                        //失败
                        throw new Exception("-3");
                    }
                    else
                    {
                        //成功
                        logModel.result = 1;//操作结果
                        _updateDal.add(model.code, logModel.operationTable,
                            modelDetail.Count + 1, "修改数据", logModel.operationTime);
                    }
                }
                else
                {
                    result = _dal.AddToMainOrDetail(model, modelDetail);
                    if (result == null)
                    {
                        //失败
                        throw new Exception("-3");
                    }
                    else
                    {
                        //成功
                        logModel.result = 1;//操作结果
                        _updateDal.add(model.code, logModel.operationTable,
                            modelDetail.Count + 1, "新增数据", logModel.operationTime);
                    }
                }
                return logModel.result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _logDal.Add(logModel);
            }
        }

        /// <summary>
        /// 判断指定数据是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                objective = "获取最新一条数据",
                operationContent = "",
                operationTable = "T_FinanceVoucherEntry",
                operationTime = DateTime.Now,
                result = 0
            };
            bool isflag = false;
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("-2");
                }
                isflag = _dal.Exists(code);
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
            return isflag;
        }
    }
}