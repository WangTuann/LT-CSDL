using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeTaiLTCSDL
{
    public partial class Form_Customer : Form
    {
        List<Bills> dsKH = new List<Bills>();
        public Form_Customer()
        {
            InitializeComponent();
        }

        public void Load_Customer()
        {
            BillsBL billsBL = new BillsBL();
            dsKH = billsBL.GetAll();
            int count = 1;
            lvKH.Items.Clear();
            foreach (var kh in dsKH)
            {
                ListViewItem item = lvKH.Items.Add(count.ToString());
                item.SubItems.Add(kh.TenKH);
                item.SubItems.Add(kh.SDT);
                count++;
            }
        }

        private void Form_Customer_Load(object sender, EventArgs e)
        {
            Load_Customer();
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = " ";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<Bills> bills = new List<Bills>();
            lvKH.Items.Clear();
            BillsBL billsBL = new BillsBL();
            bills = billsBL.Find(txtTimKiem.Text);
            foreach (Bills bill in bills)
            {

                ListViewItem item = new ListViewItem(bill.ID.ToString());
                // item.SubItems.Add(toy.Id.ToString());
                item.SubItems.Add(bill.TenKH);
                item.SubItems.Add(bill.SDT);

                lvKH.Items.Add(item);
            }
        }

    }
}
