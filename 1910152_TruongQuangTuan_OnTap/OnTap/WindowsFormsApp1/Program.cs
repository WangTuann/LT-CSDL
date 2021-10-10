using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            INewSinhVien sinhvien = new NewSinhVienDataSourch();  // gọi hàm , cía này chắc cô k bắt giải thích đâu
            var mng = new QuanLySinhVien(sinhvien);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(mng));
        }
    }
}
