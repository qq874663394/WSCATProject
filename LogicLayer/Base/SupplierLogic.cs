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
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0:模糊name,1:模糊cityName,2:isEnable,3:isClear,</param>
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
                operationTable = "T_BaseSupplier",
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
                        strWhere += string.Format("code = '{0}'", fieldValue);
                        break;
                    case 5:
                        strWhere += string.Format("name = '{0}'", fieldValue);
                        break;
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
