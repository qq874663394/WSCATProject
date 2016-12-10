
using System;
namespace Model
{
	/// <summary>
	/// 销售订单明细表
	/// </summary>
	[Serializable]
	public partial class SalesDetail
	{
		public SalesDetail()
		{}
        #region Model
        private int _id;
        private int? _isclear = 1;
        private string _code;
        private string _maincode;
        private string _storagecode;
        private string _storagename;
        private string _materialdaima;
        private string _materialcode;
        private string _materialname;
        private string _materiamodel;
        private string _unit;
        private decimal? _neednumber;
        private decimal? _actualnumber;
        private decimal? _lostnumber;
        private decimal? _discountbeforeprice;
        private decimal? _discount;
        private decimal? _discountafterprice;
        private decimal? _money;
        private string _reserved1;
        private string _reserved2;
        private string _remark;
        private DateTime? _updatedate;
        private DateTime? _productiondate;
        private decimal? _qualitydate;
        private DateTime? _effectivedate;
        private string _zhujima;
        private string _barcode;
        private decimal? _vatrate;
        private decimal? _discountmoney;
        private decimal? _tax;
        private decimal? _leviedmoney;
        private decimal? _costprice;
        private decimal? _costmoney;
        private decimal? _returnsnumber;
        private string _sourcecode;
        /// <summary>
        /// 栏号(自增)ID
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
        /// 销售订单详情code
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 主表code
        /// </summary>
        public string mainCode
        {
            set { _maincode = value; }
            get { return _maincode; }
        }
        /// <summary>
        /// 仓库code
        /// </summary>
        public string storageCode
        {
            set { _storagecode = value; }
            get { return _storagecode; }
        }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string storageName
        {
            set { _storagename = value; }
            get { return _storagename; }
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
        public string materiaModel
        {
            set { _materiamodel = value; }
            get { return _materiamodel; }
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
        /// 需求数量
        /// </summary>
        public decimal? needNumber
        {
            set { _neednumber = value; }
            get { return _neednumber; }
        }
        /// <summary>
        /// 实际数量
        /// </summary>
        public decimal? actualNumber
        {
            set { _actualnumber = value; }
            get { return _actualnumber; }
        }
        /// <summary>
        /// 欠缺数量
        /// </summary>
        public decimal? lostNumber
        {
            set { _lostnumber = value; }
            get { return _lostnumber; }
        }
        /// <summary>
        /// 单价(折扣后)
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
        /// 折扣前单价
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
        /// 
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
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        /// 
        /// </summary>
        public string zhujima
        {
            set { _zhujima = value; }
            get { return _zhujima; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string barCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 增值税税率%
        /// </summary>
        public decimal? VATRate
        {
            set { _vatrate = value; }
            get { return _vatrate; }
        }
        /// <summary>
        /// 折扣额
        /// </summary>
        public decimal? discountMoney
        {
            set { _discountmoney = value; }
            get { return _discountmoney; }
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
        public decimal? leviedMoney
        {
            set { _leviedmoney = value; }
            get { return _leviedmoney; }
        }
        /// <summary>
        /// 成本单价
        /// </summary>
        public decimal? costPrice
        {
            set { _costprice = value; }
            get { return _costprice; }
        }
        /// <summary>
        /// 成本金额
        /// </summary>
        public decimal? costMoney
        {
            set { _costmoney = value; }
            get { return _costmoney; }
        }
        /// <summary>
        /// 退货数量
        /// </summary>
        public decimal? ReturnsNumber
        {
            set { _returnsnumber = value; }
            get { return _returnsnumber; }
        }
        /// <summary>
        /// 源单code
        /// </summary>
        public string sourceCode
        {
            set { _sourcecode = value; }
            get { return _sourcecode; }
        }
        #endregion Model

    }
}

