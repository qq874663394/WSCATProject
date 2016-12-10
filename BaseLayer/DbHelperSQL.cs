using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
namespace BaseLayer
{
    /// <summary>
    /// 数据访问抽象基础类
    /// Copyright (C) Maticsoft 
    /// </summary>
    public abstract class DbHelperSQL
    {
        //数据库连接字符串(web.config来配置)，多数据库可使用DbHelperSQLP来实现.
        public static readonly string connectionString = ConfigurationManager.AppSettings["WSCAT"];
        public DbHelperSQL()
        {
        }
        ///public static readonly string strCon = "字符串";  
        /// <summary>  
        /// 打开数据库连接  
        /// </summary>  
        public static SqlConnection Conn
        {
            get
            {
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                }
                catch
                {
                    throw new Exception("-0");
                }
                return conn;
            }
        }

        #region 公用方法
        /// <summary>
        /// 判断是否存在某表的某个字段
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="columnName">列名称</param>
        /// <returns>是否存在</returns>
        public static bool ColumnExists(string tableName, string columnName)
        {
            string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
            object res = GetSingle(sql);
            if (res == null)
            {
                return false;
            }
            return Convert.ToInt32(res) > 0;
        }
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString()); //也可能=0
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool TabExists(string TableName)
        {
            string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
            object obj = GetSingle(strsql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 查询单行单列，false不存在，true存在
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = Conn)
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch
                    {
                        throw new Exception("-1");
                    }
                }
            }
        }

        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            using (SqlConnection connection = Conn)
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch
                    {
                        throw new Exception("-1");
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = Conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch
                {
                    tx.Rollback();
                    return 0;
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = Conn)
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                SqlParameter myParameter = new SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {

                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch
                {
                    throw new Exception("-1");
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            using (SqlConnection connection = Conn)
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {

                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch
                {
                    throw new Exception("-1");
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 执行带一个带参数的存储过程。
        /// </summary>
        /// <param name="SQLString">存储过程</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlPar(string proc, string code)
        {
            using (SqlConnection connection = Conn)
            {
                SqlCommand cmd = new SqlCommand(proc, connection);//调用存储过程
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter prar = new SqlParameter();//传递参数
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;//获取存储过程的返回值
                cmd.ExecuteNonQuery();
                string value = cmd.Parameters["@RETURN_VALUE"].Value.ToString();//把返回值赋值给value
                cmd.Dispose();
                connection.Close();
                if (value == "1")

                {
                    //删除成功
                    return 1;
                }

                else

                {
                    //删除失败
                    return 0;
                }

            }
        }
        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, SqlParameter[] sps)
        {
            using (SqlConnection connection = Conn)
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                cmd.Parameters.AddRange(sps);
                try
                {

                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch
                {
                    throw new Exception("-1");
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = Conn)
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch
                    {
                        throw new Exception("-1");
                    }
                }
            }
        }
        public static object GetSingle(string SQLString, int Times)
        {
            using (SqlConnection connection = Conn)
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {

                        cmd.CommandTimeout = Times;
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch
                    {
                        throw new Exception("-1");
                    }
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = Conn;
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {

                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch
            {
                throw new Exception("-1");
            }
        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = Conn)
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch
                {
                    throw new Exception("-1");
                }
                return ds;
            }
        }
        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = Conn)
            {
                DataSet ds = new DataSet();
                try
                {

                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch
                {
                    throw new Exception("-1");
                }
                return ds;
            }
        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = Conn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch
                    {
                        throw new Exception("-1");
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = Conn)
            {
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw new Exception("-1");
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。并在其中有一条多影响行数的多参数语句
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        /// <param name="sqlstr">对某表插入多条数据的sql</param>
        /// <param name="paraList">插入多条数据的sql的参数集合</param>
        /// <param name="isState">是否新增</param>
        public static object ExecuteSqlTranScalar(Hashtable SQLStringList, string sqlstr, List<SqlParameter[]> paraList)
        {
            object val1 = null;
            object val2 = null;
            using (SqlConnection conn = Conn)
            {
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        if (paraList.Count > 0)
                        {
                            try
                            {
                                //循环
                                foreach (DictionaryEntry myDE in SQLStringList)
                                {
                                    string cmdText = myDE.Key.ToString();
                                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                                    val1 = cmd.ExecuteScalar();
                                    if (val1 == null || val1 == DBNull.Value)
                                    {
                                        throw new Exception("-3");
                                    }
                                    cmd.Parameters.Clear();
                                }
                            }
                            catch (Exception)
                            {
                                throw new Exception("7.1");
                            }
                            try
                            {
                                foreach (SqlParameter[] para in paraList)
                                {
                                    string cmdText = sqlstr;
                                    SqlParameter[] cmdParms = para;
                                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                                    val2 = cmd.ExecuteScalar();
                                    if (val1 == null || val1 == DBNull.Value)
                                    {
                                        throw new Exception("-3");
                                    }
                                    cmd.Parameters.Clear();
                                }
                            }
                            catch (Exception)
                            {
                                throw new Exception("7.2");
                            }
                        }
                        trans.Commit();
                        return val1;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。并在其中有一条多影响行数的多参数语句
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        /// <param name="sqlstr">对某表插入多条数据的sql</param>
        /// <param name="paraList">插入多条数据的sql的参数集合</param>
        /// <param name="isState">是否新增</param>
        public static object ExecuteSqlTranScalar(Hashtable SQLStringList, string sqlstr, string strInsert, List<SqlParameter[]> paraList)
        {
            int val1 = 0;
            int val2 = 0;
            using (SqlConnection conn = Conn)
            {
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        if (paraList.Count > 0)
                        {
                            try
                            {
                                //循环
                                foreach (DictionaryEntry myDE in SQLStringList)
                                {
                                    string cmdText = myDE.Key.ToString();
                                    SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                                    val1 = cmd.ExecuteNonQuery();
                                    if (val1 == 0)
                                    {
                                        throw new Exception("-3");
                                    }
                                    cmd.Parameters.Clear();
                                }
                            }
                            catch (Exception)
                            {
                                throw new Exception("7.1");
                            }
                            try
                            {
                                foreach (SqlParameter[] para  in paraList)
                                {
                                    string cmdText = sqlstr;
                                    SqlParameter[] cmdParms = para;
                                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                                    val2 = cmd.ExecuteNonQuery();
                                    if (val2 == 0)
                                    {
                                        cmdText = strInsert;
                                        cmdParms = para;
                                        for (int i = 0; i < cmdParms.Length; i++)
                                        {
                                            string str1 = "declare " + cmdParms[i];
                                            string str2 = "set " + cmdParms[i] + " = ";
                                            if (cmdParms[i].SqlDbType == SqlDbType.NVarChar)
                                            {
                                                str1 += " Nvarchar(MAX)";
                                                str2 += "'" + cmdParms[i].Value + "'";
                                            }
                                            if (cmdParms[i].SqlDbType == SqlDbType.DateTime)
                                            {
                                                str1 += " DateTime";
                                                str2 += "'" + cmdParms[i].Value + "'";
                                            }
                                            if (cmdParms[i].SqlDbType == SqlDbType.Int)
                                            {
                                                str1 += " Int";
                                                str2 += cmdParms[i].Value;
                                            }
                                            if (cmdParms[i].SqlDbType == SqlDbType.Decimal)
                                            {
                                                str1 += " Decimal(18,2)";
                                                str2 += cmdParms[i].Value;
                                            }
                                            Console.WriteLine(str1);
                                            Console.WriteLine(str2);
                                        }
                                        Console.WriteLine(cmdText.ToString());
                                        PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                                        val2 = cmd.ExecuteNonQuery();
                                        if (val2 == 0)
                                        {
                                            throw new Exception("-3");
                                        }
                                    }
                                    cmd.Parameters.Clear();
                                }
                            }
                            catch (Exception)
                            {
                                throw new Exception("7.2");
                            }
                        }
                        trans.Commit();
                        return val1;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            using (SqlConnection conn = Conn)
            {
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static int GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = Conn)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    }
                    catch
                    {
                        return -4;
                    }
                    try
                    {
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return -5;
                        }
                        else
                        {
                            return Convert.ToInt32(obj);
                        }
                    }
                    catch
                    {
                        return -6;
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = Conn;
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = Conn)
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = Conn;
            SqlDataReader returnReader;
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return returnReader;
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = Conn)
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                return dataSet;
            }
        }
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = Conn)
            {
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                return dataSet;
            }
        }


        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = Conn)
            {
                int result;

                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                return result;
            }
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion
    }
}