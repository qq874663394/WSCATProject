using LogicLayer.Base;
using Model;
using System.Data;

namespace InterfaceLayer.Base
{
    public class StorageRackInterface
    {
        StorageRackLogic srl = new StorageRackLogic();

        /// <summary>
        /// 根据父级ID查询货架信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public DataTable SelStorageRackByCode(string parentId)
        {
            return srl.SelStorageRackByCode(parentId);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public DataTable SelStorageRack()
        {
            return srl.SelStorageRack();
        }
        /// <summary>
        /// 假删除
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int DelStorageRackByCode(string code)
        {
            return srl.DelStorageRackByCode(code);
        }
        /// <summary>
        /// 根据条件修改
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">修改后的值</param>
        /// <param name="code">编码</param>
        /// <returns></returns>
        public int UpdateStorageRackByCode(string fieldName, string fieldValue, string code)
        {
            return srl.UpdateStorageRackByCode(fieldName, fieldValue, code);
        }
        /// <summary>
        /// 新增货架信息
        /// </summary>
        /// <param name="srb"></param>
        /// <returns></returns>
        public int InsStorageRack(BaseStorageRack srb)
        {
            return srl.InsStorageRack(srb);
        }
        /// <summary>
        /// true存在，false不存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            return srl.Exists(code);
        }
    }
}