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
        ComboBox cmbTag1 = new ComboBox();
        Label label6 = new Label();
        Label label5 = new Label();
        ComboBox cmbOS = new ComboBox();
        Entry tbPasswd = new Entry();
        Label label4 = new Label();
        Entry tbUser = new Entry();
        Label label3 = new Label();
        Entry tbPort = new Entry();
        Label label2 = new Label();
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
            // 
            // label7
            // 
            label7.SizeAllocate(new Gdk.Rectangle(0, 0, 40, 20));
            fix.Put(label7, 20, 27);
            label7.Text = "名称:";
            // 
            // tbName
            // 
            tbName.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 26));
            fix.Put(tbName, 108, 25);

            // label1
            label1.Text = "IP:";
            fix.Put(label1,20,61);

            // tbIP
            tbIP.SizeAllocate (new Gdk.Rectangle (0,0,187,26));
            fix.Put(tbIP, 108, 55);

            // 
            // tbPort
            // 
            tbPort.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 26));
            fix.Put(tbPort, 400, 55);
            // 
            // label2
            // 
            label2.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label2.Text = "端口：";
            fix.Put(label2, 312, 55);

            // 
            // tbPasswd
            // 
            tbPasswd.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 26));
            fix.Put(tbPasswd, 400, 85);
            // 
            // label4
            // 
            label4.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label4.Text = "密码：";
            fix.Put(label4, 312, 91);
            // 
            // tbUser
            // 
            tbUser.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 26));
            fix.Put(tbUser, 108, 85);
            // 
            // label3
            // 
            label3.SizeAllocate(new Gdk.Rectangle(0, 0, 65, 20));
            label3.Text = "用户名：";
            fix.Put(label3, 20, 91);

            // 
            // tbRootPasswd
            // 
            fix.Put(tbRootPasswd, 108, 115);
            tbRootPasswd.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 26));
            // 
            // label8
            // 
            fix.Put(label8, 20, 121);
            label8.SizeAllocate(new Gdk.Rectangle(0, 0, 83, 20));
            label8.Text = "Root密码：";
            // 
            // cmbOS
            // 
            fix.Put(cmbOS, 400, 115);
            cmbOS.SizeAllocate(new Gdk.Rectangle(0, 0, 187, 28));
            // 
            // label5
            // 
            fix.Put(label5, 312, 121);
            label5.SizeAllocate(new Gdk.Rectangle(0, 0, 79, 20));
            label5.Text = "操作系统：";
          
            // 
            // tbMemory
            // 
            fix.Put(tbMemory, 400, 145);
            tbMemory.SizeAllocate(new Gdk.Rectangle(0, 0, 143, 26));
            // 
            // label11
            // 
            fix.Put(label11, 312, 151);
            label11.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label11.Text = "内存：";
            // 
            // label15
            // 
            fix.Put(label15, 562, 151);
            label15.SizeAllocate(new Gdk.Rectangle(0, 0, 28, 20));
            label15.Text = "GB";
            // 
            // tbCPU
            // 
            fix.Put(tbCPU, 108, 145);
            tbCPU.SizeAllocate(new Gdk.Rectangle(0, 0, 149, 26));
            // 
            // label10
            // 
            fix.Put(label10, 20, 151);
            label10.SizeAllocate(new Gdk.Rectangle(0, 0, 40, 20));
            label10.Text = "CPU:";
            // 
            // label13
            // 
            fix.Put(label13, 270, 151);
            label13.SizeAllocate(new Gdk.Rectangle(0, 0, 18, 20));
            label13.Text = "C";
            // 
            // tbDisk
            // 
            fix.Put(tbDisk, 108, 175);
            tbDisk.SizeAllocate(new Gdk.Rectangle(0, 0, 149, 26));
            // 
            // label12
            // 
            fix.Put(label12, 20, 181);
            label12.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label12.Text = "硬盘：";
            // 
            // label14
            // 
            fix.Put(label14, 270, 181);
            label14.SizeAllocate(new Gdk.Rectangle(0, 0, 28, 20));
            label14.Text = "GB";
            // 
            // rtbRemark
            // 
            fix.Put(rtbRemark, 108, 205);
            rtbRemark.SizeAllocate(new Gdk.Rectangle(0, 0, 479, 174));
            rtbRemark.Text = "";
            // 
            // label9
            // 
            fix.Put(label9, 20, 211);
            label9.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label9.Text = "备注：";
            // 
            // label6
            // 
            fix.Put(label6, 20, 275);
            label6.SizeAllocate(new Gdk.Rectangle(0, 0, 51, 20));
            label6.Text = "tags：";
           
            // 
            // cmbTag8
            // 
            fix.Put(cmbTag8, 427, 315);
            cmbTag8.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag6
            // 
            fix.Put(cmbTag6, 213, 315);
            cmbTag6.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag4
            // 
            fix.Put(cmbTag4, 427, 275);
            cmbTag4.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag1
            // 
            fix.Put(cmbTag1, 108, 275);
            cmbTag2.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag2
            // 
            fix.Put(cmbTag2, 213, 275);
            cmbTag2.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag7
            // 
            fix.Put(cmbTag7, 321, 315);
            cmbTag7.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag5
            // 
            fix.Put(cmbTag5, 108, 315);
            cmbTag5.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
            // 
            // cmbTag3
            // 
            fix.Put(cmbTag3, 321, 275);
            cmbTag3.SizeAllocate(new Gdk.Rectangle(0, 0, 96, 28));
           
            this.Add(fix);
            this.ShowAll();
        }
    }
}
