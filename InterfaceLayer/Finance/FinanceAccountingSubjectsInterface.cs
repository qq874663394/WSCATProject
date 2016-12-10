using LogicLayer.Finance;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceLayer.Finance
{
    public class FinanceAccountingSubjectsInterface
    {
        FinanceAccountingSubjectsLogic _dal = new FinanceAccountingSubjectsLogic();
        /// <summary>
        /// 自定义条件取得列表
        /// </summary>
        /// <param name="nodeType">选项卡索引</param>
        /// <returns></returns>
        public DataTable GetList(int type, int nodeType)
        {
            return _dal.GetList(type, nodeType);
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <returns></returns>
        public int AddParentNode(FinanceAccountingSubjects fas)
        {
            return _dal.AddParentNode(fas);
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <returns></returns>
        public int UpdateNode(FinanceAccountingSubjects fas)
        {
            return _dal.UpdateNode(fas);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <returns></returns>
        public int DelNode(string code)
        {
            return _dal.DelNode(code);
        }
    }
}
