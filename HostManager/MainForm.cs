using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HostManager.service;

namespace HostManager
{
    public partial class MainForm : Form
    {
        HostService m_HostService = new HostService();
        TagService m_TagService = new TagService();
        List<Host> m_HostList = new List<Host>();
        Host m_CurrentHost = null;

        public MainForm()
        {
            InitializeComponent();

            Init();
        }

        void Init()
        {
            m_HostList = m_HostService.GetAllHosts();
            //init host tree
            InitHostTree(m_HostList);
            //init tag tree
            InitTagTree(m_HostList);

            //init details panel
            InitDetailsPanel();
        }

        void InitDetailsPanel()
        {
            this.btnHostApply.Click += new EventHandler(btnHostApply_Click);
        }

        void btnHostApply_Click(object sender, EventArgs e)
        {
            if (m_CurrentHost != null)
            {
                Host host = ucHostDetails1.GetHost();
                List<Tag> NewTagList = ucHostDetails1.GetNewTagList();

                m_HostService.EditHost(m_CurrentHost.Id, host);
                m_TagService.AddTag(NewTagList);
            }
        }

        void InitHostTree(List<Host> hostList)
        {
            tvHost.AfterSelect += new TreeViewEventHandler(tvHost_AfterSelect);
            tvHost.Nodes.Clear();
            TreeNode RootNode = new TreeNode("主机");

            hostList = m_HostService.GetAllHosts();
            foreach (Host host in hostList)
            {
                TreeNode tn = new TreeNode();
                tn.Text = host.IP;
                tn.Name = host.Name;
                tn.Tag = host;
                RootNode.Nodes.Add(tn);
            }

            RootNode.ExpandAll();
            tvHost.Nodes.Add(RootNode);
        }

        void InitTagTree(List<Host> hostList)
        {
            tvTag.AfterSelect += new TreeViewEventHandler(tvTag_AfterSelect);
            tvTag.Nodes.Clear();
            TreeNode RootNode = new TreeNode("主机");

            Dictionary<string, List<Host>> DictTagHost = new Dictionary<string, List<Host>>();
            List<Tag> TagList = m_TagService.GetAllTags();
            foreach (Tag tag in TagList)
            {
                DictTagHost[tag.Name] = new List<Host>();
            }

            foreach (Host h in hostList)
            {
                foreach (Tag tag in h.Tags)
                {
                    DictTagHost[tag.Name].Add(h);
                }
            }

            //add to tree
            foreach (KeyValuePair<String, List<Host>> kv in DictTagHost)
            {
                TreeNode TagTn = new TreeNode();
                TagTn.Text = kv.Key;
                TagTn.Name = kv.Key;


                kv.Value.Sort(new HostManager.dao.HostRepository.IPComparer()); ;

                foreach (Host h in kv.Value)
                {
                    TreeNode HostTn = new TreeNode();
                    HostTn.Text = h.IP;
                    HostTn.Name = h.Name;
                    HostTn.Tag = h;
                    TagTn.Nodes.Add(HostTn);
                }

                RootNode.Nodes.Add(TagTn);
            }

            RootNode.ExpandAll();

            tvTag.Nodes.Add(RootNode);
        }

        void tvHost_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnHostNodeChange(e.Node);
        }

        void tvTag_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnHostNodeChange(e.Node);
        }

        void OnHostNodeChange(TreeNode tn)
        {
            m_CurrentHost = null;
            if (tn.Nodes == null || tn.Nodes.Count == 0)
            {
                //leaf
                m_CurrentHost = tn.Tag as Host;
            }
            ucHostDetails1.UpdateData(m_CurrentHost, m_TagService.GetAllTags());
        }

    }
}
