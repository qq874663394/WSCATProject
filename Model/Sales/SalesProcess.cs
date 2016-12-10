
using System;
namespace Model
{
	/// <summary>
	/// 销售订单明细表
	/// </summary>
	[Serializable]
	public partial class SalesProcess
	{
		public SalesProcess()
		{}
		#region Model
		private int _id;
		private int? _isclear;
		private string _code;
		private string _salesdetailcode;
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
		/// 是否清除
		/// </summary>
		public int? isClear
		{
			set{ _isclear=value;}
			get{return _isclear;}
		}
		/// <summary>
		/// 主表code
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 订单明细表code
		/// </summary>
		public string salesDetailCode
		{
			set{ _salesdetailcode=value;}
			get{return _salesdetailcode;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? createDatetime
		{
			set{ _createdatetime=value;}
			get{return _createdatetime;}
		}
		/// <summary>
		/// 所做操作
		/// </summary>
		public string Operator
		{
			set{ _operator=value;}
			get{return _operator;}
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public string operatorMan
		{
			set{ _operatorman=value;}
			get{return _operatorman;}
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

