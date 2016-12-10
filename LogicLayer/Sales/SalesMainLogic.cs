using BaseLayer;
using BaseLayer.Sales;
using HelperUtility;
using HelperUtility.Encrypt;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateManagerLayer;

namespace LogicLayer.Sales
{
    public class SalesMainLogic
    {
        private SalesMainBase _dal = new SalesMainBase();
        private SalesUpdataManager _update = new SalesUpdataManager();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="strWhere"></param>
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
                operationTable = "T_SalesMain",
                operationTime = DateTime.Now,
                objective = "查询销售单信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("clientCode='{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("checkState=1 and code='{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("checkState=1 and (payState=0 or payState=1) and clientCode='{0}'",fieldValue);
                        break;
                }
                model.operationContent = "查询T_SalesMain表的数据,条件：where=" + strWhere;
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
        /// 查询id和code列
        /// </summary>
        /// <param name="clientCode">客户code</param>
        /// <returns></returns>
        public DataTable GetTableByClientCode(string clientCode)
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_SalesMain",
                operationTime = DateTime.Now,
                objective = "查询销售单信息"
            };
            try
            {
                model.operationContent = "查询T_SalesMain表的数据,条件：clientCode=" + clientCode;
                dt = _dal.GetTableByClientCode(clientCode);
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
        /// 保存审核公用
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object AddOrUpdateToMainOrDetail(SalesMain model, List<SalesDetail> modelDetail)
        {
            object result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_SalesMain/T_SealesDetail",
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
                    logModel.objective = "新增销售单,新增销售详情";
                    logModel.operationContent = "新增T_SalesMain和T_SealesDetail表的数据";
                }
                else
                {
                    result = _dal.UpdateToMainOrDetail(model, modelDetail);
                    logModel.objective = "修改销售,修改销售详情";
                    logModel.operationContent = "修改T_SalesMain和T_SalesDetail表的数据";
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
                lb.Add(logModel);
            }
            return result;
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code)
        {
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_SalesMain",
                operationTime = DateTime.Now,
                objective = "查询销售信息",
                operationContent = "查询T_SalesMain表的数据,条件为：code="+code
            };
            bool isflag = false;
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
                lb.Add(model);
            }
            return isflag;
        }
        public DataTable GetExamineAndPay(string clientCode)
        {
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_SalesMain",
                operationTime = DateTime.Now,
                objective = "查询销售信息",
                operationContent = "查询T_SalesMain表的数据,条件为：clientCode="+clientCode
            };
            DataTable dt = null;
            try
            {
                dt = _dal.GetExamineAndPay(clientCode);
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
        public DataTable GetExamineAndPay(string clientCode, string salesCode)
        {
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_SalesMain",
                operationTime = DateTime.Now,
                objective = "查询销售信息",
                operationContent = string.Format("查询T_SalesMain表的数据,条件为：clientCode={0},salesCode={1}",clientCode,salesCode)
            };
            DataTable dt = null;
            try
            {
                dt = _dal.GetExamineAndPay(clientCode,salesCode);
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
        public int SetPayState(int payState, string code)
        {
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_SalesMain",
                operationTime = DateTime.Now,
                objective = "修改销售信息",
                operationContent = string.Format("修改销售表的数据,条件为：payState={0},code={1}", payState, XYEEncoding.strHexDecode(code))
            };
            int result = 0;
            try
            {
                result = _dal.SetPayState(payState, code);
                model.result = 1;
                _update.add(code, model.operationTable, result, "", model.operationTime);
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
            return result;
        }
    }
}
