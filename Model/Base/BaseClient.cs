
using System;
namespace Model
{
	/// <summary>
	/// 客户表
	/// </summary>
	[Serializable]
	public partial class BaseClient
	{
		public BaseClient()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _fingerprints;
		private string _name;
		private string _picname;
		private string _mobilephone;
		private string _fixedphone;
		private string _fax;
		private string _citycode;
		private string _cityname;
		private string _address;
		private string _linkman;
		private string _companyname;
		private string _typecode;
		private string _typename;
		private string _discountcode;
		private string _bankcard;
		private string _openbank;
		private DateTime? _initialsalestime;
		private DateTime? _initialreturntime;
		private DateTime? _lastreturntime;
		private DateTime? _lastsalestime;
		private DateTime? _createtime= DateTime.Now;
		private decimal? _availablebalance;
		private decimal? _balance;
		private DateTime? _statementdate;
		private decimal? _receivables;
		private decimal? _moneyreceipt;
		private decimal? _advancereceipts;
		private string _remark;
		private string _reserved1;
		private string _reserved2;
		private int? _enable=1;
		private DateTime? _updatedate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 客户编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 指纹
		/// </summary>
		public string fingerPrints
		{
			set{ _fingerprints=value;}
			get{return _fingerprints;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 图片名称
		/// </summary>
		public string picName
		{
			set{ _picname=value;}
			get{return _picname;}
		}
		/// <summary>
		/// 手机
		/// </summary>
		public string mobilePhone
		{
			set{ _mobilephone=value;}
			get{return _mobilephone;}
		}
		/// <summary>
		/// 座机号码
		/// </summary>
		public string fixedPhone
		{
			set{ _fixedphone=value;}
			get{return _fixedphone;}
		}
		/// <summary>
		/// 传真
		/// </summary>
		public string fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 地区编号
		/// </summary>
		public string cityCode
		{
			set{ _citycode=value;}
			get{return _citycode;}
		}
		/// <summary>
		/// 地区，用/划分级
		/// </summary>
		public string cityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
		}
		/// <summary>
		/// 地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string linkMan
		{
			set{ _linkman=value;}
			get{return _linkman;}
		}
		/// <summary>
		/// 单位名
		/// </summary>
		public string companyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 客户类别编码
		/// </summary>
		public string typeCode
		{
			set{ _typecode=value;}
			get{return _typecode;}
		}
		/// <summary>
		/// 客户类别名称
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 折扣ID
		/// </summary>
		public string discountCode
		{
			set{ _discountcode=value;}
			get{return _discountcode;}
		}
		/// <summary>
		/// 银行帐号
		/// </summary>
		public string bankCard
		{
			set{ _bankcard=value;}
			get{return _bankcard;}
		}
		/// <summary>
		/// 开户行
		/// </summary>
		public string openBank
		{
			set{ _openbank=value;}
			get{return _openbank;}
		}
		/// <summary>
		/// 最初销售时间
		/// </summary>
		public DateTime? initialSalesTime
		{
			set{ _initialsalestime=value;}
			get{return _initialsalestime;}
		}
		/// <summary>
		/// 最初退货时间
		/// </summary>
		public DateTime? initialReturnTime
		{
			set{ _initialreturntime=value;}
			get{return _initialreturntime;}
		}
		/// <summary>
		/// 最后退货时间
		/// </summary>
		public DateTime? lastReturnTime
		{
			set{ _lastreturntime=value;}
			get{return _lastreturntime;}
		}
		/// <summary>
		/// 最后销售时间
		/// </summary>
		public DateTime? lastSalesTime
		{
			set{ _lastsalestime=value;}
			get{return _lastsalestime;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 可用额度
		/// </summary>
		public decimal? availableBalance
		{
			set{ _availablebalance=value;}
			get{return _availablebalance;}
		}
		/// <summary>
		/// 剩余额度
		/// </summary>
		public decimal? balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		/// 结账日期
		/// </summary>
		public DateTime? statementDate
		{
			set{ _statementdate=value;}
			get{return _statementdate;}
		}
		/// <summary>
		/// 应收款
		/// </summary>
		public decimal? receivables
		{
			set{ _receivables=value;}
			get{return _receivables;}
		}
		/// <summary>
		/// 已收款
		/// </summary>
		public decimal? moneyReceipt
		{
			set{ _moneyreceipt=value;}
			get{return _moneyreceipt;}
		}
		/// <summary>
		/// 预收款
		/// </summary>
		public decimal? advanceReceipts
		{
			set{ _advancereceipts=value;}
			get{return _advancereceipts;}
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
		/// 是否删除,0为删除1为保留
		/// </summary>
		public int? enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		/// <summary>
		/// 更改时间
		/// </summary>
		public DateTime? updateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model

	}
}

