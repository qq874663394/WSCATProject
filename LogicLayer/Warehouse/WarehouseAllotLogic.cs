using BaseLayer;
using BaseLayer.Warehouse;
using HelperUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateManagerLayer;

namespace LogicLayer.Warehouse
{
    public class WarehouseAllotLogic
    {
        WarehouseAllotBase _dal = new WarehouseAllotBase();
        LogBase _logDAL = new LogBase();
        WarehouseUpdataManager _dalUpdate = new WarehouseUpdataManager();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            string strWhere = "";
            DataTable dt = null;
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseAllot",
                operationTime = DateTime.Now,
                objective = "查询调拨信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("code='{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("checkState={0}", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("isClear={0}", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("allotType={0}", fieldValue);
                        break;
                }
                dt = _dal.GetList(strWhere).Tables[0];
                logModel.operationContent = "查询T_WarehouseAllot表的数据,条件为：where=" + strWhere;
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                logModel.result = 0;
                throw ex;
            }
            finally
            {
                _logDAL.Add(logModel);
            }
            return dt;
        }
        
        public object AddAndModify(WarehouseAllot model, List<WarehouseAllotDetail> modelDetail)
        {
            object result = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseAllot",
                operationTime = DateTime.Now,
                objective = "新增盘亏信息",
                operationContent = "新增T_WarehouseAllot表的数据,条件为：code=" + model.code
            };
            try
            {
                if (model == null || modelDetail == null)
                {
                    throw new Exception("-2");
                }
                if (_dal.Exists(model.code) == false)
                {
                    result = _dal.Add(model, modelDetail);
                    logModel.operationContent = "新增T_WarehouseAllot表的数据,主键为：code=" + model.code;
                }
                else
                {
                    result = _dal.Modify(model, modelDetail);
                    logModel.operationContent = "修改T_WarehouseAllot表的数据,条件为：code=" + model.code;
                }
                if (result == null || result == DBNull.Value)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                _dalUpdate.add(model.code, logModel.operationTable, modelDetail.Count, "", logModel.operationTime);
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
                operationTable = "T_WarehouseAllot",
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
