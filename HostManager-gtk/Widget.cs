using System;
using Gtk;

namespace HostManagergtk
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class Widget : Gtk.Bin
    {
        Label label15=new Label();
        Label label14 = new Label();
        Label label13 = new Label();
        Entry tbDisk = new Entry();
        Label label12 = new Label();
        Entry tbMemory=new Entry();
        Label label11 = new Label();
        Entry tbCPU = new Entry();
        Label label10 = new Label();
        Entry rtbRemark = new Entry();
        Label label9 = new Label();
        Entry tbRootPasswd = new Entry();
        Label label8 = new Label();
        Entry tbName = new Entry();
        Label label7 = new Label();
        ComboBox cmbTag8=new ComboBox();
        ComboBox cmbTag6 = new ComboBox();
        ComboBox cmbTag4 = new ComboBox();
        ComboBox cmbTag2 = new ComboBox();
        ComboBox cmbTag7 = new ComboBox();
        ComboBox cmbTag5 = new ComboBox();
        ComboBox cmbTag3 = new ComboBox();
        Label label6 = new Label();
        Label label5 = new Label();
        ComboBox cmbOS = new ComboBox();
        Entry tbPasswd = new Entry();
        Label label4 = new Label();
        Entry tbUser = new Entry();
        Label label3 = new Label();
        Entry tbPort = new Entry();
        Label label2 = new Label();
        ComboBox cmbTag1 = new ComboBox();
        Entry tbIP = new Entry();
        Label label1 = new Label();

        public Widget()
        {
            this.Build();
            this.InitControls();
        }

        void InitControls()
        {
            this.SizeAllocate(new Gdk.Rectangle(0,0,609, 525));
            Fixed fix = new Fixed();

            // label1
            label1.Text = "IP:";
            fix.Put(label1,20,65);

            // tbIP
            tbIP.SizeAllocate (new Gdk.Rectangle (0,0,187,26));
            fix.Put(tbIP, 108, 60);
            // 
            // tbPasswd
            // 
            tbPasswd.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 26));
            fix.Put(tbPasswd, 400, 96);
            // 
            // label4
            // 
            label4.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label4.Text = "密码：";
            fix.Put(label4, 312, 101);
            // 
            // tbUser
            // 
            tbUser.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 26));
            fix.Put(tbUser, 108, 96);
            // 
            // label3
            // 
            label3.SizeAllocate(new Gdk.Rectangle(0, 0, 65, 20));
            label3.Text = "用户名：";
            fix.Put(label3, 20, 101);
            // 
            // tbPort
            // 
            tbPort.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 26));
            fix.Put(tbPort, 400, 60);
            // 
            // label2
            // 
            label2.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label2.Text = "端口：";
            fix.Put(label2, 312, 65);


            // 
            // label15
            // 
            fix.Put(label15, 552, 178);
            label15.SizeAllocate(new Gdk.Rectangle(0, 0, 28, 20));
            label15.Text = "GB";
            // 
            // label14
            // 
            fix.Put(label14, 267, 210);
            label14.SizeAllocate(new Gdk.Rectangle(0, 0, 28, 20));
            label14.Text = "GB";
            // 
            // label13
            // 
            fix.Put(label13, 267, 173);
            label13.SizeAllocate(new Gdk.Rectangle(0, 0, 18, 20));
            label13.Text = "C";
            // 
            // tbDisk
            // 
            fix.Put(tbDisk, 108, 205);
            tbDisk.SizeAllocate(new Gdk.Rectangle(0, 0, 149, 26));
            // 
            // label12
            // 
            fix.Put(label12, 20, 210);
            label12.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label12.Text = "硬盘：";
            // 
            // tbMemory
            // 
            fix.Put(tbMemory, 400, 173);
            tbMemory.SizeAllocate(new Gdk.Rectangle(0, 0, 143, 26));
            // 
            // label11
            // 
            fix.Put(label11, 312, 178);
            label11.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label11.Text = "内存：";
            // 
            // tbCPU
            // 
            fix.Put(tbCPU, 108, 168);
            tbCPU.SizeAllocate(new Gdk.Rectangle(0, 0, 149, 26));
            // 
            // label10
            // 
            fix.Put(label10, 20, 173);
            label10.SizeAllocate(new Gdk.Rectangle(0, 0, 40, 20));
            label10.Text = "CPU:";
            // 
            // rtbRemark
            // 
            fix.Put(rtbRemark, 108, 253);
            rtbRemark.SizeAllocate(new Gdk.Rectangle(0, 0, 479, 174));
            rtbRemark.Text = "";
            // 
            // label9
            // 
            fix.Put(label9, 20, 238);
            label9.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label9.Text = "备注：";
            // 
            // tbRootPasswd
            // 
            fix.Put(tbRootPasswd, 108, 132);
            tbRootPasswd.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 26));
            // 
            // label8
            // 
            fix.Put(label8, 20, 137);
            label8.SizeAllocate(new Gdk.Rectangle(0, 0, 83, 20));
            label8.Text = "Root密码：";
            // 
            // 
            // 
            // label7
            // 

            label7.SizeAllocate(new Gdk.Rectangle(0, 0, 40, 20));
            label7.Text = "名称:";
            // 
            // cmbTag8
            // 
            fix.Put(cmbTag8, 427, 483);
            cmbTag8.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag6
            // 
            fix.Put(cmbTag6, 213, 483);
            cmbTag6.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag4
            // 
            fix.Put(cmbTag4, 427, 440);
            cmbTag4.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag2
            // 
            fix.Put(cmbTag2, 213, 440);
            cmbTag2.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag7
            // 
            fix.Put(cmbTag7, 321, 483);
            cmbTag7.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag5
            // 
            fix.Put(cmbTag5, 108, 483);
            cmbTag5.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag3
            // 
            fix.Put(cmbTag3, 321, 440);
            cmbTag3.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // label6
            // 
            fix.Put(label6, 20, 440);
            label6.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label6.Text = "tags：";
            // 
            // label5
            // 
            fix.Put(label5, 312, 137);
            label5.SizeAllocate(new Gdk.Rectangle(0, 0, 79, 20));
            label5.Text = "操作系统：";
            // 
            // cmbOS
            // 
            fix.Put(cmbOS, 400, 132);
            cmbOS.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 28));



            this.Add(fix);
            this.ShowAll();
        }
    }
}
