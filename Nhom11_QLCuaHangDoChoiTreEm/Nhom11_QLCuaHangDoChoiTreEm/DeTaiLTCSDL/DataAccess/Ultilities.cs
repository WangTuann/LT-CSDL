using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Ultilities
    {
        // Lấy chuỗi kết nối từ App.Config
        public static string StrName = "ConnectionStringName";
        public static string ConnectionString = ConfigurationManager.ConnectionStrings[StrName].ConnectionString;

        // Các biến của bảng Toy
        public static string Toy_GetAll = "Toy_GetAll";
        public static string Type_GetAll = "Type_GetAll";
        public static string Bill_GetAll = "Bill_GetAll";
        public static string BillDetails_GetAll = "BillDetails_GetAll";
        public static string Account_GetAll = "Account_GetAll";
        public static string Loai_GetIDCha = "Loai_GetIDCha";
        public static string Loai_GetIDCon = "Loai_GetIDCon";
        public static string Loai_GetSearchBilCustom = "SearchDetailBill";
        public static string Loai_GetSearchToyCustom = "Search_Toys";
        public static string Loai_SearchKhachHang = "Search_CusDetail";


        public static string DoChoi_InsertUpdateDelete = "DoChoi_InsertUpdateDelete";
        public static string Type_InsertUpdateDelete = "Type_InsertUpdateDelete";
        public static string Bill_InsertUpdateDelete = "HoaDon_InsertUpdateDelete";
        public static string BillDetails_InsertUpdateDelete = "BillDetails_InsertUpdateDelete";

        public static string HoaDon_SoLuong = "HoaDon_SoLuong";
        public static string Toy_ChiPhiNhap = "Toy_ChiPhiNhap";
        public static string TongTienKhuyenMai = "Get_Discount";
        public static string DoanhThu = "Get_DoanhThu";

    }
}
