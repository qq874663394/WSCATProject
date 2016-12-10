
using System;
namespace Model
{
	/// <summary>
	/// 上下班时刻表
	/// </summary>
	[Serializable]
	public partial class PurchaseProcess
	{
		public PurchaseProcess()
		{}
		#region Model
		private int _id;
		private int? _isclear;
		private string _code;
		private string _purchasedetailcode;
		private DateTime? _createdatetime;
		private string _operator;
		private string _operatorman;
		private string _remark;
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
		/// 
		/// </summary>
		public int? isClear
		{
			set{ _isclear=value;}
			get{return _isclear;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string purchaseDetailCode
		{
			set{ _purchasedetailcode=value;}
			get{return _purchasedetailcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createDatetime
		{
			set{ _createdatetime=value;}
			get{return _createdatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Operator
		{
			set{ _operator=value;}
			get{return _operator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string operatorMan
		{
			set{ _operatorman=value;}
			get{return _operatorman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
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

