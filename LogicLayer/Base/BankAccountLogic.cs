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
    public class BankAccountLogic
    {
        BankAccountBase _dal = new BankAccountBase();
        LogBase _logDal = new LogBase();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="fieldName">条件字段名,0:code 1:模糊查询持卡人 2:模糊查询卡号</param>
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
                operationTable = "T_BaseBankAccount",
                operationTime = DateTime.Now,
                objective = "查询账户信息"
            };
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += string.Format("and code='{0}'", fieldValue);
                        break;
                    case 1:
                        strWhere += string.Format("and cardHolder like '%{0}%'", fieldValue);
                        break;
                    case 2:
                        strWhere += string.Format("and bankCard like '%{0}%'", fieldValue);
                        break;
                    case 3:
                        strWhere += string.Format("and openBank='{0}'", fieldValue);
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
            return dt;
        }
        public bool Exists(string code)
        {
            bool isflag = false;
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
                isflag=_dal.Exists(code);
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
    }
}
