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

namespace LogicLayer.Warehouse
{
    public class WarehouseOutDetailLogic
    {
        WarehouseOutDetailBase wodb = new WarehouseOutDetailBase();
        public DataSet GetList(int fieldName,string fieldValue)
        {
            DataSet ds = null;
            string strWhere = "";
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_WarehouseOutDetail",
                operationTime = DateTime.Now,
                objective = "查询出库明细表"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("mainCode='{0}'",fieldValue);
                        break;
                }
                ds = wodb.GetList(strWhere);
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                logModel.result = 0;
                throw ex;
            }
            finally
            {
                logModel.operationContent = "T_WarehouseOutDetail，strWhere值为" + strWhere;
                lb.Add(logModel);
            }
            return ds;
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
                operationTable = "T_WarehouseOutDetail",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                wodb.Exists(code);
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
