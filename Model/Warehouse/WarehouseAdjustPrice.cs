
using System;
namespace Model
{
    /// <summary>
    /// 销售订单明细表
    /// </summary>
    [Serializable]
    public partial class WarehouseAdjustPrice
    {
        public WarehouseAdjustPrice()
        { }
        #region Model
        private int _id;
        private string _code;
        private string _type;
        private DateTime? _date;
        private string _operationman;
        private string _makeman;
        private string _checkman;
        private int? _checkstate;
        private int? _isclear = 1;
        private DateTime? _updatedate;
        private string _remark;
        private string _reserved1;
        private string _reserved2;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 调价单号（生成）
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }  
        /// <summary>
        /// 调价类型
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 调价日期
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
        public string checkMan
        {
            set { _checkman = value; }
            get { return _checkman; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? checkState
        {
            set { _checkstate = value; }
            get { return _checkstate; }
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
        /// 更改时间
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
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
        #endregion Model

    }
}

