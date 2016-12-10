
using System;
namespace Model
{
	/// <summary>
	/// 其他支出项目表
	/// </summary>
	[Serializable]
	public partial class BaseProjectInCost
	{
		public BaseProjectInCost()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _parentid;
		private int? _isenable;
		private int? _isclear;
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
		/// 类型编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 项目1
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 项目2
		/// </summary>
		public string parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 项目3
		/// </summary>
		public int? isEnable
		{
			set{ _isenable=value;}
			get{return _isenable;}
		}
		/// <summary>
		/// 项目4
		/// </summary>
		public int? isClear
		{
			set{ _isclear=value;}
			get{return _isclear;}
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

