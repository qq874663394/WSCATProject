
using System;
namespace Model
{
	/// <summary>
	/// 销售订单明细表
	/// </summary>
	[Serializable]
	public partial class WarehouseDetail
	{
		public WarehouseDetail()
		{}
		#region Model
		private int _id;
		private string _maincode;
		private string _code;
		private decimal? _number;
		private DateTime? _date;
		private string _location;
		private int? _isclear;
		private DateTime? _updatedate;
		private string _reserved1;
		private string _reserved2;
		private string _remark;
		/// <summary>
		/// 栏号(自增)
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 主表code
		/// </summary>
		public string mainCode
		{
			set{ _maincode=value;}
			get{return _maincode;}
		}
		/// <summary>
		/// 物料编码
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 物料规格型号
		/// </summary>
		public decimal? number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime? date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 货架位置
		/// </summary>
		public string location
		{
			set{ _location=value;}
			get{return _location;}
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
		public string Reserved1
		{
			set{ _reserved1=value;}
			get{return _reserved1;}
		}
		/// <summary>
		/// 保留字段2
		/// </summary>
		public string Reserved2
		{
			set{ _reserved2=value;}
			get{return _reserved2;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

