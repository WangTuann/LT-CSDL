using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.DATA;

namespace QuanLySinhVien
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ISVDataSource dataSource = new DSSV_Text_data("Data\\DSSV.txt");
            //ISVDataSource xmlData=new 
            Context context = Context.getInstance(dataSource);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(context));
        }
    }
}
