using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.DBUtility
{
    public class MySqlHelper
    {
        //数据库连接字符串
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnectString"].ConnectionString;

        public MySqlConnection SqlConn;

        #region 数据库基本操作

        public MySqlHelper()
        {
            SqlConn = new MySqlConnection(ConnectionString);
        }

        public MySqlHelper(string conn)
        {
            SqlConn = new MySqlConnection(conn);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                return;
            }
            if (SqlConn != null)
            {
                SqlConn.Dispose();
                SqlConn = null;
            }
        }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void DBConnection()
        {
            try
            {
                //确认是否已打开连接，为打开则打开连接
                if (this.SqlConn.State != ConnectionState.Open)
                {
                    SqlConn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void DBClose()
        {
            try
            {
                //确认是否已打开连接，为打开则打开连接
                if (this.SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得查询结果
        /// </summary>
        /// <param name="sqlstr">SQL字符串</param>
        /// <returns></returns>
        public DataTable QuerySql(string sqlstr)
        {
            try
            {
                DataTable dt = null;
                try
                {
                    MySqlDataAdapter sqlda = new MySqlDataAdapter(sqlstr, ConnectionString);
                    try
                    {
                        dt = new DataTable();
                        sqlda.Fill(dt);
                    }
                    catch
                    {
                        sqlda.MissingMappingAction = MissingMappingAction.Ignore;
                    }
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获得查询结果
        /// </summary>
        /// <param name="sqlstr">SQL字符串</param>
        /// <returns></returns>
        public DataTable QuerySql(string sqlstr, string conn)
        {
            try
            {
                DataTable dt = null;
                MySqlDataAdapter sqlda = new MySqlDataAdapter(sqlstr, conn);
                dt = new DataTable();
                sqlda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 操作数据库(无返回值)
        /// </summary>
        /// <param name="sqlstr">操作SQL字符串</param>
        public int ExecuteNonQuerySQL(string sqlstr)
        {
            int i = 0;
            try
            {
                //确认是否已打开连接，为打开则打开连接
                if (this.SqlConn.State != ConnectionState.Open)
                {
                    SqlConn.Open();
                }
                MySqlCommand sqlcommand = new MySqlCommand(sqlstr, this.SqlConn);
                i = sqlcommand.ExecuteNonQuery();
                return i;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (this.SqlConn.State != ConnectionState.Closed)
                {
                    SqlConn.Close();
                }
            }
        }

        /// <summary>
        /// 操作数据库(无返回值)
        /// </summary>
        /// <param name="sqlstr">操作SQL字符串</param>
        public bool ExecuteBNonQuerySQL(string sqlstr, bool hostConnect = false)
        {
            try
            {
                //if (!PingHelper.PingConnectString(ConnectionString)) return false;
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    MySqlCommand sqlcommand = new MySqlCommand(sqlstr, conn);
                    sqlcommand.ExecuteNonQuery();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                ex.ToString();
                throw;
            }

        }

        /// <summary>
        /// 操作数据库(无返回值),调用该方法前要先打开数据库
        /// </summary>
        /// <param name="sqlstr">操作SQL字符串</param>
        /// <param name="IsOpen">操作类型：true:已打开数据库;false:数据库关闭</param>
        public void ExecuteNonQuerySQL(string sqlstr, bool IsOpen)
        {
            try
            {
                if (IsOpen)
                {
                    MySqlCommand sqlcommand = new MySqlCommand(sqlstr, this.SqlConn);
                    sqlcommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断是否存在数据
        /// </summary>
        /// <param name="sqlstr">SQL字符串</param>
        /// <returns>查询结果</returns>
        public bool b_QuerySql(string sqlstr)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(sqlstr, this.SqlConn);
                MySqlDataReader sqlda = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                return sqlda.GetBoolean(0);
            }
            catch (Exception ex)
            {
                DBClose();
                throw ex;
            }
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="TableName">数据库中数据表名</param>
        /// <param name="dt">数据源(DataTable)</param>

        //public void BulkInsert(string TableName, DataTable dt)
        //{
        //    try
        //    {
        //        SqlConn.Open();
        //        using (MySqlBulkCopy bulkcopy = new SqlBulkCopy(this.SqlConn))
        //        {
        //            bulkcopy.DestinationTableName = TableName;
        //            try
        //            {
        //                bulkcopy.WriteToServer(dt);
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine(ex.Message);
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        SqlConn.Close();
        //    }
        //}

        /// <summary>
        /// 处理存储过程并返回结果
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="prams">存储过程使用的命令参数</param>
        /// <returns>返回结果数据表</returns>
        public DataTable GetProceResult(string procName, MySqlParameter[] parameters)
        {
            try
            {
                // 确认数据库是否已打开
                if (this.SqlConn.State != ConnectionState.Open)
                {
                    SqlConn.Open();
                }

                MySqlCommand command = new MySqlCommand(procName, this.SqlConn);
                command.CommandType = CommandType.StoredProcedure;

                // 循环输入存储过程命令参数
                if (parameters != null)
                {
                    foreach (MySqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                MySqlParameter RtParameter = new MySqlParameter();
                RtParameter.Direction = ParameterDirection.ReturnValue;
                RtParameter.ParameterName = "ReturnValue";
                RtParameter.MySqlDbType = MySqlDbType.Int32;
                RtParameter.Size = 4;
                RtParameter.IsNullable = false;
                RtParameter.Precision = 0;
                RtParameter.Scale = 0;
                RtParameter.SourceColumn = string.Empty;
                RtParameter.SourceVersion = DataRowVersion.Default;
                RtParameter.Value = null;

                // 增加返回参数
                command.Parameters.Add(RtParameter);

                DataTable dt = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter(procName, this.SqlConn);
                adapter.SelectCommand = command;
                adapter.SelectCommand.CommandTimeout = 1000;
                adapter.Fill(dt);

                if (this.SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 处理存储过程(无返回值)
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="parameters">存储过程命令参数</param>
        public void ExecuteProcedure(string procName, MySqlParameter[] parameters)
        {
            // 确认数据库是否连接
            if (this.SqlConn.State != ConnectionState.Open)
            {
                SqlConn.Open();
            }
            try
            {
                MySqlCommand command = new MySqlCommand(procName, this.SqlConn);
                command.CommandType = CommandType.StoredProcedure;

                //反复输入命令参数
                if (parameters != null)
                {
                    foreach (MySqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                // 存储过程处理
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }
            }
        }

        public void ExecuteNonQuerySQLTran(List<string> sqlstrlist)
        {
            //确认是否已打开连接，为打开则打开连接
            if (this.SqlConn.State != ConnectionState.Open)
            {
                SqlConn.Open();
            }
            MySqlTransaction tran = SqlConn.BeginTransaction();
            MySqlCommand sqlcommand = SqlConn.CreateCommand();
            sqlcommand.Transaction = tran;
            try
            {
                foreach (string sqlstr in sqlstrlist)
                {
                    sqlcommand.CommandText = sqlstr;
                    sqlcommand.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch (MySqlException ex)
            {
                //Console.WriteLine(ex.Message);
                tran.Rollback();
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                if (this.SqlConn.State != ConnectionState.Closed)
                {
                    SqlConn.Close();
                }
            }
        }

        #endregion 数据库基本操作
    }
}
