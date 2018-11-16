using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HostManager.dao
{
    class HostRepository
    {
        SQLiteOperation m_SqliteOpera = DbOperation.Instance.GetSqliteOpera();

        internal Host Save(Host host)
        {
            List<String> sqlList = new List<string>();
            StringBuilder sbuilder = new StringBuilder("insert into host(ip,port, name,user,passwd,rootpasswd,os,cpu,memory,disk,remark) values");
            sbuilder.AppendFormat("('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
                host.IP, host.Port, host.Name, host.User, host.Passwd, host.RootPasswd, host.OS,host.CPU,host.Memory,host.Disk,host.Remark);
            String sqlHost = sbuilder.ToString();
            m_SqliteOpera.InsertData(sqlHost);

            //query host id
            return GetHostByIP(host.IP);
        }

        internal void DeleteById(int HostId)
        {
            m_SqliteOpera.DeleteData("delete from host where id=" + HostId);
        }

        Host GetHostByIP(String ip)
        {
            DataTable dtHost = m_SqliteOpera.Query("select * from host where ip='" + ip + "'");
            Host host = null;
            foreach (DataRow dr in dtHost.Rows)
            {
                host = DataRowToHost(dr);
                break;
            }
            return host;
        }

        Host GetHostById(int id)
        {
            DataTable dtHost = m_SqliteOpera.Query("select * from host where id='" + id + "'");
            Host host = null;
            foreach (DataRow dr in dtHost.Rows)
            {
                host = DataRowToHost(dr);
                break;
            }
            return host;
        }

        Host DataRowToHost(DataRow dr)
        {
            Host host = new Host();
            host.Id = Convert.ToInt32(dr["id"]);
            host.IP = Convert.ToString(dr["ip"]);
            host.Port = Convert.ToInt32(dr["port"]);
            host.Name = Convert.ToString(dr["name"]);
            host.OS = Convert.ToString(dr["os"]);
            host.Passwd = Convert.ToString(dr["passwd"]);
            host.RootPasswd = Convert.ToString(dr["rootpasswd"]);
            host.User = Convert.ToString(dr["user"]);
            host.CPU= Convert.ToInt32(dr["cpu"]);
            host.Memory= Convert.ToInt32(dr["memory"]);
            host.Disk = Convert.ToInt32(dr["disk"]);
            host.Remark= Convert.ToString(dr["remark"]);

            return host;
        }

        internal List<Host> FindAll()
        {
            DataTable dtHost = m_SqliteOpera.Query("select * from host");
            List<Host> HostList = new List<Host>();
            foreach (DataRow dr in dtHost.Rows)
            {
                HostList.Add(DataRowToHost(dr));
            }
            HostList.Sort(new IPComparer()); ;
            return HostList;
        }

        internal void Update(int id, Host newHost)
        {
            Host oldHost = GetHostById(id);
            if (oldHost == null)
            {
                return;
            }

            StringBuilder sbuilder = new StringBuilder();
            sbuilder.AppendFormat("update host set ip='{0}', port={1},name='{2}',user='{3}',passwd='{4}',rootpasswd='{5}',os='{6}',cpu={7},memory={8},disk={9},remark='{10}' where id={11}",
                newHost.IP, newHost.Port, newHost.Name, newHost.User, newHost.Passwd, newHost.RootPasswd, newHost.OS,newHost.CPU,newHost.Memory,newHost.Disk,newHost.Remark, id);

            m_SqliteOpera.UpdateData(sbuilder.ToString());
        }

        public class IPComparer : IComparer<Host>
        {
            //实现姓名升序
            public int Compare(Host h1, Host h2)
            {
                return (h1.IP.CompareTo(h2.IP));
            }
        }


    }
}
