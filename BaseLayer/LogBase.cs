using HelperUtility.Encrypt;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLayer
{
    public class LogBase
    {
        public int Add(Log log)
        {
            string sql = "";
            try
            {
                sql = string.Format(@"INSERT INTO T_log
                       (code
                       , operationCode
                       , operationName
                       , operationTable
                       , operationTime
                        ,objective
                        ,operationContent
                        ,result)
                 VALUES
                       ('{0}'
                       ,'{1}'
                       ,'{2}'
                       ,'{3}'
                       ,'{4}'
                       ,'{5}'
                       ,'{6}'
                       ,{7})",
                        XYEEncoding.strCodeHex(log.code),
                        XYEEncoding.strCodeHex(log.operationCode),
                        XYEEncoding.strCodeHex(log.operationName),
                        XYEEncoding.strCodeHex(log.operationTable),
                        log.operationTime,
                        XYEEncoding.strCodeHex(log.objective),
                        XYEEncoding.strCodeHex(log.operationContent),
                        log.result);
            }
            catch
            {
                return -1;
            }
            return DbHelperSQL.ExecuteSql(sql);
        }
    }
}
