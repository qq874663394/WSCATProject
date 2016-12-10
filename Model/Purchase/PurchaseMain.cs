
using System;
namespace Model
{
	/// <summary>
	/// 上下班时刻表
	/// </summary>
	[Serializable]
	public partial class PurchaseMain
	{
		public PurchaseMain()
		{}
        #region Model
        private int _id;
        private int? _isclear = 1;
        private string _code;
        private string _type;
        private DateTime? _data = DateTime.Now;
        private string _suppliercode;
        private string _suppliername;
        private int? _purchaseorderstate = 0;
        private int? _checkstate;
        private string _purchasemancode;
        private string _salesman;
        private string _operationman;
        private string _checkman;
        private int? _ispay = 0;
        private string _paymethod = "0";
        private int? _putstoragestate = 0;
        private DateTime? _deliverydate;
        private string _logistics;
        private string _logisticscode;
        private string _logisticsphone;
        private decimal? _oddmoney;
        private string _accountcode;
        private decimal? _inmoney;
        private decimal? _lastmoney;
        private DateTime? _updatedate;
        private int? _urgentstate;
        private string _remark;
        private string _reserved1;
        private string _reserved2;
        private DateTime? _examinedate;
        private DateTime? _paydate;
        private string _offerssubject;
        private decimal? _invoicedamount;
        private decimal? _unbilledamount;
        private decimal? _purchaseamount;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? isClear
        {
            set { _isclear = value; }
            get { return _isclear; }
        }
        /// <summary>
        /// 采购单号
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 单据类别
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime? data
        {
            set { _data = value; }
            get { return _data; }
        }
        /// <summary>
        /// 供应商code
        /// </summary>
        public string supplierCode
        {
            set { _suppliercode = value; }
            get { return _suppliercode; }
        }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string supplierName
        {
            set { _suppliername = value; }
            get { return _suppliername; }
        }
        /// <summary>
        /// 是否已完成,1已完成,0未完成
        /// </summary>
        public int? purchaseOrderState
        {
            set { _purchaseorderstate = value; }
            get { return _purchaseorderstate; }
        }
        /// <summary>
        /// 审核情况,1已审核,0未审核
        /// </summary>
        public int? checkState
        {
            set { _checkstate = value; }
            get { return _checkstate; }
        }
        /// <summary>
        /// 采购人员ID
        /// </summary>
        public string purchaseManCode
        {
            set { _purchasemancode = value; }
            get { return _purchasemancode; }
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
        /// 操作人
        /// </summary>
        public string operationMan
        {
            set { _operationman = value; }
            get { return _operationman; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string checkMan
        {
            set { _checkman = value; }
            get { return _checkman; }
        }
        /// <summary>
        /// 是否已付款(0为未完成,1为已完成)
        /// </summary>
        public int? isPay
        {
            set { _ispay = value; }
            get { return _ispay; }
        }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string payMethod
        {
            set { _paymethod = value; }
            get { return _paymethod; }
        }
        /// <summary>
        /// 入库状态(0未入库,1已入库)
        /// </summary>
        public int? putStorageState
        {
            set { _putstoragestate = value; }
            get { return _putstoragestate; }
        }
        /// <summary>
        /// 到货日期
        /// </summary>
        public DateTime? deliveryDate
        {
            set { _deliverydate = value; }
            get { return _deliverydate; }
        }
        /// <summary>
        /// 物流单号
        /// </summary>
        public string logistics
        {
            set { _logistics = value; }
            get { return _logistics; }
        }
        /// <summary>
        /// 物流单号
        /// </summary>
        public string logisticsCode
        {
            set { _logisticscode = value; }
            get { return _logisticscode; }
        }
        /// <summary>
        /// 快递电话
        /// </summary>
        public string logisticsPhone
        {
            set { _logisticsphone = value; }
            get { return _logisticsphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? oddMoney
        {
            set { _oddmoney = value; }
            get { return _oddmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string accountCode
        {
            set { _accountcode = value; }
            get { return _accountcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? inMoney
        {
            set { _inmoney = value; }
            get { return _inmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? lastMoney
        {
            set { _lastmoney = value; }
            get { return _lastmoney; }
        }
        /// <summary>
        /// 更改时间
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 加急状态
        /// </summary>
        public int? urgentState
        {
            set { _urgentstate = value; }
            get { return _urgentstate; }
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
        /// 保留字段1
        /// </summary>
        public string reserved1
        {
            set { _reserved1 = value; }
            get { return _reserved1; }
        }
        /// <summary>
        /// 保留字段2
        /// </summary>
        public string reserved2
        {
            set { _reserved2 = value; }
            get { return _reserved2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? examineDate
        {
            set { _examinedate = value; }
            get { return _examinedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? payDate
        {
            set { _paydate = value; }
            get { return _paydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string offersSubject
        {
            set { _offerssubject = value; }
            get { return _offerssubject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? invoicedAmount
        {
            set { _invoicedamount = value; }
            get { return _invoicedamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? unbilledAmount
        {
            set { _unbilledamount = value; }
            get { return _unbilledamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? purchaseAmount
        {
            set { _purchaseamount = value; }
            get { return _purchaseamount; }
        }
        #endregion Model
    }
}

