
using System;
namespace Model
{
    /// <summary>
    /// 上下班时刻表
    /// </summary>
    [Serializable]
    public partial class FinanceOtherExpensesOutDetail
    {
        public FinanceOtherExpensesOutDetail()
        { }
        #region Model
        private int _id;
        private string _outcode;
        private string _projectoutcode;
        private decimal? _money;
        private string _material;
        private string _remark;
        private string _reserved1;
        private DateTime? _updatedate;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 支出主表编码
        /// </summary>
        public string outCode
        {
            set { _outcode = value; }
            get { return _outcode; }
        }
        /// <summary>
        /// 支出项目编码
        /// </summary>
        public string projectOutCode
        {
            set { _projectoutcode = value; }
            get { return _projectoutcode; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 支出类别
        /// </summary>
        public string material
        {
            set { _material = value; }
            get { return _material; }
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
        /// 保留字段1
        /// </summary>
        public string Reserved1
        {
            set { _reserved1 = value; }
            get { return _reserved1; }
        }
        /// <summary>
        /// 更改时间
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
        }
        #endregion Model

    }
}

