using System;
namespace Model
{
    /// <summary>
    /// 收款单详细
    /// </summary>
	[Serializable]
	public partial class FinanceCollectionDetail
	{
		public FinanceCollectionDetail()
		{}
		#region Model
		private int _id;
		private string _maincode;
        private string _code;
		private string _salecode;
		private DateTime? _salesdate;
		private string _salestype;
		private decimal? _amountreceivable;
		private decimal? _amountreceived;
		private decimal? _amountunpaid;
		private decimal? _nowmoney;
		private decimal? _uncollection;
		private string _remark;
		/// <summary>
		/// 
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
        /// 收款详单code
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 销售单单号
        /// </summary>
        public string saleCode
		{
			set{ _salecode=value;}
			get{return _salecode;}
		}
		/// <summary>
		/// 销售单日期
		/// </summary>
		public DateTime? salesDate
		{
			set{ _salesdate=value;}
			get{return _salesdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string salesType
		{
			set{ _salestype=value;}
			get{return _salestype;}
		}
		/// <summary>
		/// 应收金额
		/// </summary>
		public decimal? amountReceivable
		{
			set{ _amountreceivable=value;}
			get{return _amountreceivable;}
		}
		/// <summary>
		/// 已核销金额
		/// </summary>
		public decimal? amountReceived
		{
			set{ _amountreceived=value;}
			get{return _amountreceived;}
		}
		/// <summary>
		/// 未核销金额
		/// </summary>
		public decimal? amountUnpaid
		{
			set{ _amountunpaid=value;}
			get{return _amountunpaid;}
		}
		/// <summary>
		/// 本次核销
		/// </summary>
		public decimal? nowMoney
		{
			set{ _nowmoney=value;}
			get{return _nowmoney;}
		}
		/// <summary>
		/// 剩余金额
		/// </summary>
		public decimal? unCollection
		{
			set{ _uncollection=value;}
			get{return _uncollection;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

