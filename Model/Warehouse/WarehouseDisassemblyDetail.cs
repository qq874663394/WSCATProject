
using System;
namespace Model
{
    /// <summary>
    /// WarehouseDisassemblyDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WarehouseDisassemblyDetail
    {
        public WarehouseDisassemblyDetail()
        { }
        #region Model
        private int _id;
        private string _code;
        private string _maincode;
        private string _materialcode;
        private string _materialdaima;
        private string _barcode;
        private string _materialname;
        private string _materialmode;
        private string _materialunit;
        private string _stockcode;
        private string _stockname;
        private decimal? _number;
        private decimal? _price;
        private decimal? _money;
        private string _remark;
        private int? _isclear;
        private DateTime? _updatetime;
        private string _reserved1;
        private string _reserved2;
        /// <summary>
        /// 自增
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string code
        {
            get;
            set;
        }
        /// <summary>
        /// 主表code
        /// </summary>
        public string mainCode
        {
            set { _maincode = value; }
            get { return _maincode; }
        }
        /// <summary>
        /// 商品code
        /// </summary>
        public string materialCode
        {
            set { _materialcode = value; }
            get { return _materialcode; }
        }
        /// <summary>
        /// 商品代码
        /// </summary>
        public string materialDaima
        {
            set { _materialdaima = value; }
            get { return _materialdaima; }
        }
        /// <summary>
        /// 条形码
        /// </summary>
        public string barCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string materialName
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string materialMode
        {
            set { _materialmode = value; }
            get { return _materialmode; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string materialUnit
        {
            set { _materialunit = value; }
            get { return _materialunit; }
        }
        /// <summary>
        /// 仓库code
        /// </summary>
        public string stockCode
        {
            set { _stockcode = value; }
            get { return _stockcode; }
        }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string stockName
        {
            set { _stockname = value; }
            get { return _stockname; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
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
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        #endregion Model

    }
}

