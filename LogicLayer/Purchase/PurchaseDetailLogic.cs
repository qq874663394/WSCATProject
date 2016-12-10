using BaseLayer;
using BaseLayer.Purchase;
using HelperUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Purchase
{
    public class PurchaseDetailLogic
    {
        PurchaseDetailBase _dal = new PurchaseDetailBase();
        LogBase _logDal = new LogBase();
        public DataTable GetList(int fieldName, string fieldValue)
        {
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseDetail",
                operationTime = DateTime.Now,
                objective = "查询采购明细表"
            };
            DataTable dt = null;
            string strWhere = "";
            try
            {
                switch (fieldName)
                {
                    case 0:
                        strWhere += "";
                        break;
                    case 1:

                        break;
                    default:
                        break;
                }
                logModel.operationContent = "查询T_PurchaseDetail表的数据,条件为："+strWhere;
                dt = _dal.GetList(strWhere);
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                logModel.result = 0;
                throw ex;
            }
            return dt;
        }
        public DataTable GetList(string purchaseCode, string zhujima)
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseDetail",
                operationTime = DateTime.Now,
                objective = "查询采购明细表",
                operationContent = string.Format("查询T_PurchaseDetail表的数据,条件为:purchaseCode={0},zhujima={1}", purchaseCode, zhujima)
            };
            try
            {
                dt = _dal.GetList(purchaseCode, zhujima);
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                logModel.result = 0;
                throw ex;
            }
            finally
            {
                lb.Add(logModel);
            }
            return dt;
        }
        public decimal GetCheckNumber(string purchaseCode, string code)
        {
            decimal result = 0;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseDetail",
                operationTime = DateTime.Now,
                objective = "查询采购明细表",
                operationContent = string.Format("查询T_PurchaseDetail表的数据,条件为:purchaseCode={0},code={1}", purchaseCode, code)
            };
            try
            {
                if (string.IsNullOrWhiteSpace(purchaseCode) && string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception("-2");
                }
                result = _dal.GetCheckNumber(purchaseCode, code);
                logModel.result = 1;
            }
            catch (Exception ex)
            {
                logModel.result = 0;
                throw ex;
            }
            finally
            {
                lb.Add(logModel);
            }
            return result;
        }
        public DataTable GetListAndMaterial(string fieldValue)
        {
            DataTable dt = null;
            LogBase lb = new LogBase();
            Log logModel = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseDetail",
                operationTime = DateTime.Now,
                objective = "查询采购明细表",
                operationContent = string.Format("查询T_PurchaseDetail表的数据,条件为:物料名，助记码，物料代码，参数：fieldValue=", fieldValue)
            };
            try
            {
                dt = _dal.GetList("", "");
                if (!string.IsNullOrWhiteSpace(fieldValue))
                {
                    DataView view = null;
                    view = new DataView();
                    view.Table = dt;
                    view.RowFilter = string.Format("materialName like '%{0}%'", fieldValue);//itemType是A中的一个字段
                    DataTable dt1 = view.ToTable();

                    view = new DataView();
                    view.Table = dt;
                    view.RowFilter = string.Format("zhujima like '%{0}%'", fieldValue);//itemType是A中的一个字段
                    DataTable dt2 = view.ToTable();

                    view = new DataView();
                    view.Table = dt;
                    view.RowFilter = string.Format("materialDaima like '%{0}%'", fieldValue);//itemType是A中的一个字段
                    DataTable dt3 = view.ToTable();

                    view = new DataView();
                    view.Table = dt;
                    view.RowFilter = string.Format("barCode like '%{0}%'", fieldValue);//itemType是A中的一个字段
                    DataTable dt4 = view.ToTable();

                    dt1.Merge(dt2);
                    dt1.Merge(dt3);
                    dt = dt1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public bool Exists(string code)
        {
            bool isflag = false;
            Log model = new Log()
            {
                code = BuildCode.ModuleCode("log"),
                operationCode = "操作人code",
                operationName = "操作人名",
                operationTable = "T_PurchaseDetail",
                operationTime = DateTime.Now,
                objective = "查询指定code的数据是否存在",
                operationContent = "查询数据"
            };
            try
            {
                isflag=_dal.Exists(code);
                model.result = 1;
            }
            catch (Exception ex)
            {
                model.result = 0;
                throw ex;
            }
            finally
            {
                _logDal.Add(model);
            }
            return isflag;
        }
    }
}