
using System;
namespace Model
{
	/// <summary>
	/// 人员资料表
	/// </summary>
	[Serializable]
	public partial class BaseEmpolyee
	{
		public BaseEmpolyee()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _password;
		private string _rolecode;
		private string _citycode;
		private string _cityname;
		private string _fingerprints;
		private string _cardcode;
		private string _departmentcode;
		private string _sex="男";
		private string _identitycard;
		private string _jobstatus;
		private string _phone;
		private string _bankcard;
		private string _openbank;
		private DateTime? _birthday;
		private string _email;
		private string _education;
		private string _school;
		private DateTime? _entrytime= DateTime.Now;
		private string _reserved1;
		private string _reserved2;
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
		/// 工号
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
		/// 登陆密码
		/// </summary>
		public string passWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 角色的外键
		/// </summary>
		public string roleCode
		{
			set{ _rolecode=value;}
			get{return _rolecode;}
		}
		/// <summary>
		/// 所属地区
		/// </summary>
		public string cityCode
		{
			set{ _citycode=value;}
			get{return _citycode;}
		}
		/// <summary>
		/// 地区，用/划分级
		/// </summary>
		public string cityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
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
		/// 卡号
		/// </summary>
		public string cardCode
		{
			set{ _cardcode=value;}
			get{return _cardcode;}
		}
		/// <summary>
		/// 部门编号
		/// </summary>
		public string departmentCode
		{
			set{ _departmentcode=value;}
			get{return _departmentcode;}
		}
		/// <summary>
		/// 默认男
		/// </summary>
		public string sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 身份证号
		/// </summary>
		public string identityCard
		{
			set{ _identitycard=value;}
			get{return _identitycard;}
		}
		/// <summary>
		/// 就职状态
		/// </summary>
		public string jobStatus
		{
			set{ _jobstatus=value;}
			get{return _jobstatus;}
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
		/// 银行卡号
		/// </summary>
		public string bankCard
		{
			set{ _bankcard=value;}
			get{return _bankcard;}
		}
		/// <summary>
		/// 开户行
		/// </summary>
		public string openBank
		{
			set{ _openbank=value;}
			get{return _openbank;}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime? birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 最高学历
		/// </summary>
		public string education
		{
			set{ _education=value;}
			get{return _education;}
		}
		/// <summary>
		/// 毕业学校
		/// </summary>
		public string school
		{
			set{ _school=value;}
			get{return _school;}
		}
		/// <summary>
		/// 入职时间,默认为创建时间
		/// </summary>
		public DateTime? entryTime
		{
			set{ _entrytime=value;}
			get{return _entrytime;}
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
		/// 0为启用，1为禁用
		/// </summary>
		public int? isEnable
		{
			set{ _isenable=value;}
			get{return _isenable;}
		}
		/// <summary>
		/// 0为删除，1为保留
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

