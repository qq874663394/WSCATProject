using LogicLayer.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.Sales
{
    public class SalesDetailInterface
    {
        SalesDetailLogic sdl = new SalesDetailLogic();
        /// <summary>
        /// 复合查询
        /// </summary>
        /// <param name="fieldName">条件字段：0:salesMainCode</param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public DataTable GetList(int fieldName, string fieldValue)
        {
            return sdl.GetList(fieldName, fieldValue);
        }
        /// <summary>
        /// 根据销售单号查销售明细表,根据明细表code查库存的数据以及商品的具体货架
        /// </summary>
        /// <param name="SalesCode"></param>
        /// <returns></returns>
        public DataTable GetDetailByMainCode(string SalesCode, int fieldName, string fieldValue)
        {
            return sdl.GetDetailByMainCode(SalesCode, fieldName, fieldValue);
        }
        public DataTable GetWhereList(string fieldValue,string salesCode)
        {
            return sdl.GetWhereList(fieldValue,salesCode);
        }
        public bool Exists(string code)
        {
            return sdl.Exists(code);
        }
    }
}
