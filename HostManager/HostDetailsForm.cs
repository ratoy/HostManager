using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HostManager
{
    public partial class HostDetailsForm : Form
    {
        Host m_Host = null;
        List<Tag> m_TagList = null;
        List<Tag> m_NewTagList = null;
        List<ComboBox> m_CmbList = null;

        public HostDetailsForm()
        {
            InitializeComponent();

            Init();
        }

        void Init()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            m_CmbList = new List<ComboBox>() { cmbTag1, cmbTag2, cmbTag3, cmbTag4, cmbTag5, cmbTag6, cmbTag7, cmbTag8 };
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            ValidData();
            this.DialogResult = DialogResult.OK;
        }

        void ClearData()
        {
            m_NewTagList = null;
            tbCPU.Text = tbDisk.Text = tbIP.Text = tbMemory.Text = tbName.Text = tbPasswd.Text = tbRootPasswd.Text = tbUser.Text = "";
            tbPort.Text = "22";

            cmbOS.Items.Clear();
            cmbOS.Items.Add("CentOS");
            cmbOS.Items.Add("Ubuntu");

            foreach (ComboBox cmb in m_CmbList)
            {
                cmb.Items.Clear();
            }

        }

        Boolean ValidData()
        {
            return true;
        }

        internal void UpdateData(Host host, List<Tag> tagList)
        {
            ClearData();
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
