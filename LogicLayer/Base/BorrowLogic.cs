using BaseLayer;
using BaseLayer.Base;
using HelperUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Base
{
    public class BorrowLogic
    {
        BorrowBase _dal = new BorrowBase();
        LogBase _logDal = new LogBase();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int code)
        {
            bool isflag = false;
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseBorrow",
                operationTime = DateTime.Now,
                objective = "查询数据",
                operationContent = "查询指定code的数据是否存在"
            };
            try
            {
                isflag = _dal.Exists(code);
                model.result = 1;
            }
            catch (Exception ex)
            {
                model.result = 0;
                throw ex;
            }
            finally
            {
                _logDal.Add(model);
            }
            return isflag;
        }
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BaseBorrow model)
        {
            int result = 0;
            Log logmodel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseBorrow",
                operationTime = DateTime.Now,
                objective = "新增数据",
                operationContent = "新增数据,id=" + model.id
            };
            try
            {
                result = _dal.Add(model);
                logmodel.result = 1;
            }
            catch (Exception ex)
            {
                logmodel.result = 0;
                throw ex;
            }
            finally
            {
                _logDal.Add(logmodel);
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(BaseBorrow model)
        {
            int result = 0;
            Log logmodel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseBorrow",
                operationTime = DateTime.Now,
                objective = "修改数据",
                operationContent = "修改数据,id=" + model.id
            };
            try
            {
                result = _dal.Update(model);
                logmodel.result = 1;
            }
            catch (Exception ex)
            {
                logmodel.result = 0;
                throw ex;
            }
            finally
            {
                _logDal.Add(logmodel);
            }
            return result;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            bool result = false;
            Log logmodel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseBorrow",
                operationTime = DateTime.Now,
                objective = "删除数据",
                operationContent = "删除指定数据,id=" + id
            };
            try
            {
                result = _dal.Delete(id);
                logmodel.result = 1;
            }
            catch (Exception ex)
            {
                logmodel.result = 0;
                throw ex;
            }
            finally
            {
                _logDal.Add(logmodel);
            }
            return result;
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public DataTable GetList(int fieldName, string fieldValue)
        {
            string strWhere = "";
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseBorrow",
                operationTime = DateTime.Now,
                objective = "查询数据"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("id = {0}", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("name = '{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("name like '%{0}%'", fieldValue);
                        break;
                }
                model.operationContent = "查询T_BaseBorrow表的所有数据,条件:" + strWhere;
                dt = _dal.GetList(strWhere);
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
    }
}