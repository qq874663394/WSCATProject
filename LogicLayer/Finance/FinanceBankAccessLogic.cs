using BaseLayer;
using BaseLayer.Finance;
using HelperUtility;
using Model;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateManagerLayer;

namespace LogicLayer.Finance
{
    public class FinanceBankAccessLogic
    {
        FinanceBankAccessBase _dal = new FinanceBankAccessBase();
        FinanceUpdataManager _update = new FinanceUpdataManager();
        LogBase _logDal = new LogBase();
        Log _logmodel = new Log()
        {
            operationCode = "操作人code",
            operationName = "操作人名",
            operationTable = "T_FinanceBankAccess",
            operationTime = DateTime.Now
        };
        public int Add(FinanceBankAccess model)
        {
            int result = 0;
            _logmodel.code = BuildCode.ModuleCode("log");
            _logmodel.objective = "新增银行存取信息";
            _logmodel.operationContent = "新增银行存取信息";
            try
            {
                result = _dal.Add(model);
                _logmodel.result = 1;
            }
            catch (Exception ex)
            {
                _logmodel.result = 0;
                throw ex;
            }
            finally
            {
                _logDal.Add(_logmodel);
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(FinanceBankAccess model)
        {
            bool result = false;
            _logmodel.code = BuildCode.ModuleCode("log");
            _logmodel.objective = "修改银行存取信息";
            _logmodel.operationContent = "修改银行存取信息";
            try
            {
                result = _dal.Update(model);
                _logmodel.result = 1;
            }
            catch (Exception ex)
            {
                _logmodel.result = 0;
                throw ex;
            }
            finally
            {
                _logDal.Add(_logmodel);
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool AddOrUpdate(FinanceBankAccess model)
        {
            bool result = false;
            _logmodel.code = BuildCode.ModuleCode("log");
            try
            {
                if (Exists(model.code))
                {
                    _logmodel.objective = "修改银行存取信息";
                    _logmodel.operationContent = "修改银行存取信息";
                    result = _dal.Update(model);
                }
                else
                {
                    _logmodel.objective = "新增银行存取信息";
                    _logmodel.operationContent = "新增银行存取信息";
                    int resultNumber = _dal.Add(model);
                    if (resultNumber > 0)
                        result = true;
                }
                _logmodel.result = 1;
            }
            catch (Exception ex)
            {
                _logmodel.result = 0;
                throw ex;
            }
            finally
            {
                _logDal.Add(_logmodel);
            }
            return result;
        }
        public bool Exists(string code)
        {
            bool isflag = false;
            _logmodel.code = BuildCode.ModuleCode("log");
            _logmodel.objective = "查询指定code的数据是否存在";
            _logmodel.operationContent = "查询数据";
            try
            {
                isflag=_dal.Exists(code);
                _logmodel.result = 1;
            }
            catch (Exception ex)
            {
                _logmodel.result = 0;
                throw ex;
            }
            finally
            {
                _logDal.Add(_logmodel);
            }
            return isflag;
        }
    }
}
