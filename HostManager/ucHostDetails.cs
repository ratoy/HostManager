using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HostManager.service;

namespace HostManager
{
    public partial class ucHostDetails : UserControl
    {
        public ucHostDetails()
        {
            InitializeComponent();

            Init();
        }

        TagService m_TagService = new TagService();
        Host m_Host = null;
        List<Tag> m_TagList = new List<Tag>();

        Dictionary<String, Tag> m_DictNameTag = new Dictionary<string, Tag>();
        List<ComboBox> m_CmbList = null;
        List<String> m_OSList = null;

        internal Host GetHost()
        {
            //handle new tags
            //get new tags
            List<Tag> newTags = GetNewTagList();
            //save to db
            m_TagService.AddTag(newTags);
            //get all tags
            List<Tag> allTags = m_TagService.GetAllTags();

            m_DictNameTag.Clear();
            foreach (Tag tag in allTags)
            {
                m_DictNameTag[tag.Name] = tag;
            }

            //read new properties
            ReadData();
            return m_Host;
        }

        List<Tag> GetNewTagList()
        {
            List<Tag> NewTagList = new List<HostManager.Tag>();
            List<String> currentTags = GetCurrentTagNames();

            foreach (String tagName in currentTags)
            {
                if (FindTagIndex(tagName)==-1)
                {
                    Tag tag = new Tag(tagName);
                    NewTagList.Add(tag);
                }
            }
            return NewTagList;
        }

        List<String> GetCurrentTagNames()
        { 
            List<String> currentTags = new List<string>();
            for (int i = 0; i < m_CmbList.Count; i++)
            {
                ComboBox cmb = m_CmbList[i];
                string tagName = Convert.ToString(cmb.SelectedItem);
                if (tagName != null && tagName.Trim().Length != 0)
                {
                    currentTags.Add(tagName);
                }
            }

            currentTags = currentTags.Distinct().ToList();
            return currentTags;       
        }

        int FindTagIndex(String TagName)
        {
            if (TagName == null || TagName.Trim().Length == 0)
            {
                return -2;
            }
            for (int i = 0; i < m_TagList.Count; i++)
            {
                if (string.Equals(m_TagList[i].Name, TagName, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        void Init()
        {
            m_OSList = new List<string>() { "CentOS", "Ubuntu" };
            m_CmbList = new List<ComboBox>() { cmbTag1, cmbTag2, cmbTag3, cmbTag4, cmbTag5, cmbTag6, cmbTag7, cmbTag8 };
        }

        void ClearData()
        {
            tbCPU.Text = tbDisk.Text = tbIP.Text = tbMemory.Text = tbName.Text = tbPasswd.Text = tbRootPasswd.Text = tbUser.Text = "";
            tbPort.Text = "22";

            cmbOS.Items.Clear();
            cmbOS.Items.AddRange(m_OSList.ToArray());

            foreach (ComboBox cmb in m_CmbList)
            {
                cmb.SelectedIndex = -1;
                cmb.Text = "";
                cmb.Items.Clear();
            }
        }

        int FindOSIndex(String os)
        {
            for (int i = 0; i < m_OSList.Count; i++)
            {
                if (string.Equals(os, m_OSList[i], StringComparison.OrdinalIgnoreCase))
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

        void ReadData()
        {
            m_Host.CPU = Convert.ToInt32(tbCPU.Text);
            m_Host.Disk = Convert.ToInt32(tbDisk.Text);
            m_Host.IP = tbIP.Text;
            m_Host.Memory = Convert.ToInt32(tbMemory.Text);
            m_Host.Name = tbName.Text;
            m_Host.Passwd = tbPasswd.Text;
            m_Host.Port = Convert.ToInt32(tbPort.Text);
            m_Host.RootPasswd = tbRootPasswd.Text;
            m_Host.User = tbUser.Text;
            m_Host.Remark = rtbRemark.Text;
            m_Host.OS = Convert.ToString(cmbOS.SelectedItem);

            List<String> currentTagNames = GetCurrentTagNames();
            m_Host.Tags.Clear();
            foreach (String tagNames in currentTagNames)
            {
                m_Host.Tags.Add(m_DictNameTag[tagNames]);
            }
        }

        internal void UpdateData(Host host, List<Tag> tagList)
        {
            ClearData();
            if (host == null)
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
            cmbOS.SelectedIndex = FindOSIndex(m_Host.OS);

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
                else
                {
                    cmb.SelectedIndex = -1;
                }
            }

        }
    }
}