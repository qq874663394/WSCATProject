using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HelperUtility.Encrypt
{
    public class CodingHelper
    {
        /// <summary>
        /// 将datatable里加密的数据解密后返回新的datatable
        /// </summary>
        /// <param name="dt">数据加密的datatable</param>
        /// <returns>解密的datatable</returns>
        public DataTable DataTableReCoding(DataTable dt)
        {
            if (dt == null)
            {
                return dt;
            }
            DataTable TempDT = dt.Clone();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        object temp = null;

                        //时间和int、decimal不加密 需排除
                        temp = (dt.Columns[j].DataType == typeof(int) ||
                            dt.Columns[j].DataType == typeof(DateTime) || dt.Columns[j].DataType==typeof(decimal)) ?
                            dt.Rows[i][j] :
                            XYEEncoding.strHexDecode(dt.Rows[i][j].ToString());

                        dr[j] = temp;
                    }
                    TempDT.Rows.Add(dr.ItemArray);
                }
            }
            return TempDT;
        }

        /// <summary>
        /// 将dataSet里加密的数据解密后返回新的dataSet
        /// </summary>
        /// <param name="ds">数据加密的dataset</param>
        /// <returns>解密的datatable</returns>
        public DataSet DataSetReCoding(DataSet ds)
        {
            if(ds == null)
            {
                return ds;
            }
            DataSet TempDS = ds.Clone();
            if(ds.Tables.Count > 0)
            {
                //遍历表 并复制数据
                for(int t = 0;t<ds.Tables.Count;t++)
                {
                    for (int i = 0; i < ds.Tables[t].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[t].NewRow();
                        for (int j = 0; j < ds.Tables[t].Columns.Count; j++)
                        {
                            object temp = null;

                            //时间和int以及bool不加密 需排除
                            temp = (ds.Tables[t].Columns[j].DataType == typeof(int) ||
                                ds.Tables[t].Columns[j].DataType == typeof(DateTime) ||
                                ds.Tables[t].Columns[j].DataType == typeof(decimal) ||
                                ds.Tables[t].Columns[j].DataType == typeof(Boolean)) ?
                                ds.Tables[t].Rows[i][j] :
                                XYEEncoding.strHexDecode(ds.Tables[t].Rows[i][j].ToString());

                            dr[j] = temp;
                        }
                        TempDS.Tables[t].Rows.Add(dr.ItemArray);
                    }
                }
            }
            return TempDS;
        }
    }
}
