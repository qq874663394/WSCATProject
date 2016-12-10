using LogicLayer.Finance;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Finance
{
    public class FinanceSummaryLibraryInterface
    {
        FinanceSummaryLibraryLogic fsll = new FinanceSummaryLibraryLogic();
        /// <summary>
        /// 类别摘要的数据
        /// </summary>
        /// <returns></returns>
        public DataTable SeleteTreeDate()
        {
            return fsll.SeleteTreeDate();
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <returns></returns>
        public int AddParentNode(FinanceSummaryLibrary fsl)
        {
            return fsll.AddParentNode(fsl);
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <returns></returns>
        public int UpdateNode(FinanceSummaryLibrary fsl)
        {
            return fsll.UpdateNode(fsl);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <returns></returns>
        public int DelNode(string code)
        {
            return fsll.DelNode(code);
        }
    }
}
