using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleManager
{
    class WarehouseUpdataManager
    {
        public string SearchLastUpdateTime()
        {
            //调用webservice查询上一次更新时间
            return "";
        }


        public int UpdateLocalWareHouseDatabase(DataTable dt)
        {
            //获取到更新时间段的datatable(上一次记录时间到最新)覆盖本地数据
            return 0;
        }
    }
}
