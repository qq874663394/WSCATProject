
using System;
namespace Model
{
	/// <summary>
	/// 上下班时刻表
	/// </summary>
	[Serializable]
	public partial class FinanceEmbezzlement
	{
		public FinanceEmbezzlement()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _borrowtype;
		private string _accountcode;
		private string _employeecode;
		private string _employeename;
		private string _operationman;
		private string _checkman;
		private string _salesman;
		private DateTime? _date= DateTime.Now;
		private string _remark;
		private string _reserved1;
		private string _reserved2;
		private int? _isclear=1;
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
		/// 挪用单号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 借款类型
		/// </summary>
		public string borrowType
		{
			set{ _borrowtype=value;}
			get{return _borrowtype;}
		}
		/// <summary>
		/// 结算账户编码
		/// </summary>
		public string accountCode
		{
			set{ _accountcode=value;}
			get{return _accountcode;}
		}
		/// <summary>
		/// 员工工号
		/// </summary>
		public string employeeCode
		{
			set{ _employeecode=value;}
			get{return _employeecode;}
		}
		/// <summary>
		/// 员工名
		/// </summary>
		public string employeeName
		{
			set{ _employeename=value;}
			get{return _employeename;}
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public string operationMan
		{
			set{ _operationman=value;}
			get{return _operationman;}
		}
		/// <summary>
		/// 审核人
		/// </summary>
		public string checkMan
		{
			set{ _checkman=value;}
			get{return _checkman;}
		}
		/// <summary>
		/// 开单业务员
		/// </summary>
		public string salesMan
		{
			set{ _salesman=value;}
			get{return _salesman;}
		}
		/// <summary>
		/// 日期
		/// </summary>
		public DateTime? date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 摘要
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 预留字段1
		/// </summary>
		public string Reserved1
		{
			set{ _reserved1=value;}
			get{return _reserved1;}
		}
		/// <summary>
		/// 预留字段2
		/// </summary>
		public string Reserved2
		{
			set{ _reserved2=value;}
			get{return _reserved2;}
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

