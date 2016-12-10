using System;
namespace Model
{
	/// <summary>
	/// T_WarehouseIn:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WarehouseIn
	{
		public WarehouseIn()
		{}
		#region Model
		private int _id=0;
		private string _code;
		private string _type;
		private string _stock;
		private string _operation;
        private string _makeman;
		private string _examine;
		private int? _state;
		private DateTime? _date;
		private string _purchasecode;
		private int? _checkstate;
		private int? _isclear;
		private DateTime? _updatedate;
		private string _reserved1;
		private string _reserved2;
		private string _remark;
        private string _goodsCode;
        private string _defaultType;
        private string _suppliercode;
        private string _suppliername;
        private string _supplierphone;
        /// <summary>
        /// 自增ID 
        /// </summary>
        public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 入货单号(生成)
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 入货类型
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 仓库
		/// </summary>
		public string stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
		/// 入库员
		/// </summary>
		public string operation
		{
			set{ _operation=value;}
			get{return _operation;}
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
        /// 审查人
        /// </summary>
        public string examine
		{
			set{ _examine=value;}
			get{return _examine;}
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
		/// 开单时间
		/// </summary>
		public DateTime? date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 采购单Code
		/// </summary>
		public string purchaseCode
		{
			set{ _purchasecode=value;}
			get{return _purchasecode;}
		}
		/// <summary>
		/// 审核状态 0、未审核，1、已审核
		/// </summary>
		public int? checkState
		{
			set{ _checkstate=value;}
			get{return _checkstate;}
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
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
        /// <summary>
        /// 供应商单据code
        /// </summary>
        public string goodsCode
        {
            get
            {
                return _goodsCode;
            }

            set
            {
                _goodsCode = value;
            }
        }
        /// <summary>
        /// 默认单据类型
        /// </summary>
        public string defaultType
        {
            get
            {
                return _defaultType;
            }

            set
            {
                _defaultType = value;
            }
        }

        /// <summary>
        /// 供应商code
        /// </summary>
        public string supplierCode
        {
            get
            {
                return _suppliercode;
            }

            set
            {
                _suppliercode = value;
            }
        }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string supplierName
        {
            get
            {
                return _suppliername;
            }

            set
            {
                _suppliername = value;
            }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string supplierPhone
        {
            get
            {
                return _supplierphone;
            }

            set
            {
                _supplierphone = value;
            }
        }
        #endregion Model

    }
}

