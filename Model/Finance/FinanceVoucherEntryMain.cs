using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Finance
{
    public class FinanceVoucherEntryMain
    {
        #region Model
        private int _id;
        private string _code;
        private DateTime? _date;
        private string _examine;
        private string _posting;
        private string _makeman;
        private int? _examinestate;
        private int? _isclear = 1;
        /// <summary>
        /// 
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
        /// 日期
        /// </summary>
        public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
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
        /// 过账人
        /// </summary>
        public string posting
        {
            set { _posting = value; }
            get { return _posting; }
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
        /// 审核状态0未审核,1已审核
        /// </summary>
        public int? examineState
        {
            set { _examinestate = value; }
            get { return _examinestate; }
        }
        /// <summary>
        /// 是否删除 0为已删除1为未删除
        /// </summary>
        public int? isClear
        {
            set { _isclear = value; }
            get { return _isclear; }
        }
        #endregion Model
    }
}
