
using System;
namespace Model
{
	/// <summary>
	/// 其他支出项目表
	/// </summary>
	[Serializable]
	public partial class BaseRole
	{
		public BaseRole()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _modules;
		private DateTime? _updatedate;
		/// <summary>
		/// 自增列
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色编码
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 角色名
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 能操作的模块，每个模块之间用逗号分割
		/// </summary>
		public string modules
		{
			set{ _modules=value;}
			get{return _modules;}
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

