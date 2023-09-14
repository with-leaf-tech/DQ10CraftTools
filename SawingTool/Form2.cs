using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SawingTool {
    public partial class Form2 : Form {
        public Form2(string msg) {
            InitializeComponent();
            label1.Text = msg;
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
