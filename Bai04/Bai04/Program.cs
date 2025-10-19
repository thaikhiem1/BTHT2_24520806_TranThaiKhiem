using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai04
{
    class Fraction
    {
        private int Numerator;
        private int Denominator;
        public int Numerator1 { get => Numerator; set => Numerator = value; }
        public int Denominator1 { get => Denominator; set => Denominator = value; }
        public Fraction(int numerator = 0, int denominator = 1)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Mẫu số không được bằng 0!");
            }
            this.Numerator = numerator;
            this.Denominator = denominator;
            rutgon();
        }
        private void rutgon()
        {
            int ucln = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= ucln;
            Denominator /= ucln;
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            int NumeratorNew = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
            int DenominatorNew = a.Denominator * b.Denominator;
            return new Fraction(NumeratorNew, DenominatorNew);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            int NumeratorNew = a.Numerator * b.Denominator - a.Denominator * b.Numerator;
            int DenominatorNew = a.Denominator * b.Denominator;
            return new Fraction(NumeratorNew, DenominatorNew);
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            int NumeratorNew = a.Numerator * b.Numerator;
            int DenominatorNew = a.Denominator * b.Denominator;
            return new Fraction(NumeratorNew, DenominatorNew);
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b == null)
            {
                throw new ArgumentNullException(nameof(b));
            }
            else if (b.Numerator == 0)
            {
                Console.WriteLine("Lỗi: Không thể chia cho phân số bằng 0!");
                return null;
            }
            int NumeratorNew = a.Numerator * b.Denominator;
            int DenominatorNew = a.Denominator * b.Numerator;
            return new Fraction(NumeratorNew, DenominatorNew);
        }
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
        }
        public static bool operator <(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }
            return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this == other;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (Numerator, Denominator).GetHashCode();
        }
        public override string ToString()
        {
            if (Numerator == 0) return "0";
            if (Denominator == 1)
            {
                return Numerator.ToString();
            }
            return $"{Numerator}/{Denominator}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập phân số thứ 1: ");
            Fraction ps1 = NhapPhanSo();
            Console.Write("Nhập phân số thứ 2: ");
            Fraction ps2 = NhapPhanSo();
            Console.WriteLine($"\nTổng: {ps1 + ps2}");
            Console.WriteLine($"Hiệu : {ps1 - ps2}");
            Console.WriteLine($"Tích: {ps1 * ps2}");
            Console.WriteLine($"Thương: {ps1 / ps2}");
            int n;
            Console.Write("Nhập số lượng phân số: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Nhập số lượng phân số phải là nguyên dương, nhập lại: ");
            }
            Fraction[] fractions = new Fraction[n];
            for (int i = 0; i < fractions.Length; i++)
            {
                Console.Write($"Nhập phân số thứ {i + 1}: ");
                fractions[i] = NhapPhanSo();
            }
            var listmaxFraction = FindMaxFraction(fractions.ToList());
            Console.Write("Các phân số lớn nhất: ");
            Console.WriteLine(string.Join(",", listmaxFraction));
            var sortedList = SortListFraction(fractions.ToList());
            Console.WriteLine("\nDanh sách phân số sau khi sắp xếp tăng dần:");
            foreach (Fraction f in sortedList)
            {
                Console.WriteLine(f);
            }
        }
        static Fraction NhapPhanSo()
        {
            int numerator;
            int denominator;
            Console.Write("\nNhập tử số: ");
            while (!int.TryParse(Console.ReadLine(), out numerator))
            {
                Console.Write("Gía trị không hợp lệ, nhập lại: ");
            }
            Console.Write("Nhập mẫu số: ");
            while (!int.TryParse(Console.ReadLine(), out denominator) || denominator == 0)
            {
                Console.Write("Gía trị không hợp lệ, nhập lại: ");
            }
            return new Fraction(numerator, denominator);
        }
        static List<Fraction> FindMaxFraction(List<Fraction> fractions)
        {
            if (fractions == null || fractions.Count == 0)
            {
                return new List<Fraction>();
            }
            List<Fraction> listmaxfraction = new List<Fraction>();
            Fraction highestFraction = fractions[0];
            foreach (Fraction fraction in fractions)
            {

                if (highestFraction < fraction)
                {
                    highestFraction = fraction;
                }
            }
            foreach (Fraction fraction in fractions)
            {
                if (fraction == highestFraction)
                {
                    listmaxfraction.Add(fraction);
                }
            }
            return listmaxfraction;
        }
        static List<Fraction> SortListFraction(List<Fraction> fractions)
        {

            List<Fraction> res = new List<Fraction>(fractions);
            for (int i = 0; i < res.Count - 1; i++)
            {
                int min_i = i;
                for (int j = i + 1; j < res.Count; j++)
                {
                    if (res[j] < res[min_i])
                    {
                        min_i = j;
                    }
                }
                Fraction tmp = res[min_i];
                res[min_i] = res[i];
                res[i] = tmp;
            }
            return res;
        }
    }
}