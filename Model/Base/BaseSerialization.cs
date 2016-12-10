
using System;
namespace Model
{
	/// <summary>
	/// 单据编码表
	/// </summary>
	[Serializable]
	public partial class BaseSerialization
	{
		public BaseSerialization()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _codingdescription;
		private string _prefixlength;
		private int? _totallenght;
		private string _codingrule;
		private DateTime? _currentdate= DateTime.Now;
		private int? _nextno;
		private int? _isclear=1;
		private DateTime? _updatedate;
		/// <summary>
		/// 单据编号
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 编码代码
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 编码说明
		/// </summary>
		public string codingdescription
		{
			set{ _codingdescription=value;}
			get{return _codingdescription;}
		}
		/// <summary>
		/// 前缀编码长度
		/// </summary>
		public string prefixLength
		{
			set{ _prefixlength=value;}
			get{return _prefixlength;}
		}
		/// <summary>
		/// 总编码长度
		/// </summary>
		public int? totalLenght
		{
			set{ _totallenght=value;}
			get{return _totallenght;}
		}
		/// <summary>
		/// 编码规则
		/// </summary>
		public string codingRule
		{
			set{ _codingrule=value;}
			get{return _codingrule;}
		}
		/// <summary>
		/// 当前日期
		/// </summary>
		public DateTime? currentDate
		{
			set{ _currentdate=value;}
			get{return _currentdate;}
		}
		/// <summary>
		/// 下个编号值
		/// </summary>
		public int? nextNo
		{
			set{ _nextno=value;}
			get{return _nextno;}
		}
		/// <summary>
		/// 是否停用
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

