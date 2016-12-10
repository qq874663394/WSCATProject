using System;
namespace Model
{
	/// <summary>
	/// T_WarehouseInDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WarehouseInDetail
	{
		public WarehouseInDetail()
		{}
		#region Model
		private int _id;
		private string _code;
        private string _zhujima;
        private string _materianame;
		private string _materiamodel;
		private string _materiaunit;
		private decimal? _number;
		private decimal? _price;
		private decimal? _money;
		private string _barcode;
		private string _rfid;
		private DateTime? _updatedate;
		private int? _state;
		private DateTime? _date;
		private int? _isclear;
		private string _remark;
		private string _reserved1;
		private string _reserved2;
        private string _storageRackName;
        private string _storageRackCode;
        private int? _isArrive;
        private string _warehouseCode;
        private string _warehouseName;
        private string _mainCode;
        private string _materialdaima;
        private DateTime? _productiondate;
        private Double? _qualitydate;
        private DateTime? _effectivedate;
        /// <summary>
        /// 栏号(自增)
        /// </summary>
        public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 入库单号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
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
        /// 物料名称
        /// </summary>
        public string materiaName
		{
			set{ _materianame=value;}
			get{return _materianame;}
		}
		/// <summary>
		/// 规格型号
		/// </summary>
		public string materiaModel
		{
			set{ _materiamodel=value;}
			get{return _materiamodel;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string materiaUnit
		{
			set{ _materiaunit=value;}
			get{return _materiaunit;}
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
		/// 单价
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 金额
		/// </summary>
		public decimal? money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 条码
		/// </summary>
		public string barcode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// RFID
		/// </summary>
		public string rfid
		{
			set{ _rfid=value;}
			get{return _rfid;}
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
		/// 
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 入库时间
		/// </summary>
		public DateTime? date
		{
			set{ _date=value;}
			get{return _date;}
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
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 保留字段1
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
        /// 货架名称
        /// </summary>
        public string storageRackName
        {
            get
            {
                return _storageRackName;
            }

            set
            {
                _storageRackName = value;
            }
        }
        /// <summary>
        /// 货架code
        /// </summary>
        public string storageRackCode
        {
            get
            {
                return _storageRackCode;
            }

            set
            {
                _storageRackCode = value;
            }
        }
        /// <summary>
        /// 货物是否抵达
        /// </summary>
        public int? isArrive
        {
            get
            {
                return _isArrive;
            }

            set
            {
                _isArrive = value;
            }
        }
        /// <summary>
        /// 仓库code
        /// </summary>
        public string warehouseCode
        {
            get
            {
                return _warehouseCode;
            }

            set
            {
                _warehouseCode = value;
            }
        }
        /// <summary>
        /// 仓库name
        /// </summary>
        public string warehouseName
        {
            get
            {
                return _warehouseName;
            }

            set
            {
                _warehouseName = value;
            }
        }
        /// <summary>
        /// 主表code
        /// </summary>
        public string mainCode
        {
            get
            {
                return _mainCode;
            }

            set
            {
                _mainCode = value;
            }
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
		public Double? qualityDate
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
        #endregion Model

    }
}

