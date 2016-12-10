using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Warehouse
{
    /// <summary>
	/// 盘盈单
	/// </summary>
	[Serializable]
    public partial  class WarehouseInventoryLoss
    {
        public WarehouseInventoryLoss()
        { }
        #region Model
        private int _id;
        private string _code;
        private string _type;
        private DateTime? _date;
        private int? _checkstate;
        private string _operation;
        private string _makeman;
        private string _examine;
        private string _remark;
        private DateTime? _updatetime;
        private string _reserved1;
        private string _reserved2;
        private int? _isclear;
        /// <summary>
		/// 自增ID
		/// </summary>
		public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
		/// 单据code
		/// </summary>
		public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
		/// 盘亏单出库类别
		/// </summary>
		public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
		/// 单据日期
		/// </summary>
		public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
		/// 单据状态0、未审核 1、已审核
		/// </summary>
		public int? checkState
        {
            set { _checkstate = value; }
            get { return _checkstate; }
        }
        /// <summary>
		/// 盘亏员
		/// </summary>
		public string operation
        {
            set { _operation = value; }
            get { return _operation; }
        }
        /// <summary>
		/// 制单人
		/// </summary>
		public string makeMan
        {
            set { _makeman = value; }
            get { return _makeman; }
        }
        /// <summary>
		/// 审核人
		/// </summary>
		public string examine
        {
            set { _examine = value; }
            get { return _examine; }
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
        /// 更新时间
        /// </summary>
        public DateTime? updatetime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 保留字段1
        /// </summary>
        public string reserved1
        {
            set { _reserved1 = value; }
            get { return _reserved1; }
        }
        /// <summary>
        /// 保留字段2
        /// </summary>
        public string reserved2
        {
            set { _reserved2 = value; }
            get { return _reserved2; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? isClear
        {
            set { _isclear = value; }
            get { return _isclear; }
        }
        #endregion
    }
}
