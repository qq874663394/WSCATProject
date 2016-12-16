using BaseLayer;
using BaseLayer.Base;
using HelperUtility;
using HelperUtility.Encrypt;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Base
{
    public class SupplierLogic
    {
        SupplierBase sb = new SupplierBase();
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <returns>所有数据以DataTable的形式返回</returns>
        public DataTable SelSupplierTable()
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseSupplier",
                operationTime = DateTime.Now,
                objective = "查询供应商信息",
                operationContent = "查询T_BaseSupplier表的数据成功"
            };
            try
            {
                dt = sb.SelSupplierTable();
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
		/// 增加一条数据
		/// </summary>
		public int Add(BaseSupplier model)
        {
            LogBase lb = new LogBase();
            int result = 0;
            Log logmodel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseSupplier",
                operationTime = DateTime.Now,
                objective = "新增数据",
                operationContent = "新增数据,code=" + model.code
            };
            try
            {
                result = sb.Add(model);
                logmodel.result = 1;
            }
            catch (Exception ex)
            {
                logmodel.result = 0;
                throw ex;
            }
            finally
            {
                lb.Add(logmodel);
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BaseSupplier model)
        {
            LogBase lb = new LogBase();
            bool result = false;
            Log logmodel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseSupplier",
                operationTime = DateTime.Now,
                objective = "修改数据",
                operationContent = "修改数据,code=" + model.code
            };
            try
            {
                result = sb.Update(model);
                logmodel.result = 1;
            }
            catch (Exception ex)
            {
                logmodel.result = 0;
                throw ex;
            }
            finally
            {
                lb.Add(logmodel);
            }
            if (result)
            {
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:模糊name,1:模糊cityName,4:code,5:name,</param>
        /// <param name="fieldValue">条件值</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue, bool isClear, bool isEnable)
        {
            string strWhere = "";
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseSupplier",
                operationTime = DateTime.Now,
                objective = "查询员工信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format(" and name like '%{0}%'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format(" and cityName like '%{0}%'", fieldValue);
                        break;
                    case 4:
                        strWhere += string.Format(" and code = '{0}'", fieldValue);
                        break;
                    case 5:
                        strWhere += string.Format(" and name = '{0}'", fieldValue);
                        break;
                }
                if (isClear == false)
                {
                    strWhere += string.Format(" and isClear=1");
                }
                if (isEnable == false)
                {
                    strWhere += string.Format(" and isEnable=1");
                }
                model.operationContent = "查询T_BaseSupplier表的所有数据,条件:" + strWhere;
                dt = sb.GetList(strWhere);
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
        /// <summary>
        /// 自定义where查询
        /// </summary>
        /// <returns></returns>
        public DataTable SelSupplierByWhere(string SQLWhere)
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseSupplier",
                operationTime = DateTime.Now,
                objective = "查询员工信息"
            };
            try
            {
                model.operationContent = "查询T_BaseSupplier表的所有数据,条件:" + SQLWhere;
                dt = sb.SelSupplierByWhere(SQLWhere);
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
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string code)
        {
            LogBase lb = new LogBase();
            bool result = false;
            Log logmodel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseSupplier",
                operationTime = DateTime.Now,
                objective = "删除数据",
                operationContent = "删除指定数据,code=" + code
            };
            try
            {
                result = sb.Delete(code);
                logmodel.result = 1;
            }
            catch (Exception ex)
            {
                logmodel.result = 0;
                throw ex;
            }
            finally
            {
                lb.Add(logmodel);
            }
            return result;
        }
        /// <summary>
        /// 删除全部数据
        /// </summary>
        public bool DeleteAll()
        {
            LogBase lb = new LogBase();
            bool result = false;
            Log logmodel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseSupplier",
                operationTime = DateTime.Now,
                objective = "删除数据",
                operationContent = "删除全部数据"
            };
            try
            {
                result = sb.DeleteAll();
                logmodel.result = 1;
            }
            catch (Exception ex)
            {
                logmodel.result = 0;
                throw ex;
            }
            finally
            {
                lb.Add(logmodel);
            }
            return result;
        }

        public DataTable GetPurchaseList(string code)
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseSupplier/T_PurchaseMain",
                operationTime = DateTime.Now,
                objective = "查询员工信息",
                operationContent = "根据T_BaseSupplier表的code查询T_PurchaseMain表的所有数据,条件:code=" + XYEEncoding.strHexDecode(code)
            };
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("-2");
                }
                dt = sb.GetPurchaseList(code);
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
        public bool Exists(string code)
        {
            bool isflag = false;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseBankAccount",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                sb.Exists(code);
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
