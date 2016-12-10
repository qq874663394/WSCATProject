
using System;
namespace Model
{
	/// <summary>
	/// 客户类别表
	/// </summary>
	[Serializable]
	public partial class BaseClientType
	{
		public BaseClientType()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
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
		/// 类型编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
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
		/// 类别备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 预留1
		/// </summary>
		public string reserved1
		{
			set{ _reserved1=value;}
			get{return _reserved1;}
		}
		/// <summary>
		/// 预留2
		/// </summary>
		public string reserved2
		{
			set{ _reserved2=value;}
			get{return _reserved2;}
		}
		/// <summary>
		/// 0为删除1为保留
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

