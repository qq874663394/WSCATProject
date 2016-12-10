
using System;
namespace Model
{
	/// <summary>
	/// 物料信息表
	/// </summary>
	[Serializable]
	public partial class BaseMaterial
	{
		public BaseMaterial()
		{}
		#region Model
		private int _id;
		private string _picname;
		private string _name;
		private string _model;
		private string _barcode;
		private string _code;
		private string _typeid;
		private string _typename;
		private decimal? _price=0M;
		private decimal? _peicea=0M;
		private decimal? _priceb=0M;
		private decimal? _pricec=0M;
		private decimal? _priced=0M;
		private decimal? _pricee=0M;
		private DateTime? _createdate= DateTime.Now;
		private string _suppliername;
		private string _suppliercode;
		private decimal? _number;
		private string _unit;
		private decimal? _inprice;
		private decimal? _outprice;
		private DateTime? _indate;
		private string _remark;
		private int? _isenable=1;
		private int? _isclear=1;
		private string _reserved1;
		private string _reserved2;
		private DateTime? _updatedate;
        private string _materialdaima;
        private DateTime? _productiondate;
        private DateTime? _qualitydate;
        private DateTime? _effectivedate;
        private int? _isassembly;
        /// <summary>
        /// 
        /// </summary>
        public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 物料图片名称
		/// </summary>
		public string picName
		{
			set{ _picname=value;}
			get{return _picname;}
		}
		/// <summary>
		/// 物料名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 规格型号
		/// </summary>
		public string model
		{
			set{ _model=value;}
			get{return _model;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string barCode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 物料编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 类别ID
		/// </summary>
		public string typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 类别名称
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 建议售价
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 售价A
		/// </summary>
		public decimal? peiceA
		{
			set{ _peicea=value;}
			get{return _peicea;}
		}
		/// <summary>
		/// 售价B
		/// </summary>
		public decimal? priceB
		{
			set{ _priceb=value;}
			get{return _priceb;}
		}
		/// <summary>
		/// 售价C
		/// </summary>
		public decimal? priceC
		{
			set{ _pricec=value;}
			get{return _pricec;}
		}
		/// <summary>
		/// D售价
		/// </summary>
		public decimal? priceD
		{
			set{ _priced=value;}
			get{return _priced;}
		}
		/// <summary>
		/// 售价E
		/// </summary>
		public decimal? priceE
		{
			set{ _pricee=value;}
			get{return _pricee;}
		}
		/// <summary>
		/// 生产日期
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 供应商
		/// </summary>
		public string supplierName
		{
			set{ _suppliername=value;}
			get{return _suppliername;}
		}
		/// <summary>
		/// 供应商编号
		/// </summary>
		public string supplierCode
		{
			set{ _suppliercode=value;}
			get{return _suppliercode;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public decimal? number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 进价
		/// </summary>
		public decimal? inPrice
		{
			set{ _inprice=value;}
			get{return _inprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? outPrice
		{
			set{ _outprice=value;}
			get{return _outprice;}
		}
		/// <summary>
		/// 进货时间
		/// </summary>
		public DateTime? inDate
		{
			set{ _indate=value;}
			get{return _indate;}
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
		/// 是否可用
		/// </summary>
		public int? isEnable
		{
			set{ _isenable=value;}
			get{return _isenable;}
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
		/// 预留字段1
		/// </summary>
		public string reserved1
		{
			set{ _reserved1=value;}
			get{return _reserved1;}
		}
		/// <summary>
		/// 保留字段2
		/// </summary>
		public string reserved2
		{
			set{ _reserved2=value;}
			get{return _reserved2;}
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
		/// 商品代码
		/// </summary>
		public string materialDaima
        {
            set { _materialdaima = value; }
            get { return _materialdaima; }
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
		public DateTime? qualityDate
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
        /// 是否可组装或拆卸
        /// </summary>
        public int? isAssembly
        {
            set { _isassembly = value; }
            get { return _isassembly; }
        }
        #endregion Model

    }
}

