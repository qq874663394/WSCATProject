
using System;
namespace Model
{
	/// <summary>
	/// 仓库表
	/// </summary>
	[Serializable]
	public partial class BaseSupplier
	{
		public BaseSupplier()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _phone;
		private string _address;
		private string _fax;
		private string _email;
		private string _bankcard;
		private string _openbank;
		private string _industryinvolved;
		private string _industrycode;
		private int? _creditrank;
		private decimal _availablebalance=0M;
		private decimal _balance=0M;
		private DateTime? _statementdate= Convert.ToDateTime(0);
		private string _linkman;
		private string _mobilephone;
		private string _remark;
		private int? _isenable=1;
		private int? _isclear=1;
		private string _reserved1;
		private string _reserved2;
		private string _code;
		private string _cityname;
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
		/// 供应商名
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
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
		/// 传真
		/// </summary>
		public string fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 银行卡号
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
		/// 所属行业
		/// </summary>
		public string industryInvolved
		{
			set{ _industryinvolved=value;}
			get{return _industryinvolved;}
		}
		/// <summary>
		/// 行业类别ID
		/// </summary>
		public string industryCode
		{
			set{ _industrycode=value;}
			get{return _industrycode;}
		}
		/// <summary>
		/// 信用等级
		/// </summary>
		public int? creditRank
		{
			set{ _creditrank=value;}
			get{return _creditrank;}
		}
		/// <summary>
		/// 账款额度
		/// </summary>
		public decimal availableBalance
		{
			set{ _availablebalance=value;}
			get{return _availablebalance;}
		}
		/// <summary>
		/// 剩余额度
		/// </summary>
		public decimal balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		/// 月结日
		/// </summary>
		public DateTime? statementDate
		{
			set{ _statementdate=value;}
			get{return _statementdate;}
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
		/// 联系人移动电话
		/// </summary>
		public string mobilePhone
		{
			set{ _mobilephone=value;}
			get{return _mobilephone;}
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
		/// 预留字段2
		/// </summary>
		public string reserved2
		{
			set{ _reserved2=value;}
			get{return _reserved2;}
		}
		/// <summary>
		/// 供应商编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 地区
		/// </summary>
		public string cityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
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

