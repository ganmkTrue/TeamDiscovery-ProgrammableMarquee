﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision
{
    public partial class UIForm : Form
    {
        MarqueeMatrix MyMarquee = null;

        public UIForm()
        {
            InitializeComponent();
        }

        public Panel panel1 { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            MyMarquee = new MarqueeMatrix(this.panel1);
        }


        private void UIForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
