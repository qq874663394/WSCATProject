using LogicLayer.Finance;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Finance
{
    public class FinanceBankAccessInterface
    {
        FinanceBankAccessLogic _dal = new FinanceBankAccessLogic();
        /// <summary>
        /// 更新一条数据,true成功 false失败
        /// </summary>
        public bool Update(FinanceBankAccess model)
        {
            return _dal.Update(model);
        }
        public int Add(FinanceBankAccess model)
        {
            return _dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool AddOrUpdate(FinanceBankAccess model)
        {
            return _dal.AddOrUpdate(model);
        }
    }
}
