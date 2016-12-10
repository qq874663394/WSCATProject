using BaseLayer;
using BaseLayer.Base;
using HelperUtility;
using Model;
using System;
using System.Data;

namespace LogicLayer.Base
{
    public class EmpolyeeLogic
    {
        EmpolyeeBase eb = new EmpolyeeBase();
        public DataTable GetEmpByBool(bool isflag)
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseEmpolyee",
                operationTime = DateTime.Now,
                objective = "查询员工信息",
                operationContent = "查询T_BaseEmpolyee表的所有数据,显示全部:" + isflag.ToString()
            };
            try
            {
                dt = eb.SelEmpolyee(isflag);
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
                operationTable = "T_BaseEmpolyee",
                operationTime = DateTime.Now,
                objective = "查询员工信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("name like '%{0}%'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("cityName like '%{0}%'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("isEnable = {0}", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("isClear = {0}", fieldValue);
                        break;
                    case 4:
                        strWhere += string.Format("roleCode = '{0}'", fieldValue);
                        break;
                    case 5:
                        strWhere += string.Format("passWord = '{0}'", fieldValue);
                        break;
                    case 6:
                        strWhere += string.Format("name = '{0}'", fieldValue);
                        break;
                }
                model.operationContent = "查询T_BaseEmpolyee表的所有数据,条件:" + strWhere;
                dt = eb.GetList(strWhere);
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
        /// 判断该客户编号判断是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string name, string pwd)
        {
            bool result = false;
            EmpolyeeBase EmpolyeeBase = new EmpolyeeBase();
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseEmpolyee",
                operationTime = DateTime.Now,
                objective = "判断入库单是否存在",
                operationContent = "查询T_BaseEmpolyee表的数据是否存在,条件code为:" + name
            };
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("-2");
                }
                result = EmpolyeeBase.Exists(name, pwd);
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
        public bool Exists(string code)
        {
            bool isflag = false;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseEmpolyee",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                eb.Exists(code);
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