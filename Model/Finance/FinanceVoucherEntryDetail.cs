using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Finance
{
    public class FinanceVoucherEntryDetail
    {
        #region Model
        private int _id;
        private string _code;
        private string _maincode;
        private string _summary;
        private string _subject;
        private decimal? _debitamount;
        private decimal? _creditamount;
        /// <summary>
        /// 摘要
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 主表code
        /// </summary>
        public string mainCode
        {
            set { _maincode = value; }
            get { return _maincode; }
        }
        /// <summary>
        /// 摘要
        /// </summary>
        public string summary
        {
            set { _summary = value; }
            get { return _summary; }
        }
        /// <summary>
        /// 科目
        /// </summary>
        public string subject
        {
            set { _subject = value; }
            get { return _subject; }
        }
        /// <summary>
        /// 借方金额
        /// </summary>
        public decimal? debitAmount
        {
            set { _debitamount = value; }
            get { return _debitamount; }
        }
        /// <summary>
        /// 贷方金额
        /// </summary>
        public decimal? creditAmount
        {
            set { _creditamount = value; }
            get { return _creditamount; }
        }
        #endregion Model

    }
}
