
using System;
namespace Model
{
    /// <summary>
    /// 上下班时刻表
    /// </summary>
    [Serializable]
    public partial class FinanceOtherExpensesOut
    {
        public FinanceOtherExpensesOut()
        { }
            #region Model
            private int _id;
            private string _code;
            private string _type;
            private string _suppliercode;
            private string _clientcode;
            private string _accountcode;
            private string _settlementtype;
            private string _settlementnumber;
            private decimal? _settlementmoney;
            private int? _checkstate;
            private DateTime? _date = DateTime.Now;
            private string _salescode;
            private string _salesman;
            private string _operationman;
            private string _checkman;
            private string _abstract;
            private int? _isclear = 1;
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
            /// 费用单单号
            /// </summary>
            public string code
            {
                set { _code = value; }
                get { return _code; }
            }
            /// <summary>
            /// 单据类型
            /// </summary>
            public string type
            {
                set { _type = value; }
                get { return _type; }
            }
            /// <summary>
            /// 供应商编码
            /// </summary>
            public string supplierCode
            {
                set { _suppliercode = value; }
                get { return _suppliercode; }
            }
            /// <summary>
            /// 客户编码
            /// </summary>
            public string clientCode
            {
                set { _clientcode = value; }
                get { return _clientcode; }
            }
            /// <summary>
            /// 账户编码
            /// </summary>
            public string accountCode
            {
                set { _accountcode = value; }
                get { return _accountcode; }
            }
            /// <summary>
            /// 结算方式
            /// </summary>
            public string settlementType
            {
                set { _settlementtype = value; }
                get { return _settlementtype; }
            }
            /// <summary>
            /// 结算号
            /// </summary>
            public string settlementNumber
            {
                set { _settlementnumber = value; }
                get { return _settlementnumber; }
            }
            /// <summary>
            /// 结算金额
            /// </summary>
            public decimal? settlementMoney
            {
                set { _settlementmoney = value; }
                get { return _settlementmoney; }
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
            /// 业务员编号
            /// </summary>
            public string salesCode
            {
                set { _salescode = value; }
                get { return _salescode; }
            }
            /// <summary>
            /// 业务员名称
            /// </summary>
            public string salesMan
            {
                set { _salesman = value; }
                get { return _salesman; }
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
            /// 审核人
            /// </summary>
            public string checkMan
            {
                set { _checkman = value; }
                get { return _checkman; }
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
            /// 审核状态，0、未审核，1、已审核
            /// </summary>
            public int? checkState
            {
                set { _checkstate = value; }
                get { return _checkstate; }
            }

            #endregion Model
    }
}

