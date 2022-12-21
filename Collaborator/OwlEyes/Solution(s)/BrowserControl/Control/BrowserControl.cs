using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;

namespace ernsoft.BrowserControl
{
    public partial class BrowserControl: UserControl
    {
        public BrowserControl()
        {
            InitializeComponent();
            //ChromiumWebBrowser WB = new ChromiumWebBrowser("https://ethikratie.net");
            //WB.Dock = DockStyle.Fill;
            //Controls.Add(WB);
            //WB.Visible = true;
            Label lbl = new Label();
            lbl.Text = "Test-Label";
            lbl.AutoSize = true;
            lbl.Dock = DockStyle.Top;
            Controls.Add(lbl);
            lbl.Visible = true;
        }
    }
}
