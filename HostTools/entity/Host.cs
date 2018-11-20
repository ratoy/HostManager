using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostTools
{
    public class Host
    {
        public int Id { get; set; }
        public String IP { get; set; }
        public String Name { get; set; }
        public String User { get; set; }
        public String Passwd { get; set; }
        public String RootPasswd { get; set; }
        public String OS  {get; set; }
        public int Port { get; set; }
        public int CPU{ get; set; }
        public int Memory { get; set; }
        public int Disk { get; set; }
        public String Remark  {get; set; }

        public List<Tag> Tags { get; set; }

        public Host()
        {
            this.Id = -1;
            this.IP = this.Name = this.User = this.Passwd = this.RootPasswd = this.OS = this.Remark = "";
            this.Port = 22;
            this.CPU = this.Memory = this.Disk = 0;
            this.Tags = new List<Tag>();
        }

    }
}
