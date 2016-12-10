
using System;
namespace Model
{
	/// <summary>
	/// 销售订单明细表
	/// </summary>
	[Serializable]
	public partial class WarehouseOutDetail
	{
		public WarehouseOutDetail()
		{}
		#region Model
		private string _code;
		private int _id;
		private string _materialcode;
		private string _materialname;
		private string _materialmodel;
		private string _materialunit;
		private decimal? _number;
		private decimal? _price;
		private decimal? _money;
		private string _barcode;
		private string _rfid;
		private DateTime? _updatedate;
		private int? _state;
		private DateTime? _date;
		private int? _isclear;
		private string _reserved1;
		private string _reserved2;
		private string _remark;
        private string _storageRackName;
        private string _storageRackCode;
        private string _mainCode;
        private int _isArrive;
        private string _warehouseCode;
        private string _warehouseName;
        private string _materialdaima;
        private DateTime? _productiondate;
        private decimal? _qualitydate;
        private DateTime? _effectivedate;
        /// <summary>
        /// 出库编号
        /// </summary>
        public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 物料code
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
			set{ _materialname = value;}
			get{return _materialname; }
		}
		/// <summary>
		/// 物料类型
		/// </summary>
		public string materialModel
        {
			set{ _materialmodel=value;}
			get{return _materialmodel; }
		}
		/// <summary>
		/// 物料单位
		/// </summary>
		public string materiaUnit
		{
			set{ _materialunit = value;}
			get{return _materialunit; }
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
		/// rfid
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
		/// 状态
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 出库时间
		/// </summary>
		public DateTime? date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 是否清除
		/// </summary>
		public int? isClear
		{
			set{ _isclear=value;}
			get{return _isclear;}
		}
		/// <summary>
		/// 备用字段1
		/// </summary>
		public string reserved1
		{
			set{ _reserved1=value;}
			get{return _reserved1;}
		}
		/// <summary>
		/// 备用字段2
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
        /// 货架名称
        /// </summary>
        public string StorageRackName
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
        public string StorageRackCode
        {
            get{ return _storageRackCode;}

            set{_storageRackCode = value; }
        }
        /// <summary>
        /// 主表code
        /// </summary>
        public string MainCode
        {
            get{ return _mainCode;}

            set{ _mainCode = value;}
        }
        /// <summary>
        /// 是否出库
        /// </summary>
        public int IsArrive
        {
            get{ return _isArrive; }

            set{ _isArrive = value;}
        }
        /// <summary>
        /// 仓库code
        /// </summary>
        public string WarehouseCode
        {
            get{ return _warehouseCode;}

            set
            { _warehouseCode = value;}
        }
        /// <summary>
        /// 仓库名
        /// </summary>
        public string WarehouseName
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
        #endregion Model

    }
}

