using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HostManager
{
    public partial class ucHostDetails : UserControl
    {
        public ucHostDetails()
        {
            InitializeComponent();

            Init();
        }

        Host m_Host = null;
        List<Tag> m_TagList = null;
        List<Tag> m_NewTagList = null;
        List<ComboBox> m_CmbList = null;
        List<String> m_OSList = null;

        internal Host GetHost()
        {
            return m_Host;
        }

        internal List<Tag> GetNewTagList()
        {
            return m_NewTagList;
        }

        void Init()
        {
            m_OSList = new List<string>() {"CentOS","Ubuntu" };
            m_CmbList = new List<ComboBox>() { cmbTag1, cmbTag2, cmbTag3, cmbTag4, cmbTag5, cmbTag6, cmbTag7, cmbTag8 };
        }

        void ClearData()
        {
            m_NewTagList = null;
            tbCPU.Text = tbDisk.Text = tbIP.Text = tbMemory.Text = tbName.Text = tbPasswd.Text = tbRootPasswd.Text = tbUser.Text = "";
            tbPort.Text = "22";

            cmbOS.Items.Clear();
            cmbOS.Items.AddRange(m_OSList.ToArray());

            foreach (ComboBox cmb in m_CmbList)
            {
                cmb.Items.Clear();
            }
        }

        int FindOSIndex(String os)
        {
            for (int i = 0; i < m_OSList.Count; i++)
            {
                if(string.Equals(os, m_OSList[i], StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return -1;
        }

        Boolean ValidData()
        {
            return true;
        }

        internal void UpdateData(Host host, List<Tag> tagList)
        {
            ClearData();
            if (host==null)
            {
                return;
            }
            m_Host = host;

            tbCPU.Text = Convert.ToString(m_Host.CPU);
            tbDisk.Text = Convert.ToString(m_Host.Disk);
            tbIP.Text = m_Host.IP;
            tbMemory.Text = Convert.ToString(m_Host.Memory);
            tbName.Text = m_Host.Name;
            tbPasswd.Text = m_Host.Passwd;
            tbPort.Text = Convert.ToString(m_Host.Port);
            tbRootPasswd.Text = m_Host.RootPasswd;
            tbUser.Text = m_Host.User;
            rtbRemark.Text = m_Host.Remark;
            cmbOS.SelectedIndex=FindOSIndex(m_Host.OS);

            m_TagList = tagList;
            if (tagList == null)
            {
                m_TagList = new List<Tag>();
            }
            for (int i = 0; i < m_CmbList.Count; i++)
            {
                ComboBox cmb = m_CmbList[i];
                foreach (Tag tag in m_TagList)
                {
                    cmb.Items.Add(tag.Name);
                }
                if (i < host.Tags.Count)
                {
                    cmb.SelectedItem = host.Tags[i].Name;
                }
            }

        }
    }
}