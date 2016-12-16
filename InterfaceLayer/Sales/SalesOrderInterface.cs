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

        /// <summary>
        /// 获取默认的上一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetFLastData(string code)
        {
            return _dal.GetFLastData(code);
        }

        /// <summary>
        /// 获取上一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetLastData(string code)
        {
            return _dal.GetLastData(code);
        }

        /// <summary>
        /// 获取下一单数据
        /// </summary>
        /// <param name="code">code</param>
        /// <returns></returns>
        public DataTable GetNextData(string code)
        {
            return _dal.GetNextData(code);
        }

        /// <summary>
        /// 获取最新的code
        /// </summary>
        /// <returns></returns>
        public string GetNewCode()
        {
            return _dal.GetNewCode();
        }
    }
}
