using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Model;
using System.IO;
using Newtonsoft.Json;

namespace QuanLySinhVien.DATA
{
    public class DSSV_JSON_data:ISVDataSource
    {
        public string fileName;

        public DSSV_JSON_data(string fileName)
        {
            this.fileName = fileName;
        }

        public List<SinhVien> GetSV()
        {
            if (!File.Exists(fileName))
            {
                FileStream fs = File.Create(fileName);
                fs.Close();
            }
            using (StreamReader sr = new StreamReader(fileName))
            {
                string json = sr.ReadToEnd();
                if (string.IsNullOrWhiteSpace(json))
                    return new List<SinhVien>();
                List<SinhVien> items = JsonConvert.DeserializeObject<List<SinhVien>>(json);
                return items;
            }
        }

        public void Save(List<SinhVien> sv)
        {
            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, sv);
            }
        }
    }
}

