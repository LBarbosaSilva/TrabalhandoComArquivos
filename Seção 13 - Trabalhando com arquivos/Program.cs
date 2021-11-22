using System;
using System.IO;
using Seção_13___Trabalhando_com_arquivos.Entities;
using System.Globalization;

namespace Seção_13___Trabalhando_com_arquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
           
          // FileInfo & IOException
           
            string sourcePath = @"D:\Test\file1.txt";
            string targetPath = @"D:\Test\file2.txt";

            string[] lines = File.ReadAllLines(sourcePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            try
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);
            }
            catch(IOException e)
            {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(e.Message);
            }
            */


            /*
            //FileStream & StreamReader
            
            string path = @"D:\Test\file1.txt";
            //FileStream fs = null;
            StreamReader sr = null;

            try
            {
                //fs = new FileStream(path, FileMode.Open);
                sr = File.OpenText(path);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(e.Message);
            }

            finally
            {
                if (sr != null) sr.Close();
                //if (fs != null) fs.Close();
            }
            */

            /*
              
            
            //Bloco Using
            try
            {
                string path = @"D:\Test\file1.txt";
                //using (FileStream fs = new FileStream(path, FileMode.Open))

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(e.Message);
            }

            */

            /*
            // StreamWriter

            string sourcepath = @"D:\Test\file1.txt";
            string targetpath = @"D:\Test\file2.txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcepath);

                using (StreamWriter sw = File.AppendText(targetpath))
                {
                    foreach(string line in lines){
                        sw.WriteLine(line.ToUpper());
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }

            */


            //Directory, DirectoryInfo

            /*
            string path = @"d:\Test\myfolder";

            try
            {
               var folder =  Directory.EnumerateDirectories(path, ".", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS: ");
                foreach (string s in folder)
                {
                    Console.WriteLine(s);
                }

                Console.WriteLine();

                var files = Directory.EnumerateFiles(path, ".", SearchOption.AllDirectories);
                Console.WriteLine("FILES: ");
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }

                Directory.CreateDirectory(path + @"\newfolder");
            }
            catch(IOException e)
            {
                Console.WriteLine("An error ocurred");
                Console.WriteLine(e.Message);
            }
            */


            /*
            //Path

            string path = @"d:\Test\myfolder\file1.txt";

            Console.WriteLine("DirectorySeparatorChar: " + Path.DirectorySeparatorChar);
            Console.WriteLine("PathSeparator" + Path.PathSeparator);
            Console.WriteLine("GetDirectoryName: " + Path.GetDirectoryName(path));
            Console.WriteLine("Path.GetFileNam: " + Path.GetFileName(path));
            Console.WriteLine("Path.GetExtension: " + Path.GetExtension(path));
            Console.WriteLine("Path.GetFullPath: " + Path.GetFullPath(path)) ;
            Console.WriteLine("GetFileNameWithoutExtension: " + Path.GetFileNameWithoutExtension(path));
            Console.WriteLine("Path.GetTempPath: " + Path.GetTempPath());
            */



            //Exercicio de Fixacao
            /*
             * Fazer um programa para ler o caminho de um arquivo .csv
                contendo os dados de itens vendidos. Cada item possui um
                nome, preço unitário e quantidade, separados por vírgula. Você
                deve gerar um novo arquivo chamado "summary.csv", localizado
                em uma subpasta chamada "out" a partir da pasta original do
                arquivo de origem, contendo apenas o nome e o valor total para
                aquele item (preço unitário multiplicado pela quantidade),
                conforme exemplo.
             */

            Console.Write("Enter file full path: ");
            string sourceFilePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {

                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        Product prod = new Product(name, price, quantity);

                        sw.WriteLine(prod.Name + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
