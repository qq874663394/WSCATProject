using LogicLayer.Finance;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Finance
{
    public class FinanceOtherExpensesInInterface
    {
        FinanceOtherExpensesInLogic _dal = new FinanceOtherExpensesInLogic();
        public object AddOrUpdateToMainOrDetail(FinanceOtherExpensesIn model, List<FinanceOtherExpenseInDetail> modelDetail)
        {
            return _dal.AddOrUpdateToMainOrDetail(model, modelDetail);
        }
        public bool Exists(string code)
        {
            return _dal.Exists(code);
        }
    }
}
