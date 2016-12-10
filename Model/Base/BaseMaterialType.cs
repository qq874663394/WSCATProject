
using System;
namespace Model
{
	/// <summary>
	/// 物料类别表
	/// </summary>
	[Serializable]
	public partial class BaseMaterialType
	{
		public BaseMaterialType()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _parentid;
		private int? _isenable=1;
		private int? _isclear=1;
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
		/// 类别编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 类别名
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 父级编号
		/// </summary>
		public string parentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 是否启用
		/// </summary>
		public int? isEnable
		{
			set{ _isenable=value;}
			get{return _isenable;}
		}
		/// <summary>
		/// 是否删除
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

