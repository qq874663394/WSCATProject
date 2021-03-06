﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Finance
{
    public class FinanceAccountingSubjects
    {
        #region Model
        private int _id;
        private string _code;
        private string _name;
        private string _parentCode;
        private string _hotKey;
        private int _nodeType;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 节点编号
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 父节点标识
        /// </summary>
        public string parentCode
        {
            set { _parentCode = value; }
            get { return _parentCode; }
        }
        /// <summary>
        /// 快捷代码
        /// </summary>
        public string hotKey
        {
            set { _hotKey = value; }
            get { return _hotKey; }
        }
        /// <summary>
        /// 科目选项
        /// </summary>
        public int nodeType
        {
            set { _nodeType = value; }
            get { return _nodeType; }
        }
        #endregion Model
    }
}
