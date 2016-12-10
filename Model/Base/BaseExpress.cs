
using System;
namespace Model
{
	/// <summary>
	/// 人员资料表
	/// </summary>
	[Serializable]
	public partial class BaseExpress
	{
		public BaseExpress()
		{}
		#region Model
		private int? _id;
		private string _code;
		private string _name;
		/// <summary>
		/// 
		/// </summary>
		public int? id
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
		/// 名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

