
using System;
namespace Model
{
	/// <summary>
	/// 上下班时刻表
	/// </summary>
	[Serializable]
	public partial class FinanceEmbezzlementDetail
	{
		public FinanceEmbezzlementDetail()
		{}
		#region Model
		private int _id;
		private string _embezzlementcode;
		private string _detail;
		private decimal? _money;
		private string _remark;
		private string _reserved1;
		private string _reserved2;
		private DateTime? _updatedate;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 挪用主表编号
		/// </summary>
		public string embezzlementCode
		{
			set{ _embezzlementcode=value;}
			get{return _embezzlementcode;}
		}
		/// <summary>
		/// 详细说明
		/// </summary>
		public string detail
		{
			set{ _detail=value;}
			get{return _detail;}
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
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Reserved1
		{
			set{ _reserved1=value;}
			get{return _reserved1;}
		}
		/// <summary>
		/// 保留字段1
		/// </summary>
		public string Reserved2
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
		#endregion Model

	}
}

