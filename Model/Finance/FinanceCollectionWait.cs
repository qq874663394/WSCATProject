﻿
using System;
namespace Model
{
	/// <summary>
	/// 上下班时刻表
	/// </summary>
	[Serializable]
	public partial class FinanceCollectionWait
	{
		public FinanceCollectionWait()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _clientcode;
		private string _clientname;
		private string _accountcode;
		private string _salecode;
		private string _salesman;
		private string _operationman;
		private string _checkman;
		private DateTime? _date;
		private string _remark;
		private int? _checkstate;
		private string _reserved1;
		private string _reserved2;
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
		/// 待收款单单号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 客户编号
		/// </summary>
		public string clientCode
		{
			set{ _clientcode=value;}
			get{return _clientcode;}
		}
		/// <summary>
		/// 客户名称
		/// </summary>
		public string clientName
		{
			set{ _clientname=value;}
			get{return _clientname;}
		}
		/// <summary>
		/// 账户编号
		/// </summary>
		public string accountCode
		{
			set{ _accountcode=value;}
			get{return _accountcode;}
		}
		/// <summary>
		/// 所属销售单编号
		/// </summary>
		public string saleCode
		{
			set{ _salecode=value;}
			get{return _salecode;}
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
		/// 日期
		/// </summary>
		public DateTime? date
		{
			set{ _date=value;}
			get{return _date;}
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
		/// 审核状态  0 未审核  1 已审核
		/// </summary>
		public int? checkState
		{
			set{ _checkstate=value;}
			get{return _checkstate;}
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
		/// 是否删除  0 删除   1保留
		/// </summary>
		public int? isClear
		{
			set{ _isclear=value;}
			get{return _isclear;}
		}
		/// <summary>
		/// 更改时间
		/// </summary>
		public DateTime? updatedate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model

	}
}

