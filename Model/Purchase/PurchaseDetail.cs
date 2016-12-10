
using System;
namespace Model
{
	/// <summary>
	/// 上下班时刻表
	/// </summary>
	[Serializable]
	public partial class PurchaseDetail
	{
		public PurchaseDetail()
		{}
        #region Model
        private int _id;
        private int? _isclear;
        private string _materialdaima;
        private string _zhujima;
        private string _barcode;
        private string _code;
        private string _purchasecode;
        private string _storagecode;
        private string _storagename;
        private string _materialcode;
        private string _materialname;
        private string _materialmodel;
        private string _unit;
        private decimal? _number;
        private decimal? _discountbeforeprice;
        private decimal? _discount;
        private decimal? _discountafterprice;
        private decimal? _money;
        private string _remark;
        private DateTime? _updatedate;
        private string _reserved1;
        private string _reserved2;
        private DateTime? _productiondate;
        private decimal? _qualitydate;
        private DateTime? _effectivedate;
        private decimal? _vatrate;
        private decimal? _tax;
        private decimal? _taxtotal;
        private decimal? _discountmoney;
        /// <summary>
        /// 栏号自增
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
        /// 商品代码
        /// </summary>
        public string materialDaima
        {
            set { _materialdaima = value; }
            get { return _materialdaima; }
        }
        /// <summary>
        /// 助记码
        /// </summary>
        public string zhujima
        {
            set { _zhujima = value; }
            get { return _zhujima; }
        }
        /// <summary>
        /// 条形码
        /// </summary>
        public string barCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 仓库code
        /// </summary>
        public string purchaseCode
        {
            set { _purchasecode = value; }
            get { return _purchasecode; }
        }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string storageCode
        {
            set { _storagecode = value; }
            get { return _storagecode; }
        }
        /// <summary>
        /// 物料ID
        /// </summary>
        public string storageName
        {
            set { _storagename = value; }
            get { return _storagename; }
        }
        /// <summary>
        /// 物料编号
        /// </summary>
        public string materialCode
        {
            set { _materialcode = value; }
            get { return _materialcode; }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string materialName
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string materialModel
        {
            set { _materialmodel = value; }
            get { return _materialmodel; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string unit
        {
            set { _unit = value; }
            get { return _unit; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 折扣前价格
        /// </summary>
        public decimal? discountBeforePrice
        {
            set { _discountbeforeprice = value; }
            get { return _discountbeforeprice; }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal? discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 折扣后价格
        /// </summary>
        public decimal? discountAfterPrice
        {
            set { _discountafterprice = value; }
            get { return _discountafterprice; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? money
        {
            set { _money = value; }
            get { return _money; }
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
        /// 更新时间
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string reserved1
        {
            set { _reserved1 = value; }
            get { return _reserved1; }
        }
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string reserved2
        {
            set { _reserved2 = value; }
            get { return _reserved2; }
        }
        /// <summary>
        /// 生产/采购日期
        /// </summary>
        public DateTime? productionDate
        {
            set { _productiondate = value; }
            get { return _productiondate; }
        }
        /// <summary>
        /// 保质期
        /// </summary>
        public decimal? qualityDate
        {
            set { _qualitydate = value; }
            get { return _qualitydate; }
        }
        /// <summary>
        /// 有效期至
        /// </summary>
        public DateTime? effectiveDate
        {
            set { _effectivedate = value; }
            get { return _effectivedate; }
        }
        /// <summary>
        /// 增值税税率
        /// </summary>
        public decimal? VATRate
        {
            set { _vatrate = value; }
            get { return _vatrate; }
        }
        /// <summary>
        /// 税额
        /// </summary>
        public decimal? tax
        {
            set { _tax = value; }
            get { return _tax; }
        }
        /// <summary>
        /// 价税合计
        /// </summary>
        public decimal? taxTotal
        {
            set { _taxtotal = value; }
            get { return _taxtotal; }
        }
        /// <summary>
        /// 折扣额
        /// </summary>
        public decimal? discountMoney
        {
            set { _discountmoney = value; }
            get { return _discountmoney; }
        }
        #endregion Model
    }
}

