using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Finance
{
    public class FinanceVerificationMain
    {
        #region Model
        private int _id;
        private string _summary;
        private string _description;
        private string _code;
        private DateTime? _date;
        private string _salesman;
        private string _departmentcode;
        private string _operator;
        private string _auditors;
        private string _inclientcode;
        private string _outclientcode;
        private string _insuppliercode;
        private string _outsuppliercode;
        private string _verificationtype;
        private int _checkstate;
        /// <summary>
        /// 审核状态
        /// </summary>
        public int checkState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 说明
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
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
        /// 业务员
        /// </summary>
        public string salesMan
        {
            set { _salesman = value; }
            get { return _salesman; }
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
        /// 制单员
        /// </summary>
        public string operators
        {

            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// 审核员
        /// </summary>
        public string auditors
        {
            set { _auditors = value; }
            get { return _auditors; }
        }
        /// <summary>
        /// 转入客户
        /// </summary>
        public string inClientCode
        {
            set { _inclientcode = value; }
            get { return _inclientcode; }
        }
        /// <summary>
        /// 转出客户
        /// </summary>
        public string outClientCode
        {
            set { _outclientcode = value; }
            get { return _outclientcode; }
        }
        /// <summary>
        /// 转入供应商
        /// </summary>
        public string inSupplierCode
        {
            set { _insuppliercode = value; }
            get { return _insuppliercode; }
        }
        /// <summary>
        /// 转出供应商
        /// </summary>
        public string outSupplierCode
        {
            set { _outsuppliercode = value; }
            get { return _outsuppliercode; }
        }
        /// <summary>
        /// 核销类型
        /// </summary>
        public string verificationType
        {
            set { _verificationtype = value; }
            get { return _verificationtype; }
        }
        #endregion Model
    }
}
