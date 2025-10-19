using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bai02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập đường dẫn thư mục: ");
            string path = Console.ReadLine();
            try
            {
                if (Directory.Exists(path))
                {
                    Console.Write($"Directory of {path}\n");
                    string[] directories = Directory.GetDirectories(path);
                    string[] listfiles = Directory.GetFiles(path);
                    foreach (string file in listfiles)
                    {
                        FileInfo fi = new FileInfo(file);
                        Console.WriteLine($"{fi.LastWriteTime:dd/MM/yyyy hh:mm tt}    {fi.Length,10:N0}    {fi.Name}");
                    }
                    foreach (string directory in directories)
                    {
                        try
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                            Console.WriteLine($"{directoryInfo.LastWriteTime:dd/MM/yyyy  hh:mm tt}   <DIR>      {directoryInfo.Name}");
                            string[] files = Directory.GetFiles(directory);
                            foreach (string file in files)
                            {

                                FileInfo fileInfo = new FileInfo(file);
                                Console.WriteLine($"{fileInfo.LastWriteTime:dd/MM/yyyy  hh:mm tt}     {fileInfo.Length,12:N0}      {fileInfo.Name}");
                            }
                        }
                        catch (UnauthorizedAccessException)
                        {
                            Console.WriteLine($"Bỏ qua Không có quyền truy cập: {directory}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Lỗi {directory}: {ex.Message}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Directory không tồn tại!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
    }
}
