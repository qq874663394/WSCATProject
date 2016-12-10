using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using BaseLayer;
using HelperUtility.Encrypt;
using HelperUtility;
using UpdateManagerLayer;
using System.Collections;
using System.Data.SqlClient;

namespace LogicLayer
{
    public class WarehouseInLogic
    {
        WarehouseUpdataManager wum = new WarehouseUpdataManager();
        /// <summary>
        /// 根据审核状态查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetListToIn(int state)
        {
            WarehouseInBase warehouseInBase = new WarehouseInBase();
            DataSet ds = null;

            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseIn",
                operationTime = DateTime.Now,
                objective = "根据审核状态查询",
                operationContent = "根据审核状态查询入库表,条件为：state=" + state
            };
            try
            {
                ds = warehouseInBase.GetListToIn(state);
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
        /// 事务修改
        /// </summary>
        /// <param name="hashTable">主表的sql和parameter</param>
        /// <param name="sql">子表sql</param>
        /// <param name="list">子表的parameter</param>
        public int UpdateList(Hashtable hashTable, string sql, List<SqlParameter[]> list)
        {
            int result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseIn",
                operationTime = DateTime.Now,
                objective = "修改入库信息,修改入库商品详情",
                operationContent = "修改T_WarehouseIn和T_WarehouseInDetail表的数据"
            };

            WarehouseInBase warehouseInBase = new WarehouseInBase();
            try
            {
                result = warehouseInBase.UpdateList(hashTable, sql, list);
                if (result <= 0)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add("", logModel.operationTable, list.Count, "", logModel.operationTime);
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
        /// 根据where条件获取数据列表
        /// </summary>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
        public DataSet GetList(int fieldName, string fieldValue)
        {
            string strWhere = "";
            WarehouseInBase warehouseInBase = new WarehouseInBase();
            DataSet ds = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseIn",
                operationTime = DateTime.Now,
                objective = "查询入库信息",
                operationContent = "查询T_WarehouseIn表的数据,条件为:" + strWhere
            };
            try
            {
                switch (fieldName)
                {
                    case 1:
                        strWhere += string.Format(" code='{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format(" type='{0}'", fieldValue);
                        break;
                }
                ds = warehouseInBase.GetList(strWhere);
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
        /// 增加一条数据
        /// </summary>
        /// <returns>返回新增结果,1为成功</returns>
        public object AddWarehouseOrToDetail(WarehouseIn warehouseIn, List<WarehouseInDetail> warehouseInDetail)
        {
            object result = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseIn",
                operationTime = DateTime.Now,
                objective = "新增入库信息,新增入库商品详情",
                operationContent = "新增T_WarehouseIn和T_WarehouseInDetail表的数据"
            };

            WarehouseInBase warehouseInBase = new WarehouseInBase();
            try
            {
                if (warehouseIn == null || warehouseInDetail == null)
                {
                    throw new Exception("-2");
                }
                result = warehouseInBase.AddWarehouseOrToDetail(warehouseIn, warehouseInDetail);
                if (result == null)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add(warehouseIn.code, logModel.operationTable, warehouseInDetail.Count + 1, "", logModel.operationTime);
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
        /// 根据code删除一条数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int deleteByCode(string code)
        {
            WarehouseInBase warehouseInBase = new WarehouseInBase();
            int result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseIn",
                operationTime = DateTime.Now,
                objective = "删除入库信息",
                operationContent = "删除T_WarehouseIn表的数据,code为:" + code
            };
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("-2");
                }
                result = warehouseInBase.deleteByCode(code);
                if (result <= 0)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add(code, logModel.operationTable, result, "", logModel.operationTime);
            }
            catch (Exception)
            {
                logModel.result = 0;
                throw;
            }
            finally
            {
                lb.Add(logModel);
            }
            return result;
        }
        /// <summary>
        /// 根据code更新某一条数据
        /// </summary>
        /// <param name="wi"></param>
        /// <returns></returns>
        public int update(WarehouseIn wi)
        {
            int result = 0;
            WarehouseInBase warehouseInBase = new WarehouseInBase();
            //添加日志
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseIn",
                operationTime = DateTime.Now,
                objective = "更新入库表信息",
                operationContent = "更新T_WarehouseIn表的数据,code为:" + wi.code
            };
            try
            {
                if (wi == null)
                {
                    throw new Exception("-2");
                }
                result = warehouseInBase.update(wi);
                if (result <= 0)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add(wi.code, logModel.operationTable, result, "", logModel.operationTime);
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
        /// 修改审核状态
        /// </summary>
        /// <param name="warehouseIn">主表</param>
        /// <param name="list">从表</param>
        /// <returns></returns>
        public int updateByCode(WarehouseIn warehouseIn, List<WarehouseInDetail> list)
        {
            WarehouseInBase warehouseInBase = new WarehouseInBase();

            int result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseIn",
                operationTime = DateTime.Now,
                objective = "更新入库表信息",
                operationContent = "更新T_WarehouseIn表的数据,code为:" + warehouseIn.code
            };
            try
            {
                if (string.IsNullOrWhiteSpace(warehouseIn.code))//判断单号是否为空
                {
                    throw new Exception("-2");
                }
                if (Exists(warehouseIn.code) == true)//判断此入库单是否存在
                {
                    result = warehouseInBase.updateByCode(warehouseIn.code);
                }
                else
                {
                    result = Convert.ToInt32(AddWarehouseOrToDetail(warehouseIn, list));
                }
                if (result <= 0)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add(warehouseIn.code, logModel.operationTable, result, "", logModel.operationTime);
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
        /// 上下一单
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="state">状态:0:下一单,1:上一单</param>
        /// <returns></returns>
        public WarehouseIn GetPreAndNext(int id, int state)
        {
            WarehouseInBase warehouseInBase = new WarehouseInBase();
            WarehouseIn whi = new WarehouseIn();
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseIn",
                operationTime = DateTime.Now,
                objective = "修改入库状态",
                operationContent = "修改T_WarehouseIn表的数据,条件id为:" + id
            };
            try
            {
                if (state != 0 && state != 1)
                {
                    throw new Exception("-2");
                }
                whi = warehouseInBase.GetPreAndNext(id, state);
                if (whi == null)
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                logModel.result = 0;
                throw ex;
            }
            return whi;
        }
        /// <summary>
        /// 判断该客户编号判断是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            bool result = false;
            WarehouseInBase warehouseInBase = new WarehouseInBase();
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseIn",
                operationTime = DateTime.Now,
                objective = "判断入库单是否存在",
                operationContent = "查询T_WarehouseIn表的数据是否存在,条件code为:" + code
            };
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("-2");
                }
                result = warehouseInBase.Exists(code);
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
            return result;
        }
    }
}