
using System;
namespace Model
{
	/// <summary>
	/// 借款类型表
	/// </summary>
	[Serializable]
	public partial class BaseBorrow
	{
		public BaseBorrow()
		{}
		#region Model
		private int _id;
		private string _name;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
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

