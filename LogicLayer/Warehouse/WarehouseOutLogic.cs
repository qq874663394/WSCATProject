using BaseLayer;
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

namespace LogicLayer.Warehouse
{
    public class WarehouseOutLogic
    {
        WarehouseUpdataManager wum = new WarehouseUpdataManager();
        /// <summary>
        /// 根据审核状态查询
        /// </summary>
        /// <returns></returns>
        public DataSet GetListToOut(int state)
        {
            WarehouseOutBase wob = new WarehouseOutBase();
            DataSet ds = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseOut",
                operationTime = DateTime.Now,
                objective = "查询出库表",
                operationContent = "根据审核状态查询T_WarehouseOut，条件state值为" + state
            };

            try
            {
                ds = wob.GetListToOut(state);
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                logModel.result = 0;
                throw ex;
            }

            lb.Add(logModel);//rz
            return ds;
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            WarehouseOutBase wob = new WarehouseOutBase();
            string strWhere = "";
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseOut",
                operationTime = DateTime.Now,
                objective = "根据where条件获取出库单列表",
                operationContent = "根据where条件查询表T_WarehouseOut出库单列表，条件strWhere值为" + strWhere
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("code='{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("type='{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("checkState='{0}'", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("clientCode = '{0}'", fieldValue);
                        break;
                    case 4:
                        strWhere += string.Format("mainCode='{0}'", fieldValue);
                        break;
                }
                dt = wob.GetList(strWhere);
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
        /// <summary>
        /// 事务新增
        /// </summary>
        /// <param name="warehouseOut">主表值</param>
        /// <param name="warehouseOutDetail">从表值的list</param>
        /// <returns></returns>
        public object Add(WarehouseOut warehouseOut, List<WarehouseOutDetail> warehouseOutDetail)
        {
            WarehouseOutBase wob = new WarehouseOutBase();
            object result = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseOut",
                operationTime = DateTime.Now,
                objective = "新增出库信息,修改出库商品详情",
                operationContent = "新增T_WarehouseOut和T_WarehouseOutDetail表的数据"
            };
            try
            {
                if (warehouseOut == null)
                {
                    throw new Exception("-2");
                }
                result = wob.Add(warehouseOut, warehouseOutDetail);
                if (string.IsNullOrWhiteSpace(result.ToString()))
                {
                    throw new Exception("-3");
                }
                logModel.result = 1;
                wum.add(warehouseOut.code, logModel.operationTable, warehouseOutDetail.Count + 1, "", logModel.operationTime);
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
        /// 事务修改
        /// </summary>
        /// <param name="warehouseOut">主表值</param>
        /// <param name="listModel">从表值的list</param>
        /// <returns></returns>
        public int update(WarehouseOut warehouseOut, List<WarehouseOutDetail> listModel)
        {
            int result = 0;
            WarehouseOutBase wob = new WarehouseOutBase();
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseOutDetail/T_WarehouseOut",
                operationTime = DateTime.Now,
                objective = "修改入库表和入库明细表",
                operationContent = "修改T_WarehouseOutDetail和T_WarehouseOut表的数据"
            };
            try
            {
                result = wob.update(warehouseOut, listModel);
                logModel.result = 1;
                wum.add(warehouseOut.code, logModel.operationTable, listModel.Count + 1, "", logModel.operationTime);
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
        public WarehouseOut GetPreAndNext(int id, int state)
        {
            WarehouseOutBase wob = new WarehouseOutBase();
            WarehouseOut who = new WarehouseOut();
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseOut",
                operationTime = DateTime.Now,
                objective = "修改入库状态",
                operationContent = "修改T_WarehouseOut表的数据,条件id为:" + id
            };
            try
            {
                if (state != 0 && state != 1)
                {
                    throw new Exception("-2");
                }
                who = wob.GetPreAndNext(id, state);
                if (who == null)
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
            return who;
        }
        public bool Exists(string code)
        {
            WarehouseOutBase wob = new WarehouseOutBase();
            bool isflag = false;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseOut",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                wob.Exists(code);
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
