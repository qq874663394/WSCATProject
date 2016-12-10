using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BaseLayer;
using HelperUtility.Encrypt;
using System.Data;
using HelperUtility;
using UpdateManagerLayer;

namespace LogicLayer
{
    public class WarehouseInDetailLogic
    {
        private WarehouseInDetailBase wdb = new WarehouseInDetailBase();
        private WarehouseUpdataManager wum = new WarehouseUpdataManager();
        /// <summary>
        /// 新增一条数据 
        /// </summary>
        public int InsertWarehouseInDetailTable(WarehouseInDetail model)
        {
            int result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInDetail",
                operationTime = DateTime.Now,
                objective = "新增入库商品详情",
                operationContent = "新增T_WarehouseInDetail表的数据"
            };

            try
            {
                if (model == null && string.IsNullOrWhiteSpace(model.code))
                {
                    throw new Exception("-2");
                }
                result = wdb.Add(model);
                if (result <= 0)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add(model.code, logModel.operationTable, result, logModel.operationContent, logModel.operationTime);
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
        /// 根据code删除表里数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int deleteInDetailTable(string code)
        {
            int result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInDetail",
                operationTime = DateTime.Now,
                objective = "删除入库商品详情",
                operationContent = "删除T_WarehouseInDetail表的数据,条件为:code=" + code
            };
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("-2");
                }
                WarehouseInDetailBase warehouseInDetailBase = new WarehouseInDetailBase();
                result = warehouseInDetailBase.deleteByCode(code);
                if (result <= 0)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add(code, logModel.operationTable, result, logModel.operationContent, logModel.operationTime);
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
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:模糊zhujima,1:模糊materialName,2:state,3:isClear</param>
        /// <param name="fieldValue">条件值</param>
        /// <returns></returns>
        public DataSet getList(int fieldName, string fieldValue)
        {
            string strWhere = "";
            WarehouseInDetailBase warehouseInDetailBase = new WarehouseInDetailBase();
            DataSet ds = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInDetail",
                operationTime = DateTime.Now,
                objective = "查询入库商品详情"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("zhujima like '{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("materialName like '{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("state={0}", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("isClear={0}", fieldValue);
                        break;
                }
                logModel.operationContent = "查询T_WarehouseInDetail表的数据,条件为:" + strWhere;
                ds = warehouseInDetailBase.getList(strWhere);
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
            return ds;
        }
        /// <summary>
        /// 根据主单code获取数据列表
        /// </summary>
        /// <param name="mainCode">主单code</param>
        /// <returns></returns>
        public DataSet getListByMainCode(string mainCode)
        {
            WarehouseInDetailBase warehouseInDetailBase = new WarehouseInDetailBase();
            DataSet ds = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInDetail",
                operationTime = DateTime.Now,
                objective = "根据主单code查询入库商品详情",
                operationContent = "根据主单code查询T_WarehouseInDetail表的数据,条件为:mainCode=" + mainCode
            };
            if (string.IsNullOrWhiteSpace(mainCode))
            {
                throw new Exception("-2");
            }
            try
            {
                ds = warehouseInDetailBase.getListByMainCode(mainCode);
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
            return ds;
        }
        /// <summary>
        /// 根据code来更新入库状态
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int updateByCode(string code)
        {
            int result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseInDetail",
                operationTime = DateTime.Now,
                objective = "修改入库商品详情",
                operationContent = "修改T_WarehouseInDetail表的数据,条件为:code=" + code
            };

            if (string.IsNullOrWhiteSpace(code))
            {
                throw new Exception("-2");
            }
            try
            {
                result = wdb.updateByCode(code);
                if (result<=0)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add(code, logModel.operationTable, result, logModel.operationContent, logModel.operationTime);
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
                operationTable = "T_WarehouseAdjustPrice",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                wdb.Exists(code);
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