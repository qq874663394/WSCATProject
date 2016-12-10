
using System;
namespace Model
{
	/// <summary>
	/// 退货明细表
	/// </summary>
	[Serializable]
	public partial class SalesCancelDetail
	{
		public SalesCancelDetail()
		{}
		#region Model
		private int _id;
		private int? _isclear=1;
		private string _code;
		private string _salescancelcode;
		private string _materialcode;
		private string _materianame;
		private string _materialmodel;
		private string _unit;
		private decimal? _number;
		private decimal? _discountafterprice;
		private decimal? _discount;
		private decimal? _discountbeforeprice;
		private decimal? _money;
		private DateTime? _updatedate;
		private string _remark;
		private string _reserved1;
		private string _reserved2;
		/// <summary>
		/// 栏号(自增)
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
		/// 主表编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string salesCancelCode
		{
			set{ _salescancelcode=value;}
			get{return _salescancelcode;}
		}
		/// <summary>
		/// 物料编号
		/// </summary>
		public string materialCode
		{
			set{ _materialcode=value;}
			get{return _materialcode;}
		}
		/// <summary>
		/// 物料名称
		/// </summary>
		public string materiaName
		{
			set{ _materianame=value;}
			get{return _materianame;}
		}
		/// <summary>
		/// 规格型号
		/// </summary>
		public string materialModel
		{
			set{ _materialmodel=value;}
			get{return _materialmodel;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public decimal? number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 折扣后的单价
		/// </summary>
		public decimal? discountAfterPrice
		{
			set{ _discountafterprice=value;}
			get{return _discountafterprice;}
		}
		/// <summary>
		/// 折扣
		/// </summary>
		public decimal? discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		/// <summary>
		/// 折扣前单价
		/// </summary>
		public decimal? discountBeforePrice
		{
			set{ _discountbeforeprice=value;}
			get{return _discountbeforeprice;}
		}
		/// <summary>
		/// 金额
		/// </summary>
		public decimal? money
		{
			set{ _money=value;}
			get{return _money;}
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
		/// 预留字段1
		/// </summary>
		public string reserved1
		{
			set{ _reserved1=value;}
			get{return _reserved1;}
		}
		/// <summary>
		/// 预留字段2
		/// </summary>
		public string reserved2
		{
			set{ _reserved2=value;}
			get{return _reserved2;}
		}
		#endregion Model

	}
}

