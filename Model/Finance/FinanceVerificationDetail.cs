using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Finance
{
    public class FinanceVerificationDetail
    {
        #region Model
        private int _id;
        private string _code;
        private DateTime? _date;
        private string _maincode;
        private string _sourcecode;
        private string _sourcetype;
        private decimal? _sourceamount;
        private decimal? _alreadyverificationamount;
        private decimal? _notverificationamount;
        private string _remark;
        private decimal? _theVerificationamount;
        /// <summary>
        /// 本次核销
        /// </summary>
        public decimal? theVerificationAmount { get; set; }
        /// <summary>
        /// 
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
        /// 创建日期
        /// </summary>
        public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 主表编码
        /// </summary>
        public string mainCode
        {
            set { _maincode = value; }
            get { return _maincode; }
        }
        /// <summary>
        /// 源单编码
        /// </summary>
        public string sourceCode
        {
            set { _sourcecode = value; }
            get { return _sourcecode; }
        }
        /// <summary>
        /// 源单类型
        /// </summary>
        public string sourceType
        {
            set { _sourcetype = value; }
            get { return _sourcetype; }
        }
        /// <summary>
        /// 单据金额
        /// </summary>
        public decimal? sourceAmount
        {
            set { _sourceamount = value; }
            get { return _sourceamount; }
        }
        /// <summary>
        /// 已核销金额
        /// </summary>
        public decimal? alreadyVerificationAmount
        {
            set { _alreadyverificationamount = value; }
            get { return _alreadyverificationamount; }
        }
        /// <summary>
        /// 未核销金额
        /// </summary>
        public decimal? notVerificationAmount
        {
            set { _notverificationamount = value; }
            get { return _notverificationamount; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model
    }
}
