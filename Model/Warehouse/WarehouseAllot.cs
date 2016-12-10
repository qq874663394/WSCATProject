
using System;
namespace Model
{
	/// <summary>
	/// 销售订单明细表
	/// </summary>
	[Serializable]
	public partial class WarehouseAllot
	{
		public WarehouseAllot()
		{}
        #region Model
        private int _id;
        private string _code;
        private DateTime? _date;
        private string _operationman;
        private string _checkman;
        private string _cause;
        private DateTime? _updatedate;
        private int? _isclear = 1;
        private string _reserved1;
        private string _reserved2;
        private string _remark;
        private decimal? _allotgap;
        private int? _checkstate;
        private string _allottype;
        private string _makeman;
        /// <summary>
        /// 调拨单号(生成)
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 调价编号
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 调拨日期
        /// </summary>
        public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string operationMan
        {
            set { _operationman = value; }
            get { return _operationman; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string checkMan
        {
            set { _checkman = value; }
            get { return _checkman; }
        }
        /// <summary>
        /// 调拨原因
        /// </summary>
        public string cause
        {
            set { _cause = value; }
            get { return _cause; }
        }
        /// <summary>
        /// 更改时间
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? isClear
        {
            set { _isclear = value; }
            get { return _isclear; }
        }
        /// <summary>
        /// 预留字段1
        /// </summary>
        public string reserved1
        {
            set { _reserved1 = value; }
            get { return _reserved1; }
        }
        /// <summary>
        /// 预留字段2
        /// </summary>
        public string reserved2
        {
            set { _reserved2 = value; }
            get { return _reserved2; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 调拨差额
        /// </summary>
        public decimal? allotGap
        {
            set { _allotgap = value; }
            get { return _allotgap; }
        }
        /// <summary>
        /// 是否审核0、未审核，1、已审核
        /// </summary>
        public int? checkState
        {
            set { _checkstate = value; }
            get { return _checkstate; }
        }
        /// <summary>
        /// 调拨类型
        /// </summary>
        public string allotType
        {
            set { _allottype = value; }
            get { return _allottype; }
        }
        /// <summary>
        /// 调拨员
        /// </summary>
        public string makeMan
        {
            set { _makeman = value; }
            get { return _makeman; }
        }
        #endregion Model

    }
}

