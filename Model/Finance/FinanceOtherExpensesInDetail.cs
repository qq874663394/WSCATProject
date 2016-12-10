
using System;
namespace Model
{
    /// <summary>
    /// 上下班时刻表
    /// </summary>
    [Serializable]
    public partial class FinanceOtherExpensesInDetail
    {
        public FinanceOtherExpensesInDetail()
        { }
        #region Model
        private int _id;
        private string _code;
        private string _maincode;
        private string _projectincode;
        private decimal? _money;
        private string _abstract;
        private string _remark;
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
        /// 编码
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 收入主表编码
        /// </summary>
        public string mainCode
        {
            set { _maincode = value; }
            get { return _maincode; }
        }
        /// <summary>
        /// 收入项目编码
        /// </summary>
        public string projectInCode
        {
            set { _projectincode = value; }
            get { return _projectincode; }
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
        /// 摘要
        /// </summary>
        public string Abstract
        {
            set { _abstract = value; }
            get { return _abstract; }
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

