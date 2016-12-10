using BaseLayer;
using BaseLayer.Purchase;
using HelperUtility;
using Model;
using Model.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateManagerLayer;

namespace LogicLayer.Purchase
{
    public class PurchaseOrderLogic
    {
        PurchaseOrderBase _dal = new PurchaseOrderBase();
        PurchaseUpdataManager _update = new PurchaseUpdataManager();
        private readonly LogBase _logDal = new LogBase();
        /// <summary>
        /// 保存审核公用
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object AddOrUpdateToMainOrDetail(PurchaseOrder model, List<PurchaseOrderDetail> modelDetail)
        {
            object result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_Purchase/T_PurchaseDetail",
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
                    result = _dal.AddPurchaseOrderOrToDetail(model, modelDetail);
                    logModel.objective = "新增采购订单,新增采购订单详情";
                    logModel.operationContent = "新增T_Purchase和T_PurchaseDetail表的数据";
                }
                else
                {
                    result = _dal.UpdateSalesOrToDetail(model, modelDetail);
                    logModel.objective = "修改采购订单,修改采购订单详情";
                    logModel.operationContent = "修改T_Purchase和T_PurchaseDetail表的数据";
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
            }
            finally
            {
                lb.Add(logModel);
            }
            return result;
        }
        public DataTable GetMainTable(string supplierCode)
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseOrder/T_PurchaseOrderDetail/T_BaseSupplier",
                operationTime = DateTime.Now,
                objective = "查询采购订单表信息",
                operationContent = "查询T_PurchaseOrder表的所有数据"
            };
            try
            {
                dt = _dal.GetMainTable(supplierCode);
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lb.Add(logModel);
            }
            return dt;
        }
        public DataTable GetMinorTable()
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseOrderDetail/T_BaseMaterial/T_WarehouseMain",
                operationTime = DateTime.Now,
                objective = "查询采购订单详细表信息",
                operationContent = "查询T_PurchaseOrderDetail表的所有数据"
            };
            try
            {
                dt = _dal.GetMinorTable();
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lb.Add(logModel);
            }
            return dt;
        }
        public DataTable GetJoinSearch(string code, string detailCode)
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseOrderDetail/T_BaseMaterial",
                operationTime = DateTime.Now,
                objective = "查询采购订单详细表信息",
                operationContent = string.Format("查询T_PurchaseOrderDetail表的数据，条件:code={0},mainCode={1}", detailCode, code)
            };
            try
            {
                dt = _dal.GetJoinSearch(code, detailCode);
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lb.Add(logModel);
            }
            return dt;
        }
        public bool Exists(string code)
        {
            bool isflag = false;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseMain",
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
                lb.Add(model);
            }
            return isflag;
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
                operationTable = "T_PurchaseOrderInterface",
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
            return _dal.GetLastData(code);
        }

        /// <summary>
        /// 获取默认的下一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetNextData(string code)
        {
            return _dal.GetNextData(code);
        }
    }
}