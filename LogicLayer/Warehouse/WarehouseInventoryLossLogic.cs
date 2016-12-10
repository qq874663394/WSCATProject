using BaseLayer;
using BaseLayer.Warehouse;
using HelperUtility;
using Model;
using Model.Warehouse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateManagerLayer;
namespace LogicLayer.Warehouse
{
    public class WarehouseInventoryLossLogic
    {
        WarehouseInventoryLossBase wilb = new WarehouseInventoryLossBase();
        WarehouseUpdataManager wum = new WarehouseUpdataManager();
        public DataTable Search(int fieldName, string fieldValue)
        {
            string strWhere = "";
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInventoryLoss",
                operationTime = DateTime.Now,
                objective = "新增盘亏信息"
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
                }
                dt = wilb.Search(strWhere);
                model.operationContent = "查询T_WarehouseInventoryLoss表的数据,条件为：where" + strWhere;
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
        public object AddAndModify(WarehouseInventoryLoss warehouseInventoryLoss, List<WarehouseInventoryLossDetail> warehouseInventoryLossDetail)
        {
            object result = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInventoryLoss",
                operationTime = DateTime.Now,
                objective = "新增盘亏信息",
                operationContent = "新增T_WarehouseInventoryLoss表的数据,条件为：code=" + warehouseInventoryLoss.code
            };
            try
            {
                if (warehouseInventoryLoss == null || warehouseInventoryLossDetail==null)
                {
                    throw new Exception("-2");
                }
                 if (wilb.Exists(warehouseInventoryLoss.code) == false)
                {
                    result = wilb.Add(warehouseInventoryLoss, warehouseInventoryLossDetail);
                    model.operationContent = "新增T_WarehouseInventoryProfit表的数据,主键为：code=" + warehouseInventoryLoss.code;
                }
                else
                {
                    result = wilb.Modify(warehouseInventoryLoss, warehouseInventoryLossDetail);
                    model.operationContent = "修改T_WarehouseInventoryProfit表的数据,条件为：code=" + warehouseInventoryLoss.code;
                }
                if (result == null || result==DBNull.Value)
                {
                    throw new Exception("-3");
                }
                model.result = 1;
                wum.add(warehouseInventoryLoss.code, model.operationTable, warehouseInventoryLossDetail.Count, "", model.operationTime);
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
        public bool Exists(string code)
        {
            bool isflag = false;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInventoryLoss",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                wilb.Exists(code);
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
