using BaseLayer;
using BaseLayer.Base;
using HelperUtility;
using Model;
using System;
using System.Data;

namespace LogicLayer.Base
{
    public class StorageLogic
    {
        StorageBase srb = new StorageBase();
        public DataTable GetList(int fieldName, string fieldValue)
        {
            string strWhere = "";
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_StorageRack",
                operationTime = DateTime.Now,
                objective = "查询仓库信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("name like '%{0}%'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("address like '%{0}%'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("name = '{0}'", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("code='{0}'", fieldValue);
                        break;
                }
                logModel.operationContent = "查询T_Storage表的所有数据,条件:" + strWhere;
                dt = srb.GetList(strWhere);
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
        public bool Exists(string code)
        {
            bool isflag = false;
            LogBase lb = new LogBase();
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_BaseStorage",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                srb.Exists(code);
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
