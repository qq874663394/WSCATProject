using LogicLayer.Sales;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Sales
{
    public class SalesMainInterface
    {
        private SalesMainLogic _dal = new SalesMainLogic();
        /// <summary>
        /// 根据条件获取销售单列表
        /// </summary>
        /// <param name="fieldName">字段名，0：clientCode</param>
        /// <param name="fieldValue">条件值</param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return _dal.GetList(fieldName, fieldValue);
        }
        /// <summary>
        /// 根据客户编号返回销售单的Table(id,code)
        /// </summary>
        /// <param name="clientCode"></param>
        /// <returns></returns>
        public DataTable GetTableByClientCode(string clientCode)
        {
            return _dal.GetTableByClientCode(clientCode);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code)
        {
            return _dal.Exists(code);
        }
        /// <summary>
        /// 保存审核公用
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelDetail"></param>
        /// <returns></returns>
        public object AddOrUpdateToMainOrDetail(SalesMain model, List<SalesDetail> modelDetail)
        {
            return _dal.AddOrUpdateToMainOrDetail(model, modelDetail);
        }
        public DataTable GetExamineAndPay(string clientCode)
        {
            return _dal.GetExamineAndPay(clientCode);
        }
        public DataTable GetExamineAndPay(string clientCode, string salesCode)
        {
            return _dal.GetExamineAndPay(clientCode, salesCode);
        }
        public int SetPayState(int payState, string code)
        {
            return _dal.SetPayState(payState, code);
        }
    }
}