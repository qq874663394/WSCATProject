
using System;
namespace Model
{
	/// <summary>
	/// 上下班时刻表
	/// </summary>
	[Serializable]
	public partial class PurchaseCancel
	{
		public PurchaseCancel()
		{}
		#region Model
		private int _id;
		private int? _isclear=1;
		private string _code;
		private string _storagecode;
		private string _storagename;
		private DateTime? _returndate= DateTime.Now;
		private int? _purchasecancelstate=0;
		private int? _checkstate=0;
		private string _salesman;
		private string _operationman;
		private string _checkman;
		private string _remark;
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
		/// 是否删除
		/// </summary>
		public int? isClear
		{
			set{ _isclear=value;}
			get{return _isclear;}
		}
		/// <summary>
		/// 退货单号（生成）
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 供应商编号
		/// </summary>
		public string storageCode
		{
			set{ _storagecode=value;}
			get{return _storagecode;}
		}
		/// <summary>
		/// 供应商名称
		/// </summary>
		public string storageName
		{
			set{ _storagename=value;}
			get{return _storagename;}
		}
		/// <summary>
		/// 退货日期
		/// </summary>
		public DateTime? returnDate
		{
			set{ _returndate=value;}
			get{return _returndate;}
		}
		/// <summary>
		/// 是否已完成,1已完成,0未完成
		/// </summary>
		public int? purchaseCancelState
		{
			set{ _purchasecancelstate=value;}
			get{return _purchasecancelstate;}
		}
		/// <summary>
		/// 是否已完成,1已完成,0未完成
		/// </summary>
		public int? checkState
		{
			set{ _checkstate=value;}
			get{return _checkstate;}
		}
		/// <summary>
		/// 业务员
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

