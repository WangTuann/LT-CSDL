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
using DataAccess;


namespace DeTaiLTCSDL
{
    public partial class Form_ToyDetail : Form
    {
        BillDetailsBL BillDetailsBL = new BillDetailsBL();
        private string _toyName;    
        public Form_ToyDetail()
        {
            InitializeComponent();
        }
        //
        public string ToyName 
        {
            get { return _toyName; }
            set { _toyName = value; } 
        }

        private void Form_ToyDetail_Load(object sender, EventArgs e)
        {
            dgvToy.DataSource = BillDetailsBL.GetSearch_Toy(_toyName);
        }

        private void dgvToy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvToy.CurrentRow.Index;
            txtID.Text=dgvToy.Rows[i].Cells[1].Value.ToString();
            txtToyName.Text = dgvToy.Rows[i].Cells[0].Value.ToString();
            txtCusName.Text = dgvToy.Rows[i].Cells[2].Value.ToString();
        }
    }
}
