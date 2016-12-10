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
    public class OrderTypeLogic
    {
        OrderTypeBase otb = new OrderTypeBase();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:模糊name,1:name,2:code</param>
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
                operationTable = "T_BaseOrderType",
                operationTime = DateTime.Now,
                objective = "查询客户信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("name like '{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("name = '{0}'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("code = '{0}'", fieldValue);
                        break;
                }
                model.operationContent = "查询T_OrderType表的所有数据,条件:" + strWhere;
                dt = otb.GetList(strWhere);
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
                operationTable = "T_BaseOrderType",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                otb.Exists(code);
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
