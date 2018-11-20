using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.IO;
using System.Threading;
using Mono.Data.Sqlite;
using Renci.SshNet;
using HostTools;

namespace HostManager
{
    /// <summary>
    /// 操作Sqilte数据库
    /// </summary>
    sealed class SqliteOperation :IDbTools
    {
        string m_DbFile = "host.db";
        private static readonly Lazy<SqliteOperation> lazy =
        new Lazy<SqliteOperation>(() => new SqliteOperation());
        List<String> m_InitSqlList = new List<string>();

        public static SqliteOperation Instance { get { return lazy.Value; } }

        private SqliteOperation()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            m_DbFile = System.IO.Path.Combine(assemblyFolder, m_DbFile);

            InitDb(m_DbFile);
            InitSql();
            UpdateTables();
        }
        public String GetDbFile()
        { return m_DbFile; }

        void InitSql()
        {
            m_InitSqlList.Clear();
            m_InitSqlList.Add("create table tag (id integer PRIMARY KEY  AUTOINCREMENT, name)");
            m_InitSqlList.Add("create table host (id integer PRIMARY KEY  AUTOINCREMENT,ip,port, name,user,passwd,rootpasswd,os,cpu,memory,disks)");
            m_InitSqlList.Add("create table host_tag (id integer PRIMARY KEY  AUTOINCREMENT, host_id, tag_id)");
            m_InitSqlList.Add("create table parameters (id integer PRIMARY KEY  AUTOINCREMENT, sys_key, sys_value)");
        }

        void UpdateTables()
        {
            //get update flag
            DataTable dt = Query("select sys_value from parameters where sys_key='update'");
            if (dt != null && dt.Rows.Count != 0)
            {
                int flag = 0;
                int.TryParse(Convert.ToString(dt.Rows[0][0]), out flag);
                if (flag == 1)
                {
                    try
                    {
                        File.Delete(m_DbFile);
                    }
                    catch
                    {
                    }
                    BatProcess(m_InitSqlList);
                }
            }
        }

        string m_ConnectString = "";
        SqliteConnection m_Conn;
        SqliteDataAdapter m_DataAdapter;
        SqliteCommand m_Command;//
        string m_Passwd = "";
        string m_LastErrorMsg = "";
        bool m_Busy = false;
        Random m_Rd = new Random();
        int MAX_TIME_SEC = 30;

        public string LastErrorMsg
        {
            get { return m_LastErrorMsg; }
        }

        ///构造函数
        /// <summary>
        /// 构造sqlite对象
        /// </summary>
        /// <param name="SqliteDbName">包含路径和文件名</param>
        void InitDb(string SqliteDbName)
        {
            if (!System.IO.File.Exists(SqliteDbName))
            {
                CreateSQLiteDB(SqliteDbName, "");
            }
            ConnectionInit(SqliteDbName, "");
        }

        /// <summary>
        /// 构造sqlite对象
        /// </summary>
        /// <param name="SqliteDbName">包含路径和文件名</param>
        /// <param name="Passwd">密码</param>
        void InitDb(string SqliteDbName, string Passwd)
        {
            if (!System.IO.File.Exists(SqliteDbName))
            {
                CreateSQLiteDB(SqliteDbName, Passwd);
            }

            ConnectionInit(SqliteDbName, Passwd);
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="SqliteDbName"></param>
        /// <param name="Passwd"></param>
        void CreateSQLiteDB(string SqliteDbName, string Passwd)
        {
            //创建文件j
            SqliteConnection.CreateFile(SqliteDbName);
            //初始化连接
            ConnectionInit(SqliteDbName, "");
            //设置密码
            ChangePasswd(Passwd);
        }

        /// <summary>
        /// 初始化连接
        /// </summary>
        /// <param name="SqliteDbName"></param>
        /// <param name="Passwd"></param>
        void ConnectionInit(string SqliteDbName, string Passwd)
        {
            m_LastErrorMsg = "";
            try
            {
                m_ConnectString = "Data Source=" + SqliteDbName;
                m_Conn = new SqliteConnection(m_ConnectString);
                m_Command = m_Conn.CreateCommand();
                m_Passwd = Passwd;
            }
            catch (Exception e)
            {
                m_LastErrorMsg = e.Message;
                System.Diagnostics.Debug.Print(e.Message);
                ShutDown();
            }
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="Passwd"></param>
        /// <returns></returns>
        public bool ChangePasswd(string Passwd)
        {
            m_LastErrorMsg = "";
            try
            {
                ConnectToDB();
                m_Conn.ChangePassword(Passwd);
                ShutDown();
                return true;
            }
            catch (Exception e)
            {
                m_LastErrorMsg = e.Message;
                System.Diagnostics.Debug.Print(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <returns></returns>
        public bool TestDB()
        {
            if (ConnectToDB())
            {
                ShutDown();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 连接到数据库
        /// </summary>
        private bool ConnectToDB()
        {
            m_LastErrorMsg = "";
            try
            {
                if (m_Conn.State != ConnectionState.Open)
                {
                    m_Conn.SetPassword(m_Passwd);
                    m_Conn.Open();
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                m_LastErrorMsg = e.Message;
                System.Diagnostics.Debug.Print(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        private void ShutDown()
        {
            m_Busy = false;
            m_Conn.Close();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="QueryCmd">查询命令</param>
        /// <returns></returns>
        public DataTable Query(string QueryCmd)
        {
            //判断是否有其它线程正在操作
            SetExclusive();

            m_LastErrorMsg = "";
            if (!QueryCmd.TrimStart(' ').ToLower().StartsWith("select"))
            {
                System.Diagnostics.Debug.Print("查询命令不正确！");
                return null;
            }
            //连接到数据库
            ConnectToDB();

            try
            {
                m_DataAdapter = new SqliteDataAdapter(QueryCmd, m_Conn);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                m_DataAdapter.Fill(table);

                //关闭数据库
                ShutDown();
                return table;
            }
            catch (Exception e)
            {
                ShutDown();
                m_LastErrorMsg = e.Message;
                System.Diagnostics.Debug.Print("数据查询出错！\r\n原因：" + e.Message);
                return null;
            }

        }

        /// <summary>
        /// 批量操作
        /// </summary>
        /// <param name="InstertCmdList"></param>
        /// <returns></returns>
        public bool BatProcess(List<string> BatCmdList)
        {
            if (BatCmdList == null || BatCmdList.Count == 0)
            {
                return true;
            }

            //判断是否有其它线程正在操作
            SetExclusive();

            m_LastErrorMsg = "";
            //连接
            ConnectToDB();

            SqliteTransaction transcation = m_Conn.BeginTransaction();
            try
            {
                int count = BatCmdList.Count + 1;
                for (int i = 1; i < count; i++)
                {
                    OutputDebugMsg(BatCmdList[i - 1]);

                    m_Command.CommandText = BatCmdList[i - 1];
                    m_Command.ExecuteNonQuery();

                    //if (i % 10000 == 0)
                    //{
                    //    transcation.Commit();
                    //    transcation = m_Conn.BeginTransaction();
                    //}
                }
                transcation.Commit();
            }
            catch (Exception e)
            {
                m_LastErrorMsg = e.Message;
                //回滚
                transcation.Rollback();

                //关闭
                ShutDown();
                return false;
            }

            //关闭
            ShutDown();
            return true;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="InsertCmd"></param>
        /// <returns></returns>
        public bool InsertData(string InsertCmd)
        {
            if (!InsertCmd.TrimStart(' ').ToLower().StartsWith("insert"))
            {
                System.Diagnostics.Debug.Print("插入命令不正确！");
                return false;
            }

            return ExecuteSql(InsertCmd);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="DeleteCmd"></param>
        /// <returns></returns>
        public bool DeleteData(string DeleteCmd)
        {
            if (!DeleteCmd.TrimStart(' ').ToLower().StartsWith("delete"))
            {
                System.Diagnostics.Debug.Print("删除命令不正确！");
                return false;
            }

            return ExecuteSql(DeleteCmd);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="UpdateCmd"></param>
        /// <returns></returns>
        public bool UpdateData(string UpdateCmd)
        {
            if (!UpdateCmd.TrimStart(' ').ToLower().StartsWith("update"))
            {
                System.Diagnostics.Debug.Print("更新数据命令不正确！");
                return false;
            }

            return ExecuteSql(UpdateCmd);
        }

        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <param name="SqlCmd"></param>
        /// <returns></returns>
        public bool ExecuteSql(string SqlCmd)
        {
            //判断是否有其它线程正在操作
            SetExclusive();

            OutputDebugMsg(SqlCmd);

            m_LastErrorMsg = "";
            //连接到数据库
            ConnectToDB();
            try
            {
                m_Command.CommandText = SqlCmd;
                m_Command.ExecuteNonQuery();
                //关闭数据库
                ShutDown();
            }
            catch (Exception e)
            {
                ShutDown();
                m_LastErrorMsg = e.Message;
                System.Diagnostics.Debug.Print("Sql语句执行失败！\r\n原因：" + e.Message);

                return false;
            }

            return true;
        }

        /// <summary>
        /// 压缩数据库
        /// </summary>
        public void CompressDB()
        {
            ExecuteSql("vacuum");
        }

        void SetExclusive()
        {
            DateTime dt = DateTime.Now;
            while (m_Busy)
            {
                //如果其它操作正在进行，延时
                Thread.Sleep(m_Rd.Next(1, 150));

                //如果超时了，也跳出
                if ((DateTime.Now - dt).TotalSeconds > MAX_TIME_SEC)
                {
                    break;
                }
            }
            m_Busy = true;
        }

        void OutputDebugMsg(string FunctionName)
        {
            //System.Diagnostics.Debug.Print("操作sqlite: " + FunctionName);
        }

        public bool BakDb(Host FileServerHost)
        {
            string old_FileName = m_DbFile;
            string dbFile_ext = Path.GetExtension(old_FileName);
            string new_FileName = Path.GetFileNameWithoutExtension(old_FileName) +
                                    DateTime.Now.ToString("yy-MM-dd_HH-mm-ss") + dbFile_ext;

            System.IO.File.Move(old_FileName, new_FileName);
            using (var client = new ScpClient(FileServerHost.IP, FileServerHost.User, FileServerHost.Passwd))
            {
                client.Connect();
                client.Download("/app/fileserver/www/" + Path.GetFileName(old_FileName), new FileInfo(old_FileName));
            }
            return true;
        }

        public bool RecoverDb(Host FileServerHost)
        {
            string old_FileName = m_DbFile;
            string dbFile_ext = Path.GetExtension(old_FileName);
            string new_FileName = Path.GetFileNameWithoutExtension(old_FileName) +
                                    DateTime.Now.ToString("yy-MM-dd_HH-mm-ss") + dbFile_ext;

            System.IO.File.Copy(old_FileName, new_FileName);

            using (var client = new ScpClient(FileServerHost.IP, FileServerHost.User, FileServerHost.Passwd))
            {
                client.Connect();
                client.Upload(new FileInfo(old_FileName), "/app/fileserver/www/" + Path.GetFileName(old_FileName));
                client.Upload(new FileInfo(new_FileName), "/app/fileserver/www/" + Path.GetFileName(new_FileName));
            }
            return true;
        }

    }
}