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
            dgvHoaDon.DataSource = BillDetailsBL.GetSearch_Bill(int.Parse(txtTimKiem.Text));
                        
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHoaDon.CurrentRow.Index;
            txtBillId.Text = dgvHoaDon.Rows[i].Cells[0].Value.ToString();
            txtToyName.Text = dgvHoaDon.Rows[i].Cells[1].Value.ToString();
            txtAmount.Text = dgvHoaDon.Rows[i].Cells[2].Value.ToString();
            txtCusName.Text = dgvHoaDon.Rows[i].Cells[3].Value.ToString();
        }

    }
}
