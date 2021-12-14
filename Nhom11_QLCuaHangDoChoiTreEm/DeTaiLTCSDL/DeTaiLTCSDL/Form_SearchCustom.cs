using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
namespace DeTaiLTCSDL
{
    public partial class Form_SearchCustom : Form
    {
        BillDetailsBL BillDetailsBL = new BillDetailsBL();
        public Form_SearchCustom()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BillDetailsBL.GetSearch(int.Parse(txtTimKiem.Text));
        }

    }
}
