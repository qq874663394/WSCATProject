
using System;
namespace Model
{
	/// <summary>
	/// 销售订单明细表
	/// </summary>
	[Serializable]
	public partial class WarehouseAllotDetail
	{
		public WarehouseAllotDetail()
		{}
        #region Model
        private int _id;
        private string _code;
        private string _maincode;
        private string _materialcode;
        private string _materialdaima;
        private string _materianame;
        private string _materiamodel;
        private string _barcode;
        private string _materiaunit;
        private decimal? _curnumber;
        private string _stoincode;
        private string _stoinname;
        private string _stooutcode;
        private string _stooutname;
        private decimal? _allotinprice;
        private decimal? _allotinsummoney;
        private decimal? _allotoutprice;
        private decimal? _allotoutsummoney;
        private DateTime? _productiondate;
        private decimal? _qualitydate;
        private DateTime? _effectivedate;
        private int? _isclear;
        private string _reserved1;
        private string _reserved2;
        private string _remark;
        private DateTime? _updatedate;
        /// <summary>
        /// 栏号(自增)
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 调拨编号
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
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
        /// 物料编号
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
        /// 物料名称
        /// </summary>
        public string materiaName
        {
            set { _materianame = value; }
            get { return _materianame; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string materiaModel
        {
            set { _materiamodel = value; }
            get { return _materiamodel; }
        }
        /// <summary>
        /// 条形码
        /// </summary>
        public string barcode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string materiaUnit
        {
            set { _materiaunit = value; }
            get { return _materiaunit; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? curNumber
        {
            set { _curnumber = value; }
            get { return _curnumber; }
        }
        /// <summary>
        /// 调入仓库code
        /// </summary>
        public string stoIncode
        {
            set { _stoincode = value; }
            get { return _stoincode; }
        }
        /// <summary>
        /// 调入仓库名称
        /// </summary>
        public string stoInName
        {
            set { _stoinname = value; }
            get { return _stoinname; }
        }
        /// <summary>
        /// 调出仓库code
        /// </summary>
        public string stoOutcode
        {
            set { _stooutcode = value; }
            get { return _stooutcode; }
        }
        /// <summary>
        /// 调出仓库名称
        /// </summary>
        public string stoOutName
        {
            set { _stooutname = value; }
            get { return _stooutname; }
        }
        /// <summary>
        /// 调入单价
        /// </summary>
        public decimal? allotInPrice
        {
            set { _allotinprice = value; }
            get { return _allotinprice; }
        }
        /// <summary>
        /// 调入金额
        /// </summary>
        public decimal? allotInSummoney
        {
            set { _allotinsummoney = value; }
            get { return _allotinsummoney; }
        }
        /// <summary>
        /// 调出单价
        /// </summary>
        public decimal? allotOutPrice
        {
            set { _allotoutprice = value; }
            get { return _allotoutprice; }
        }
        /// <summary>
        /// 调出总金额
        /// </summary>
        public decimal? allotOutSummoney
        {
            set { _allotoutsummoney = value; }
            get { return _allotoutsummoney; }
        }
        /// <summary>
        /// 生成/采购日期
        /// </summary>
        public DateTime? productionDate
        {
            set { _productiondate = value; }
            get { return _productiondate; }
        }
        /// <summary>
        /// 保质期（天）
        /// </summary>
        public decimal? qualityDate
        {
            set { _qualitydate = value; }
            get { return _qualitydate; }
        }
        /// <summary>
        /// 有效期至
        /// </summary>
        public DateTime? effectiveDate
        {
            set { _effectivedate = value; }
            get { return _effectivedate; }
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

