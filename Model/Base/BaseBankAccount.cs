
using System;
namespace Model
{
	/// <summary>
	/// 账户表
	/// </summary>
	[Serializable]
	public partial class BaseBankAccount
	{
		public BaseBankAccount()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _openbank;
		private string _bankcard;
		private string _cardholder;
		private string _remark;
		private decimal? _availablebalance;
		private int? _isenable=1;
		private int? _isclear=1;
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
		/// 账户编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
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
		/// 银行账户
		/// </summary>
		public string bankCard
		{
			set{ _bankcard=value;}
			get{return _bankcard;}
		}
		/// <summary>
		/// 持卡人
		/// </summary>
		public string cardHolder
		{
			set{ _cardholder=value;}
			get{return _cardholder;}
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
		/// 可用金额
		/// </summary>
		public decimal? availableBalance
		{
			set{ _availablebalance=value;}
			get{return _availablebalance;}
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

