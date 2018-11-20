
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action addAction;

	private global::Gtk.Action removeAction;

	private global::Gtk.Action refreshAction;

	private global::Gtk.Action goDownAction;

	private global::Gtk.Action goUpAction;

	private global::Gtk.VPaned vpaned2;

	private global::Gtk.Toolbar toolbar1;

	private global::Gtk.VPaned vpaned3;

	private global::Gtk.HPaned hpaned1;

	private global::Gtk.Notebook notebook3;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TreeView tvHost;

	private global::Gtk.Label label4;

	private global::Gtk.ScrolledWindow GtkScrolledWindow1;

	private global::Gtk.TreeView tvTag;

	private global::Gtk.Label label6;

	private global::Gtk.Notebook notebook1;

	private global::Gtk.VPaned vpaned4;

	private global::HostManagergtk.Widget widget1;

	private global::Gtk.Button btnApply;

	private global::Gtk.Label label1;

	private global::Gtk.Label label3;

	private global::Gtk.Statusbar statusbar1;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.addAction = new global::Gtk.Action("addAction", null, null, "gtk-add");
		w1.Add(this.addAction, null);
		this.removeAction = new global::Gtk.Action("removeAction", null, null, "gtk-remove");
		w1.Add(this.removeAction, null);
		this.refreshAction = new global::Gtk.Action("refreshAction", null, null, "gtk-refresh");
		w1.Add(this.refreshAction, null);
		this.goDownAction = new global::Gtk.Action("goDownAction", null, null, "gtk-go-down");
		w1.Add(this.goDownAction, null);
		this.goUpAction = new global::Gtk.Action("goUpAction", null, null, "gtk-go-up");
		w1.Add(this.goUpAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(3));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vpaned2 = new global::Gtk.VPaned();
		this.vpaned2.CanFocus = true;
		this.vpaned2.Name = "vpaned2";
		this.vpaned2.Position = 44;
		// Container child vpaned2.Gtk.Paned+PanedChild
		this.UIManager.AddUiFromString(@"<ui><toolbar name='toolbar1'><toolitem name='addAction' action='addAction'/><toolitem name='removeAction' action='removeAction'/><toolitem name='refreshAction' action='refreshAction'/><toolitem name='goDownAction' action='goDownAction'/><toolitem name='goUpAction' action='goUpAction'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.toolbar1.ToolbarStyle = ((global::Gtk.ToolbarStyle)(0));
		this.vpaned2.Add(this.toolbar1);
		global::Gtk.Paned.PanedChild w2 = ((global::Gtk.Paned.PanedChild)(this.vpaned2[this.toolbar1]));
		w2.Resize = false;
		w2.Shrink = false;
		// Container child vpaned2.Gtk.Paned+PanedChild
		this.vpaned3 = new global::Gtk.VPaned();
		this.vpaned3.CanFocus = true;
		this.vpaned3.Name = "vpaned3";
		this.vpaned3.Position = 481;
		// Container child vpaned3.Gtk.Paned+PanedChild
		this.hpaned1 = new global::Gtk.HPaned();
		this.hpaned1.CanFocus = true;
		this.hpaned1.Name = "hpaned1";
		this.hpaned1.Position = 170;
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.notebook3 = new global::Gtk.Notebook();
		this.notebook3.CanFocus = true;
		this.notebook3.Name = "notebook3";
		this.notebook3.CurrentPage = 1;
		this.notebook3.TabPos = ((global::Gtk.PositionType)(3));
		// Container child notebook3.Gtk.Notebook+NotebookChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.tvHost = new global::Gtk.TreeView();
		this.tvHost.CanFocus = true;
		this.tvHost.Name = "tvHost";
		this.GtkScrolledWindow.Add(this.tvHost);
		this.notebook3.Add(this.GtkScrolledWindow);
		// Notebook tab
		this.label4 = new global::Gtk.Label();
		this.label4.Name = "label4";
		this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Host");
		this.notebook3.SetTabLabel(this.GtkScrolledWindow, this.label4);
		this.label4.ShowAll();
		// Container child notebook3.Gtk.Notebook+NotebookChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.tvTag = new global::Gtk.TreeView();
		this.tvTag.CanFocus = true;
		this.tvTag.Name = "tvTag";
		this.GtkScrolledWindow1.Add(this.tvTag);
		this.notebook3.Add(this.GtkScrolledWindow1);
		global::Gtk.Notebook.NotebookChild w6 = ((global::Gtk.Notebook.NotebookChild)(this.notebook3[this.GtkScrolledWindow1]));
		w6.Position = 1;
		// Notebook tab
		this.label6 = new global::Gtk.Label();
		this.label6.Name = "label6";
		this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Tag");
		this.notebook3.SetTabLabel(this.GtkScrolledWindow1, this.label6);
		this.label6.ShowAll();
		this.hpaned1.Add(this.notebook3);
		global::Gtk.Paned.PanedChild w7 = ((global::Gtk.Paned.PanedChild)(this.hpaned1[this.notebook3]));
		w7.Resize = false;
		// Container child hpaned1.Gtk.Paned+PanedChild
		this.notebook1 = new global::Gtk.Notebook();
		this.notebook1.CanFocus = true;
		this.notebook1.Name = "notebook1";
		this.notebook1.CurrentPage = 0;
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vpaned4 = new global::Gtk.VPaned();
		this.vpaned4.CanFocus = true;
		this.vpaned4.Name = "vpaned4";
		this.vpaned4.Position = 411;
		// Container child vpaned4.Gtk.Paned+PanedChild
		this.widget1 = new global::HostManagergtk.Widget();
		this.widget1.Events = ((global::Gdk.EventMask)(256));
		this.widget1.Name = "widget1";
		this.vpaned4.Add(this.widget1);
		global::Gtk.Paned.PanedChild w8 = ((global::Gtk.Paned.PanedChild)(this.vpaned4[this.widget1]));
		w8.Resize = false;
		// Container child vpaned4.Gtk.Paned+PanedChild
		this.btnApply = new global::Gtk.Button();
		this.btnApply.CanFocus = true;
		this.btnApply.Name = "btnApply";
		this.btnApply.UseUnderline = true;
		this.btnApply.Label = global::Mono.Unix.Catalog.GetString("应用");
		this.vpaned4.Add(this.btnApply);
		this.notebook1.Add(this.vpaned4);
		// Notebook tab
		this.label1 = new global::Gtk.Label();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("page1");
		this.notebook1.SetTabLabel(this.vpaned4, this.label1);
		this.label1.ShowAll();
		// Notebook tab
		global::Gtk.Label w11 = new global::Gtk.Label();
		w11.Visible = true;
		this.notebook1.Add(w11);
		this.label3 = new global::Gtk.Label();
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("page2");
		this.notebook1.SetTabLabel(w11, this.label3);
		this.label3.ShowAll();
		this.hpaned1.Add(this.notebook1);
		this.vpaned3.Add(this.hpaned1);
		global::Gtk.Paned.PanedChild w13 = ((global::Gtk.Paned.PanedChild)(this.vpaned3[this.hpaned1]));
		w13.Resize = false;
		// Container child vpaned3.Gtk.Paned+PanedChild
		this.statusbar1 = new global::Gtk.Statusbar();
		global::Gtk.Tooltips w14 = new Gtk.Tooltips();
		w14.SetTip(this.statusbar1, "ready", "ready");
		this.statusbar1.Name = "statusbar1";
		this.statusbar1.Spacing = 6;
		this.vpaned3.Add(this.statusbar1);
		global::Gtk.Paned.PanedChild w15 = ((global::Gtk.Paned.PanedChild)(this.vpaned3[this.statusbar1]));
		w15.Resize = false;
		w15.Shrink = false;
		this.vpaned2.Add(this.vpaned3);
		global::Gtk.Paned.PanedChild w16 = ((global::Gtk.Paned.PanedChild)(this.vpaned2[this.vpaned3]));
		w16.Resize = false;
		w16.Shrink = false;
		this.Add(this.vpaned2);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 772;
		this.DefaultHeight = 570;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
	}
}
