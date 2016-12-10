
using System;
namespace Model
{
	/// <summary>
	/// 销售订单明细表
	/// </summary>
	[Serializable]
	public partial class WarehouseInventoryDetail
	{
		public WarehouseInventoryDetail()
		{}
		#region Model
		private string _code;
		private int _id;
		private string _materialcode;
		private string _materialname;
		private string _materialmodel;
		private string _materialunit;
		private decimal? _curnumber;
		private decimal? _checknumber;
        private decimal? _profitnumber;
		private decimal? _lossnumber;
		private decimal? _price;
		private decimal? _lossmoney;
        private decimal? _profitmoney;
		private string _cause;
		private int? _isclear=1;
		private DateTime? _updatedate;
		private string _reserved1;
		private string _reserved2;
		private string _remark;
        private string _stockcode;
        private string _stockname;
        private string _materiadaima;
        private string _barcode;
        private DateTime? _productiondate;
        private decimal? _qualitydate;
        private DateTime? _effectivedate;
        private string _maincode;
        /// <summary>
        /// 盘点编号
        /// </summary>
        public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 栏号(自增)
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 物料ID
		/// </summary>
		public string materialCode
		{
			set{ _materialcode=value;}
			get{return _materialcode;}
		}
		/// <summary>
		/// 物料名称
		/// </summary>
		public string materialName
		{
			set{ _materialname=value;}
			get{return _materialname;}
		}
		/// <summary>
		/// 规格型号
		/// </summary>
		public string materialModel
		{
			set{ _materialmodel=value;}
			get{return _materialmodel;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string materialUnit
		{
			set{ _materialunit=value;}
			get{return _materialunit;}
		}
		/// <summary>
		/// 账面数量
		/// </summary>
		public decimal? curNumber
		{
			set{ _curnumber=value;}
			get{return _curnumber;}
		}
		/// <summary>
		/// 盘点数量
		/// </summary>
		public decimal? checkNumber
		{
			set{ _checknumber=value;}
			get{return _checknumber;}
		}
        /// <summary>
        /// 盘盈数量
        /// </summary>
        public decimal? profitNumber
        {
            set { _profitnumber = value; }
            get { return _profitnumber; }
        }
        /// <summary>
        /// 盘亏数量
        /// </summary>
        public decimal? lossNumber
		{
			set{ _lossnumber=value;}
			get{return _lossnumber;}
		}
		/// <summary>
		/// 单价
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
        /// <summary>
		/// 盘盈金额
		/// </summary>
		public decimal? profitMoney
        {
            set { _profitmoney = value; }
            get { return _profitmoney; }
        }
        /// <summary>
        /// 盘亏金额
        /// </summary>
        public decimal? lossMoney
		{
			set{ _lossmoney=value;}
			get{return _lossmoney;}
		}
		/// <summary>
		/// 原因
		/// </summary>
		public string cause
		{
			set{ _cause=value;}
			get{return _cause;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? isClear
		{
			set{ _isclear=value;}
			get{return _isclear;}
		}
		/// <summary>
		/// 更改时间
		/// </summary>
		public DateTime? updateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		/// <summary>
		/// 预留字段1
		/// </summary>
		public string reserved1
		{
			set{ _reserved1=value;}
			get{return _reserved1;}
		}
		/// <summary>
		/// 预留字段2
		/// </summary>
		public string reserved2
		{
			set{ _reserved2=value;}
			get{return _reserved2;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}

        /// <summary>
		/// 仓库
		/// </summary>
		public string stockCode
        {
            set { _stockcode = value; }
            get { return _stockcode; }
        }
        /// <summary>
		/// 仓库名称
		/// </summary>
		public string stockName
        {
            set { _stockname = value; }
            get { return _stockname; }
        }
        /// <summary>
		/// 物料代码
		/// </summary>
		public string materialDaima
        {
            set { _materiadaima = value; }
            get { return _materiadaima; }
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
		/// 生产日期
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
            set {  _qualitydate= value; }
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
        /// 主表code
        /// </summary>
        public string  mainCode
        {
            set { _maincode = value; }
            get { return _maincode; }
        }
        #endregion Model

    }
}

