
using System;
namespace Model
{
	/// <summary>
	/// 销售订单明细表
	/// </summary>
	[Serializable]
	public partial class WarehouseInventory
	{
		public WarehouseInventory()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _stockcode;
		private string _stockname;
		private DateTime? _date;
		private string _operationman;
		private string _checkman;
		private string _remark;
		private int? _isclear;
		private DateTime? _updatedate;
		private string _reserved1;
		private string _reserved2;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 盘点单号（生成）
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 仓库编号
		/// </summary>
		public string stockcode
		{
			set{ _stockcode=value;}
			get{return _stockcode;}
		}
		/// <summary>
		/// 仓库名称
		/// </summary>
		public string stockName
		{
			set{ _stockname=value;}
			get{return _stockname;}
		}
		/// <summary>
		/// 盘点日期
		/// </summary>
		public DateTime? date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 盘点人
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
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
		#endregion Model

	}
}

