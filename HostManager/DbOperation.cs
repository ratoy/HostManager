using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace HostManager
{
    sealed class DbOperation
    {
		string m_DbFile =System.IO.Path.Combine(Application.StartupPath, "host.db");
        SQLiteOperation m_SqliteOpera = null;
        private static readonly Lazy<DbOperation> lazy =
            new Lazy<DbOperation>(() => new DbOperation());
        List<String> m_InitSqlList = new List<string>();

        public static DbOperation Instance { get { return lazy.Value; } }

        private DbOperation()
        {
            m_SqliteOpera = new SQLiteOperation(m_DbFile);

            InitSql();
            UpdateTables();
           
        }

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
            DataTable dt = m_SqliteOpera.Query("select sys_value from parameters where sys_key='update'");
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
                    m_SqliteOpera.BatProcess(m_InitSqlList);
                }
            }
        }

        public SQLiteOperation GetSqliteOpera()
        {
            return m_SqliteOpera;
        }

    }

}
