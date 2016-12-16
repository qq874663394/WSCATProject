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
    public class AreaLogic
    {
        AreaBase _dal = new AreaBase();
        LogBase _logDal = new LogBase();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="fieldName">条件字段名,0:code 1:parentId 2:name</param>
        /// <param name="fieldValue">条件值</param>
        /// <param name="isClear">是否检索所有删除状态,true:检索已删除和未删除的数据，false:只检索未删除的数据</param>
        /// <param name="isEnable">是否检索所有禁用状态,true:检索已禁用和未禁用的数据，false:只检索未禁用的数据</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue, bool isClear, bool isEnable)
        {
            DataTable dt = null;
            string strWhere = "";
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseArea",
                operationTime = DateTime.Now,
                objective = "查询地区信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("and code='{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("and parentId ='{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("and name = '{0}'", fieldValue);
                        break;
                }
                if (isClear == false)
                {
                    strWhere += string.Format("and isClear=1");
                }
                if (isEnable == false)
                {
                    strWhere += string.Format(" and isEnable=1");
                }
                model.operationContent = "查询T_BaseBankAccount表的所有数据,条件:" + strWhere;
                dt = _dal.GetList(strWhere).Tables[0];
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
            return dt;
        }

        public int Add(BaseArea area)
        {
            int result = 0;
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseArea",
                operationTime = DateTime.Now,
                objective = "新增数据,code=" + area.code,
                operationContent = "新增数据",
                result = 0
            };
            try
            {
                result = _dal.Add(area);
                if (result > 0)
                    model.result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _logDal.Add(model);
            }
            return result;
        }
        public int UpdateAllClear(int isClearValue, int fieldName, string fieldValue)
        {
            string strWhere = "";
            int result = 0;
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseArea",
                operationTime = DateTime.Now,
                objective = "修改所有isClear字段的值",
                operationContent = "修改数据",
                result = 0
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere = string.Format("and code='{0}'", fieldValue);
                        break;
                }

                result = _dal.UpdateAllClear(isClearValue, strWhere);
                if (result > 0)
                    model.result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _logDal.Add(model);
            }
            return result;
        }
        public int Update(BaseArea area)
        {
            int result = 0;
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseArea",
                operationTime = DateTime.Now,
                objective = "修改指定code的数据,code=" + area.code,
                operationContent = "修改数据",
                result = 0
            };
            try
            {
                result = _dal.Update(area);
                if (result > 0)
                    model.result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _logDal.Add(model);
            }
            return result;
        }
        public bool Exists(string code)
        {
            bool isflag = false;
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseArea",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
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
        /// 根据点击的节点用linq的lambda表达式检索数据 
        /// </summary>
        /// <param name="dt">所有数据列表</param>
        /// <param name="nodeText">查询的文本</param>
        /// <param name="field">查询的数据列</param>
        /// <returns></returns>
        public DataTable searchClientByNodeClick(DataTable dt, string nodeText, string field)
        {
            return _dal.searchClientByNodeClick(dt, nodeText, field);
        }
    }
}
