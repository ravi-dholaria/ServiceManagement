using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceManagement
{
    public partial class ProgressForm : Form
    {
        public ProgressForm(string msg)
        {
            InitializeComponent();
            this.Text = $"{msg}ing Service Please wait...";
            progressBar1.Style = ProgressBarStyle.Marquee;
        }
    }
}
