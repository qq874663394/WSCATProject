
using System;
namespace Model
{
	/// <summary>
	/// 单据类型表
	/// </summary>
	[Serializable]
	public partial class BasePermission
	{
		public BasePermission()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _modulename;
		private int? _readstate;
		private int? _writestate;
		private int? _checkstate;
		private int? _isclear;
		private string _type;
		private string _rolecode;
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
		/// 编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 模块名称
		/// </summary>
		public string moduleName
		{
			set{ _modulename=value;}
			get{return _modulename;}
		}
		/// <summary>
		/// 读取权限状态
		/// </summary>
		public int? readState
		{
			set{ _readstate=value;}
			get{return _readstate;}
		}
		/// <summary>
		/// 写入权限状态
		/// </summary>
		public int? writeState
		{
			set{ _writestate=value;}
			get{return _writestate;}
		}
		/// <summary>
		/// 审核权限状态
		/// </summary>
		public int? checkState
		{
			set{ _checkstate=value;}
			get{return _checkstate;}
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
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string roleCode
		{
			set{ _rolecode=value;}
			get{return _rolecode;}
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

