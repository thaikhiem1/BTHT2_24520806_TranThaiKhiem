using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int row, col;
            try
            {
                while (true)
                {
                    Console.Write("Nhập số hàng: ");
                    string strRow = Console.ReadLine();
                    if (int.TryParse(strRow, out row))
                    {
                        if (row > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Vui lòng nhập số nguyên >0!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vui lòng nhập số nguyên!");
                    }
                }
                while (true)
                {
                    Console.Write("Nhập số cột: ");
                    string strCol = Console.ReadLine();
                    if (int.TryParse(strCol, out col))
                    {
                        if (col > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Vui lòng nhập số nguyên >0!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vui lòng nhập số nguyên!");
                    }
                }
                int[,] matrix = new int[row, col];
                Console.WriteLine("Nhập ma trận: ");
                NhapMaTrix(matrix);
                Console.WriteLine("Ma trận vừa nhập: ");
                XuatMatrix(matrix);
                Console.Write("Nhập giá trị cần tìm: ");
                int x = int.Parse(Console.ReadLine());
                var listans = FindInMatrix(matrix, x);
                if (listans.Count == 0)
                {
                    Console.Write($"Không tìm thấy phần tử {x} trong ma trận!");
                }
                else
                {
                    Console.Write($"Tìm thấy {x} tại các vị trí: ");
                    int i = 0;
                    foreach (var item in listans)
                    {
                        Console.Write($"[{item.row},{item.col}]");
                        i++;
                        if (i <= listans.Count - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                }
                Console.Write("\nCác số nguyên tố trong ma trận: ");
                var listPrime = ListPrime(matrix);
                if (listPrime.Count == 0)
                {
                    Console.WriteLine("Không tìm thấy số nguyên tố nào trong ma trận!");
                }
                else
                {
                    Console.Write(string.Join(", ", listPrime));
                }
                Console.Write("\nCác hàng có nhiều số nguyên tố nhất: ");
                var listrows = RowsMostPrime(matrix);
                if (listrows.Count == 0)
                {
                    Console.WriteLine("Không tìm thấy số nguyên tố nào trong ma trận!");
                }
                else
                {
                    Console.Write(string.Join(", ", listrows));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thực thi: " + ex.Message);
            }
        }
        //câu a: Nhập / xuất ma trận hai chiều các số nguyên.
        static void NhapMaTrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"Nhập [{i}, {j}]: ");
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        static void XuatMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        //câu b: Tìm kiếm một phần tử trong ma trận.
        static List<(int row, int col)> FindInMatrix(int[,] matrix, int x)
        {
            List<(int, int)> res = new List<(int, int)>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == x)
                    {
                        res.Add((i, j));
                    }
                }
            }
            return res;
        }
        //câu c: Xuất các phần tử là số nguyên tố.
        static List<int> ListPrime(int[,] matrix)
        {

            bool[] Isprime = Sieve(10000);
            List<int> listPrimeInmatrix = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] >= 2 && Isprime[matrix[i, j]])
                    {
                        listPrimeInmatrix.Add(matrix[i, j]);
                    }
                }
            }
            return listPrimeInmatrix;
        }
        //Câu d: Cho biết dòng nào có nhiều số nguyên tố nhất.
        static List<int> RowsMostPrime(int[,] matrix)
        {
            bool[] IsPrime = Sieve(10000);
            List<int> listrows = new List<int>();
            List<int> PrimeInRows = new List<int>();
            int rowsPrimeHighest = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int countPrime = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] >= 2 && IsPrime[matrix[i, j]])
                    {
                        countPrime++;
                    }
                }
                PrimeInRows.Add(countPrime);
                if (rowsPrimeHighest < countPrime)
                {
                    rowsPrimeHighest = countPrime;
                }
            }
            if (rowsPrimeHighest == 0)
            {
                return new List<int>();
            }
            for (int i = 0; i < PrimeInRows.Count; i++)
            {
                if (rowsPrimeHighest == PrimeInRows[i])
                {
                    listrows.Add(i);
                }
            }
            return listrows;
        }
        static bool[] Sieve(int n)
        {
            bool[] check = new bool[n + 1];
            check[0] = check[1] = false;
            for (int i = 2; i < check.Length; i++)
            {
                check[i] = true;
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (check[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        check[j] = false;
                    }
                }
            }
            return check;
        }
    }
}
