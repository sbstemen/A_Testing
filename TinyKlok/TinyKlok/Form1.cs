/******************************
 * Author Date 20141212 
 *  By Scott B. Stemen 
 *   For Simple Clock for Johanath
 *******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinyKlok
{
    public partial class f1 : Form
    {
        public f1()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timelcl.Text = DateTime.Now.ToString("HH:mm:ss");
            timeZulu.Text = DateTime.UtcNow.ToString("HH:mm:ss");
            timeEast.Text =  DateTime.UtcNow.AddHours(-4).ToString("HH:mm:ss");
            dateBox.Text = DateTime.UtcNow.ToString("yyyyMMdd");
        }

        private void lbl_click(object sender, EventArgs e)
        {

        }

        private void f1_Load(object sender, EventArgs e)
        {

        }
    }
}
