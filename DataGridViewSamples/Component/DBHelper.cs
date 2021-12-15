using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DataGridViewSamples
{
    /// <summary>
    /// �ṩ�Ե���Sql Server���ݿ�ĸ��ֲ���
    /// </summary>
    /// �� �� ��: Anders
    /// ��������: 2006-11-17
    /// �� �� ��: 
    /// �޸�����: 
    /// �޸�����: 
    /// ��    ��: 1.0.0
    public class DBHelper
    {
        private SqlConnection _conn;
        private static DBHelper instance;

        //private static string connString = "server=(local);database=testbase;uid=sa;pwd=admin";
        private static string connString = ConfigReader.GetConfig("DefaultConnString");
        //for Parameters cashing mechanism
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        private static readonly string RETURNVALUE = "RETURNVALUE";

        private DBHelper()
        {
            _conn = new SqlConnection(connString);
        }

        /// <summary>
        /// Get the default database, using singleton pattern:)
        /// </summary>
        /// <returns>current database instance</returns>
        public static DBHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (typeof(DBHelper))
                    {
                        if (instance == null)
                        {
                            instance = new DBHelper();
                        }
                    }
                }

                return instance;
            }
        }

        #region ExecuteReader : Return a single DataReader

        public SqlDataReader ExecuteReader(string commandText)
        {
            return ExecuteReader(CommandType.Text, commandText, (SqlParameter[])null);
        }

        public SqlDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return ExecuteReader(commandType, commandText, (SqlParameter[])null);
        }

        /// <summary>
        /// ʹ��using����Թرն�ռ����
        /// </summary>
        /// <param name="cmdType">��������</param>
        /// <param name="cmdText">�����ı�����</param>
        /// <param name="cmdParms">�����������</param>
        /// <example>
        ///		DataGrid1.DataSource = DBHelper.Instance.ExecuteReader(CommandType.Text, "Select ID, Name From Employees", (SqlParameter[])null);
        /// </example>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                PrepareCommand(cmd, null, cmdType, cmdText, cmdParms);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch (Exception ex)
            {
                _conn.Close();
                throw ex;
            }
            finally
            {
                _conn.Close();
            }
        }

        public SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, SqlParameter[] cmdParms, bool useTrans)
        {
            SqlCommand cmd = _conn.CreateCommand();

            SqlTransaction trans = null;
            if (useTrans)
            {
                trans = _conn.BeginTransaction();
            }

            try
            {
                PrepareCommand(cmd, trans, cmdType, cmdText, cmdParms);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();

                //Commit current transaction
                if (useTrans)
                {
                    trans.Commit();
                }

                return rdr;
            }
            catch (Exception ex)
            {
                if (useTrans)
                {
                    trans.Rollback();
                }

                Close();
                throw ex;
            }
        }

        #endregion

        #region ExecuteScalar : Return a single value(object)

        public object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(CommandType.Text, cmdText, null);
        }

        public object ExecuteScalar(CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(cmdType, cmdText, null);
        }

        /// <summary>
        /// Executes a sqlCommand and return a single value(object) without using transaction
        /// </summary>
        public object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = _conn.CreateCommand();

            try
            {
                PrepareCommand(cmd, null, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                return val;
            }
            catch (Exception ex)
            {
                Close();
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Executes a sqlCommand and return a single value(object), we can use transaction by assign true to parameter 'useTrans'
        /// </summary>
        public object ExecuteScalar(CommandType cmdType, string cmdText, SqlParameter[] cmdParms, bool useTrans)
        {
            SqlCommand cmd = _conn.CreateCommand();

            //Initialize transaction
            SqlTransaction trans = null;
            if (useTrans)
            {
                trans = _conn.BeginTransaction();
            }

            try
            {
                PrepareCommand(cmd, trans, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                if (useTrans)
                {
                    trans.Commit();
                }
                return val;
            }
            catch (Exception ex)
            {
                if (useTrans)
                {
                    trans.Rollback();
                }

                Close();
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        #endregion

        #region ExecuteNonQuery : Return the number of lines affected!

        public int ExecuteNonQuery(string cmdText)
        {
            return this.ExecuteNonQuery(CommandType.Text, cmdText, (SqlParameter[])null);
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText)
        {
            return this.ExecuteNonQuery(cmdType, cmdText, (SqlParameter[])null);
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = _conn.CreateCommand();

            try
            {
                PrepareCommand(cmd, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
            catch (Exception ex)
            {
                Close();
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        public int ExecuteNonQuery(CommandType cmdType, string cmdText, SqlParameter[] cmdParms, bool useTrans)
        {
            SqlCommand cmd = _conn.CreateCommand();

            SqlTransaction trans = null;
            if (useTrans)
            {
                trans = _conn.BeginTransaction();
            }

            try
            {
                PrepareCommand(cmd, trans, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                if (useTrans)
                {
                    trans.Commit();
                }
                return val;
            }
            catch (Exception ex)
            {
                if (useTrans)
                {
                    trans.Rollback();
                }

                Close();
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        #endregion

        #region ExecuteDataSet : Return a DataSet

        public DataSet ExecuteDataSet(string cmdText)
        {
            return this.ExecuteDataSet(CommandType.Text, cmdText, (SqlParameter[])null);
        }

        public DataSet ExecuteDataSet(CommandType cmdType, string cmdText)
        {
            return this.ExecuteDataSet(cmdType, cmdText, (SqlParameter[])null);
        }

        public DataSet ExecuteDataSet(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //����һ��SqlCommand���󣬲�������г�ʼ��
            SqlCommand cmd = new SqlCommand();

            try
            {
                PrepareCommand(cmd, (SqlTransaction)null, commandType, commandText, commandParameters);

                //����SqlDataAdapter�����Լ�DataSet
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                //���ds
                da.Fill(ds);

                // ���cmd�Ĳ�������	
                cmd.Parameters.Clear();

                //����ds
                return ds;
            }
            catch (Exception ex)
            {
                Close();
                throw ex;
            }
            finally
            {
                Close();
            }
        }

        public DataSet ExecuteDataSet(CommandType commandType, string commandText, SqlParameter[] commandParameters, bool useTrans)
        {
            //����һ��SqlCommand���󣬲�������г�ʼ��
            SqlCommand cmd = _conn.CreateCommand();

            SqlTransaction trans = null;
            if (useTrans)
            {
                trans = _conn.BeginTransaction();
            }

            try
            {
                PrepareCommand(cmd, trans, commandType, commandText, commandParameters);

                //����SqlDataAdapter�����Լ�DataSet
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                //���ds
                da.Fill(ds);

                // ���cmd�Ĳ�������	
                cmd.Parameters.Clear();

                if (useTrans)
                {
                    trans.Commit();
                }
                //����ds
                return ds;
            }
            catch (Exception ex)
            {
                if (useTrans)
                {
                    trans.Rollback();
                }

                Close();
                throw ex;
            }
            finally
            {
                Close();
            }
        }


        #endregion

        #region TODO: ExecuteXmlReader

        #endregion ExecuteXmlReader

        #region TODO: ExecProc : Execute a Stored Procedure

        /// <summary>
        /// ATODO:
        /// </summary>
        /// <param name="procName"></param>
        /// <returns></returns>
        public int ExecProc(string procName)
        {
            return 0;
        }

        public int ExecProc(string procName, SqlParameter[] paras)
        {
            return 0;
        }

        public SqlDataReader ExecProcReader(string procName)
        {
            return this.ExecuteReader(CommandType.StoredProcedure, procName);
        }

        public SqlDataReader ExecProcReader(string procName, SqlParameter[] paras)
        {
            return this.ExecuteReader(CommandType.StoredProcedure, procName, paras);
        }

        public DataSet ExecProcDataSet(string procName)
        {
            return this.ExecuteDataSet(CommandType.StoredProcedure, procName);
        }

        public DataSet ExecProcDataSet(string procName, SqlParameter[] paras)
        {
            return this.ExecuteDataSet(CommandType.StoredProcedure, procName, paras);
        }

        #endregion ExecProc : Execute a Stored Procedure

        #region Public Properties

        public string DBName
        {
            get
            {
                return _conn.Database;
            }
        }

        public string ConnString
        {
            get
            {
                return _conn.ConnectionString;
            }
        }

        public string DataSource
        {
            get
            {
                return _conn.DataSource;
            }
        }

        //get the sql server's version string
        public string ServerVersion
        {
            get
            {
                return _conn.ServerVersion;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void Close()
        {
            if (_conn != null)
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                _conn.Dispose();
                _conn = null;
            }
        }

        /// <summary>
        /// ����ǰ�����ݿ����ָ���Ĭ�ϳ�ʼ״̬
        /// </summary>
        public void Refresh()
        {
            this.Close();
            this.Dispose();

            DBHelper.instance = null;
        }

        #endregion Public Methods

        #region Private Methods

        private void PrepareCommand(SqlCommand cmd, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            //�ж����ӵ�״̬������ǹر�״̬�����
            if (_conn.State != ConnectionState.Open)
                _conn.Open();
            //cmd���Ը�ֵ
            cmd.Connection = _conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            //�������ʱʱ�䣬Ĭ��Ϊ30�룬�������ִ��ʱ��ܳ������Ӧ�޸���������� ^_^
            //���Խ�������д��config�ļ���˴�����Ϊ300��
            cmd.CommandTimeout = 300;

            //���cmd��Ҫ�Ĵ洢���̲���
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }

            //�Ƿ���Ҫ�õ�������
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
        }

        #endregion Private Methods

        #region Static Methods

        public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        #endregion
    }
}
