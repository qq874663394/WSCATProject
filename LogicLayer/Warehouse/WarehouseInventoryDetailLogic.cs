using BaseLayer;
using BaseLayer.Warehouse;
using HelperUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateManagerLayer;

namespace LogicLayer.Warehouse
{
    public class WarehouseInventoryDetailLogic
    {
        WarehouseInventoryDetailBase widb = new WarehouseInventoryDetailBase();
        WarehouseUpdataManager wum = new WarehouseUpdataManager();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:code,1:materialDaima,2:stockCode,3:barCode,4:mainCode,5:盘亏,6:盘盈</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns></returns>
        public DataTable Search(int fieldName, string fieldValue)
        {
            string strWhere = "";
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInventoryDetail",
                operationTime = DateTime.Now,
                objective = "查询盘点明细单"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("code='{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("materialDaima='{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("stockCode='{0}'", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("barCode='{0}'", fieldValue);
                        break;
                    case 4:
                        strWhere += string.Format("mainCode='{0}'", fieldValue);
                        break;
                    case 5:
                        strWhere += string.Format("stockCode='{0}' and lossNumber>0",fieldValue);
                        break;
                    case 6:
                        strWhere += string.Format("stockCode='{0}' and profitNumber>0", fieldValue);
                        break;
                }
                logModel.operationContent = "查询T_WarehouseInventoryDetail表的数据,条件：where=" + strWhere;
                dt = widb.Search(strWhere);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public int Add(WarehouseInventoryDetail wid)
        {
            int result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInventoryDetail",
                operationTime = DateTime.Now,
                objective = "新增盘点明细单",
                operationContent = "新增T_WarehouseInventoryDetail表的数据"
            };
            try
            {
                if (wid == null)
                {
                    throw new Exception("-2");
                }
                result = widb.Add(wid);
                if (result <= 0)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add(wid.code, logModel.operationTable, result, "", logModel.operationTime);
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
        /// 修改数据
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public int Modify(WarehouseInventoryDetail wid)
        {
            int result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInventoryDetail",
                operationTime = DateTime.Now,
                objective = "修改盘点明细单",
                operationContent = "修改T_WarehouseInventoryDetail表的数据,条件：code=" + wid.code
            };
            try
            {
                if (wid == null)
                {
                    throw new Exception("-2");
                }
                result = widb.Modify(wid);
                if (result <= 0)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add(wid.code, logModel.operationTable, result, "", logModel.operationTime);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lb.Add(logModel);
            }
            return result;
        }
        public int AddAndModify(WarehouseInventoryDetail wid)
        {
            int result = 0;
            try
            {
                if (wid == null)
                {
                    throw new Exception("-2");
                }
                if (widb.Exists(wid.code)==false)
                {
                    result=Add(wid);
                }
                else
                {
                    result = Modify(wid);
                };
                if (result <= 0)
                {
                    throw new Exception("-3");
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                widb.Exists(code);
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
