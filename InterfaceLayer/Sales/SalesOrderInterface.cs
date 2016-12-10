using LogicLayer.Sales;
using Model.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Sales
{
    public class SalesOrderInterface
    {
        SalesOrderLogic _dal = new SalesOrderLogic();
        /// <summary>
        /// 事务操作
        /// </summary>
        /// <returns>返回结果,不等于null成功</returns>
        public object AddOrUpdate(SalesOrder model, List<SalesOrderDetail> modelDetail)
        {
            return _dal.AddOrUpdate(model, modelDetail);
        }
        public DataTable GetSalesJoinSearch(string clientcode)
        {
            return _dal.GetSalesJoinSearch(clientcode);
        }
        public DataTable GetSalesDetailJoinSearch()
        {
            return _dal.GetSalesDetailJoinSearch();
        }
        public DataTable GetSelectedDetail(string salesCode, string salesDetailCode)
        {
            return _dal.GetSelectedDetail(salesCode, salesDetailCode);
        }
        public bool Exists(string code)
        {
            return _dal.Exists(code);
        }
        }
}
