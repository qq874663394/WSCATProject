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
    public class WarehouseAssemblyLogic
    {
        LogBase lb = new LogBase();
        WarehouseAssemblyBase dal = new WarehouseAssemblyBase();
        WarehouseUpdataManager warehouseUpdate = new WarehouseUpdataManager();
        public DataTable GetList(int fieldName, string fieldValue)
        {
            DataTable dt = null;
            string strWhere = "";
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseAssembly",
                operationTime = DateTime.Now,
                objective = "查询拆卸信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("code='{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("materialDaima like '%{0}%'", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("materialName like '%{0}%'", fieldValue);
                        break;
                }
                model.operationContent = "查询T_WarehouseAssembly表的数据,条件为：where=" + strWhere;
                dt = dal.GetList(strWhere);
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
        public object AddAndModify(WarehouseAssembly model, List<WarehouseAssemblyDetail> listModel)
        {
            object result = null;
            LogBase lb = new LogBase();
            Log LogModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseAssembly",
                operationTime = DateTime.Now
            };
            try
            {
                if (model == null || listModel == null)
                {
                    throw new Exception("-2");
                }
                if (dal.Exists(model.code) == false)
                {
                    result = dal.Add(model, listModel);
                    LogModel.objective = "新增拆卸信息";
                    LogModel.operationContent = "新增T_WarehouseAssembly表的数据,主键为：code=" + model.code;
                }
                else
                {
                    result = dal.Modify(model, listModel);
                    LogModel.objective = "修改拆卸信息";
                    LogModel.operationContent = "修改T_WarehouseAssembly表的数据,条件为：code=" + model.code;
                }
                if (result == null || result == DBNull.Value)
                {
                    throw new Exception("-3");
                }
                LogModel.result = 1;
                warehouseUpdate.add(model.code, LogModel.operationTable, listModel.Count, "", LogModel.operationTime);
            }
            catch (Exception ex)
            {
                LogModel.result = 0;
                throw ex;
            }
            finally
            {
                lb.Add(LogModel);
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
                operationTable = "T_WarehouseAssembly",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                dal.Exists(code);
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
