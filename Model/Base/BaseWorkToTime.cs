
using System;
namespace Model
{
	/// <summary>
	/// 上下班时刻表
	/// </summary>
	[Serializable]
	public partial class BaseWorkToTime
	{
		public BaseWorkToTime()
		{}
		#region Model
		private int _id;
		private string _code;
		private DateTime? _wokedate;
		private DateTime? _offdate;
		private DateTime? _allowlatedate;
		private DateTime? _allowleavedate;
		private decimal? _restdays;
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
		/// 编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 上班时刻
		/// </summary>
		public DateTime? wokeDate
		{
			set{ _wokedate=value;}
			get{return _wokedate;}
		}
		/// <summary>
		/// 下班时刻
		/// </summary>
		public DateTime? offDate
		{
			set{ _offdate=value;}
			get{return _offdate;}
		}
		/// <summary>
		/// 允许迟到分钟数
		/// </summary>
		public DateTime? allowLateDate
		{
			set{ _allowlatedate=value;}
			get{return _allowlatedate;}
		}
		/// <summary>
		/// 允许早退分钟数
		/// </summary>
		public DateTime? allowLeaveDate
		{
			set{ _allowleavedate=value;}
			get{return _allowleavedate;}
		}
		/// <summary>
		/// 每月休息天数
		/// </summary>
		public decimal? restDays
		{
			set{ _restdays=value;}
			get{return _restdays;}
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

