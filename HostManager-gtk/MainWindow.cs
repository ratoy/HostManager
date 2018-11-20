using System;
using System.Collections.Generic;
using Gtk;
using HostTools;
using HostTools.service;
using HostManagergtk;

public partial class MainWindow : Gtk.Window
{
    HostService m_HostService = null;
    TagService m_TagService = null;
    List<Host> m_HostList = new List<Host>();
    IDbTools m_DbTools = null;
    Host m_CurrentHost = null;


    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        //db init
        m_DbTools = SqliteOperation.Instance;
        DbOperation.Create(m_DbTools);

        Build();
        Init();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    void Init()
    {
        m_HostService = new HostService();
        m_TagService = new TagService();

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

    void InitHostTree(List<Host> hostList)
    {
        this.tvHost.Selection.Changed += (sender, e) => {
            Gtk.TreeIter selected;
            if (this.tvHost.Selection.GetSelected(out selected))
            {
                OnHostNodeChanged(Convert.ToString(this.tvHost.Model.GetValue(selected, 0)));
            }
        };
        UpdateHostTree(hostList);
        NotifyMsg("主机初始化成功");
    }

    void OnHostNodeChanged(String HostIP)
    {
        m_CurrentHost =FindByIP(HostIP);
        if (m_CurrentHost!=null)
        {
            NotifyMsg("当前主机：" + m_CurrentHost.Id);
        }
        //ucHostDetails1.UpdateData(m_CurrentHost, m_TagService.GetAllTags());
    }

    void UpdateHostTree(List<Host> hostList)
    {
        TreeView tree = this.tvHost;

        TreeViewColumn tvcHost= new TreeViewColumn();
        tvcHost.Title = "";

        CellRendererText cell = new CellRendererText();
        tvcHost.PackStart(cell, true);
        tvcHost.AddAttribute(cell, "text", 0);

        TreeStore treestore = new TreeStore(typeof(string), typeof(string));

        TreeIter iter = treestore.AppendValues("主机");
        foreach (Host host in hostList)
        {
            treestore.AppendValues(iter, host.IP);
        }

        tree.AppendColumn(tvcHost);
        tree.Model = treestore;
        tree.ExpandAll();
    }

    void InitTagTree(List<Host> hostList)
    {
        this.tvTag.Selection.Changed += (sender, e) => {
            Gtk.TreeIter selected;
            if (this.tvHost.Selection.GetSelected(out selected))
            {
                OnHostNodeChanged(Convert.ToString(this.tvHost.Model.GetValue(selected, 0)));
            }
        };

        UpdateTagTree(hostList);
        NotifyMsg("主机分类初始化成功");
    }

    void UpdateTagTree(List<Host> hostList)
    {
        TreeView tree = this.tvTag;

        TreeViewColumn tvcTag = new TreeViewColumn();
        tvcTag.Title = "";

        CellRendererText cell = new CellRendererText();
        tvcTag.PackStart(cell, true);
        tvcTag.AddAttribute(cell, "text", 0);

        TreeStore treestore = new TreeStore(typeof(string), typeof(string));
        Dictionary<string, List<Host>> DictTagHost = m_TagService.GetTagHosts(hostList);

        //add to tree
        TreeIter iter = treestore.AppendValues("主机");
        foreach (KeyValuePair<String, List<Host>> kv in DictTagHost)
        {
            TreeIter iterTag = treestore.AppendValues(iter,kv.Key);
            foreach (Host h in kv.Value)
            {
                treestore.AppendValues(iterTag, h.IP);
            }
        }

        tree.AppendColumn(tvcTag);
        tree.Model = treestore;
        tree.ExpandRow(treestore.GetPath(iter),false);
    }

    void InitDetailsPanel()
    { }

    void InitCmsStrip()
    { }

    void InitToolStrip()
    { 
    }

    void NotifyMsg(string msg)
    {
        msg = msg == null ? "就绪" : msg;
        statusbar1.Push(this.statusbar1.GetContextId("status"), msg);
    }

        Host FindByIP(string ip)
    {
        foreach (Host host in m_HostList)
        {
            if (host.IP == ip)
            {
                return host;
            }
        }
        return null;
    }

}
