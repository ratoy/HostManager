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
    public partial class NewHostForm : Form
    {
        public NewHostForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.btnOK.Click += new EventHandler(btnOK_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        internal Host GetHost()
        {
            return this.ucHostDetails1.GetHost();
        }
    }
}
