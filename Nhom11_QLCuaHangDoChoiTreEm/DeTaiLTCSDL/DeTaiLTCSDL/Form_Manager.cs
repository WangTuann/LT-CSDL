using BusinessLogic;
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

namespace DeTaiLTCSDL
{
    public partial class Form_Manager : Form
    {
        List<Toy> listToy = new List<Toy>();
        List<TypeToy> listType = new List<TypeToy>();
        Toy ToyCurrent = new Toy();
        string imgLocation = "";
        byte[] img = null;

        public Form_Manager()
        {
            InitializeComponent();
        }

        #region Thêm xóa sửa đồ chơi
        // Thêm
        public int InsertToy()
        {
            Toy toy = new Toy();
            toy.Id = 0;
            if (txtGiaBan.Text == "" || txtToyName.Text == "" || txtGiaNhap.Text == "" || txtXX.Text == "" || txtNhaCC.Text == "" || txtAge.Text == "")
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô");
            }
            else
            {
                int giaban = 0;
                try
                {
                    giaban = int.Parse(txtGiaBan.Text);
                }
                catch
                {
                    giaban = 0;
                }
                int gianhap = 0;
                try
                {
                    gianhap = int.Parse(txtGiaNhap.Text);
                }
                catch
                {
                    giaban = 0;
                }
                int soluong = 0;
                try
                {
                    soluong = int.Parse(txtSoLuong.Text);
                }
                catch
                {
                    soluong = 0;
                }
                toy.TenDoChoi = txtToyName.Text;
                toy.GiaBan = giaban;
                toy.GiaNhap = gianhap;
                toy.SoLuong = soluong;
                toy.TenDoChoi = txtToyName.Text;
                toy.ThuongHieu = txtNhaCC.Text;
                toy.XuatXu = txtXX.Text;
                toy.DoTuoi = txtAge.Text;
                toy.ID_Loai = int.Parse(cbbType.SelectedValue.ToString());
                if (toy.HinhAnh == null)
                {
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader binary = new BinaryReader(stream);
                    img = binary.ReadBytes((int)stream.Length);
                    toy.HinhAnh = img;
                }
                ToyBL toyBL = new ToyBL();
                return toyBL.Insert(toy);
            }
            return -1;
        }

        // Update
        public int UpdateToy()
        {
            Toy toy = ToyCurrent;
            if (txtGiaBan.Text == "" || txtToyName.Text == "" || txtGiaNhap.Text == "" || txtXX.Text == "" || txtNhaCC.Text == "" || txtAge.Text == "")
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô");
            }
            else
            {
                int giaban = 0;
                try
                {
                    giaban = int.Parse(txtGiaBan.Text);
                }
                catch
                {
                    giaban = 0;
                }
                int gianhap = 0;
                try
                {
                    gianhap = int.Parse(txtGiaNhap.Text);
                }
                catch
                {
                    giaban = 0;
                }
                int soluong = 0;
                try
                {
                    soluong = int.Parse(txtSoLuong.Text);
                }
                catch
                {
                    soluong = 0;
                }
                toy.GiaBan = giaban;
                toy.GiaNhap = gianhap;
                toy.SoLuong = soluong;
                toy.TenDoChoi = txtToyName.Text;
                toy.ThuongHieu = txtNhaCC.Text;
                toy.XuatXu = txtXX.Text;
                toy.DoTuoi = txtAge.Text;
                toy.ID_Loai = int.Parse(cbbType.SelectedValue.ToString());
                if (toy.HinhAnh != null)
                {
                    toy.HinhAnh = ToyCurrent.HinhAnh;
                }
                else
                {
                    FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader binary = new BinaryReader(stream);
                    img = binary.ReadBytes((int)stream.Length);
                    toy.HinhAnh = img;
                }
                ToyBL toyBL = new ToyBL();
                return toyBL.Update(toy);
            }
            return -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = InsertToy();
            int result1 = UpdateToy();
            if (result > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công");
                LoadToyDataToDGV(listToy);
            }
            else if (result1 > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");
                LoadToyDataToDGV(listToy);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi. Vui lòng kiểm tra lại");
            }
        }

        // Xóa
        private void tsmiXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa đồ chơi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ToyBL toybl = new ToyBL();
                if (toybl.Delete(ToyCurrent) > 0)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    LoadToyDataToDGV(listToy);
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi! Vui lòng thử lại", "Lỗi");
                }
            }
        }
        #endregion

        #region Hiển thị
        // Chọn hình ảnh hiển thị lên PictureBox
        private void btnChooseImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open File Image";
            dlg.FileName = "Hãy chọn File";
            dlg.Filter = "Image Files (JPEG, GIF, BMP, etc.)|"
                            + ".jpg;.jpeg;*.gif;*.bmp;"
                            + ".tif;.tiff;*.png|"
                            + "JPEG files (.jpg;.jpeg)|*.jpg;*.jpeg|"
                            + "GIF files (.gif)|.gif|"
                            + "BMP files (.bmp)|.bmp|"
                            + "TIFF files (.tif;.tiff)|*.tif;*.tiff|"
                            + "PNG files (.png)|.png|"
                            + "All files (.)|*.*";

            dlg.InitialDirectory = Environment.CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dlg.FileName.ToString();
                pbImg.ImageLocation = imgLocation;
            }
        }

        // Load thông tin đồ chơi vào Listview
        public void LoadToyDataToDGV(List<Toy> listToys = null)
        {
            if(listToys == null)
            {
                listToys = listToy;
            }

            int count = 1;
            lvToy.Items.Clear();
            foreach (var toy in listToys)
            {
                ListViewItem item = lvToy.Items.Add(count.ToString());
                item.SubItems.Add(toy.TenDoChoi);
                item.SubItems.Add(toy.ID_Loai.ToString());
                item.SubItems.Add(toy.DoTuoi);
                item.SubItems.Add(toy.XuatXu);
                item.SubItems.Add(toy.ThuongHieu);
                item.SubItems.Add(toy.SoLuong.ToString());
                item.SubItems.Add(toy.GiaBan.ToString());
                item.SubItems.Add(toy.GiaNhap.ToString());
                count++;

            }
        }


        // Click item listview hiển thị lên form
        private void lvToy_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            for (int i = 0; i < lvToy.Items.Count; i++)
            {
                if (lvToy.Items[i].Selected)
                {
                    ToyCurrent = listToy[i];
                    txtToyId.Text = ToyCurrent.Id.ToString();
                    txtToyName.Text = ToyCurrent.TenDoChoi;
                    txtGiaBan.Text = ToyCurrent.GiaBan.ToString();
                    txtGiaNhap.Text = ToyCurrent.GiaNhap.ToString();
                    txtAge.Text = ToyCurrent.DoTuoi;
                    txtNhaCC.Text = ToyCurrent.ThuongHieu;
                    txtXX.Text = ToyCurrent.XuatXu;
                    txtSoLuong.Text = ToyCurrent.SoLuong.ToString();
                    cbbType.SelectedValue = ToyCurrent.ID_Loai;
                    //LoadImg
                    if (ToyCurrent.HinhAnh == null)
                    {
                        pbImg.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(ToyCurrent.HinhAnh);
                        pbImg.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        // Load Loai vào cbb
        private void LoadTypeToLV()
        {
            TypeBL typeBL = new TypeBL();
            listType = typeBL.GetIDCon();
            cbbType.DataSource = listType;
            cbbType.ValueMember = "ID";
            cbbType.DisplayMember = "TenLoai";
        }
        private void LoadTypeToCbbSX()
        {
            
            TypeBL typeBL = new TypeBL();
            listType = typeBL.GetIDCon();
            cbbLoaiXX.DataSource = listType;
            cbbLoaiXX.ValueMember = "ID";
            cbbLoaiXX.DisplayMember = "TenLoai";
        }

        private void Form_Manager_Load(object sender, EventArgs e)
        {
            LoadTypeToCbbSX();
            LoadTypeToLV();
            cbbLoaiXX.SelectedIndex = -1;
            cbbType.SelectedIndex = -1;
            ToyBL toyBL = new ToyBL();
            listToy = toyBL.GetAll();
            LoadToyDataToDGV(listToy);
        }
        #endregion


        private void btnReset_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            txtToyId.Text = "";
            txtToyName.Text = "";
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            txtAge.Text = "";
            txtNhaCC.Text = "";
            txtSoLuong.Text = "";
            txtXX.Text = "";
            pbImg.Image = null;
            cbbType.SelectedIndex = -1;
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            Form_UpdateType frm = new Form_UpdateType();
            frm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Toy> toys = new List<Toy>();
            lvToy.Items.Clear();
            ToyBL toyBL = new ToyBL();
            toys = toyBL.Find(txtSearch.Text);
            foreach (Toy toy in toys)
            {
                ListViewItem item = new ListViewItem(toy.Id.ToString());
                // item.SubItems.Add(toy.Id.ToString());
                item.SubItems.Add(toy.TenDoChoi);
                item.SubItems.Add(toy.ID_Loai.ToString());
                item.SubItems.Add(toy.DoTuoi);
                item.SubItems.Add(toy.XuatXu.ToString());
                item.SubItems.Add(toy.ThuongHieu);
                item.SubItems.Add(toy.SoLuong.ToString());
                item.SubItems.Add(toy.GiaBan.ToString());
                item.SubItems.Add(toy.GiaNhap.ToString());

                lvToy.Items.Add(item);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadToyDataToDGV(listToy);
        }

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cbbLoaiXX.Enabled = false;
            var toys = listToy.OrderBy(x => x.TenDoChoi).ToList();
            LoadToyDataToDGV(toys);
        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cbbLoaiXX.Enabled = true;
        }

        private void cbbLoaiXX_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbbLoaiXX.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                int ID = 0;
                Int32.TryParse(cbbLoaiXX.SelectedValue.ToString(), out ID);
                if (ID == 0)
                {
                    return;
                }
                else
                {
                    var Toys = listToy.FindAll(x => x.ID_Loai == ID).ToList();
                    LoadToyDataToDGV(Toys);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int result1 = UpdateToy();
            if (result1 > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");
                LoadToyDataToDGV();
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi. Vui lòng kiểm tra lại");
            }
        }
    }
}
