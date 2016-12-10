
using System;
namespace Model
{
	/// <summary>
	/// 客户折扣表
	/// </summary>
	[Serializable]
	public partial class BaseDiscount
	{
		public BaseDiscount()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _clientcode;
		private DateTime? _createdate= DateTime.Now;
		private DateTime? _cleardate;
        private decimal? _discount;
		private int? _enable=1;
		private int? _clear=1;
		private string _remark;
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
		/// 折扣编号
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 客户名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 客户编码
		/// </summary>
		public string clientCode
		{
			set{ _clientcode=value;}
			get{return _clientcode;}
		}
		/// <summary>
		/// 建立时间
		/// </summary>
		public DateTime? createDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// 到期时间
		/// </summary>
		public DateTime? clearDate
		{
			set{ _cleardate=value;}
			get{return _cleardate;}
		}
		/// <summary>
		/// 折数（%）
		/// </summary>
		public decimal? discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		/// <summary>
		/// 是否可用
		/// </summary>
		public int? enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? clear
		{
			set{ _clear=value;}
			get{return _clear;}
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

