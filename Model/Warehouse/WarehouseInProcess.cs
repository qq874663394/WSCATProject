
using System;
namespace Model
{
	/// <summary>
	/// 销售订单明细表
	/// </summary>
	[Serializable]
	public partial class WarehouseInProcess
	{
		public WarehouseInProcess()
		{}
		#region Model
		private int _id;
		private int? _isclear;
		private string _code;
		private string _warehouseindetailcode;
		private DateTime? _createdatetime;
		private string _operator;
		private string _operatorman;
		private string _remark;
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
		/// 是否删除
		/// </summary>
		public int? isClear
		{
			set{ _isclear=value;}
			get{return _isclear;}
		}
		/// <summary>
		/// 编号Code
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 入库明细Code
		/// </summary>
		public string warehouseInDetailCode
		{
			set{ _warehouseindetailcode=value;}
			get{return _warehouseindetailcode;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? createDatetime
		{
			set{ _createdatetime=value;}
			get{return _createdatetime;}
		}
		/// <summary>
		/// 所做操作
		/// </summary>
		public string Operator
		{
			set{ _operator=value;}
			get{return _operator;}
		}
		/// <summary>
		/// 操作人
		/// </summary>
		public string operatorMan
		{
			set{ _operatorman=value;}
			get{return _operatorman;}
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
		/// 更新时间
		/// </summary>
		public DateTime? updateDate
		{
			set{ _updatedate=value;}
			get{return _updatedate;}
		}
		#endregion Model

	}
}

