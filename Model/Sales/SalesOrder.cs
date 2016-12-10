using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Sales
{
    public class SalesOrder
    {
        #region Model
        private int _id;
        private string _clientcode;
        private DateTime? _deliversdate;
        private int? _deliversmethod;
        private string _remark;
        private string _code;
        private DateTime? _date;
        private string _deliverslocation;
        private string _operation;
        private string _makeman;
        private string _examine;
        private int? _checkstate;
        private decimal? _depositreceived;
        private DateTime? _examinedate;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 客户外键
        /// </summary>
        public string clientCode
        {
            set { _clientcode = value; }
            get { return _clientcode; }
        }
        /// <summary>
        /// 交货日期
        /// </summary>
        public DateTime? deliversDate
        {
            set { _deliversdate = value; }
            get { return _deliversdate; }
        }
        /// <summary>
        /// 交货方式
        /// </summary>
        public int? deliversMethod
        {
            set { _deliversmethod = value; }
            get { return _deliversmethod; }
        }
        /// <summary>
        /// 摘要
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 交货地点
        /// </summary>
        public string deliversLocation
        {
            set { _deliverslocation = value; }
            get { return _deliverslocation; }
        }
        /// <summary>
        /// 销售员
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
        /// 审核状态  
        /// </summary>
        public int? checkState
        {
            set { _checkstate = value; }
            get { return _checkstate; }
        }
        /// <summary>
        /// 已收订金  
        /// </summary>
        public decimal? depositReceived
        {
            set { _depositreceived = value; }
            get { return _depositreceived; }
        }
        /// <summary>
        /// 审核日期  
        /// </summary>
        public DateTime? examineDate
        {
            set { _examinedate = value; }
            get { return _examinedate; }
        }
        #endregion Model
    }
}
