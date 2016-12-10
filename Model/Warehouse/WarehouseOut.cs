
using System;
namespace Model
{
	/// <summary>
	/// 销售订单明细表
	/// </summary>
	[Serializable]
	public partial class WarehouseOut
	{
		public WarehouseOut()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _type;
		private string _stock;
		private string _operation;
		private string _examine;
		private int? _isclear;
		private DateTime? _updatedate;
		private int? _state;
		private string _salescode;
		private DateTime? _date;
		private int? _checkstate;
		private string _remark;
		private string _reserved1;
		private string _reserved2;
        private string _delivery;
        private string _clientCode;
        private string _expressOdd;
        private string _expressMan;
        private string _expressPhone;
        private string _defaultType;
        private string _makeMan;
        private string _clientName;
        private string _salesPhone;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 出货单号（生成）
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 出货类型
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
		/// 出库员
		/// </summary>
		public string operation
		{
			set{ _operation=value;}
			get{return _operation;}
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
		/// 
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 销售单Code
		/// </summary>
		public string salesCode
		{
			set{ _salescode=value;}
			get{return _salescode;}
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
		/// 审核状态0、未审核，1、已审核
		/// </summary>
		public int? checkState
		{
			set{ _checkstate=value;}
			get{return _checkstate;}
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
        /// 配送方式
        /// </summary>
        public string delivery
        {
            get
            {
                return _delivery;
            }

            set
            {
                _delivery = value;
            }
        }
        /// <summary>
        /// 客户code
        /// </summary>
        public string clientCode
        {
            get
            {
                return _clientCode;
            }

            set
            {
                _clientCode = value;
            }
        }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string expressOdd
        {
            get
            {
                return _expressOdd;
            }

            set
            {
                _expressOdd = value;
            }
        }
        /// <summary>
        /// 快递员
        /// </summary>
        public string expressMan
        {
            get
            {
                return _expressMan;
            }

            set
            {
                _expressMan = value;
            }
        }
        /// <summary>
        /// 快递电话
        /// </summary>
        public string expressPhone
        {
            get
            {
                return _expressPhone;
            }

            set
            {
                _expressPhone = value;
            }
        }
        /// <summary>
        /// 默认类型
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
        /// 操作员
        /// </summary>
        public string MakeMan
        {
            get
            {
                return _makeMan;
            }

            set
            {
                _makeMan = value;
            }
        }
        /// <summary>
        /// 客户Name
        /// </summary>
        public string ClientName
        {
            get{return _clientName; }
            set {_clientName = value;}
        }
        /// <summary>
        /// 销售电话
        /// </summary>
        public string SalesPhone
        {
            get { return _salesPhone;}
            set{ _salesPhone = value;}
        }
        #endregion Model

    }
}

