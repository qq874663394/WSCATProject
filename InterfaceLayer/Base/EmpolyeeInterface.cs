using LogicLayer.Base;
using System.Data;

namespace InterfaceLayer.Base
{
    public class EmpolyeeInterface
    {
        EmpolyeeLogic el = new EmpolyeeLogic();
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <param name="isflag">是否显示禁用：true显示所有禁用状态的信息，false仅显示未禁用状态的信息</param>
        /// <returns></returns>
        public DataTable SelSupplierTable(bool isflag)
        {
            return el.GetEmpByBool(isflag);
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="fieldName">需要查询的列:0:name,1:cityName,2:jobStatus,3:isEnable,4:isClear,5:roleCode,6:passWord</param>
        /// <param name="fieldValue">需要查询的列的值</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return el.GetList(fieldName, fieldValue);
        }
        public bool Exists(string name, string pwd)
        {
            return el.Exists(name, pwd);
        }
        public bool Exists(string code)
        {
            return el.Exists(code);
        }
    }
}
