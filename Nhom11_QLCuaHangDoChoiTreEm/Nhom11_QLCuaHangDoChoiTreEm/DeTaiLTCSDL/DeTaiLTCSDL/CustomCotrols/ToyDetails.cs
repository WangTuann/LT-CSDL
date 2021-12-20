using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DeTaiLTCSDL.Form_Sell;

namespace DeTaiLTCSDL.CustomCotrols
{
    public partial class ToyDetails : UserControl
    {
        public ReceiveToy sendToy;
        private Toy curToy;
        public ToyDetails()
        {
            InitializeComponent();
        }

        public ToyDetails(ReceiveToy sender)
        {
            InitializeComponent();
            this.sendToy = sender;
        }

        // Click nút thêm hóa đơn -> Xuất đồ chơi vào Bill
        private void btnValid_Click(object sender, EventArgs e)
        {
            this.sendToy(curToy);
        }

        // Hiển thị thông tin món ăn lên user Control
        public void LoadToy(string name, int price, Toy toy)
        {
            this.curToy = toy;
            lblPrice.Text = price.ToString();
            lbToyName.Text = name;
            MemoryStream ms = new MemoryStream(curToy.HinhAnh);
            ptbImageToy.Image = Image.FromStream(ms);
            btnValid.Visible = true;
        }
    }
}
