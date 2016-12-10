using BaseLayer.Finance;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Finance
{
    public class FinanceSummaryLibraryLogic
    {
        FinanceSummaryLibraryBase fslb = new FinanceSummaryLibraryBase(); 

        /// <summary>
        /// 类别摘要的数据
        /// </summary>
        /// <returns></returns>
        public DataTable SeleteTreeDate()
        {
            return fslb.SeleteTreeDate();
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <returns></returns>
        public int AddParentNode(FinanceSummaryLibrary fsl)
        {
            return fslb.AddParentNode(fsl);
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <returns></returns>
        public int UpdateNode(FinanceSummaryLibrary fsl)
        {
            return fslb.UpdateNode(fsl);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <returns></returns>
        public int DelNode(string code)
        {
            return fslb.DelNode(code);
        }
    }
}
