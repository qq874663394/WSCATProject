
using System;
namespace Model
{
	/// <summary>
	/// 仓库表
	/// </summary>
	[Serializable]
	public partial class BaseStorage
	{
		public BaseStorage()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _empname;
		private string _phone;
		private string _address;
		private int? _isenable=1;
		private int? _isclear=1;
		private string _remark;
		private string _reserved1;
		private string _reserved2;
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
		/// 仓库编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 仓库名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string empName
		{
			set{ _empname=value;}
			get{return _empname;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 仓库地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
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
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 保留字段1
		/// </summary>
		public string reserved1
		{
			set{ _reserved1=value;}
			get{return _reserved1;}
		}
		/// <summary>
		/// 保留字段2
		/// </summary>
		public string reserved2
		{
			set{ _reserved2=value;}
			get{return _reserved2;}
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

