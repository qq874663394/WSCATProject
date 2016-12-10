
using System;
namespace Model
{
	/// <summary>
	/// 其他支出项目表
	/// </summary>
	[Serializable]
	public partial class BaseSalary
	{
		public BaseSalary()
		{}
		#region Model
		private int _id;
		private string _code;
		private decimal? _salarymoney;
		private string _reserved1;
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
		/// 类型编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 工资金额
		/// </summary>
		public decimal? salaryMoney
		{
			set{ _salarymoney=value;}
			get{return _salarymoney;}
		}
		/// <summary>
		/// 预留字段1
		/// </summary>
		public string Reserved1
		{
			set{ _reserved1=value;}
			get{return _reserved1;}
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

