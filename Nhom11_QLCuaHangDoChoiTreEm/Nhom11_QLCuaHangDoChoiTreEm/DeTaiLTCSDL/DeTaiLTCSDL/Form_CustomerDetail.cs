using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using BusinessLogic;

namespace DeTaiLTCSDL
{
    public partial class Form_CustomerDetail : Form
    {
        BillDetailsBL billDetailsBL = new BillDetailsBL();
        private string _cusName;
        public Form_CustomerDetail()
        {
            InitializeComponent();
        }
        public string CusName
        {
            get { return _cusName; }
            set { _cusName = value; }
        }

        private void Form_CustomerDetail_Load(object sender, EventArgs e)
        {
            dgvToy.DataSource = billDetailsBL.GetSearch_Customer(_cusName);
        }
    }
}
