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
using static DeTaiLTCSDL.Form_Sell;

namespace DeTaiLTCSDL.CustomCotrols
{
    public partial class OrderToys : UserControl
    {
        public int soLuong;
        int toyID, billId, billDetailId;
        public RecieveBillsDetails send;
        public OrderToys()
        {
            InitializeComponent();
        }

        public OrderToys(RecieveBillsDetails sender)
        {

            InitializeComponent();
            this.send = sender;
        }

        private int UpDateBillDetail(int quantity)
        {
            BillDetails billDetails = new BillDetails();
            billDetails.ID = billDetailId;
            billDetails.ID_HoaDon = billId;
            billDetails.SoLuong = quantity;

            BillDetailsBL bdBL = new BillDetailsBL();
            return bdBL.Update(billDetails);
        }

        public void InitUI(string tittle, int price, int quantity, int toyID)
        {
            this.toyID = toyID;
            lbTitle.Text = tittle;
            lbPrice.Text = price.ToString();
            nmrCount.Text = quantity.ToString();
        }

        public int GetSoLuong()
        {
            return int.Parse(nmrCount.Text);
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void nmrCount_ValueChanged(object sender, EventArgs e)
        {
            UpDateBillDetail(int.Parse(nmrCount.Value.ToString()));
        }
    }
}
