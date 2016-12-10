using LogicLayer.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Base
{
    public class BankAccountInterface
    {
        BankAccountLogic _dal = new BankAccountLogic();
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
            return _dal.GetList(fieldName, fieldValue, isClear, isEnable);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return _dal.Exists(code);
        }
    }
}
