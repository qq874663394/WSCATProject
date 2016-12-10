
using System;
namespace Model
{
	/// <summary>
	/// 单据类型表
	/// </summary>
	[Serializable]
	public partial class BaseOrderType
	{
		public BaseOrderType()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _code;
		private DateTime? _updatedate;
		/// <summary>
		/// 类型ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
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

