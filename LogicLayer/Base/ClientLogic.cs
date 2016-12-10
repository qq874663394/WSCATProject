using BaseLayer;
using BaseLayer.Base;
using HelperUtility;
using Model;
using System;
using System.Data;
using UpdateManagerLayer;

namespace LogicLayer.Base
{
    public class ClientLogic
    {
        BaseUpdataManager bum = new BaseUpdataManager();
        ClientBase cb = new ClientBase();
        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <param name="isflag">true显示全部 false显示未禁用</param>
        /// <returns></returns>
        public DataTable GetClientByBool(bool isflag)
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseClient",
                operationTime = DateTime.Now,
                objective = "查询信息",
                operationContent = "查询T_BaseClient表的所有数据,显示全部:" + isflag.ToString()
            };
            try
            {
                dt = cb.GetClientByBool(isflag);
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
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0：模糊name,1:cityName,2:name,3:code</param>
        /// <param name="fieldValue">条件值</param>
        /// <returns></returns>
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
                operationTable = "T_BaseClient",
                operationTime = DateTime.Now,
                objective = "查询数据"
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
                        strWhere += string.Format("name = '{0}'", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("code = '{0}'", fieldValue);
                        break;
                }
                model.operationContent = "查询T_BaseClient表的所有数据,条件:" + strWhere;
                dt = cb.GetList(strWhere);
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
                operationTable = "T_BaseClient",
                operationTime = DateTime.Now,
                objective = "查询数据",
                operationContent = "查询T_BaseClient表的数据是否存在,条件:code=" + code
            };
            try
            {
                cb.Exists(code);
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
