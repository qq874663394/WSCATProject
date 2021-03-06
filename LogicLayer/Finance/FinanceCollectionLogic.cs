﻿using BaseLayer;
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
    public class FinanceCollectionLogic
    {
        FinanceCollectionBase _dal = new FinanceCollectionBase();
        LogBase _logDal = new LogBase();
        FinanceUpdataManager _update = new FinanceUpdataManager();
        public object AddOrUpdateToMainOrDetail(FinanceCollection model, List<FinanceCollectionDetail> modelDetail)
        {
            object result = 0;
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_FinanceCollection/T_FinanceCollectionDetail",
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
                    logModel.operationContent = "新增T_FinanceCollection和T_FinanceCollectionDetail表的数据";
                }
                else
                {
                    result = _dal.UpdateToMainOrDetail(model, modelDetail);
                    logModel.objective = "修改收款,修改收款详情";
                    logModel.operationContent = "修改T_FinanceCollection和T_FinanceCollectionDetail表的数据";
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
                operationTable = "T_FinanceCollection",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                isflag = _dal.Exists(code);
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
        /// 自定义条件取得列表
        /// </summary>
        /// <param name="strWhere">where后面的条件</param>
        /// <returns></returns>
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
                operationTable = "T_FinanceCollection",
                operationTime = DateTime.Now,
                objective = "查询信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("fin.checkState=1 and fin.financeCollectionState=1  and fin.code=tf.mainCode and fin.clientCode='{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("fin.checkState=1 and fin.financeCollectionState=1 and fin.code=tf.mainCode and fin.supplierCode='{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("fin.code='{0}'", fieldValue);
                        break;
                }
                model.operationContent = "查询T_FinanceCollection表的所有数据,条件:" + strWhere;
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
        /// 默认的上一单
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetFLastData(string code)
        {
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                objective = "获取上一单数据",
                operationContent = "code=" + code,
                operationTable = "T_SalesOrder",
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
                dt = _dal.GetFLastData(code);
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
            return _dal.GetNewCode();
        }

        /// <summary>
        /// 获取上一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetLastData(string code)
        {
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                objective = "获取上一单数据",
                operationContent = "code=" + code,
                operationTable = "T_SalesOrder",
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
                dt = _dal.GetFLastData(code);
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
            return _dal.GetLastData(code);
        }

        /// <summary>
        /// 获取下一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetNextData(string code)
        {
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                objective = "获取下一单数据",
                operationContent = "code=" + code,
                operationTable = "T_SalesOrder",
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
                dt = _dal.GetFLastData(code);
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
            return _dal.GetNextData(code);
        }

    }
}
