using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool siderbarExpand = true;
        bool homeExpand = true;
        private void siderbarTimer_Tick(object sender, EventArgs e)
        {
            if (siderbarExpand)
            {
                siderbar.Width -= 10;
                if (siderbar.Width == siderbar.MinimumSize.Width)
                {
                    siderbarExpand = false;
                    siderbarTimer.Stop();
                }
            }
            else
            {
                siderbar.Width += 10;
                if (siderbar.Width == siderbar.MaximumSize.Width)
                {
                    siderbarExpand = true;
                    siderbarTimer.Stop();
                }            
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            siderbarTimer.Start();
        }

        private void homeTimer_Tick(object sender, EventArgs e)
        {
            if (homeExpand)
            {
                homeContainer.Height += 10;
                if (homeContainer.Height == homeContainer.MaximumSize.Height)
                {
                    homeExpand = false;
                    homeTimer.Stop();
                }
            }
            else
            {
                homeContainer.Height -= 10;
                if (homeContainer.Height == homeContainer.MinimumSize.Height)
                {
                    homeExpand = true;
                    homeTimer.Stop();
                }
            }
        }

        private void ButtonHome_Click(object sender, EventArgs e)
        {
            homeTimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 设置双缓冲
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            #endregion
        }
        //扁平化移动窗体
        private System.Drawing.Point mPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new System.Drawing.Point(e.X, e.Y);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

    }
}
