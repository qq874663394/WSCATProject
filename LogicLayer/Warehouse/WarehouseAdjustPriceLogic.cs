using BaseLayer;
using BaseLayer.Warehouse;
using HelperUtility;
using LogicLayer.Base;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UpdateManagerLayer;

namespace LogicLayer.Warehouse
{
    public class WarehouseAdjustPriceLogic
    {
        LogBase lb = new LogBase();
        WarehouseAdjustPriceBase dal = new WarehouseAdjustPriceBase();
        WarehouseUpdataManager warehouseUpdate = new WarehouseUpdataManager();
        MaterialLogic materialLogic = new MaterialLogic();
        public DataTable Search(int fieldName, string fieldValue)
        {
            DataTable dt = null;
            string strWhere = "";
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseAdjustPrice",
                operationTime = DateTime.Now,
                objective = "查询调价单信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("code='{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("MainCode='{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("materialDaima like '%{0}%'", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("materialName like '%{0}%'", fieldValue);
                        break;
                }
                model.operationContent = "查询T_WarehouseAdjustPrice表的数据,条件为：where=" + strWhere;
                dt = dal.Search(strWhere);
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
        public object AddAndModify(WarehouseAdjustPrice model, List<WarehouseAdjustPriceDetail> listModel)
        {
            object result = null;
            int priceResult = 0;
            LogBase lb = new LogBase();
            Log LogModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseAdjustPrice",
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
                    LogModel.objective = "新增调价信息";
                    LogModel.operationContent = "新增T_WarehouseAdjustPrice表的数据,主键为：code=" + model.code;
                }
                else
                {
                    result = dal.Modify(model, listModel);
                    LogModel.objective = "修改调价信息";
                    LogModel.operationContent = "修改T_WarehouseAdjustPrice表的数据,条件为：code=" + model.code;
                }
                if (result != null && model.checkState != 0)
                {
                    foreach (var item in listModel)
                    {
                        priceResult = materialLogic.SetMaterialNumber(item.materialCode, item.price.ToString());
                        if (priceResult <= 0)
                        {
                            throw new Exception("-3");
                        }
                    }
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
                operationTable = "T_WarehouseAdjustPrice",
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