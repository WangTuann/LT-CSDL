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
    public partial class Form_UpdateType : Form
    {
        List<TypeToy> listType = new List<TypeToy>();
        TypeToy curType = new TypeToy();
        public Form_UpdateType()
        {
            InitializeComponent();
        }

        #region Hiển thị

        private void LoadIDParentToLV()
        {
            TypeBL typeBL = new TypeBL();
            listType = typeBL.GetIDCha();
            cbbIDCha.DataSource = listType;
            cbbIDCha.ValueMember = "ID";
            cbbIDCha.DisplayMember = "ID_Cha";
        }



        private void Form_UpdateType_Load(object sender, EventArgs e)
        {
            
            LoadIDParentToLV();
        }
        #endregion


        #region Thêm xóa sửa Type
        public int InsertType()
        {
            TypeToy type = new TypeToy();
            type.Id = 0;
            if (txtNameType.Text == "")
            {
                MessageBox.Show("Chưa nhập dữ liệu cho các ô");
            }
            else
            {
                type.TenLoai = txtNameType.Text;
                type.GhiChu = txtNotes.Text;
                type.IdParent = int.Parse(cbbIDCha.SelectedValue.ToString());
                TypeBL typeBL = new TypeBL();
                return typeBL.Insert(type);

            }
            return -1;
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = InsertType();
            if (result > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công");

            }

            else
            {
                MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại");
            }
        }
        // Xóa

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion

    }

}
