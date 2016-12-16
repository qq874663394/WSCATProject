using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Purchase
{
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {

        }
        #region Model
        private int _id;
        private string _suppliercode;
        private DateTime? _deliversdate;
        private int? _deliversmethod;
        private string _remark;
        private string _code;
        private DateTime? _date;
        private string _deliverslocation;
        private string _operation;
        private string _makeman;
        private string _examine;
        private int? _checkstate;
        private decimal? _depositreceived;
        private DateTime? _examinedate;
        private DateTime? _paydate;
        private string _offerssubject;
        private decimal? _invoicedamount;
        private decimal? _unbilledamount;
        private decimal? _purchaseamount;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 客户外键
        /// </summary>
        public string supplierCode
        {
            set { _suppliercode = value; }
            get { return _suppliercode; }
        }
        /// <summary>
        /// 交货日期
        /// </summary>
        public DateTime? deliversDate
        {
            set { _deliversdate = value; }
            get { return _deliversdate; }
        }
        /// <summary>
        /// 交货方式
        /// </summary>
        public int? deliversMethod
        {
            set { _deliversmethod = value; }
            get { return _deliversmethod; }
        }
        /// <summary>
        /// 摘要
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        /// 日期
        /// </summary>
        public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 交货地点
        /// </summary>
        public string deliversLocation
        {
            set { _deliverslocation = value; }
            get { return _deliverslocation; }
        }
        /// <summary>
        /// 销售员
        /// </summary>
        public string operation
        {
            set { _operation = value; }
            get { return _operation; }
        }
        /// <summary>
        /// 制单人
        /// </summary>
        public string makeMan
        {
            set { _makeman = value; }
            get { return _makeman; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string examine
        {
            set { _examine = value; }
            get { return _examine; }
        }
        /// <summary>
        /// 审核状态  
        /// </summary>
        public int? checkState
        {
            set { _checkstate = value; }
            get { return _checkstate; }
        }
        /// <summary>
        /// 已收订金
        /// </summary>
        public decimal? depositReceived
        {
            set { _depositreceived = value; }
            get { return _depositreceived; }
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
        /// 付款期限
        /// </summary>
        public DateTime? payDate
        {
            set { _paydate = value; }
            get { return _paydate; }
        }

        /// <summary>
        /// 优惠项目
        /// </summary>
        public string offersSubject
        {
            set { _offerssubject = value; }
            get { return _offerssubject; }
        }
        /// <summary>
        /// 未开票金额
        /// </summary>
        public decimal? invoicedAmount
        {
            set { _invoicedamount = value; }
            get { return _invoicedamount; }
        }
        /// <summary>
        /// 已开票金额
        /// </summary>
        public decimal? unbilledAmount
        {
            set { _unbilledamount = value; }
            get { return _unbilledamount; }
        }
        /// <summary>
        /// 采购费用合计
        /// </summary>
        public decimal? purchaseAmount
        {
            set { _purchaseamount = value; }
            get { return _purchaseamount; }
        }

        #endregion Model
    }
}