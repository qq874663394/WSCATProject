using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Purchase
{
    public class PurchaseOrderDetail
    {
        public PurchaseOrderDetail()
        {

        }
        #region Model
        private int _id;
        private string _materialcode;
        private decimal? _materialnumber;
        private decimal? _materialprice;
        private decimal? _materialmoney;
        private decimal? _discountrate;
        private decimal? _vatrate;
        private decimal? _discountmoney;
        private decimal? _purchaseamount;
        private decimal? _tax;
        private decimal? _taxtotal;
        private string _remark;
        private decimal? _deliverynumber;
        private string _maincode;
        private string _code;
        private string _amount;
        private string _mainCode;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 物料外键
        /// </summary>
        public string materialCode
        {
            set { _materialcode = value; }
            get { return _materialcode; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? materialNumber
        {
            set { _materialnumber = value; }
            get { return _materialnumber; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? materialPrice
        {
            set { _materialprice = value; }
            get { return _materialprice; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? materialMoney
        {
            set { _materialmoney = value; }
            get { return _materialmoney; }
        }
        /// <summary>
        /// 折扣率
        /// </summary>
        public decimal? discountRate
        {
            set { _discountrate = value; }
            get { return _discountrate; }
        }
        /// <summary>
        /// 增值税税率
        /// </summary>
        public decimal? VATRate
        {
            set { _vatrate = value; }
            get { return _vatrate; }
        }
        /// <summary>
        /// 折扣额
        /// </summary>
        public decimal? discountMoney
        {
            set { _discountmoney = value; }
            get { return _discountmoney; }
        }
        /// <summary>
        /// 采购费用合计
        /// </summary>
        public decimal? purchaseAmount
        {
            set { _purchaseamount = value; }
            get { return _purchaseamount; }
        }
        /// <summary>
        /// 税额
        /// </summary>
        public decimal? tax
        {
            set { _tax = value; }
            get { return _tax; }
        }
        /// <summary>
        /// 价税合计
        /// </summary>
        public decimal? taxTotal
        {
            set { _taxtotal = value; }
            get { return _taxtotal; }
        }
        /// <summary>
        /// 备注、摘要
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 发货数量
        /// </summary>
        public decimal? deliveryNumber
        {
            set { _deliverynumber = value; }
            get { return _deliverynumber; }
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
        /// 
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        #endregion Model
    }
}
