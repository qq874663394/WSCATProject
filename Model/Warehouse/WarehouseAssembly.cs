
using System;
namespace Model
{
	/// <summary>
	/// WarehouseAssembly:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WarehouseAssembly
	{
		public WarehouseAssembly()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _type;
		private decimal? _assemblycost;
		private DateTime? _date;
		private string _abstract;
		private string _materialcode;
		private string _materialdaima;
		private string _barcode;
		private string _materialname;
		private string _materialmode;
		private string _materialunit;
		private string _stockcode;
		private string _stockname;
		private decimal? _number;
		private string _materialremark;
		private int? _checkstate;
		private string _operation;
		private string _makeman;
		private string _examine;
		private int? _isclear;
		private DateTime? _updatetime;
		private string _reserved1;
		private string _reserved2;
		/// <summary>
		/// 自增id
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 单据code
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 费用类型
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 组装费用
		/// </summary>
		public decimal? assemblyCost
		{
			set{ _assemblycost=value;}
			get{return _assemblycost;}
		}
		/// <summary>
		/// 单据日期
		/// </summary>
		public DateTime? date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 摘要
		/// </summary>
		public string Abstract
		{
			set{ _abstract=value;}
			get{return _abstract;}
		}
		/// <summary>
		/// 商品code
		/// </summary>
		public string materialCode
		{
			set{ _materialcode=value;}
			get{return _materialcode;}
		}
		/// <summary>
		/// 商品代码
		/// </summary>
		public string materialDaima
		{
			set{ _materialdaima=value;}
			get{return _materialdaima;}
		}
		/// <summary>
		/// 条形码
		/// </summary>
		public string barCode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 商品名称
		/// </summary>
		public string materialName
		{
			set{ _materialname=value;}
			get{return _materialname;}
		}
		/// <summary>
		/// 规格型号
		/// </summary>
		public string materialMode
		{
			set{ _materialmode=value;}
			get{return _materialmode;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string materialUnit
		{
			set{ _materialunit=value;}
			get{return _materialunit;}
		}
		/// <summary>
		/// 仓库code
		/// </summary>
		public string stockCode
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
		/// 数量
		/// </summary>
		public decimal? number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string materialremark
		{
			set{ _materialremark=value;}
			get{return _materialremark;}
		}
		/// <summary>
		/// 审核状态
		/// </summary>
		public int? checkState
		{
			set{ _checkstate=value;}
			get{return _checkstate;}
		}
		/// <summary>
		/// 组装员
		/// </summary>
		public string operation
		{
			set{ _operation=value;}
			get{return _operation;}
		}
		/// <summary>
		/// 制单人
		/// </summary>
		public string makeMan
		{
			set{ _makeman=value;}
			get{return _makeman;}
		}
		/// <summary>
		/// 审核人
		/// </summary>
		public string examine
		{
			set{ _examine=value;}
			get{return _examine;}
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
		/// 更新时间
		/// </summary>
		public DateTime? updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
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

