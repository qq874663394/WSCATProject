using LogicLayer.Base;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Base
{
    public class AreaInterface
    {
        AreaLogic _dal = new AreaLogic();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="fieldName">条件字段名,0:code 1:parentId 2:name</param>
        /// <param name="fieldValue">条件值</param>
        /// <param name="isClear">是否检索所有删除状态,true:检索已删除和未删除的数据，false:只检索未删除的数据</param>
        /// <param name="isEnable">是否检索所有禁用状态,true:检索已禁用和未禁用的数据，false:只检索未禁用的数据</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue, bool isClear, bool isEnable)
        {
            return _dal.GetList(fieldName, fieldValue, isClear, isEnable);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public int Add(BaseArea area)
        {
            return _dal.Add(area);
        }
        /// <summary>
        /// 修改所有数据的isClear字段
        /// </summary>
        /// <param name="isClearValue"></param>
        /// <returns></returns>
        public int UpdateAllClear(int isClearValue, int fieldName, string fieldValue)
        {
            return _dal.UpdateAllClear(isClearValue, fieldName, fieldValue);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public int Update(BaseArea area)
        {
            return _dal.Update(area);
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

        /// <summary>
        /// 根据点击的节点用linq的lambda表达式检索数据 
        /// </summary>
        /// <param name="dt">所有数据列表</param>
        /// <param name="nodeText">查询的文本</param>
        /// <param name="field">查询的数据列</param>
        /// <returns></returns>
        public DataTable searchClientByNodeClick(DataTable dt, string nodeText, string field)
        {
            return _dal.searchClientByNodeClick(dt, nodeText, field);
        }
    }
}