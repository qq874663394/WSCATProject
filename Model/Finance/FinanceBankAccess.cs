using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Finance
{
    public class FinanceBankAccess
    {
        #region Model
        private int _id;
        private string _code;
        private DateTime? _date;
        private string _paymentaccount;
        private string _receiptaccount;
        private decimal? _amount;
        private string _summary;
        private string _handled;
        private string _departmentcode;
        private string _operators;
        private string _auditors;
        private int _checkstate;
        /// <summary>
        /// 审核状态
        /// </summary>
        public int checkState
        {
            set { _checkstate = value; }
            get { return _checkstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 付款账户
        /// </summary>
        public string paymentAccount
        {
            set { _paymentaccount = value; }
            get { return _paymentaccount; }
        }
        /// <summary>
        /// 收款账户
        /// </summary>
        public string receiptAccount
        {
            set { _receiptaccount = value; }
            get { return _receiptaccount; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 摘要
        /// </summary>
        public string summary
        {
            set { _summary = value; }
            get { return _summary; }
        }
        /// <summary>
        /// 经手人
        /// </summary>
        public string handled
        {
            set { _handled = value; }
            get { return _handled; }
        }
        /// <summary>
        /// 部门外键
        /// </summary>
        public string departmentCode
        {
            set { _departmentcode = value; }
            get { return _departmentcode; }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string operators
        {
            set { _operators = value; }
            get { return _operators; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string auditors
        {
            set { _auditors = value; }
            get { return _auditors; }
        }
        #endregion Model
    }
}
