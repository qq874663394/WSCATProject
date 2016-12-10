
using System;
namespace Model.Finance
{
    /// <summary>
    /// 采购付款表
    /// </summary>
    [Serializable]
	public partial class FinancePayment
	{
        public FinancePayment()
        { }
        #region Model
        private int _id;
        private string _code;

        private string _suppiercode;
        private string _suppiername;
        private string _accountcode;
        private string _accountname;
        private string _salecode;
        private DateTime? _date;
        private string _operationman;
        private string _checkman;
        private string _salesman;
        private string _salescode;
        private int? _checkstate;
        private string _remark;
        private string _reserved1;
        private string _reserved2;
        private int? _isclear;
        private int? _financecollectionstate;
        private DateTime? _updatedate;
        private string _type;
        private string _settlementmethod;
        private decimal? _discount;
        private decimal? _totalcollection;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 资金收款账号
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 客户编号
        /// </summary>

        public string supplierCode
        {
            set { _suppiercode = value; }
            get { return _suppiercode; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string supplierName
        {

            set { _suppiername = value; }
            get { return _suppiername; }
        }
        /// <summary>
        /// 账户编号
        /// </summary>
        public string accountCode
        {
            set { _accountcode = value; }
            get { return _accountcode; }
        }
        /// <summary>
        /// 账户名称
        /// </summary>
        public string accountName
        {
            set { _accountname = value; }
            get { return _accountname; }
        }
        /// <summary>
        /// 销售单单号
        /// </summary>
        public string saleCode
        {
            set { _salecode = value; }
            get { return _salecode; }
        }
        /// <summary>
        /// 开单日期
        /// </summary>
        public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string operationMan
        {
            set { _operationman = value; }
            get { return _operationman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string checkMan
        {
            set { _checkman = value; }
            get { return _checkman; }
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
        /// 业务员编号
        /// </summary>
        public string salesCode
        {
            set { _salescode = value; }
            get { return _salescode; }
        }
        /// <summary>
        /// 审核状态  0 未审核  1 已审核
        /// </summary>
        public int? checkState
        {
            set { _checkstate = value; }
            get { return _checkstate; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string Reserved1
        {
            set { _reserved1 = value; }
            get { return _reserved1; }
        }
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string Reserved2
        {
            set { _reserved2 = value; }
            get { return _reserved2; }
        }
        /// <summary>
        /// 是否删除  0 删除   1保留
        /// </summary>
        public int? isClear
        {
            set { _isclear = value; }
            get { return _isclear; }
        }
        /// <summary>
        /// 单据状态  0 未收款   1部分收款   2已全款
        /// </summary>
        public int? financeCollectionState
        {
            set { _financecollectionstate = value; }
            get { return _financecollectionstate; }
        }
        /// <summary>
        /// 更改时间
        /// </summary>
        public DateTime? updatedate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 单据类型
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 结算方式
        /// </summary>
        public string settlementMethod
        {
            set { _settlementmethod = value; }
            get { return _settlementmethod; }
        }
        /// <summary>
        /// 整单折扣
        /// </summary>
        public decimal? discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 整单收款
        /// </summary>
        public decimal? totalCollection
        {
            set { _totalcollection = value; }
            get { return _totalcollection; }
        }
        #endregion Model
    }
}

