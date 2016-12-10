using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Warehouse
{
    /// <summary>
    /// 盘亏单明细表
    /// </summary>
    [Serializable]
    public partial class WarehouseInventoryLossDetail
    {
        public WarehouseInventoryLossDetail()
        { }
        #region Model
        private int _id;
        private string _code;
        private string _maincode;
        private string _barcode;
        private string _materialdaima;
        private string _materialcode;
        private string _materialname;
        private string _materialmodel;
        private string _materialunit;
        private string _warehousecode;
        private string _warehousename;
        private decimal? _price;
        private decimal? _number;
        private decimal? _inventorynumber;
        private decimal? _lossnumber;
        private decimal? _lossmoney;
        private DateTime? _productiondate;
        private decimal? _qualitydate;
        private DateTime? _effectivedate;
        private int? _isclear;
        private DateTime? _updatedate;
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
        /// 单据code
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
        /// 条形码
        /// </summary>
        public string barCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string materialDaima
        {
            set { _materialdaima = value; }
            get { return _materialdaima; }
        }
        /// <summary>
        /// 物料code
        /// </summary>
        public string materialCode
        {
            set { _materialcode = value; }
            get { return _materialcode; }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string materialName
        {
            set { _materialname = value; }
            get { return _materialname; }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string materialModel
        {
            set { _materialmodel = value; }
            get { return _materialmodel; }
        }
        /// <summary>
        /// 物料单位
        /// </summary>
        public string materialUnit
        {
            set { _materialunit = value; }
            get { return _materialunit; }
        }
        /// <summary>
        /// 仓库code
        /// </summary>
        public string warehouseCode
        {
            set { _warehousecode = value; }
            get { return _warehousecode; }
        }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string warehouseName
        {
            set { _warehousename = value; }
            get { return _warehousename; }
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
        /// 账存数量
        /// </summary>
        public decimal? number
        {
            set { _number = value; }
            get { return _number; }
        }
        /// <summary>
        /// 盘点数量
        /// </summary>
        public decimal? inventoryNumber
        {
            set { _inventorynumber = value; }
            get { return _inventorynumber; }
        }
        /// <summary>
        /// 盘亏数量
        /// </summary>
        public decimal? lossNumber
        {
            set { _lossnumber = value; }
            get { return _lossnumber; }
        }
        /// <summary>
        /// 盘亏金额
        /// </summary>
        public decimal? lossMoney
        {
            set { _lossmoney = value; }
            get { return _lossmoney; }
        }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? productionDate
        {
            set { _productiondate = value; }
            get { return _productiondate; }
        }
        /// <summary>
        /// 保质期
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
        /// 更新时间
        /// </summary>
        public DateTime? updateDate
        {
            set { _updatedate = value; }
            get { return _updatedate; }
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
