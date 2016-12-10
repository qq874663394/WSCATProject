using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer.Sales
{
    public class SalesOrderDetailBase
    {
        public DataTable GetSalesJoinSearch()
        {
            DataTable dt = null;
            string sql = @"select * from 
T_SalesOrderDetail sod, T_BaseMaterial bm,T_WarehouseMain wm
where
sod.materialCode = bm.code and
wm.materialCode = sod.materialCode and
wm.materialCode = bm.code";
            dt = DbHelperSQL.Query(sql).Tables[0];
            return dt;
        }
    }
}
