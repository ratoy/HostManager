﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using HostTools;
using HostTools.service;

namespace HostManager
{
    public partial class MainForm : Form
    {
        HostService m_HostService = null;
        TagService m_TagService = null;
        List<Host> m_HostList = new List<Host>();
        IDbTools m_DbTools = null;
        Host m_CurrentHost = null;

        public MainForm()
        {
            //db init
            m_DbTools = SqliteOperation.Instance;
            DbOperation.Create(m_DbTools);

            InitializeComponent();

            Init();
        }

        void Init()
        {
            m_HostService = new HostService();
            m_TagService = new TagService();

            this.tvHost.HideSelection = this.tvTag.HideSelection = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            m_HostList = m_HostService.GetAllHosts();
            //init host tree
            InitHostTree(m_HostList);
            //init tag tree
            InitTagTree(m_HostList);

            //init details panel
            InitDetailsPanel();

            //init cms
            InitCmsStrip();

            //init toolstrip
            InitToolStrip();
        }

        void InitToolStrip()
        {
            this.toolStrip1.ItemClicked += new ToolStripItemClickedEventHandler(toolStrip1_ItemClicked);
        }

        void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name.ToLower())
            {
                case "tsbnew":
                    NewHost();
                    break;
                case "tsbrefresh":
                    UpdateData();
                    break;
                case "tsbdelete":
                    DeleteHost();
                    break;
                case "tsbpull":
					PullDbFile();
                    break;
                case "tsbpush":
					PushDbFile();
                    break;
                default:
                    break;
            }
        }

        void UpdateData()
        {
            m_HostList = m_HostService.GetAllHosts();
            UpdateHostTree(m_HostList);
            UpdateTagTree(m_HostList);
        }

        void InitCmsStrip()
        {
            this.cmsHost.ItemClicked += new ToolStripItemClickedEventHandler(cmsHost_ItemClicked);
        }

        void cmsHost_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
			this.cmsHost.Hide();
            switch (e.ClickedItem.Name.ToLower())
            {
                case "tsminew":
                    NewHost();
                    break;
                case "tsmidelete":
                    DeleteHost();
                    break;
                case "tsmirefresh":
					UpdateData();
                    break;
                default:
                    break;
            }
        }

        void NewHost()
        {
            NewHostForm nhf = new NewHostForm();
            if (nhf.ShowDialog() == DialogResult.OK)
            {
                m_HostService.AddHost(nhf.GetHost());
                UpdateData();
                NotifyMsg("主机已添加");
            }
        }

        void DeleteHost()
        {
            if (MessageBox.Show("删除 Host", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                m_HostService.RemoveHost(m_CurrentHost.Id);
                UpdateData();
                NotifyMsg("主机已删除");
            }
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
                m_HostService.UpdateHost(m_CurrentHost.Id, host);
                UpdateData();
                NotifyMsg("主机已更新");
            }
        }

        void InitHostTree(List<Host> hostList)
        {
            tvHost.ContextMenuStrip = this.cmsHost;
            tvHost.AfterSelect += new TreeViewEventHandler(tvHost_AfterSelect);

            UpdateHostTree(hostList);
            NotifyMsg("主机初始化成功");
        }

        void UpdateHostTree(List<Host> hostList)
        {
            tvHost.Nodes.Clear();
            TreeNode RootNode = new TreeNode("主机");

            //hostList = m_HostService.GetAllHosts();
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
            tvTag.ContextMenuStrip = this.cmsHost;
            tvTag.AfterSelect += new TreeViewEventHandler(tvTag_AfterSelect);

            UpdateTagTree(hostList);
            NotifyMsg("主机分类初始化成功");
        }

        void UpdateTagTree(List<Host> hostList)
        {
            tvTag.Nodes.Clear();
            TreeNode RootNode = new TreeNode("主机");

            Dictionary<string, List<Host>> DictTagHost = m_TagService.GetTagHosts(hostList);

            //add to tree
            foreach (KeyValuePair<String, List<Host>> kv in DictTagHost)
            {
                TreeNode TagTn = new TreeNode();
                TagTn.Text = kv.Key;
                TagTn.Name = kv.Key;

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

            RootNode.Expand();

            tvTag.Nodes.Add(RootNode);
        }

        void tvHost_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnHostNodeChanged(e.Node);
        }

        void tvTag_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnHostNodeChanged(e.Node);
        }

        void OnHostNodeChanged(TreeNode tn)
        {
            m_CurrentHost = null;
            if (tn.Nodes == null || tn.Nodes.Count == 0)
            {
                //leaf
                m_CurrentHost = tn.Tag as Host;
	            NotifyMsg("当前主机：" + m_CurrentHost.Id);
            }
            ucHostDetails1.UpdateData(m_CurrentHost, m_TagService.GetAllTags());
        }

        void NotifyMsg(string msg)
        {
            msg = msg == null ? "就绪" : msg;
            tsslStatus.Text = msg;
        }

		Host FindByIP(string ip)
		{
			foreach (Host host in m_HostList)
			{
				if (host.IP==ip)
				{
					return host;
				}
			}
			return null;
		}

        void PullDbFile()
        {
            Host host = FindByIP("10.2.18.160");
            m_DbTools.BakDb(host);
            NotifyMsg("DbFile pulled!");
        }

        void PushDbFile()
        {
            Host host = FindByIP("10.2.18.160");
            m_DbTools.RecoverDb(host);
            NotifyMsg("DbFile pushed!");
        }
    }
}
