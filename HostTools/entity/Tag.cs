using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostTools
{
    public class Tag
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Tag(int Id,String Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Tag(String Name)
        {
            this.Name = Name;
        }
    }
}
