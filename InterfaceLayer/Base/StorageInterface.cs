using LogicLayer.Base;
using System.Data;

namespace InterfaceLayer.Base
{
    public class StorageInterface
    {
        StorageLogic sl = new StorageLogic();
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="fieldName">需要查询的列：0：模糊查询name,1：模糊查询address,2:name,3:code</param>
        /// <param name="fieldValue">需要查询的列的值</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return sl.GetList(fieldName, fieldValue);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return sl.Exists(code);
        }
    }
}
