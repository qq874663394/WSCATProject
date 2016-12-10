using LogicLayer.Base;
using System.Data;

namespace InterfaceLayer.Base
{
    public class ClientInterface
    {
        ClientLogic cb = new ClientLogic();
        /// <summary>
        /// 查询所有客户信息
        /// </summary>
        /// <param name="isflag">true显示全部 false显示未禁用</param>
        /// <returns></returns>
        public DataTable GetClientByBool(bool isflag)
        {
            return cb.GetClientByBool(isflag);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return cb.Exists(code);
        }
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">0：模糊name,1:cityName,2:name,3:code</param>
        /// <param name="fieldValue">条件值</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return cb.GetList(fieldName,fieldValue);
        }
    }
}
