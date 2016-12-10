
using System;
namespace Model
{
	/// <summary>
	/// 上下班时刻表
	/// </summary>
	[Serializable]
	public partial class SalesCancel
	{
		public SalesCancel()
		{}
		#region Model
		private int _id;
		private int? _isclear=1;
		private string _code;
		private string _clientcode;
		private string _clientname;
		private string _clientphone;
		private DateTime? _returndate= DateTime.Now;
		private string _salesmancode;
		private string _salesmanname;
		private int? _enable=1;
		private int? _againinstorage;
		private string _operationman;
		private string _checkedman;
		private DateTime? _updatedate;
		private string _remark;
		private string _satetyone;
		private string _satetytwo;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
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
		/// 退货编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 客户ID，散客选择散客ID
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
		/// 客户电话
		/// </summary>
		public string clientPhone
		{
			set{ _clientphone=value;}
			get{return _clientphone;}
		}
		/// <summary>
		/// 退货时间
		/// </summary>
		public DateTime? returnDate
		{
			set{ _returndate=value;}
			get{return _returndate;}
		}
		/// <summary>
		/// 业务员编号
		/// </summary>
		public string salesManCode
		{
			set{ _salesmancode=value;}
			get{return _salesmancode;}
		}
		/// <summary>
		/// 业务员姓名
		/// </summary>
		public string salesManName
		{
			set{ _salesmanname=value;}
			get{return _salesmanname;}
		}
		/// <summary>
		/// 是否已审核
		/// </summary>
		public int? enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		/// <summary>
		/// 是否重新入库
		/// </summary>
		public int? againInStorage
		{
			set{ _againinstorage=value;}
			get{return _againinstorage;}
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
		public string checkedMan
		{
			set{ _checkedman=value;}
			get{return _checkedman;}
		}
		/// <summary>
		/// 更改时间
		/// </summary>
		public DateTime? updateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
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
		public string satetyone
		{
			set{ _satetyone=value;}
			get{return _satetyone;}
		}
		/// <summary>
		/// 保留字段2
		/// </summary>
		public string satetytwo
		{
			set{ _satetytwo=value;}
			get{return _satetytwo;}
		}
		#endregion Model

	}
}

