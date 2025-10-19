using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai05
{
    abstract class BatDongSan
    {
        protected string diaDiem;
        protected double giaBan;
        protected double dienTich;
        public string DiaDiem { get => diaDiem; set => diaDiem = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public double DienTich { get => dienTich; set => dienTich = value; }
        public BatDongSan(string diadiem = "", double giaban = 0, double dientich = 0)
        {
            this.diaDiem = diadiem;
            this.giaBan = giaban;
            this.dienTich = dientich;
        }
        public virtual void Nhap()
        {
            Console.Write("Nhập Địa điểm: ");
            diaDiem = Console.ReadLine();
            Console.Write("Nhập Gía Bán: ");
            giaBan = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhập Diện Tích: ");
            dienTich = Convert.ToDouble(Console.ReadLine());
        }
        public abstract void Xuat();
        public abstract override string ToString();
    }
    class KhuDat : BatDongSan
    {
        public KhuDat(string diadiem = "", double giaban = 0, double dientich = 0) : base(diadiem, giaban, dientich) { }
        public override void Nhap()
        {
            Console.WriteLine("Thông tin cho khu đất: ");
            base.Nhap();
        }
        public override void Xuat()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            return $"Địa diểm khu đất: {DiaDiem}, Giá bán: {GiaBan}VND, Diện tích: {DienTich}m2";
        }
    }
    class NhaPho : BatDongSan
    {
        private int NamXayDung;
        private int SoTang;
        public NhaPho(string diadiem = "", double giaban = 0, double dientich = 0, int namxd = 0, int sotang = 0) : base(diadiem, giaban, dientich)
        {
            this.NamXayDung1 = namxd;
            this.SoTang1 = sotang;
        }
        public int NamXayDung1 { get => NamXayDung; set => NamXayDung = value; }
        public int SoTang1 { get => SoTang; set => SoTang = value; }
        public override void Nhap()
        {
            Console.WriteLine("Thông tin cho nhà phố: ");
            base.Nhap();
            Console.Write("Nhập Năm Xây Dựng: ");
            NamXayDung = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhập Số Tầng: ");
            SoTang = Convert.ToInt32(Console.ReadLine());
        }
        public override void Xuat()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            return $"Địa diểm Nhà Phố: {DiaDiem}, Giá bán: {GiaBan}VND, Diện tích: {DienTich}m2, Năm xây dựng: {NamXayDung}, Số tầng: {SoTang}";
        }
    }
    class ChungCu : BatDongSan
    {
        private int SoTang;
        public ChungCu(string diadiem = "", double giaban = 0, double dientich = 0, int sotang = 0) : base(diadiem, giaban, dientich)
        {
            this.SoTang = sotang;
        }
        public int SoTang1 { get => SoTang; set => SoTang = value; }
        public override void Nhap()
        {
            Console.WriteLine("Thông tin cho chung cư: ");
            base.Nhap();
            Console.Write("Nhập Số Tầng: ");
            SoTang = Convert.ToInt32(Console.ReadLine());
        }
        public override void Xuat()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            return $"Địa diểm Chung Cư: {DiaDiem}, Giá bán: {GiaBan}VND, Diện tích: {DienTich}m2, Số tầng: {SoTang}";
        }
    }
    class CongTyDaiPhu
    {
        List<BatDongSan> ds = new List<BatDongSan>();
        public CongTyDaiPhu()
        {
            ds = new List<BatDongSan>();
        }
        public void NhapBDS()
        {
            int n;
            Console.Write("Nhập số lượng bất động sản: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Số lượng bất động sản không hợp lệ, vui lòng nhập số nguyên dương: ");
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập thông tin bất động sản thứ {i + 1}:");
                Console.Write("\nChọn loại BĐS (1-Khu Đất, 2-Nhà Phố, 3-Chung Cư): ");
                int loai;
                while (!int.TryParse(Console.ReadLine(), out loai) || loai < 1 || loai > 3)
                {
                    Console.Write("Loại không hợp lệ, nhập lại (1-Khu Đất, 2-Nhà Phố, 3-Chung Cư): ");
                }
                BatDongSan batDongSan;
                switch (loai)
                {
                    case 1:
                        batDongSan = new KhuDat();
                        break;
                    case 2:
                        batDongSan = new NhaPho();
                        break;
                    case 3:
                        batDongSan = new ChungCu();
                        break;
                    default:
                        batDongSan = null;
                        break;
                }
                batDongSan.Nhap();
                ds.Add(batDongSan);
            }
        }
        public void XuatDanhSach()
        {
            Console.WriteLine("\nDanh sách bất động sản:");
            foreach (var bds in ds)
            {
                bds.Xuat();
            }
        }
        public void XuatTongTienBDS()
        {
            double TongTien = 0;
            foreach (var bds in ds)
            {
                TongTien += bds.GiaBan;
            }
            Console.WriteLine($"Tổng tiền của công ty: {TongTien}");
        }
        public void XuatDsBDSThoaDK()
        {
            Console.WriteLine("\nDanh sách BĐS của công ty ((Khu Đất > 100m2) hoặc (Nhà Phố > 60m2 và năm xây dựng >= 2019)):");
            bool check = false;
            foreach (var bds in ds)
            {
                if (bds is KhuDat kd && kd.DienTich > 100)
                {
                    kd.Xuat();
                    check = true;
                }
                else if (bds is NhaPho np && np.DienTich > 60 && np.NamXayDung1 >= 2019)
                {
                    np.Xuat();
                    check = true;
                }
            }
            if (!check)
            {
                Console.WriteLine("Không tồn tại bất động sản với điều kiện đã cho.");
            }
        }
        public void TimKiemNhaPhoChungCu()
        {
            Console.Write("Nhập chuỗi tìm kiếm địa điểm: ");
            string keyDiaDiem = Console.ReadLine().ToLower();
            Console.Write("Nhập giá tìm kiếm: ");
            double giatimkiem;
            while (!double.TryParse(Console.ReadLine(), out giatimkiem) || giatimkiem < 0)
            {
                Console.Write("Giá không hợp lệ, nhập lại: ");
            }
            Console.Write("Nhập diện tích tìm kiếm: ");
            double dttimkiem;
            while (!double.TryParse(Console.ReadLine(), out dttimkiem) || dttimkiem < 0)
            {
                Console.Write("Diện tích không hợp lệ, nhập lại: ");
            }
            bool exist = false;
            Console.WriteLine("\nKết quả tìm kiếm(địa điểm, giá <= giá tìm kiếm, diện tích >= diện tích tìm kiếm): ");
            foreach (var bds in ds)
            {
                if (bds is NhaPho np)
                {
                    if (np.DiaDiem.ToLower().Contains(keyDiaDiem) && np.GiaBan <= giatimkiem && np.DienTich >= dttimkiem)
                    {
                        np.Xuat();
                        exist = true;
                    }
                }
                else if (bds is ChungCu cc)
                {
                    if (cc.DiaDiem.ToLower().Contains(keyDiaDiem) && cc.GiaBan <= giatimkiem && cc.DienTich >= dttimkiem)
                    {
                        cc.Xuat();
                        exist = true;
                    }
                }
            }
            if (!exist)
            {
                Console.WriteLine("Không tìm thấy Nhà Phố hoặc Chung Cư phù hợp.");
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            CongTyDaiPhu congTyDaiPhu = new CongTyDaiPhu();
            congTyDaiPhu.NhapBDS();
            congTyDaiPhu.XuatDanhSach();
            congTyDaiPhu.XuatTongTienBDS();
            congTyDaiPhu.XuatDsBDSThoaDK();
            congTyDaiPhu.TimKiemNhaPhoChungCu();
        }
    }
}
