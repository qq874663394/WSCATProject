
using System;
namespace Model
{
	/// <summary>
	/// 仓库表
	/// </summary>
	[Serializable]
	public partial class BaseUser
	{
		public BaseUser()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _fingerprints;
		private string _name;
		private string _cardcode;
		private string _rolecode;
		private string _password;
		private int? _ismanager=0;
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
		/// 编码
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 指纹
		/// </summary>
		public string fingerprints
		{
			set{ _fingerprints=value;}
			get{return _fingerprints;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 卡号
		/// </summary>
		public string cardCode
		{
			set{ _cardcode=value;}
			get{return _cardcode;}
		}
		/// <summary>
		/// 权限的外键
		/// </summary>
		public string roleCode
		{
			set{ _rolecode=value;}
			get{return _rolecode;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string passWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 是否是管理员,0为不是,1为是
		/// </summary>
		public int? isManager
		{
			set{ _ismanager=value;}
			get{return _ismanager;}
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

