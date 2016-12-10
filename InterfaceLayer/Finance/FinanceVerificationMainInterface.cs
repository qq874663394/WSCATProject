using HelperUtility;
using LogicLayer.Finance;
using Model;
using Model.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Finance
{
    public class FinanceVerificationMainInterface
    {
        FinanceVerificationMainLogic _dal = new FinanceVerificationMainLogic();
        public object AddOrUpdateToMainOrDetail(FinanceVerificationMain model, List<FinanceVerificationDetail> modelDetail)
        {
            return _dal.AddOrUpdateToMainOrDetail(model, modelDetail);
        }
        public bool Exists(string code)
        {
            return _dal.Exists(code);
        }
    }
}
