using BaseLayer;
using HelperUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateManagerLayer;

namespace LogicLayer.Purchase
{
    public class PurchaseMainLogic
    {
        PurchaseMainBase _dal = new PurchaseMainBase();
        PurchaseUpdataManager _update = new PurchaseUpdataManager();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:模糊name,1:模糊supplierName,2:supplierCode</param>
        /// <param name="fieldValue">条件值</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            string strWhere = "";
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseMain",
                operationTime = DateTime.Now,
                objective = "查询采购表"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("name like '{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("supplierName like '{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("supplierCode='{0}'", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("code ='{0}'", fieldValue);
                        break;
                    case 4:
                        strWhere += string.Format("type='{0}'", fieldValue);
                        break;
                    case 5:
                        strWhere += string.Format("checkState=1 and (isPay=0 or isPay=1) and supplierCode='{0}'",fieldValue);
                        break;
                }
                logModel.operationContent = "查询T_PurchaseMain表的数据,条件:" + strWhere;
                dt = _dal.GetList(strWhere);
                logModel.result = 1;
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
            return dt;
        }
        public object AddOrUpdateToMainOrDetail(PurchaseMain model, List<PurchaseDetail> modelDetail)
        {
            object result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseMain/T_PurchaseDetail",
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
                    logModel.objective = "新增采购单,新增采购详情";
                    logModel.operationContent = "新增T_PurchaseMain和T_PurchaseDetail表的数据";
                }
                else
                {
                    result = _dal.UpdateSalesOrToDetail(model, modelDetail);
                    logModel.objective = "修改采购单,修改采购详情";
                    logModel.operationContent = "修改T_PurchaseMain和T_PurchaseDetail表的数据";
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
                lb.Add(model);
            }
            return isflag;
        }
    }
}