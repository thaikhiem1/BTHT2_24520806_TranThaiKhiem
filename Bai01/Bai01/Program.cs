using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int month, year;
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.Write("Nhập tháng: ");
                string strMonth = Console.ReadLine();
                if (int.TryParse(strMonth, out month))
                {
                    if (month >= 1 && month <= 12)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Tháng phải nằm trong khoảng 1 đến 12!");
                    }
                }
                else
                {
                    Console.WriteLine("Vui lòng nhập số nguyên!");
                }
            }
            while (true)
            {
                Console.Write("Nhập năm: ");
                string strYear = Console.ReadLine();
                if (int.TryParse(strYear, out year))
                {
                    if (year >= 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Năm phải >=1 và không được là số âm!");
                    }
                }
                else
                {
                    Console.WriteLine("Vui lòng nhập số nguyên!");
                }
            }
            printcalendar(month, year);
        }
        static void printcalendar(int month, int year)
        {
            Console.WriteLine($"Month: {month:D2}/{year}");
            Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");
            DateTime firtday = new DateTime(year, month, 1);
            int dayinmonth = DateTime.DaysInMonth(year, month);
            int currentdaysOfweek = (int)firtday.DayOfWeek;
            for (int i = 0; i < currentdaysOfweek; i++)
            {
                Console.Write("    ");

            }
            for (int days = 1; days <= dayinmonth; days++)
            {
                Console.Write($"{days,2}  ");
                currentdaysOfweek++;
                if (currentdaysOfweek == 7)
                {
                    currentdaysOfweek = 0;
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }
    }
}

